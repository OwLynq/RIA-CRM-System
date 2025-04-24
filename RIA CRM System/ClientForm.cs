using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RIA_CRM_System
{
    public partial class ClientForm : Form
    {
        SqlConnection con;
        bool noexit = false;
        bool ds = false;
        public ClientForm()
        {
            InitializeComponent();
            string connectionString = @"Data Source=OwlPC; Initial Catalog=RIA CRM DB; User ID=" + AuthorizationForm.Login + "; Password=" + AuthorizationForm.Password;
            con = new SqlConnection(connectionString);
            con.Open();
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
        private void Form7klients_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (noexit == false)
            {
                Form f1 = Application.OpenForms[0];
                f1.Close();
                con.Close();
            }
        }
        private void Form7klients_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "RIA_CRM_DBDataSet.Юридические_лица". При необходимости она может быть перемещена или удалена.
            this.юридические_лицаTableAdapter.Fill(this.RIA_CRM_DBDataSet.Юридические_лица);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "RIA_CRM_DBDataSet.Физические_Лица". При необходимости она может быть перемещена или удалена.
            this.физические_ЛицаTableAdapter.Fill(this.RIA_CRM_DBDataSet.Физические_Лица);
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            button4.Enabled = true;
            label6.Visible = false;
            panel3.Visible = false;
            panel1.Visible = true;
            if (ds == false)
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
            }
            dataGridView1.DataSource = this.физическиеЛицаBindingSource;
            string col = dataGridView1.Columns[0].Name;
            dataGridView1.Columns.Remove(col);
            dataGridView1.Columns[0].DisplayIndex = 0;
            dataGridView1.Columns[1].DisplayIndex = 1;
            dataGridView1.Columns[2].DisplayIndex = 2;
            dataGridView1.Columns[3].DisplayIndex = 3;
            dataGridView1.Columns[4].DisplayIndex = 4;
            dataGridView1.Visible = true;
            ds = true;

            button2.Enabled = false;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            button2.Enabled = true;
            label6.Visible = false;
            panel3.Visible = true;
            panel1.Visible = false;
            if (ds == false)
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
            }
            dataGridView1.DataSource = this.юридическиелицаBindingSource;
            string col = dataGridView1.Columns[0].Name;
            dataGridView1.Columns.Remove(col);
            dataGridView1.Columns[0].DisplayIndex = 0;
            dataGridView1.Columns[1].DisplayIndex = 1;
            dataGridView1.Columns[2].DisplayIndex = 2;
            dataGridView1.Visible = true;
            ds = true;
            button4.Enabled = false;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            button4.Enabled = true;
            label6.Visible = false;
            dataGridView1.Visible = true;
            dataGridView1.DataSource = null;
            if (ds == false)
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
            }
            ds = false;

            var column1 = new DataGridViewColumn();
            column1.HeaderText = "Наименование";
            column1.CellTemplate = new DataGridViewTextBoxCell();

            var column2 = new DataGridViewColumn();
            column2.HeaderText = "Телефон";
            column2.CellTemplate = new DataGridViewTextBoxCell();

            var column3 = new DataGridViewColumn();
            column3.HeaderText = "E-mail";
            column3.CellTemplate = new DataGridViewTextBoxCell();

            dataGridView1.Columns.Add(column1);
            dataGridView1.Columns.Add(column2);
            dataGridView1.Columns.Add(column3);

            string zapros = "Select * From Юридические_Лица Where Наименование = @1";
            SqlCommand command = new SqlCommand(zapros, con);
            command.Parameters.AddWithValue("@1", Convert.ToString(textBox2.Text));
            SqlDataReader read = command.ExecuteReader();
            while (read.Read())
            {
                dataGridView1.Rows.Add(read[1].ToString(), read[2].ToString(), read[3].ToString());
            }
            if (dataGridView1.Rows.Count == 0) { dataGridView1.Visible = false; label6.Visible = true; }
            read.Close();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            label6.Visible = false;
            dataGridView1.Visible = true;
            dataGridView1.DataSource = null;
            if (ds == false)
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
            }
            ds = false;

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
            column4.HeaderText = "Телефон";
            column4.CellTemplate = new DataGridViewTextBoxCell();

            var column5 = new DataGridViewColumn();
            column5.HeaderText = "E-mail";
            column5.CellTemplate = new DataGridViewTextBoxCell();


            dataGridView1.Columns.Add(column1);
            dataGridView1.Columns.Add(column2);
            dataGridView1.Columns.Add(column3);
            dataGridView1.Columns.Add(column4);
            dataGridView1.Columns.Add(column5);

            string zapros = "Select * From Физические_Лица Where Имя = @1";
            SqlCommand command = new SqlCommand(zapros, con);
            command.Parameters.AddWithValue("@1", Convert.ToString(textBox1.Text));
            SqlDataReader read = command.ExecuteReader();
            while (read.Read())
            {
                dataGridView1.Rows.Add(read[1].ToString(), read[2].ToString(), read[3].ToString(), read[4].ToString(), read[5].ToString());
            }
            if (dataGridView1.Rows.Count == 0) { dataGridView1.Visible = false; label6.Visible = true; }
            read.Close();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            noexit = true;
            ClientRegForm f8 = new ClientRegForm();
            f8.Left = this.Left;
            f8.Top = this.Top;
            f8.Show();
            this.Close();
            con.Close();
        }
    }
}
