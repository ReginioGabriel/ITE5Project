namespace WinFormsApp7
{
    partial class archiveForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(archiveForm));
            dataGridView1 = new DataGridView();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            lblCount = new Label();
            button3 = new Button();
            button4 = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            label2 = new Label();
            txtSearch = new TextBox();
            _searchTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(40, 82);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1047, 360);
            dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ControlLight;
            label1.Location = new Point(55, 23);
            label1.Name = "label1";
            label1.Size = new Size(222, 39);
            label1.TabIndex = 1;
            label1.Text = "Archives";
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(26, 30, 50);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            button1.ForeColor = SystemColors.ControlLight;
            button1.Location = new Point(218, 460);
            button1.Name = "button1";
            button1.Size = new Size(153, 44);
            button1.TabIndex = 2;
            button1.Text = "Retrieve";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(26, 30, 50);
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            button2.ForeColor = SystemColors.ControlLight;
            button2.Location = new Point(558, 460);
            button2.Name = "button2";
            button2.Size = new Size(153, 44);
            button2.TabIndex = 3;
            button2.Text = "Delete";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // lblCount
            // 
            lblCount.BackColor = Color.FromArgb(26, 30, 50);
            lblCount.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            lblCount.ForeColor = SystemColors.ControlLightLight;
            lblCount.Location = new Point(848, 23);
            lblCount.Name = "lblCount";
            lblCount.Padding = new Padding(5);
            lblCount.Size = new Size(222, 56);
            lblCount.TabIndex = 4;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(26, 30, 50);
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            button3.ForeColor = SystemColors.ControlLight;
            button3.Location = new Point(731, 460);
            button3.Name = "button3";
            button3.Size = new Size(153, 44);
            button3.TabIndex = 5;
            button3.Text = "Return";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(26, 30, 50);
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Popup;
            button4.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            button4.ForeColor = SystemColors.ControlLight;
            button4.Location = new Point(388, 460);
            button4.Name = "button4";
            button4.Size = new Size(153, 44);
            button4.TabIndex = 6;
            button4.Text = "Select All";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo;
            pictureBox1.Location = new Point(12, 1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(37, 31);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(12, 35);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(37, 41);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 8;
            pictureBox2.TabStop = false;
            // 
            // label2
            // 
            label2.ForeColor = SystemColors.GrayText;
            label2.Location = new Point(55, 64);
            label2.Name = "label2";
            label2.Size = new Size(403, 15);
            label2.TabIndex = 9;
            label2.Text = " Archived songs are placed here and can be retrieved or permanently deleted";
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.FromArgb(50, 53, 90);
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.ForeColor = Color.FromArgb(120, 125, 170);
            txtSearch.Location = new Point(438, 35);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search tracks or artists...";
            txtSearch.Size = new Size(380, 25);
            txtSearch.TabIndex = 10;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // archiveForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 27, 50);
            ClientSize = new Size(1158, 677);
            Controls.Add(txtSearch);
            Controls.Add(label2);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(lblCount);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "archiveForm";
            StartPosition = FormStartPosition.CenterScreen;
            FormClosed += archiveForm_FormClosed;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private Button button1;
        private Button button2;
        private Label lblCount;
        private Button button3;
        private Button button4;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label label2;
        private TextBox txtSearch;
        private System.Windows.Forms.Timer _searchTimer;
    }
}