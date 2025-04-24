using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RIA_CRM_System
{
    public partial class MainForm : Form
    {
        SqlConnection con;
        bool noexit = false;
        public MainForm()
        {
            InitializeComponent();
            this.Text = "Главное меню (Учетная Запись - " + Convert.ToString(AuthorizationForm.Login) + ")";
            string connectionString = @"Data Source=OwlPC; Initial Catalog=RIA CRM DB; User ID=" + AuthorizationForm.Login + "; Password=" + AuthorizationForm.Password;
            con = new SqlConnection(connectionString);
            con.Open();
            if (AuthorizationForm.Job == "Директор") button7.Visible = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ProfileForm f3 = new ProfileForm();
            f3.Left = this.Left;
            f3.Top = this.Top;
            f3.Show();
            this.Hide();
            con.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            EmployeeForm f4 = new EmployeeForm();
            f4.Left = this.Left;
            f4.Top = this.Top;
            f4.Show();
            this.Hide();
            con.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            TaskForm f6 = new TaskForm();
            f6.Left = this.Left;
            f6.Top = this.Top;
            f6.Show();
            this.Hide();
            con.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            ChatForm f5 = new ChatForm();
            f5.Left = this.Left;
            f5.Top = this.Top;
            f5.Show();
            this.Hide();
            con.Close();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            ClientForm f7 = new ClientForm();
            f7.Left = this.Left;
            f7.Top = this.Top;
            f7.Show();
            this.Hide();
            con.Close();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            AuthorizationForm f1 = new AuthorizationForm();
            f1.Left = this.Left;
            f1.Top = this.Top;
            f1.Show();
            this.Hide();
            con.Close();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == false)
            {
                panel1.Visible = true;
                button7.Text = "Отменить передачу прав";
            }
            else
            {
                panel1.Visible = false;
                button7.Text = "Передать права Директора";
                foreach (Control C in panel1.Controls)
                {
                    if (C is ComboBox)
                        C.Text = "";
                }
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            string qwery1 = "Select Distinct ID, Фамилия, Имя, Отчество From Сотрудники Where ID != @1";
            SqlCommand command1 = new SqlCommand(qwery1, con);
            command1.Parameters.AddWithValue("@1", Convert.ToString(AuthorizationForm.o)); //ID
            SqlDataReader read = command1.ExecuteReader();
            while (read.Read())
            {
                comboBox1.Items.Add(read[0].ToString() + ") " + read[1].ToString() + " " + read[2].ToString() + " " + read[3].ToString());
            }
            read.Close();
            comboBox1.SelectedIndex = -1;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
                button8.Enabled = false;
            else
                button8.Enabled = true;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Нажимая на кнопку ДА вы подтверждаете, что хотите передать свои права другому сотруднику, это лишит вас этих прав. В противном случае нажмите на кнопку НЕТ.", "Подтверждение", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string[] arr = Convert.ToString(comboBox1.Text).Split(')'); //Извлечение ID Сотрудника
                String ID = arr[0];

                //Запрос 2: Поиск Логина Сотрудника.
                string qwery2 = "SELECT Логин FROM Учетные_Записи WHERE ID = @1";
                SqlCommand command2 = new SqlCommand(qwery2, con);
                command2.Parameters.AddWithValue("@1", Convert.ToString(ID)); //ID Сотрудника
                string log = Convert.ToString(command2.ExecuteScalar());

                //Запрос 3: Лишение Прав Cотрудника, выдача прав Директора.
                string qwery3 = "USE [RIA CRM DB] ALTER ROLE [db_owner] ADD MEMBER " + Convert.ToString(log)
                              + " USE[master] ALTER SERVER ROLE[sysadmin] ADD MEMBER " + Convert.ToString(log)
                              + " USE[master] ALTER SERVER ROLE[securityadmin] DROP MEMBER " + Convert.ToString(log)
                              + " USE [RIA CRM DB] ALTER ROLE [Сотрудник] DROP MEMBER " + Convert.ToString(log)
                              + " USE [RIA CRM DB] ALTER ROLE [db_accessadmin] DROP MEMBER " + Convert.ToString(log);
                SqlCommand command3 = new SqlCommand(qwery3, con);
                command3.ExecuteNonQuery();

                //Запрос 4: Изменение Должности Директора в БД.
                string qwery4 = "UPDATE Сотрудники SET ID_Должности = 3 WHERE ID = @1";
                SqlCommand command4 = new SqlCommand(qwery4, con);
                command4.Parameters.AddWithValue("@1", Convert.ToString(AuthorizationForm.o)); //ID Директора
                command4.ExecuteNonQuery();

                //Запрос 5: Изменение типа учетной записи Директора.
                string qwery5 = "UPDATE Учетные_Записи SET Тип_Учетной_Записи = 'Учетная запись Сотрудника' WHERE ID =  @1";
                SqlCommand command5 = new SqlCommand(qwery5, con);
                command5.Parameters.AddWithValue("@1", Convert.ToString(AuthorizationForm.o)); //ID Директора
                command5.ExecuteNonQuery();

                //Запрос 6: Изменение Должности Сотрудника в БД.
                string qwery6 = "UPDATE Сотрудники SET ID_Должности = 1 WHERE ID = @1";
                SqlCommand command6 = new SqlCommand(qwery6, con);
                command6.Parameters.AddWithValue("@1", Convert.ToString(ID)); //ID Сотрудника
                command6.ExecuteNonQuery();

                //Запрос 7: Изменение типа учетной записи Сотрудника.
                string qwery7 = "UPDATE Учетные_Записи SET Тип_Учетной_Записи = 'Учетная запись Директора' WHERE ID =  @1";
                SqlCommand command7 = new SqlCommand(qwery7, con);
                command7.Parameters.AddWithValue("@1", Convert.ToString(ID)); //ID Сотрудника
                command7.ExecuteNonQuery();

                //Запрос 1: Лишение Прав Директора, выдача прав Cотрудника.
                string qwery1 = "USE[master] ALTER SERVER ROLE[securityadmin] ADD MEMBER " + Convert.ToString(AuthorizationForm.Login)
                              + " USE [RIA CRM DB] ALTER ROLE [Сотрудник] ADD MEMBER " + Convert.ToString(AuthorizationForm.Login)
                              + " USE [RIA CRM DB] ALTER ROLE [db_accessadmin] ADD MEMBER " + Convert.ToString(AuthorizationForm.Login)
                              + " USE [RIA CRM DB] ALTER ROLE [db_owner] DROP MEMBER " + Convert.ToString(AuthorizationForm.Login)
                              + " USE[master] ALTER SERVER ROLE[sysadmin] DROP MEMBER " + Convert.ToString(AuthorizationForm.Login);
                SqlCommand command1 = new SqlCommand(qwery1, con);
                command1.ExecuteNonQuery();

                MessageBox.Show("Права успешно переданы, производится перезагрузка системы.", "Готово");
                noexit = true;
                AuthorizationForm f1 = new AuthorizationForm();
                f1.Left = this.Left;
                f1.Top = this.Top;
                f1.Show();
                this.Close();
                con.Close();
            }
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (noexit == false)
            {
                Form f1 = Application.OpenForms[0];
                f1.Close();
                con.Close();
            }
        }
    }
}
