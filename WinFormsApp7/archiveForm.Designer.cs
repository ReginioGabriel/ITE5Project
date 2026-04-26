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
            btnRetrieve = new Button();
            btnDelete = new Button();
            btnSelectAll = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            label2 = new Label();
            txtSearch = new TextBox();
            _searchTimer = new System.Windows.Forms.Timer(components);
            MenuBar = new ToolStrip();
            MenuCollection = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            MenuArchive = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            MenuLogout = new ToolStripButton();
            toolStripLabel1 = new ToolStripLabel();
            toolStripLabel2 = new ToolStripLabel();
            btnReturn = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            MenuBar.SuspendLayout();
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
            dataGridView1.Location = new Point(34, 143);
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
            label1.Location = new Point(55, 72);
            label1.Name = "label1";
            label1.Size = new Size(222, 39);
            label1.TabIndex = 1;
            label1.Text = "Archives";
            // 
            // btnRetrieve
            // 
            btnRetrieve.BackColor = Color.FromArgb(26, 30, 50);
            btnRetrieve.FlatAppearance.BorderSize = 0;
            btnRetrieve.FlatStyle = FlatStyle.Popup;
            btnRetrieve.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnRetrieve.ForeColor = SystemColors.ControlLight;
            btnRetrieve.Location = new Point(287, 525);
            btnRetrieve.Name = "btnRetrieve";
            btnRetrieve.Size = new Size(153, 44);
            btnRetrieve.TabIndex = 2;
            btnRetrieve.Text = "Retrieve";
            btnRetrieve.UseVisualStyleBackColor = false;
            btnRetrieve.Click += btnRetrieve_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(26, 30, 50);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Popup;
            btnDelete.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnDelete.ForeColor = SystemColors.ControlLight;
            btnDelete.Location = new Point(627, 525);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(153, 44);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSelectAll
            // 
            btnSelectAll.BackColor = Color.FromArgb(26, 30, 50);
            btnSelectAll.FlatAppearance.BorderSize = 0;
            btnSelectAll.FlatStyle = FlatStyle.Popup;
            btnSelectAll.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnSelectAll.ForeColor = SystemColors.ControlLight;
            btnSelectAll.Location = new Point(457, 525);
            btnSelectAll.Name = "btnSelectAll";
            btnSelectAll.Size = new Size(153, 44);
            btnSelectAll.TabIndex = 6;
            btnSelectAll.Text = "Select All";
            btnSelectAll.UseVisualStyleBackColor = false;
            btnSelectAll.Click += btnSelectAll_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo;
            pictureBox1.Location = new Point(12, 59);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(37, 31);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(12, 96);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(37, 41);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 8;
            pictureBox2.TabStop = false;
            // 
            // label2
            // 
            label2.ForeColor = SystemColors.GrayText;
            label2.Location = new Point(55, 113);
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
            txtSearch.Location = new Point(624, 103);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search tracks or artists...";
            txtSearch.Size = new Size(457, 25);
            txtSearch.TabIndex = 10;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // MenuBar
            // 
            MenuBar.BackColor = Color.Transparent;
            MenuBar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MenuBar.Items.AddRange(new ToolStripItem[] { MenuCollection, toolStripSeparator4, MenuArchive, toolStripSeparator2, MenuLogout, toolStripLabel1, toolStripLabel2 });
            MenuBar.Location = new Point(0, 0);
            MenuBar.Margin = new Padding(10);
            MenuBar.Name = "MenuBar";
            MenuBar.Padding = new Padding(20, 5, 10, 5);
            MenuBar.Size = new Size(1151, 45);
            MenuBar.TabIndex = 11;
            MenuBar.Text = "toolStrip1";
            // 
            // MenuCollection
            // 
            MenuCollection.BackColor = Color.ForestGreen;
            MenuCollection.DisplayStyle = ToolStripItemDisplayStyle.Text;
            MenuCollection.ForeColor = SystemColors.ActiveCaptionText;
            MenuCollection.ImageScaling = ToolStripItemImageScaling.None;
            MenuCollection.ImageTransparentColor = Color.Magenta;
            MenuCollection.Name = "MenuCollection";
            MenuCollection.Padding = new Padding(50, 0, 0, 0);
            MenuCollection.Size = new Size(133, 32);
            MenuCollection.Text = "Collection";
            MenuCollection.Click += MenuCollection_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Margin = new Padding(10, 5, 10, 5);
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 25);
            // 
            // MenuArchive
            // 
            MenuArchive.BackColor = Color.Yellow;
            MenuArchive.DisplayStyle = ToolStripItemDisplayStyle.Text;
            MenuArchive.ForeColor = SystemColors.ActiveCaptionText;
            MenuArchive.ImageScaling = ToolStripItemImageScaling.None;
            MenuArchive.ImageTransparentColor = Color.Magenta;
            MenuArchive.Name = "MenuArchive";
            MenuArchive.Padding = new Padding(50, 0, 0, 0);
            MenuArchive.Size = new Size(116, 32);
            MenuArchive.Text = "Archive";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.AutoSize = false;
            toolStripSeparator2.Margin = new Padding(10, 5, 10, 5);
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Padding = new Padding(50, 0, 0, 0);
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // MenuLogout
            // 
            MenuLogout.BackColor = Color.Red;
            MenuLogout.DisplayStyle = ToolStripItemDisplayStyle.Text;
            MenuLogout.ForeColor = SystemColors.ActiveCaptionText;
            MenuLogout.ImageScaling = ToolStripItemImageScaling.None;
            MenuLogout.ImageTransparentColor = Color.Magenta;
            MenuLogout.Name = "MenuLogout";
            MenuLogout.Padding = new Padding(50, 0, 0, 0);
            MenuLogout.Size = new Size(113, 32);
            MenuLogout.Text = "Logout";
            MenuLogout.Click += MenuLogout_Click;
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Alignment = ToolStripItemAlignment.Right;
            toolStripLabel1.AutoSize = false;
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(200, 22);
            toolStripLabel1.Text = "toolStripLabel1";
            toolStripLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Alignment = ToolStripItemAlignment.Right;
            toolStripLabel2.AutoSize = false;
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new Size(200, 22);
            toolStripLabel2.Text = "toolStripLabel2";
            toolStripLabel2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnReturn
            // 
            btnReturn.BackColor = Color.FromArgb(26, 30, 50);
            btnReturn.FlatAppearance.BorderSize = 0;
            btnReturn.FlatStyle = FlatStyle.Popup;
            btnReturn.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnReturn.ForeColor = SystemColors.ControlLight;
            btnReturn.Location = new Point(457, 609);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(153, 44);
            btnReturn.TabIndex = 12;
            btnReturn.Text = "Return";
            btnReturn.UseVisualStyleBackColor = false;
            btnReturn.Click += btnReturn_Click;
            // 
            // archiveForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 27, 50);
            ClientSize = new Size(1151, 689);
            Controls.Add(btnReturn);
            Controls.Add(MenuBar);
            Controls.Add(txtSearch);
            Controls.Add(label2);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(btnSelectAll);
            Controls.Add(btnDelete);
            Controls.Add(btnRetrieve);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "archiveForm";
            StartPosition = FormStartPosition.CenterScreen;
            FormClosed += archiveForm_FormClosed;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            MenuBar.ResumeLayout(false);
            MenuBar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private Button btnRetrieve;
        private Button btnDelete;
        private Button btnSelectAll;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label label2;
        private TextBox txtSearch;
        private System.Windows.Forms.Timer _searchTimer;
        private ToolStrip MenuBar;
        private ToolStripButton MenuArchive;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton MenuLogout;
        private ToolStripLabel toolStripLabel1;
        private ToolStripLabel toolStripLabel2;
        private Button btnReturn;
        private ToolStripButton MenuCollection;
        private ToolStripSeparator toolStripSeparator4;
    }
}