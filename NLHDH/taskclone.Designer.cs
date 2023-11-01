namespace NLHDH
{
    partial class taskclone
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
            lv_process = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            button2 = new Button();
            label5 = new Label();
            label4 = new Label();
            btn_reload = new Button();
            btn_kill = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // lv_process
            // 
            lv_process.BackColor = SystemColors.Window;
            lv_process.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            lv_process.ForeColor = Color.FromArgb(43, 155, 244);
            lv_process.FullRowSelect = true;
            lv_process.GridLines = true;
            lv_process.Location = new Point(14, 102);
            lv_process.MultiSelect = false;
            lv_process.Name = "lv_process";
            lv_process.Size = new Size(556, 582);
            lv_process.TabIndex = 1;
            lv_process.UseCompatibleStateImageBehavior = false;
            lv_process.View = View.Details;
            lv_process.SelectedIndexChanged += lv_process_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Process name";
            columnHeader1.Width = 250;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "PID";
            columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Physical memory usage ";
            columnHeader3.Width = 180;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(210, 234, 253);
            button2.BackgroundImage = Properties.Resources.icons8_delete_50;
            button2.BackgroundImageLayout = ImageLayout.Stretch;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = Color.Transparent;
            button2.Location = new Point(538, 12);
            button2.Name = "button2";
            button2.Size = new Size(35, 30);
            button2.TabIndex = 63;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.FromArgb(210, 234, 253);
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.FromArgb(43, 155, 244);
            label5.Location = new Point(195, 16);
            label5.Name = "label5";
            label5.Size = new Size(189, 32);
            label5.TabIndex = 62;
            label5.Text = "FCFS Algorithm";
            // 
            // label4
            // 
            label4.BackColor = Color.FromArgb(210, 234, 253);
            label4.Dock = DockStyle.Top;
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Size = new Size(582, 67);
            label4.TabIndex = 61;
            // 
            // btn_reload
            // 
            btn_reload.BackColor = Color.White;
            btn_reload.BackgroundImageLayout = ImageLayout.Stretch;
            btn_reload.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn_reload.ForeColor = Color.FromArgb(43, 155, 244);
            btn_reload.Location = new Point(312, 699);
            btn_reload.Name = "btn_reload";
            btn_reload.Size = new Size(126, 41);
            btn_reload.TabIndex = 68;
            btn_reload.Text = "Reload";
            btn_reload.UseVisualStyleBackColor = false;
            btn_reload.Click += btn_reload_Click;
            // 
            // btn_kill
            // 
            btn_kill.BackColor = Color.White;
            btn_kill.BackgroundImageLayout = ImageLayout.Stretch;
            btn_kill.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn_kill.ForeColor = Color.FromArgb(43, 155, 244);
            btn_kill.Location = new Point(444, 699);
            btn_kill.Name = "btn_kill";
            btn_kill.Size = new Size(126, 41);
            btn_kill.TabIndex = 69;
            btn_kill.Text = "End";
            btn_kill.UseVisualStyleBackColor = false;
            btn_kill.Click += btn_kill_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.FromArgb(43, 155, 244);
            button1.Location = new Point(14, 699);
            button1.Name = "button1";
            button1.Size = new Size(126, 41);
            button1.TabIndex = 70;
            button1.Text = "Back";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // taskclone
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.White;
            CancelButton = button2;
            ClientSize = new Size(582, 756);
            Controls.Add(button1);
            Controls.Add(btn_kill);
            Controls.Add(btn_reload);
            Controls.Add(button2);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(lv_process);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "taskclone";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TackClone";
            Load += Group3_Task_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListView lv_process;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private Button button2;
        private Label label5;
        private Label label4;
        private Button btn_reload;
        private Button btn_kill;
        private Button button1;
    }
}