using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RIA_CRM_System
{
    public partial class EmployeeForm : Form
    {
        SqlConnection con;
        bool noexit = false;
        bool ad = false;
        public EmployeeForm()
        {
            InitializeComponent();
            string connectionString = @"Data Source=OwlPC; Initial Catalog=RIA CRM DB; User ID=" + AuthorizationForm.Login + "; Password=" + AuthorizationForm.Password;
            con = new SqlConnection(connectionString);
            con.Open();
        }
        private void Form4sotr_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (noexit == false)
            {
                Form f1 = Application.OpenForms[0];
                f1.Close();
                con.Close();
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
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true; label6.Visible = false;
            if (ad == true)
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
            }
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear(); 
            dataGridView1.DataSource = this.сотрудникиНаПредприятииBindingSource;
            ad = false;
        }
        private void Form4sotr_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "RIA_CRM_DBDataSet.Сотрудники_на_предприятии". При необходимости она может быть перемещена или удалена.
            this.сотрудники_на_предприятииTableAdapter.Fill(this.RIA_CRM_DBDataSet.Сотрудники_на_предприятии);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            ad = true;
            dataGridView1.Visible = true; label6.Visible = false;
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            var column1 = new DataGridViewColumn();
            column1.HeaderText = "Имя";
            column1.CellTemplate = new DataGridViewTextBoxCell();

            var column2 = new DataGridViewColumn();
            column2.HeaderText = "Фамилия";
            column2.CellTemplate = new DataGridViewTextBoxCell();

            var column3 = new DataGridViewColumn();
            column3.HeaderText = "Отчество";
            column3.CellTemplate = new DataGridViewTextBoxCell();

            var column4 = new DataGridViewColumn();
            column4.HeaderText = "Должность";
            column4.CellTemplate = new DataGridViewTextBoxCell();

            var column5 = new DataGridViewColumn();
            column5.HeaderText = "Псевдоним";
            column5.CellTemplate = new DataGridViewTextBoxCell();


            dataGridView1.Columns.Add(column1);
            dataGridView1.Columns.Add(column2);
            dataGridView1.Columns.Add(column3);
            dataGridView1.Columns.Add(column4);
            dataGridView1.Columns.Add(column5);

            string zapros = "Select * From [Сотрудники на предприятии] Where Псевдоним = @1";
            SqlCommand command = new SqlCommand(zapros, con);
            command.Parameters.AddWithValue("@1", Convert.ToString(textBox1.Text));
            SqlDataReader read = command.ExecuteReader();
            while (read.Read())
            {
                dataGridView1.Rows.Add(read[0].ToString(), read[1].ToString(), read[2].ToString(), read[3].ToString(), read[4].ToString());
            }
            if (dataGridView1.Rows.Count == 0) { dataGridView1.Visible = false; label6.Visible = true; }
            read.Close();
        }
    }
}
