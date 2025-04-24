using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Net.Sockets;
using System.Threading;

namespace RIA_CRM_System
{
    public partial class ChatForm : Form
    {
        SqlConnection con;
        bool noexit = false;
        bool connect = false;
        int companionID; //ID Собеседника
        private const int port = 8888; //Порт
        private const string host = "127.0.0.1"; //Хост
        static TcpClient client;
        static NetworkStream stream;
        bool ReceiveAccept = false;
        Thread receiveThread;
        public ChatForm()
        {
            InitializeComponent();
            //Подключение к Базе Данных
            string connectionString = @"Data Source=OwlPC; Initial Catalog=RIA CRM DB; User ID=" + AuthorizationForm.Login + "; Password=" + AuthorizationForm.Password;
            con = new SqlConnection(connectionString);
            con.Open();

            string qwery1 = "Select Логин From Учетные_Записи Where Логин != @1"; //Вывод всех Переписок
            SqlCommand command1 = new SqlCommand(qwery1, con);
            command1.Parameters.AddWithValue("@1", Convert.ToString(AuthorizationForm.Login)); //Логин учетки
            SqlDataReader read1 = command1.ExecuteReader();
            while (read1.Read())
            {
                listBox1.Items.Add(read1[0].ToString());
            }
            read1.Close();
            listBox1.DrawItem += listBox1_DrawItem;
        }       
        private void ReceiveMessage() //Получение Сообщений
        {
            while (true)
            {
                while (ReceiveAccept == true)
                {
                    try
                    {
                        byte[] data = new byte[64]; //Буфер Данных
                        StringBuilder builder = new StringBuilder();
                        int bytes = 0;
                        do
                        {
                            bytes = stream.Read(data, 0, data.Length);
                            builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                        }
                        while (stream.DataAvailable);

                        string message = builder.ToString();
                        Action action = () => ToRichTextBox(richTextBox1, message);
                        if (InvokeRequired)
                            Invoke(action);
                        else
                            action();
                    }
                    catch (SocketException ex){
                        MessageBox.Show(Convert.ToString(ex.ErrorCode), "Ошибка: Выход из Програмы");
                        Disconnect();
                        Environment.Exit(0);
                    }
                }
            }
        }
        private void ToRichTextBox(RichTextBox RichTextBox, string message) //Вставка в RichTextBox
        {
            richTextBox1.SelectionColor = Color.Blue;
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
            richTextBox1.AppendText(listBox1.SelectedItem.ToString() + ": " + message + Environment.NewLine);
            richTextBox1.AppendText("" + Environment.NewLine);
        }
        private void button2_Click(object sender, EventArgs e) //Отправка Сообщений
        {
            string messege = Convert.ToString(textBox1.Text); //Сообщение
            textBox1.Text = "";

            //1) Вывод Введеного Сообщения в Текстовое Поле
            richTextBox1.SelectionColor = Color.Red;
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
            richTextBox1.AppendText("Вы: " + messege + Environment.NewLine);
            richTextBox1.AppendText("" + Environment.NewLine);

            //2) Передача Сообщения на Сервер 
            try
            {
                do
                {
                    byte[] data = Encoding.Unicode.GetBytes(messege); //Передача Сообщения
                    stream.Write(data, 0, data.Length);
                }
                while (stream.DataAvailable); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка: Выход из Програмы");
                Disconnect();
                Environment.Exit(0);
            }

            //3) Передача Сообщения в Базу Даных
            string qwery = "INSERT INTO Сообщения(ID_Отправителя, ID_Получателя, Текст) VALUES (@1, @2, @3)"; 
            SqlCommand command = new SqlCommand(qwery, con);
            command.Parameters.AddWithValue("@1", Convert.ToString(AuthorizationForm.o)); //ID_Отправителя
            command.Parameters.AddWithValue("@2", Convert.ToString(companionID)); //ID_Получателя
            command.Parameters.AddWithValue("@3", Convert.ToString(messege)); //Текст
            command.ExecuteNonQuery();
        }
        static void Disconnect() //Отключение от Сервера
        {
            if (stream != null)stream.Close(); //Отключение Потока
            if (client != null)
                client.Close(); //Отключение Клиента
        }
        private void button1_Click(object sender, EventArgs e)
        {
            noexit = true;
            if (connect == true)
            {
                receiveThread.Abort();
            }
            Disconnect();
            MainForm f2 = new MainForm();
            f2.Left = this.Left;
            f2.Top = this.Top;
            f2.Show();
            this.Close();
            con.Close();
        }
        private void Form5soob_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (connect == true)
            {
                receiveThread.Abort();
            }
            if (noexit == false)
            {
                Disconnect();
                Form f1 = Application.OpenForms[0];
                f1.Close();
                con.Close();
            }
        }
        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            TextRenderer.DrawText(e.Graphics, listBox1.Items[e.Index].ToString(), e.Font, e.Bounds, e.ForeColor, e.BackColor, TextFormatFlags.HorizontalCenter);
        }
        private void button3_Click(object sender, EventArgs e) //Очистка Переписки
        {
            string qwery = "Delete From Сообщения Where ID_Отправителя = @1 and ID_Получателя = @2";
            SqlCommand command = new SqlCommand(qwery, con);
            command.Parameters.AddWithValue("@1", Convert.ToString(AuthorizationForm.o)); //ID_Отправителя
            command.Parameters.AddWithValue("@2", Convert.ToString(companionID)); //ID_Получателя
            command.ExecuteNonQuery();
            MessageBox.Show("Переписка успешно очищена, осуществляется перезагрузка");
            noexit = true;
            if (connect == true)
            {
                receiveThread.Abort();
            }
            Disconnect();
            ChatForm f5 = new ChatForm();
            f5.Left = this.Left;
            f5.Top = this.Top;
            f5.Show();
            this.Close();
            con.Close();
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) //Выбор Переписки
        {
            ReceiveTimer.Stop();
            ReceiveTimer.Enabled = false;
            panel2.Visible = false;
            if (connect == true)
            {
                Disconnect();
                receiveThread.Abort();
            }
            richTextBox1.Clear();
            ConnectTimer.Enabled = true;
            ConnectTimer.Start();
        }
        public void ChatAccept() //Вывод Переписки
        {
            //Поиск ID Собеседника
            string qwery1 = "Select ID From Учетные_Записи Where Логин = @1";
            SqlCommand command1 = new SqlCommand(qwery1, con);
            command1.Parameters.AddWithValue("@1", Convert.ToString(listBox1.SelectedItem.ToString())); //Логин учетки
            companionID = Convert.ToInt32(command1.ExecuteScalar());

            //Вывод всех Сообщений из БД по ID
            string qwery2 = "Select Distinct * From Сообщения Where ID_Отправителя = @1 and ID_Получателя = @2 or ID_Получателя = @1 and ID_Отправителя = @2 ORDER BY [Дата и Время] ASC";
            SqlCommand command2 = new SqlCommand(qwery2, con);
            command2.Parameters.AddWithValue("@1", Convert.ToString(AuthorizationForm.o)); //Логин учетки
            command2.Parameters.AddWithValue("@2", Convert.ToString(companionID)); //Логин собеседника
            SqlDataReader read2 = command2.ExecuteReader();
            while (read2.Read())
            {
                if (read2[1].ToString() == AuthorizationForm.o)
                {
                    richTextBox1.SelectionColor = Color.Red;
                    richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
                    richTextBox1.AppendText("Вы: " + read2[3].ToString() + Environment.NewLine);
                    richTextBox1.AppendText("" + Environment.NewLine);
                }
                else
                {
                    richTextBox1.SelectionColor = Color.Blue;
                    richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
                    richTextBox1.AppendText(listBox1.SelectedItem.ToString() + ": " + read2[3].ToString() + Environment.NewLine);
                    richTextBox1.AppendText("" + Environment.NewLine);
                }
            }
            read2.Close();

            client = new TcpClient(); //Подключение к Сереверу
            try
            {
                //Подключение Клиента
                client.Connect(host, port);
                //Получение Потока
                stream = client.GetStream();
                connect = true;

                //Отправка ID Клиента и Собеседника
                string message = (Convert.ToString(AuthorizationForm.o) + " / " + Convert.ToString(companionID));
                byte[] data = Encoding.Unicode.GetBytes(message);
                stream.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка: Выход из Програмы");
                Disconnect();
                Environment.Exit(0);
            }

            try //Запуск Потока Получения Даннных
            {
                ReceiveTimer.Enabled = true;
                ReceiveTimer.Start();
                receiveThread = new Thread(new ThreadStart(ReceiveMessage)); 
                receiveThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка: Выход из Програмы");
                Disconnect();
                Environment.Exit(0);
            }
            panel2.Visible = true;
        }
        private void ConnectTimer_Tick(object sender, EventArgs e)
        {
            ChatAccept();
            ConnectTimer.Stop();
            ConnectTimer.Enabled = false;
        }
        private void ReceiveTimer_Tick(object sender, EventArgs e)
        {
            ReceiveAccept = !ReceiveAccept;
        }
    }
}
