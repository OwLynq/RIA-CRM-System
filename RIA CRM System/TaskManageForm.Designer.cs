namespace RIA_CRM_System
{
    partial class TaskManageForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.RIA_CRM_DBDataSet = new RIA_CRM_System.RIA_CRM_DBDataSet();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.списокЗадачBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.список_ЗадачTableAdapter = new RIA_CRM_System.RIA_CRM_DBDataSetTableAdapters.Список_ЗадачTableAdapter();
            this.списокЗадачBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RIA_CRM_DBDataSet)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.списокЗадачBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.списокЗадачBindingSource1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(27, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(336, 16);
            this.label3.TabIndex = 35;
            this.label3.Text = "Система Управления Рекламным Агенством";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label1.Location = new System.Drawing.Point(118, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 15);
            this.label1.TabIndex = 36;
            this.label1.Text = "Управление Задачами";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(396, 12);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 426);
            this.panel1.TabIndex = 37;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(411, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(238, 23);
            this.button1.TabIndex = 38;
            this.button1.Text = "Назад";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(411, 62);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(238, 23);
            this.button2.TabIndex = 39;
            this.button2.Text = "Назначить задачу";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label4.Location = new System.Drawing.Point(464, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 15);
            this.label4.TabIndex = 52;
            this.label4.Text = "Назначение Задачи";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(8, 43);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(238, 23);
            this.button3.TabIndex = 53;
            this.button3.Text = "Удалить задачу";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(8, 252);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(238, 23);
            this.button4.TabIndex = 54;
            this.button4.Text = "Очистить выполненые задачи";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label2.Location = new System.Drawing.Point(473, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 15);
            this.label2.TabIndex = 55;
            this.label2.Text = "Удаление Задачи";
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = this.RIA_CRM_DBDataSet;
            this.bindingSource1.Position = 0;
            // 
            // RIA_CRM_DBDataSet
            // 
            this.RIA_CRM_DBDataSet.DataSetName = "RIA_CRM_DBDataSet";
            this.RIA_CRM_DBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.comboBox3);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.comboBox2);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(4, 85);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(389, 353);
            this.panel2.TabIndex = 57;
            this.panel2.Visible = false;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(82, 259);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(238, 23);
            this.button5.TabIndex = 58;
            this.button5.Text = "Подтвердить";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Visible = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(82, 169);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(292, 21);
            this.comboBox3.TabIndex = 61;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label8.Location = new System.Drawing.Point(8, 170);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 15);
            this.label8.TabIndex = 62;
            this.label8.Text = "ФИО:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label7.Location = new System.Drawing.Point(127, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 15);
            this.label7.TabIndex = 60;
            this.label7.Text = "Выбор Сотрудника";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(130, 61);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(244, 21);
            this.comboBox2.TabIndex = 58;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label6.Location = new System.Drawing.Point(8, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 15);
            this.label6.TabIndex = 59;
            this.label6.Text = "Наименование:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label5.Location = new System.Drawing.Point(142, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 15);
            this.label5.TabIndex = 58;
            this.label5.Text = "Выбор Задачи";
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.списокЗадачBindingSource;
            this.comboBox1.DisplayMember = "Наименование";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(8, 16);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(238, 21);
            this.comboBox1.TabIndex = 58;
            // 
            // списокЗадачBindingSource
            // 
            this.списокЗадачBindingSource.DataMember = "Список_Задач";
            this.списокЗадачBindingSource.DataSource = this.bindingSource1;
            // 
            // список_ЗадачTableAdapter
            // 
            this.список_ЗадачTableAdapter.ClearBeforeFill = true;
            // 
            // списокЗадачBindingSource1
            // 
            this.списокЗадачBindingSource1.DataMember = "Список_Задач";
            this.списокЗадачBindingSource1.DataSource = this.bindingSource1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.comboBox1);
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.button4);
            this.panel3.Location = new System.Drawing.Point(403, 131);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(255, 278);
            this.panel3.TabIndex = 59;
            // 
            // Form9yprzadach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel3);
            this.Name = "Form9yprzadach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Управление Задачами";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form9yprzadach_FormClosing);
            this.Load += new System.EventHandler(this.Form9yprzadach_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form9yprzadach_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RIA_CRM_DBDataSet)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.списокЗадачBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.списокЗадачBindingSource1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.BindingSource bindingSource1;
        private RIA_CRM_DBDataSet RIA_CRM_DBDataSet;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.BindingSource списокЗадачBindingSource;
        private RIA_CRM_DBDataSetTableAdapters.Список_ЗадачTableAdapter список_ЗадачTableAdapter;
        private System.Windows.Forms.BindingSource списокЗадачBindingSource1;
        private System.Windows.Forms.Panel panel3;
    }
}