using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RIA_CRM_System
{
    public partial class TaskForm : Form
    {
        SqlConnection con;
        bool noexit = false;
        public TaskForm()
        {

            InitializeComponent();
            string connectionString = @"Data Source=OwlPC; Initial Catalog=RIA CRM DB; User ID=" + AuthorizationForm.Login + "; Password=" + AuthorizationForm.Password;
            con = new SqlConnection(connectionString);
            con.Open();
            
            if (AuthorizationForm.Job == "Директор") //доп. функции директора
            {
                paneldirector.Visible = true;
                label67.Visible = true;
                label15.Visible = true;
                string zapros = "Select Наименование From Список_Задач";
                SqlCommand command = new SqlCommand(zapros, con);
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
                    listBox1.Enabled = false;
                    labelnotasks1.Visible = true;
                }
                else
                {
                    listBox1.Visible = true;
                    listBox1.Enabled = true;
                    labelnotasks1.Visible = false;
                }
            }
            else //доп. функции остальных
            {
                panelsotr.Visible = true;
                button3.Visible = true;
                string zapros = "Select СЗ.Наименование From Список_Задач СЗ, Учетные_Записи У Where У.ID = СЗ.ID_Учетной_Записи and У.ID = @1 and СЗ.Статус = 'Действующая'";
                SqlCommand command = new SqlCommand(zapros, con);
                command.Parameters.AddWithValue("@1", Convert.ToString(AuthorizationForm.o)); //ID Учетки
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    listBox2.Items.Add(read[0].ToString());
                }
                read.Close();
                listBox2.DrawItem += listBox2_DrawItem;
                if (listBox2.Items.Count == 0)
                {
                    listBox2.Visible = false;
                    listBox2.Enabled = false;
                    labelnotasks2.Visible = true;
                }
                else
                {
                    listBox2.Visible = true;
                    listBox2.Enabled = true;
                    labelnotasks2.Visible = false;
                }
            }
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            noexit = true;
            MainForm f2 = new MainForm();
            f2.Left = this.Left;
            f2.Top = this.Top;
            f2.Show();
            this.Close();
            con.Close();
        }
        private void Form6zadach_FormClosing(object sender, FormClosingEventArgs e)
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
        private void listBox2_DrawItem(object sender, DrawItemEventArgs e)
        {
            TextRenderer.DrawText(e.Graphics, listBox2.Items[e.Index].ToString(), e.Font, e.Bounds, e.ForeColor, e.BackColor, TextFormatFlags.HorizontalCenter);
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) //ЛистБокс для Директора
        {
            label14.Text = "";
            label13.Text = "";
            string item = listBox1.SelectedItem.ToString();
            label10.Text = item;
            bool FL = false;
            string check = "Select ID_Физического_лица, ID_Юридического_Лица From Список_Задач С Where С.Наименование = @item";
            SqlCommand command = new SqlCommand(check, con);
            command.Parameters.AddWithValue("@item", Convert.ToString(item)); //Наименование задачи
            SqlDataReader read = command.ExecuteReader();
            read.Read();
            if (read[0].ToString() != "") FL = true;
            read.Close();
            if (FL == true) //Для Физ.Лиц
            {
                string zapros = "Select ФЛ.Фамилия, ФЛ.Имя, ФЛ.Отчество, СЗ.Дата_Поступления, СЗ.Текст, СЗ.Статус "
                              + "From Список_Задач СЗ, Физические_Лица ФЛ "
                              + "Where ФЛ.ID = СЗ.ID_Физического_лица and СЗ.Наименование = @1";
                SqlCommand command1 = new SqlCommand(zapros, con);
                command1.Parameters.AddWithValue("@1", Convert.ToString(item)); //Наименование задачи
                SqlDataReader read1 = command1.ExecuteReader();
                while (read1.Read())
                {
                    label11.Text = read1[0].ToString() + " " + read1[1].ToString() + " " + read1[2].ToString();
                    label12.Text = read1[3].ToString();
                    label14.Text = read1[4].ToString();
                    label15.Text = read1[5].ToString();
                }
                read1.Close();
                string zapros2 = "Select С.Имя, С.Фамилия, С.Отчество "
                               + "From Список_Задач СЗ, Учетные_Записи У, Сотрудники С "
                               + "Where У.ID = СЗ.ID_Учетной_Записи and У.ID = С.ID and СЗ.Наименование = @1";
                SqlCommand command2 = new SqlCommand(zapros2, con);
                command2.Parameters.AddWithValue("@1", Convert.ToString(item)); //Наименование задачи
                SqlDataReader read2 = command2.ExecuteReader();
                while (read2.Read())
                {
                    label13.Text = read2[0].ToString() + " " + read2[1].ToString() + " " + read2[2].ToString();
                }
                read2.Close();
            }
            else //Для Юр.Лиц
            {
                string zapros = "Select ЮЛ.Наименование, СЗ.Дата_Поступления, СЗ.Текст, СЗ.Статус "
                              + "From Список_Задач СЗ, Юридические_Лица ЮЛ  "
                              + "Where ЮЛ.ID = СЗ.ID_Юридического_Лица and СЗ.Наименование = @1";
                SqlCommand command1 = new SqlCommand(zapros, con);
                command1.Parameters.AddWithValue("@1", Convert.ToString(item)); //Наименование задачи
                SqlDataReader read1 = command1.ExecuteReader();
                while (read1.Read())
                {
                    label11.Text = read1[0].ToString();
                    label12.Text = read1[1].ToString();
                    label14.Text = read1[2].ToString();
                    label15.Text = read1[3].ToString();
                }
                read1.Close();
                string zapros2 = "Select С.Имя, С.Фамилия, С.Отчество "
                               + "From Список_Задач СЗ, Учетные_Записи У, Сотрудники С "
                               + "Where У.ID = СЗ.ID_Учетной_Записи and У.ID = С.ID and СЗ.Наименование = @1";
                SqlCommand command2 = new SqlCommand(zapros2, con);
                command2.Parameters.AddWithValue("@1", Convert.ToString(item)); //Наименование задачи
                SqlDataReader read2 = command2.ExecuteReader();
                while (read2.Read())
                {
                    label13.Text = read2[0].ToString() + " " + read2[1].ToString() + " " + read2[2].ToString();
                }
                read2.Close();
            }
            if (label14.Text == "") label14.Text = "(отсутвует)";
            if (label13.Text == "") label13.Text = "(отсутвует)";
            panel2.Visible = true;
        }
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e) //ЛистБокс для остальных
        {
            label14.Text = "";
            label13.Text = "";
            string item = listBox2.SelectedItem.ToString();
            label10.Text = item;
            bool FL = false;
            string check = "Select ID_Физического_лица, ID_Юридического_Лица From Список_Задач С Where С.Наименование = @item";
            SqlCommand command = new SqlCommand(check, con);
            command.Parameters.AddWithValue("@item", Convert.ToString(item)); //Наименование задачи
            SqlDataReader read = command.ExecuteReader();
            read.Read();
            if (read[0].ToString() != "") FL = true;
            read.Close();
            if (FL == true) //Для Физ.Лиц
            {
                string zapros = "Select ФЛ.Фамилия, ФЛ.Имя, ФЛ.Отчество, СЗ.Дата_Поступления, СЗ.Текст "
                              + "From Список_Задач СЗ, Физические_Лица ФЛ "
                              + "Where ФЛ.ID = СЗ.ID_Физического_лица and СЗ.Наименование = @1";
                SqlCommand command1 = new SqlCommand(zapros, con);
                command1.Parameters.AddWithValue("@1", Convert.ToString(item)); //Наименование задачи
                SqlDataReader read1 = command1.ExecuteReader();
                while (read1.Read())
                {
                    label11.Text = read1[0].ToString() + " " + read1[1].ToString() + " " + read1[2].ToString();
                    label12.Text = read1[3].ToString();
                    label14.Text = read1[4].ToString();
                }
                read1.Close();
                string zapros2 = "Select С.Имя, С.Фамилия, С.Отчество "
                               + "From Список_Задач СЗ, Учетные_Записи У, Сотрудники С "
                               + "Where У.ID = СЗ.ID_Учетной_Записи and У.ID = С.ID and СЗ.Наименование = @1";
                SqlCommand command2 = new SqlCommand(zapros2, con);
                command2.Parameters.AddWithValue("@1", Convert.ToString(item)); //Наименование задачи
                SqlDataReader read2 = command2.ExecuteReader();
                while (read2.Read())
                {
                    label13.Text = read2[0].ToString() + " " + read2[1].ToString() + " " + read2[2].ToString();
                }
                read2.Close();
            }
            else //Для Юр.Лиц
            {
                string zapros = "Select ЮЛ.Наименование, СЗ.Дата_Поступления, СЗ.Текст "
                              + "From Список_Задач СЗ, Юридические_Лица ЮЛ  "
                              + "Where ЮЛ.ID = СЗ.ID_Юридического_Лица and СЗ.Наименование = @1";
                SqlCommand command1 = new SqlCommand(zapros, con);
                command1.Parameters.AddWithValue("@1", Convert.ToString(item)); //Наименование задачи
                SqlDataReader read1 = command1.ExecuteReader();
                while (read1.Read())
                {
                    label11.Text = read1[0].ToString();
                    label12.Text = read1[1].ToString();
                    label14.Text = read1[2].ToString();
                }
                read1.Close();
                string zapros2 = "Select С.Имя, С.Фамилия, С.Отчество "
                               + "From Список_Задач СЗ, Учетные_Записи У, Сотрудники С "
                               + "Where У.ID = СЗ.ID_Учетной_Записи and У.ID = С.ID and СЗ.Наименование = @1";
                SqlCommand command2 = new SqlCommand(zapros2, con);
                command2.Parameters.AddWithValue("@1", Convert.ToString(item)); //Наименование задачи
                SqlDataReader read2 = command2.ExecuteReader();
                while (read2.Read())
                {
                    label13.Text = read2[0].ToString() + " " + read2[1].ToString() + " " + read2[2].ToString();
                }
                read2.Close();
            }
            if (label14.Text == "") label14.Text = "(отсутвует)";
            if (label13.Text == "") label13.Text = "(отсутвует)";
            panel2.Visible = true;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Нажимая на кнопку ДА вы подтверждаете, что выполнили задачу. В противном случае нажмите на кнопку НЕТ.", "Подтверждение", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string task = label10.Text;
                string zapros = "Update Список_Задач Set Статус = N'Выполненная' Where Наименование = @1";
                SqlCommand command1 = new SqlCommand(zapros, con);
                command1.Parameters.AddWithValue("@1", Convert.ToString(task)); //Наименование задачи
                command1.ExecuteNonQuery();
                noexit = true;
                TaskForm f6 = new TaskForm();
                f6.Left = this.Left;
                f6.Top = this.Top;
                f6.Show();
                this.Close();
                con.Close();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (panel3.Visible == false)
            {
                panel2.Visible = false;
                panel3.Visible = true;
                button2.Text = "Отменить";
            }
            else 
            {
                var result = MessageBox.Show("Вы уверены, что хотите отменить оформление?", "Предупреждение", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    panel3.Visible = false;
                    button2.Text = "Оформление заказа";
                    checkBox1.Checked = false;
                    checkBox2.Checked = false;
                    foreach (Control C in panel3.Controls)
                    {
                        if (C is TextBox || C is ComboBox)
                            C.Text = "";
                    }
                }
                
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            noexit = true;
            TaskManageForm f10 = new TaskManageForm();
            f10.Left = this.Left;
            f10.Top = this.Top;
            f10.Show();
            this.Close();
            con.Close();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox2.Enabled = false;
                comboBox1.DataSource = юридическиелицаBindingSource;
                comboBox1.DisplayMember = "Наименование";
                comboBox1.SelectedIndex = -1;
                comboBox1.Enabled = true;
            }
            else
            {
                checkBox2.Enabled = true;
                comboBox1.DataSource = null;
                comboBox1.DisplayMember = null;
                comboBox1.Text = "";
                comboBox1.Enabled = false;
            }

        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Enabled = false;
                string qwery = "Select Distinct ID, Фамилия, Имя, Отчество From Физические_Лица";
                SqlCommand command = new SqlCommand(qwery, con); 
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader[0].ToString() + ") " + reader[1].ToString() + " " + reader[2].ToString() + " " + reader[3].ToString());
                }
                reader.Close();
                comboBox1.SelectedIndex = -1;
                comboBox1.Enabled = true;
            }
            else
            {
                checkBox1.Enabled = true;
                comboBox1.Items.Clear();
                comboBox1.Text = "";
                comboBox1.Enabled = false;

            }
        }
        private void Form6zadach_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "RIA_CRM_DBDataSet.Физические_Лица". При необходимости она может быть перемещена или удалена.
            this.физические_ЛицаTableAdapter.Fill(this.RIA_CRM_DBDataSet.Физические_Лица);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "RIA_CRM_DBDataSet.Юридические_лица". При необходимости она может быть перемещена или удалена.
            this.юридические_лицаTableAdapter.Fill(this.RIA_CRM_DBDataSet.Юридические_лица);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "RIA_CRM_DBDataSet.Юридические_лица". При необходимости она может быть перемещена или удалена.
            this.юридические_лицаTableAdapter.Fill(this.RIA_CRM_DBDataSet.Юридические_лица);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "RIA_CRM_DBDataSet.Юридические_лица". При необходимости она может быть перемещена или удалена.
            this.юридические_лицаTableAdapter.Fill(this.RIA_CRM_DBDataSet.Юридические_лица);

        }
        private void button4_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите сохранить заказ?", "Предупреждение", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                bool error = false;
                label20.Visible = false;
                string check = "SELECT ID FROM Список_Задач WHERE Наименование = @1";
                SqlCommand command = new SqlCommand(check, con);
                command.Parameters.AddWithValue("@1", Convert.ToString(textBox3.Text)); //наименование
                SqlDataReader read = command.ExecuteReader();
                if (read.Read())
                {
                    error = true;
                    label20.Visible = true;
                }
                read.Close();
                if (error == false)
                {
                    if (checkBox1.Checked == true)
                    {
                        string idsearch = "Select ID From Юридические_Лица Where Наименование = @1";
                        SqlCommand command1 = new SqlCommand(idsearch, con);
                        command1.Parameters.AddWithValue("@1", Convert.ToString(comboBox1.Text));
                        string UL = Convert.ToString(command1.ExecuteScalar());

                        string query = "INSERT INTO Список_Задач(Наименование, Текст, Дата_Поступления, ID_Физического_лица, ID_Юридического_Лица) "
                                     + "VALUES(@1, '" + Convert.ToString(textBox1.Text) + "', CURRENT_TIMESTAMP, NULL, @2)";
                        SqlCommand command2 = new SqlCommand(query, con);
                        command2.Parameters.AddWithValue("@1", Convert.ToString(textBox3.Text)); //Наименование
                        command2.Parameters.AddWithValue("@2", Convert.ToString(UL)); //ID ЮЛ
                        command2.ExecuteNonQuery();
                        MessageBox.Show("Заказ успешно сохранен.");
                    }
                    else
                    {
                        string[] arr = Convert.ToString(comboBox1.Text).Split(')');
                        String ID = arr[0];
                        string query = "INSERT INTO Список_Задач(Наименование, Текст, Дата_Поступления, ID_Физического_лица, ID_Юридического_Лица) "
                                     + "VALUES(@1, '" + Convert.ToString(textBox1.Text) + "', CURRENT_TIMESTAMP, @2, NULL)";
                        SqlCommand command2 = new SqlCommand(query, con);
                        command2.Parameters.AddWithValue("@1", Convert.ToString(textBox3.Text)); //Наименование
                        command2.Parameters.AddWithValue("@2", Convert.ToString(ID)); //ID ФЛ
                        command2.ExecuteNonQuery();
                        MessageBox.Show("Заказ успешно сохранен.");
                    }
                }
            }
        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            if (comboBox1.SelectedIndex == -1 || textBox3.Text == "")
                button4.Enabled = false;
            else
                button4.Enabled = true;
        }
    }
}
