using System;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RIA_CRM_System
{
    public partial class AuthorizationForm : Form
    {
        SqlConnection con;
        static public string ooo; //Фио Сотрудника
        static public string o; //Код Учетки
        static public string Login; //Логин
        static public string Password; //Пароль
        static public string Job; //Должность
        static public string Pasport; //Паспортные Данные
        public AuthorizationForm()
        {
            InitializeComponent();
            string connectionString = @"Data Source=OwlPC;Initial Catalog=RIA CRM DB;Integrated Security=True";
            con = new SqlConnection(connectionString);
            con.Open();   
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.сотрудникиTableAdapter.Fill(this.RIA_CRM_DBDataSet.Сотрудники);
            this.должностиTableAdapter.Fill(this.RIA_CRM_DBDataSet.Должности);
            comboBox1.SelectedIndex = -1;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == true)
            {
                panel1.Enabled = false;
                panel1.Visible = false;
                panel3.Enabled = true;
                panel3.Visible = true;
                button2.Text = "Авторизация";             
            }
            else 
            {
                panel1.Enabled = true;
                panel1.Visible = true;
                panel3.Enabled = false;
                panel3.Visible = false;
                button2.Text = "Регистрация";
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Директор")
            {
                MessageBox.Show("Ошибка: У вас нет прав на создание учетной записи с типом - Директор");
            }
            else 
            { 
                string check = "";
                if (textBox5.TextLength == 0) textBox5.Text = " ";
                bool tfilled = panel3.Controls.OfType<TextBox>().All(textBox => textBox.TextLength != 0);
                bool cfilled = panel3.Controls.OfType<ComboBox>().All(ComboBox => ComboBox.Text != "");
                if (tfilled == true && cfilled == true)
                {
                    if (textBox5.Text == " ") textBox5.Text = "";
                    string proverka = "(SELECT Логин FROM Учетные_Записи WHERE Логин = @1) UNION (SELECT Серия_Паспорта FROM Сотрудники WHERE Серия_Паспорта = @2)UNION(SELECT Номер_Паспорта FROM Сотрудники WHERE Номер_Паспорта = @3)";
                    SqlCommand command = new SqlCommand(proverka, con);
                    command.Parameters.AddWithValue("@1", Convert.ToString(textBox9.Text)); //логин
                    command.Parameters.AddWithValue("@2", Convert.ToString(textBox7.Text)); //серия
                    command.Parameters.AddWithValue("@3", Convert.ToString(textBox8.Text)); //номер
                    SqlDataReader read = command.ExecuteReader();
                    while (read.Read())
                    {
                        check = check + read[0].ToString() + " ";
                    }
                    read.Close();
                    if (check == "")
                    {
                        check = "";
                        string zapros1 = "INSERT INTO Учетные_Записи(Тип_Учетной_Записи, Логин, Пароль) VALUES (@3, @1, @2)";
                        SqlCommand command1 = new SqlCommand(zapros1, con);
                        command1.Parameters.AddWithValue("@1", Convert.ToString(textBox9.Text)); //логин
                        command1.Parameters.AddWithValue("@2", Convert.ToString(textBox10.Text)); //пароль
                        command1.Parameters.AddWithValue("@3", "Учетная запись " + Convert.ToString(comboBox1.Text) + "а"); //должность
                        command1.ExecuteNonQuery();
                        string zapros2 = "INSERT INTO Сотрудники(ID, Имя, Фамилия, Отчество, Серия_Паспорта, Номер_Паспорта, ID_Должности) "
                                       + "VALUES ((SELECT ID FROM Учетные_Записи WHERE Учетные_Записи.Логин = @6), @1, @2, " + (string.IsNullOrEmpty(textBox5.Text) ? "NULL" : string.Format("'{0}'", textBox5.Text)) + ", @4, @5, (SELECT ID FROM Должности WHERE Должности.Наименование = @7))";
                        SqlCommand command2 = new SqlCommand(zapros2, con);
                        command2.Parameters.AddWithValue("@1", Convert.ToString(textBox3.Text)); //имя
                        command2.Parameters.AddWithValue("@2", Convert.ToString(textBox4.Text)); //фамилия
                        command2.Parameters.AddWithValue("@4", Convert.ToString(textBox7.Text)); //серия
                        command2.Parameters.AddWithValue("@5", Convert.ToString(textBox8.Text)); //номер
                        command2.Parameters.AddWithValue("@6", Convert.ToString(textBox9.Text)); //логин
                        command2.Parameters.AddWithValue("@7", Convert.ToString(comboBox1.Text)); //должность
                        command2.ExecuteNonQuery();
                        string zapros3 = "USE [master] " +
                                         "CREATE LOGIN " + Convert.ToString(textBox9.Text) + " WITH PASSWORD =N'" + Convert.ToString(textBox10.Text) + "', " +
                                         "DEFAULT_DATABASE = [RIA CRM DB], DEFAULT_LANGUAGE =[русский], " +
                                         "CHECK_EXPIRATION = OFF, CHECK_POLICY = OFF USE[RIA CRM DB] " +
                                         "CREATE USER " + Convert.ToString(textBox9.Text) + " FOR LOGIN " + Convert.ToString(textBox9.Text);
                        SqlCommand command3 = new SqlCommand(zapros3, con);
                        command3.ExecuteNonQuery();
                        string zapros5 = "USE [master] ALTER SERVER ROLE[securityadmin] ADD MEMBER " + Convert.ToString(textBox9.Text);
                        SqlCommand command5 = new SqlCommand(zapros5, con);
                        command5.ExecuteNonQuery();
                        string zapros4 = "USE [RIA CRM DB] ALTER ROLE [Сотрудник] ADD MEMBER " + Convert.ToString(textBox9.Text);
                        SqlCommand command4 = new SqlCommand(zapros4, con);
                        command4.ExecuteNonQuery();
                        string zapros6 = "USE [RIA CRM DB] ALTER ROLE [db_accessadmin] ADD MEMBER " + Convert.ToString(textBox9.Text);
                        SqlCommand command6 = new SqlCommand(zapros6, con);
                        command6.ExecuteNonQuery();
                        MessageBox.Show("Учетная Запись пользователя " + Convert.ToString(textBox9.Text) + " - Успешно создана.", "Подтверждение");
                        foreach (Control C in panel3.Controls)
                        {
                            if (C is TextBox)
                                C.Text = "";
                            else if (C is ComboBox)
                                C.Text = null;
                        }
                    }
                    else
                    {
                        check = "";
                        MessageBox.Show("Ошибка: В Базе Данных уже существует учетная запись с идентичным логином или паспортными данными.");
                    }
                }
                else
                {
                    if (textBox5.Text == " ") textBox5.Text = "";
                    MessageBox.Show("Ошибка: Заполнены не все поля.");
                }
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string proverka = "Select С.Имя, С.Фамилия, С.Отчество, У.ID, У.Логин, У.Пароль, Д.Наименование, С.Серия_Паспорта, С.Номер_Паспорта From Сотрудники С, Учетные_Записи У, Должности Д Where У.ID = С.ID and Д.ID = С.ID_Должности and У.Логин = @1 and У.Пароль = @2";
            SqlCommand command = new SqlCommand(proverka, con);

            command.Parameters.AddWithValue("@1", Convert.ToString(textBox1.Text)); //логин

            command.Parameters.AddWithValue("@2", Convert.ToString(textBox2.Text)); //серия

            SqlDataReader read = command.ExecuteReader();
            if (read.Read())
            {
                label17.Visible = false;
                ooo = read[0].ToString() + " " + read[1].ToString() + " " + read[2].ToString();
                o = read[3].ToString();
                Login = read[4].ToString();
                Password = read[5].ToString();
                Job = read[6].ToString();
                Pasport = read[7].ToString() + " " + read[8].ToString();
                read.Close();

                MainForm f2 = new MainForm();
                f2.Left = this.Left;
                f2.Top = this.Top;
                f2.Show();
                this.Hide();
                con.Close();         
            }
            else
            {
                label17.Visible = true;
                read.Close();
            }
        }

    }
}
