namespace RIA_CRM_System
{
    partial class EmployeeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.RIA_CRM_DBDataSet = new RIA_CRM_System.RIA_CRM_DBDataSet();
            this.сотрудникиНаПредприятииBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.сотрудники_на_предприятииTableAdapter = new RIA_CRM_System.RIA_CRM_DBDataSetTableAdapters.Сотрудники_на_предприятииTableAdapter();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RIA_CRM_DBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.сотрудникиНаПредприятииBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(396, 12);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 426);
            this.panel2.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(27, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(336, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Система Управления Рекламным Агенством";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label1.Location = new System.Drawing.Point(144, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "Сотрудники";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(411, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(238, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "Назад";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.Location = new System.Drawing.Point(12, 70);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(381, 368);
            this.dataGridView1.TabIndex = 23;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(411, 59);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(238, 23);
            this.button2.TabIndex = 24;
            this.button2.Text = "Отобразить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(411, 187);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(238, 23);
            this.button3.TabIndex = 25;
            this.button3.Text = "Отобразить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label2.Location = new System.Drawing.Point(443, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 15);
            this.label2.TabIndex = 26;
            this.label2.Text = "Отобразить сотрудников";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label4.Location = new System.Drawing.Point(465, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 15);
            this.label4.TabIndex = 27;
            this.label4.Text = "Найти сотрудника";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(474, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Введите Псевдоним";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(411, 161);
            this.textBox1.MaxLength = 20;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(238, 20);
            this.textBox1.TabIndex = 29;
            // 
            // RIA_CRM_DBDataSet
            // 
            this.RIA_CRM_DBDataSet.DataSetName = "RIA_CRM_DBDataSet";
            this.RIA_CRM_DBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // сотрудникиНаПредприятииBindingSource
            // 
            this.сотрудникиНаПредприятииBindingSource.DataMember = "Сотрудники на предприятии";
            this.сотрудникиНаПредприятииBindingSource.DataSource = this.RIA_CRM_DBDataSet;
            // 
            // сотрудники_на_предприятииTableAdapter
            // 
            this.сотрудники_на_предприятииTableAdapter.ClearBeforeFill = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label6.Location = new System.Drawing.Point(114, 215);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 15);
            this.label6.TabIndex = 30;
            this.label6.Text = "Сотрудник не найден";
            this.label6.Visible = false;
            // 
            // Form4sotr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 450);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Name = "Form4sotr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Сотрудники";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form4sotr_FormClosed);
            this.Load += new System.EventHandler(this.Form4sotr_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RIA_CRM_DBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.сотрудникиНаПредприятииBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private RIA_CRM_DBDataSet RIA_CRM_DBDataSet;
        private System.Windows.Forms.BindingSource сотрудникиНаПредприятииBindingSource;
        private RIA_CRM_DBDataSetTableAdapters.Сотрудники_на_предприятииTableAdapter сотрудники_на_предприятииTableAdapter;
        private System.Windows.Forms.Label label6;
    }
}