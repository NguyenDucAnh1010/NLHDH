namespace NLHDH
{
    partial class fcfs
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            label1 = new Label();
            numericUpDown1 = new NumericUpDown();
            label2 = new Label();
            avgwt = new TextBox();
            label3 = new Label();
            avgta = new TextBox();
            label4 = new Label();
            label5 = new Label();
            button2 = new Button();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            button11 = new Button();
            button4 = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(210, 234, 253);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(43, 155, 244);
            dataGridViewCellStyle1.SelectionBackColor = Color.White;
            dataGridViewCellStyle1.SelectionForeColor = Color.Blue;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5, Column6 });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(43, 155, 244);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = Color.FromArgb(231, 229, 255);
            dataGridView1.Location = new Point(17, 218);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(530, 218);
            dataGridView1.TabIndex = 1;
            // 
            // Column1
            // 
            Column1.FillWeight = 50F;
            Column1.HeaderText = "PID";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Column2
            // 
            Column2.FillWeight = 70F;
            Column2.HeaderText = "Arrival";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.FillWeight = 47.9826279F;
            Column3.HeaderText = "Burst";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.HeaderText = "Complete";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            // 
            // Column5
            // 
            Column5.HeaderText = "Turnaround";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            // 
            // Column6
            // 
            Column6.FillWeight = 64.32266F;
            Column6.HeaderText = "Waiting";
            Column6.MinimumWidth = 6;
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(43, 155, 244);
            label1.Location = new Point(17, 171);
            label1.Name = "label1";
            label1.Size = new Size(212, 28);
            label1.TabIndex = 2;
            label1.Text = "Number of processes";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            numericUpDown1.ForeColor = Color.Black;
            numericUpDown1.Location = new Point(259, 171);
            numericUpDown1.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(144, 34);
            numericUpDown1.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(43, 155, 244);
            label2.Location = new Point(17, 524);
            label2.Name = "label2";
            label2.Size = new Size(216, 28);
            label2.TabIndex = 15;
            label2.Text = "Average waiting time";
            // 
            // avgwt
            // 
            avgwt.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            avgwt.ForeColor = Color.Black;
            avgwt.Location = new Point(275, 516);
            avgwt.Margin = new Padding(3, 4, 3, 4);
            avgwt.Name = "avgwt";
            avgwt.ReadOnly = true;
            avgwt.Size = new Size(128, 34);
            avgwt.TabIndex = 16;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.FromArgb(43, 155, 244);
            label3.Location = new Point(17, 475);
            label3.Name = "label3";
            label3.Size = new Size(252, 28);
            label3.TabIndex = 17;
            label3.Text = "Average turnaround time";
            // 
            // avgta
            // 
            avgta.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            avgta.ForeColor = Color.Black;
            avgta.Location = new Point(275, 469);
            avgta.Margin = new Padding(3, 4, 3, 4);
            avgta.Name = "avgta";
            avgta.ReadOnly = true;
            avgta.Size = new Size(128, 34);
            avgta.TabIndex = 18;
            // 
            // label4
            // 
            label4.BackColor = Color.FromArgb(210, 234, 253);
            label4.Dock = DockStyle.Top;
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Size = new Size(568, 64);
            label4.TabIndex = 24;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.FromArgb(210, 234, 253);
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.FromArgb(43, 155, 244);
            label5.Location = new Point(177, 18);
            label5.Name = "label5";
            label5.Size = new Size(189, 32);
            label5.TabIndex = 25;
            label5.Text = "FCFS Algorithm";
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(210, 234, 253);
            button2.BackgroundImage = Properties.Resources.icons8_delete_50;
            button2.BackgroundImageLayout = ImageLayout.Stretch;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = Color.Transparent;
            button2.Location = new Point(525, 18);
            button2.Name = "button2";
            button2.Size = new Size(31, 29);
            button2.TabIndex = 60;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button8
            // 
            button8.BackColor = Color.White;
            button8.BackgroundImageLayout = ImageLayout.Stretch;
            button8.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            button8.ForeColor = Color.FromArgb(43, 155, 244);
            button8.Location = new Point(444, 91);
            button8.Name = "button8";
            button8.Size = new Size(103, 51);
            button8.TabIndex = 66;
            button8.Text = "SRTN";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.BackColor = Color.White;
            button9.BackgroundImageLayout = ImageLayout.Stretch;
            button9.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            button9.ForeColor = Color.FromArgb(43, 155, 244);
            button9.Location = new Point(308, 91);
            button9.Name = "button9";
            button9.Size = new Size(103, 51);
            button9.TabIndex = 65;
            button9.Text = "SJF";
            button9.UseVisualStyleBackColor = false;
            button9.Click += button9_Click;
            // 
            // button10
            // 
            button10.BackColor = Color.White;
            button10.BackgroundImageLayout = ImageLayout.Stretch;
            button10.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            button10.ForeColor = Color.FromArgb(43, 155, 244);
            button10.Location = new Point(165, 91);
            button10.Name = "button10";
            button10.Size = new Size(103, 51);
            button10.TabIndex = 64;
            button10.Text = "RR";
            button10.UseVisualStyleBackColor = false;
            button10.Click += button10_Click;
            // 
            // button11
            // 
            button11.BackColor = Color.White;
            button11.BackgroundImageLayout = ImageLayout.Stretch;
            button11.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            button11.ForeColor = Color.FromArgb(43, 155, 244);
            button11.Location = new Point(17, 91);
            button11.Name = "button11";
            button11.Size = new Size(103, 51);
            button11.TabIndex = 63;
            button11.Text = "FCFS";
            button11.UseVisualStyleBackColor = false;
            button11.Click += button11_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.White;
            button4.BackgroundImageLayout = ImageLayout.Stretch;
            button4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button4.ForeColor = Color.FromArgb(43, 155, 244);
            button4.Location = new Point(444, 167);
            button4.Name = "button4";
            button4.Size = new Size(101, 37);
            button4.TabIndex = 67;
            button4.Text = "Create";
            button4.UseVisualStyleBackColor = false;
            button4.Click += Create_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.FromArgb(43, 155, 244);
            button1.Location = new Point(428, 466);
            button1.Name = "button1";
            button1.Size = new Size(119, 84);
            button1.TabIndex = 68;
            button1.Text = "Calculate";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button3_Click;
            // 
            // fcfs
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.White;
            CancelButton = button2;
            ClientSize = new Size(568, 573);
            Controls.Add(button1);
            Controls.Add(button4);
            Controls.Add(button8);
            Controls.Add(button9);
            Controls.Add(button10);
            Controls.Add(button11);
            Controls.Add(button2);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(avgta);
            Controls.Add(label3);
            Controls.Add(avgwt);
            Controls.Add(label2);
            Controls.Add(numericUpDown1);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Name = "fcfs";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "fcfs";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridView1;
        private Label label1;
        private NumericUpDown numericUpDown1;
        private Label label2;
        private TextBox avgwt;
        private Label label3;
        private TextBox avgta;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private Label label4;
        private Label label5;
        private Button button2;
        private Button button8;
        private Button button9;
        private Button button10;
        private Button button11;
        private Button button4;
        private Button button1;
    }
}