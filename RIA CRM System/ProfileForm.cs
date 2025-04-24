using System;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RIA_CRM_System
{
    public partial class ProfileForm : Form
    {
        SqlConnection con;
        bool noexit = false;
        public ProfileForm()
        {
            InitializeComponent();
            this.Text = "Учетная Запись " + Convert.ToString(AuthorizationForm.Login);
            string connectionString = @"Data Source=OwlPC; Initial Catalog=RIA CRM DB; User ID=" + AuthorizationForm.Login + "; Password=" + AuthorizationForm.Password;
            con = new SqlConnection(connectionString);
            con.Open();

            string zapros = "Select СЗ.Наименование From Список_Задач СЗ, Учетные_Записи У Where У.ID = СЗ.ID_Учетной_Записи and У.ID = @1";
            SqlCommand command = new SqlCommand(zapros, con);
            command.Parameters.AddWithValue("@1", Convert.ToString(AuthorizationForm.o)); //ID Учетки
            SqlDataReader read = command.ExecuteReader();
            while (read.Read())
            {
                listBox1.Items.Add(read[0].ToString());
            }
            read.Close();
            listBox1.DrawItem += listBox1_DrawItem;
            if (listBox1.Items.Count == 0)
            {
                listBox1.Visible = false;
                label4.Visible = true;
            }
            else
            {
                listBox1.Visible = true;
                label4.Visible = false;
            }

            string[] fio = AuthorizationForm.ooo.Split(' ');
            string[] pas = AuthorizationForm.Pasport.Split(' ');
            label16.Text = Convert.ToString(fio[0]);
            label27.Text = Convert.ToString(fio[1]);
            label28.Text = Convert.ToString(fio[2]);
            label29.Text = Convert.ToString(AuthorizationForm.Job);
            label30.Text = Convert.ToString(pas[0]);
            label31.Text = Convert.ToString(pas[1]);
            label32.Text = Convert.ToString(AuthorizationForm.Login);
        }
        private void Form3lichkab_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (noexit == false)
            {
                Form f1 = Application.OpenForms[0];
                f1.Close();
                con.Close();
            }
        }
        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            TextRenderer.DrawText(e.Graphics, listBox1.Items[e.Index].ToString(), e.Font, e.Bounds, e.ForeColor, e.BackColor, TextFormatFlags.HorizontalCenter);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == true)
            {
                panel1.Enabled = false;
                panel1.Visible = false;
                panel3.Enabled = true;
                panel3.Visible = true;
                button1.Text = "Назад";
                foreach (Control C in panel1.Controls)
                {
                    if (C is TextBox)
                        C.Text = "";
                }

            }
            else
            {
                textBox1.Text = label28.Text;
                textBox2.Text = label30.Text;
                textBox3.Text = label16.Text;
                textBox5.Text = label27.Text;
                textBox6.Text = label31.Text;
                textBox7.Text = label32.Text;
                panel1.Enabled = true;
                panel1.Visible = true;
                panel3.Enabled = false;
                panel3.Visible = false;
                button1.Text = "Изменить данные";

            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            int count = 0;
            int problems = 0;
            bool p1 = false;
            bool p2 = false;
            bool p3 = false;
            bool p4 = false;
            if (textBox2.Text != label30.Text)
            {
                string proverka = "SELECT Серия_Паспорта FROM Сотрудники WHERE Серия_Паспорта = @1";
                SqlCommand command = new SqlCommand(proverka, con);
                command.Parameters.AddWithValue("@1", Convert.ToString(textBox2.Text)); //серия
                SqlDataReader read = command.ExecuteReader();
                if (read.Read())
                {
                    problems++;
                    label33.Visible = true;
                    label35.Visible = true;
                }
                else
                {
                    label33.Visible = false;
                    label35.Visible = false;
                    p1 = true;
                }
                read.Close();
            }
            if (textBox6.Text != label31.Text)
            {
                string proverka = "SELECT Номер_Паспорта FROM Сотрудники WHERE Номер_Паспорта = @1";
                SqlCommand command = new SqlCommand(proverka, con);
                command.Parameters.AddWithValue("@1", Convert.ToString(textBox6.Text)); //номер
                SqlDataReader read = command.ExecuteReader();
                if (read.Read())
                {
                    problems++;
                    label33.Visible = true;
                    label36.Visible = true;
                }
                else
                {
                    label33.Visible = false;
                    label36.Visible = false;
                    p2 = true;
                }
                read.Close();
            }
            if (textBox7.Text != label32.Text)
            {
                string proverka = "SELECT Логин FROM Учетные_Записи WHERE Логин = @1";
                SqlCommand command = new SqlCommand(proverka, con);
                command.Parameters.AddWithValue("@1", Convert.ToString(textBox7.Text)); //логин
                SqlDataReader read = command.ExecuteReader();
                if (read.Read())
                {
                    problems++;
                    label33.Visible = true;
                    label37.Visible = true;
                }
                else
                {
                    label33.Visible = false;
                    label37.Visible = false;
                    p3 = true;
                }
                read.Close();
            }
            if (textBox8.TextLength > 0)
            {
                if (Convert.ToString(textBox9.Text) == AuthorizationForm.Password)
                {
                    label33.Visible = false;
                    label34.Visible = false;
                    p4 = true;
                }
                else
                {
                    label33.Visible = true;
                    label34.Visible = true;
                    problems++;
                }
            }
            bool tfilled = panel5.Controls.OfType<TextBox>().Any(t => t.TextLength == 0);
            if (tfilled == true)
                {
                    problems++;
                    MessageBox.Show("Изменено объектов — " + Convert.ToString(count) + ", попытка стереть данные.", "Предупреждение");
                }
            if (problems == 0)
            {
                var result = MessageBox.Show("Вы уверены, что хотите ввести измененые данные?", "Предупреждение", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (textBox1.Text != label28.Text) //отчество
                    {
                        string zapros1 = "Update Сотрудники Set Отчество = " + (string.IsNullOrEmpty(textBox1.Text) ? "NULL" : string.Format("'{0}'", textBox1.Text)) + " Where ID = @1";
                        SqlCommand command1 = new SqlCommand(zapros1, con);
                        command1.Parameters.AddWithValue("@1", Convert.ToString(AuthorizationForm.o)); //учетка
                        command1.ExecuteNonQuery();
                        count++;
                    }
                    if (p1 == true) //серия
                    {
                        string zapros1 = "Update Сотрудники Set Серия_Паспорта = @1 Where ID = @2";
                        SqlCommand command1 = new SqlCommand(zapros1, con);
                        command1.Parameters.AddWithValue("@1", Convert.ToString(textBox2.Text)); //серия
                        command1.Parameters.AddWithValue("@2", Convert.ToString(AuthorizationForm.o)); //учетка
                        command1.ExecuteNonQuery();
                        count++;
                    }
                    if (textBox3.Text != label16.Text) //имя
                    {
                        string zapros1 = "Update Сотрудники Set Имя = @1 Where ID = @2";
                        SqlCommand command1 = new SqlCommand(zapros1, con);
                        command1.Parameters.AddWithValue("@1", Convert.ToString(textBox3.Text)); //имя
                        command1.Parameters.AddWithValue("@2", Convert.ToString(AuthorizationForm.o)); //учетка
                        command1.ExecuteNonQuery();
                        count++;
                    }

                    if (textBox5.Text != label27.Text) //фамилия
                    {
                        string zapros1 = "Update Сотрудники Set Фамилия = @1 Where ID = @2";
                        SqlCommand command1 = new SqlCommand(zapros1, con);
                        command1.Parameters.AddWithValue("@1", Convert.ToString(textBox5.Text)); //фамилия
                        command1.Parameters.AddWithValue("@2", Convert.ToString(AuthorizationForm.o)); //учетка
                        command1.ExecuteNonQuery();
                        count++;
                    }
                    if (p2 == true) //номер
                    {
                        string zapros1 = "Update Сотрудники Set Номер_Паспорта = @1 Where ID = @2";
                        SqlCommand command1 = new SqlCommand(zapros1, con);
                        command1.Parameters.AddWithValue("@1", Convert.ToString(textBox6.Text)); //номер
                        command1.Parameters.AddWithValue("@2", Convert.ToString(AuthorizationForm.o)); //учетка
                        command1.ExecuteNonQuery();
                        count++;
                    }
                    if (p3 == true) //логин
                    {
                        string zapros1 = "Use [master] ALTER Login " + Convert.ToString(label32.Text) + " WITH NAME = " + Convert.ToString(textBox7.Text) + " Use [RIA CRM DB] ALter User " + Convert.ToString(label32.Text) + " WITH NAME = " + Convert.ToString(textBox7.Text);
                        SqlCommand command1 = new SqlCommand(zapros1, con);
                        command1.ExecuteNonQuery();

                        string zapros2 = "Update Учетные_Записи Set Логин = @1 Where ID = @2";
                        SqlCommand command2 = new SqlCommand(zapros2, con);
                        command2.Parameters.AddWithValue("@1", Convert.ToString(textBox7.Text)); //логин
                        command2.Parameters.AddWithValue("@2", Convert.ToString(AuthorizationForm.o)); //учетка
                        command2.ExecuteNonQuery();
                        count++;
                    }
                    if (p4 == true) //пароль
                    {
                        string zapros1 = "Use [master] ALTER LOGIN " + Convert.ToString(label32.Text) + " WITH PASSWORD=N'" + Convert.ToString(textBox8.Text) + "'";
                        SqlCommand command1 = new SqlCommand(zapros1, con);
                        command1.ExecuteNonQuery();

                        string zapros2 = "Use [RIA CRM DB] Update Учетные_Записи Set Пароль = @1 Where ID = @2";
                        SqlCommand command2 = new SqlCommand(zapros2, con);
                        command2.Parameters.AddWithValue("@1", Convert.ToString(textBox8.Text)); //пароль
                        command2.Parameters.AddWithValue("@2", Convert.ToString(AuthorizationForm.o)); //учетка
                        command2.ExecuteNonQuery();
                        count++;
                    }
                    if (count > 0)
                    {
                        MessageBox.Show("Изменено объектов — " + Convert.ToString(count) + ", производится перезапуск приложения.", "Подтверждение");
                        noexit = true;
                        AuthorizationForm f1 = new AuthorizationForm();
                        f1.Left = this.Left;
                        f1.Top = this.Top;
                        f1.Show();
                        this.Close();
                        con.Close();
                    }
                    else
                        MessageBox.Show("Изменено объектов — " + Convert.ToString(count) + ", не было введено информации.", "Предупреждение");
                }
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            noexit = true;
            MainForm f2 = new MainForm();
            f2.Left = this.Left;
            f2.Top = this.Top;
            f2.Show();
            this.Close();
            con.Close();
        }
    }
}
