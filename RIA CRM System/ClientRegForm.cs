using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RIA_CRM_System
{
    public partial class ClientRegForm : Form
    {
        SqlConnection con;
        bool noexit = false;
        public ClientRegForm()
        {
            InitializeComponent();
            string connectionString = @"Data Source=OwlPC; Initial Catalog=RIA CRM DB; User ID=" + AuthorizationForm.Login + "; Password=" + AuthorizationForm.Password;
            con = new SqlConnection(connectionString);
            con.Open();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control C in panel1.Controls)
            {
                if (C is TextBox && C.Text == "")
                    C.Text = "NULL";
            }
            bool tfilled = true;
            if (textBox1.TextLength == 0 || textBox2.TextLength == 0) tfilled = false;
            if (tfilled == true)
            {
                string check = "";
                string zapros = "SELECT ID FROM Физические_Лица WHERE [E-mail] = @1  AND [E-mail] != ''";
                SqlCommand command = new SqlCommand(zapros, con);
                command.Parameters.AddWithValue("@1", Convert.ToString(textBox5.Text)); //почта
                check = Convert.ToString(command.ExecuteScalar());
                if (check == "")
                {
                    check = "";
                    string zapros2 = "INSERT INTO Физические_Лица(Имя, Фамилия, Отчество, Телефон, [E-mail]) VALUES (@1, @2, @3, @4, @5)";
                    SqlCommand command2 = new SqlCommand(zapros2, con);
                    command2.Parameters.AddWithValue("@1", Convert.ToString(textBox1.Text)); //имя
                    command2.Parameters.AddWithValue("@2", Convert.ToString(textBox2.Text)); //фамилия
                    command2.Parameters.AddWithValue("@3", Convert.ToString(textBox3.Text)); //отчество
                    command2.Parameters.AddWithValue("@4", Convert.ToString(textBox4.Text)); //телефон
                    command2.Parameters.AddWithValue("@5", Convert.ToString(textBox5.Text)); //почта
                    command2.ExecuteNonQuery();
                    MessageBox.Show("Клиент успешно зарегистрирован.");
                    foreach (Control C in panel1.Controls)
                    {
                        if (C is TextBox)
                            C.Text = "";
                    }
                }
                else
                {
                    check = "";
                    MessageBox.Show("Ошибка: В Базе Данных уже существует клиент с введенной почтой.");
                }
            }
            else
            MessageBox.Show("Ошибка: Заполнены не все поля.");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Control C in panel2.Controls)
            {
                if (C is TextBox && C.Text == "")
                    C.Text = "NULL";
            }
            bool tfilled = true;
            if (textBox6.TextLength == 0) tfilled = false;
            if (tfilled == true)
            {
                string check = "";
                string zapros = "SELECT ID FROM Юридические_Лица WHERE [E-mail] = @1  AND [E-mail] != ''";
                SqlCommand command = new SqlCommand(zapros, con);
                command.Parameters.AddWithValue("@1", Convert.ToString(textBox8.Text)); //почта
                check = Convert.ToString(command.ExecuteScalar());
                if (check == "")
                {
                    check = "";
                    string zapros2 = "INSERT INTO Юридические_Лица(Наименование, Телефон, [E-mail]) VALUES (@1, " + Convert.ToString(textBox7.Text) + "," + Convert.ToString(textBox8.Text) + ")";
                    SqlCommand command2 = new SqlCommand(zapros2, con);
                    command2.Parameters.AddWithValue("@1", Convert.ToString(textBox6.Text)); //наименование
                    command2.Parameters.AddWithValue("@2", Convert.ToString(textBox7.Text)); //телефон
                    command2.Parameters.AddWithValue("@3", Convert.ToString(textBox8.Text)); //почта
                    command2.ExecuteNonQuery();
                    MessageBox.Show("Клиент успешно зарегистрирован.");
                    foreach (Control C in panel2.Controls)
                    {
                        if (C is TextBox)
                            C.Text = "";
                    }
                }
                else
                {
                    check = "";
                    MessageBox.Show("Ошибка: В Базе Данных уже существует клиент с введенной почтой.");
                }
            }
            else
                MessageBox.Show("Ошибка: Заполнены не все поля.");
        }
        private void Form8klientsreg_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (noexit == false)
            {
                Form f1 = Application.OpenForms[0];
                f1.Close();
                con.Close();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            noexit = true;
            ClientForm f7 = new ClientForm();
            f7.Left = this.Left;
            f7.Top = this.Top;
            f7.Show();
            this.Close();
            con.Close();
        }
    }
}
