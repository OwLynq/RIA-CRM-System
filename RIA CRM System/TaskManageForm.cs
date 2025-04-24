using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RIA_CRM_System
{
    public partial class TaskManageForm : Form
    {
        SqlConnection con;
        bool noexit = false;
        public TaskManageForm()
        {
            InitializeComponent();
            string connectionString = @"Data Source=OwlPC; Initial Catalog=RIA CRM DB; User ID=" + AuthorizationForm.Login + "; Password=" + AuthorizationForm.Password;
            con = new SqlConnection(connectionString);
            con.Open();
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            noexit = true;
            TaskForm f6 = new TaskForm();
            f6.Left = this.Left;
            f6.Top = this.Top;
            f6.Show();
            this.Close();
            con.Close();
        }
        private void Form9yprzadach_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (noexit == false)
            {
                Form f1 = Application.OpenForms[0];
                f1.Close();
                con.Close();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (panel2.Visible == false)
            {
                panel2.Visible = true;
                button2.Text = "Отменить назначение";
                foreach (Control C in panel3.Controls)
                {
                    if (C is ComboBox || C is Button)
                        C.Enabled = false;
                }
            }
            else
            {
                var result = MessageBox.Show("Вы уверены, что хотите отменить назначение задачи?", "Предупреждение", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    panel2.Visible = false;
                    button2.Text = "Назначить задачу";
                    foreach (Control C in panel2.Controls)
                    {
                        if (C is ComboBox)
                            C.Text = "";
                    }
                    foreach (Control C in panel3.Controls)
                    {
                        if (C is ComboBox || C is Button)
                            C.Enabled = true;
                    }
                }
            }
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            if (comboBox2.SelectedIndex == -1 || comboBox3.SelectedIndex == -1)
                button5.Visible = false;
            else
                button5.Visible = true;
        }
        private void Form9yprzadach_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "RIA_CRM_DBDataSet.Список_Задач". При необходимости она может быть перемещена или удалена.
            this.список_ЗадачTableAdapter.Fill(this.RIA_CRM_DBDataSet.Список_Задач);
            comboBox1.SelectedIndex = -1;
            string qwery = "SELECT Наименование FROM Список_Задач WHERE Статус = 'Не назначенная'";
            SqlCommand command = new SqlCommand(qwery, con);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox2.Items.Add(reader[0].ToString());
            }
            if (comboBox2.Items.Count < 1) button2.Enabled = false;
            reader.Close();
            comboBox2.SelectedIndex = -1;

            string qwery1 = "Select Distinct ID, Фамилия, Имя, Отчество From Сотрудники";
            SqlCommand command1 = new SqlCommand(qwery1, con);
            SqlDataReader read = command1.ExecuteReader();
            while (read.Read())
            {
                comboBox3.Items.Add(read[0].ToString() + ") " + read[1].ToString() + " " + read[2].ToString() + " " + read[3].ToString());
            }
            read.Close();
            comboBox3.SelectedIndex = -1;
        }
        private void Form9yprzadach_Paint(object sender, PaintEventArgs e)
        {
            if (comboBox1.SelectedIndex != -1) button3.Visible = true;
            else button3.Visible = false;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Нажимая на кнопку ДА вы подтверждаете, что хотите удалить задачу. В противном случае нажмите на кнопку НЕТ.", "Подтверждение", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string qwery = "Delete From Список_Задач Where Наименование = @1";
                SqlCommand command = new SqlCommand(qwery, con);
                command.Parameters.AddWithValue("@1", Convert.ToString(comboBox1.Text)); //Наименование задачи
                command.ExecuteNonQuery();
                MessageBox.Show("Задача успешно удалена.", "Готово");
                comboBox1.SelectedIndex = -1;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Нажимая на кнопку ДА вы подтверждаете, что хотите удалить выполненые задачи из базы данных. В противном случае нажмите на кнопку НЕТ.", "Подтверждение", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string qwery = "Delete From Список_Задач Where Статус = 'Выполненная'";
                SqlCommand command = new SqlCommand(qwery, con);
                command.ExecuteNonQuery();
                MessageBox.Show("Действие успешно выполненно", "Готово");
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            string[] arr = Convert.ToString(comboBox3.Text).Split(')');
            String ID = arr[0];
            string query = "UPDATE Список_Задач SET ID_Учетной_Записи = @2 WHERE Наименование = @1";
            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@1", Convert.ToString(comboBox2.Text)); //Наименование
            command.Parameters.AddWithValue("@2", Convert.ToString(ID)); //ID
            command.ExecuteNonQuery();
            MessageBox.Show("Задача успешно назначена.");
            noexit = true;
            TaskManageForm f9 = new TaskManageForm();
            f9.Left = this.Left;
            f9.Top = this.Top;
            f9.Show();
            this.Close();
            con.Close();
        }
    }
}
