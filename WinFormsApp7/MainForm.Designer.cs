namespace WinFormsApp7
{
    partial class MainForm
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
            pictureBox1 = new PictureBox();
            dataGridView1 = new DataGridView();
            editBtn = new Button();
            createBtn = new Button();
            songIDTxt = new TextBox();
            songNameTxt = new TextBox();
            artistNameTxt = new TextBox();
            albumNameTxt = new TextBox();
            genreTxt = new TextBox();
            languageTxt = new TextBox();
            openFileDialog1 = new OpenFileDialog();
            filepathBtn = new Button();
            userID_Txt = new TextBox();
            playPauseBtn = new Button();
            archiveBtn = new Button();
            TestConn = new Button();
            groupBox1 = new GroupBox();
            releaseDatePicker = new DateTimePicker();
            filepathTxt = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.asteroid;
            pictureBox1.Location = new Point(722, 366);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(528, 384);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 20);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(591, 373);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentDoubleClick += dataGridView1_CellContentDoubleClick;
            dataGridView1.DoubleClick += dataGridView1_DoubleClick;
            // 
            // editBtn
            // 
            editBtn.Location = new Point(157, 399);
            editBtn.Name = "editBtn";
            editBtn.Size = new Size(75, 23);
            editBtn.TabIndex = 3;
            editBtn.Text = "Edit";
            editBtn.UseVisualStyleBackColor = true;
            editBtn.Click += editBtn_Click;
            // 
            // createBtn
            // 
            createBtn.Location = new Point(259, 399);
            createBtn.Name = "createBtn";
            createBtn.Size = new Size(75, 23);
            createBtn.TabIndex = 4;
            createBtn.Text = "Create";
            createBtn.UseVisualStyleBackColor = true;
            createBtn.Click += createBtn_Click;
            // 
            // songIDTxt
            // 
            songIDTxt.Location = new Point(59, 34);
            songIDTxt.Name = "songIDTxt";
            songIDTxt.ReadOnly = true;
            songIDTxt.Size = new Size(196, 23);
            songIDTxt.TabIndex = 5;
            // 
            // songNameTxt
            // 
            songNameTxt.Location = new Point(59, 63);
            songNameTxt.Name = "songNameTxt";
            songNameTxt.Size = new Size(196, 23);
            songNameTxt.TabIndex = 6;
            // 
            // artistNameTxt
            // 
            artistNameTxt.Location = new Point(59, 92);
            artistNameTxt.Name = "artistNameTxt";
            artistNameTxt.Size = new Size(196, 23);
            artistNameTxt.TabIndex = 7;
            // 
            // albumNameTxt
            // 
            albumNameTxt.Location = new Point(59, 121);
            albumNameTxt.Name = "albumNameTxt";
            albumNameTxt.Size = new Size(196, 23);
            albumNameTxt.TabIndex = 10;
            // 
            // genreTxt
            // 
            genreTxt.Location = new Point(59, 150);
            genreTxt.Name = "genreTxt";
            genreTxt.Size = new Size(196, 23);
            genreTxt.TabIndex = 9;
            // 
            // languageTxt
            // 
            languageTxt.Location = new Point(59, 208);
            languageTxt.Name = "languageTxt";
            languageTxt.Size = new Size(196, 23);
            languageTxt.TabIndex = 13;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // filepathBtn
            // 
            filepathBtn.Location = new Point(12, 399);
            filepathBtn.Name = "filepathBtn";
            filepathBtn.Size = new Size(140, 23);
            filepathBtn.TabIndex = 14;
            filepathBtn.Text = "Edit Filepath";
            filepathBtn.UseVisualStyleBackColor = true;
            filepathBtn.Click += button4_Click;
            // 
            // userID_Txt
            // 
            userID_Txt.Location = new Point(59, 237);
            userID_Txt.Name = "userID_Txt";
            userID_Txt.ReadOnly = true;
            userID_Txt.Size = new Size(196, 23);
            userID_Txt.TabIndex = 15;
            userID_Txt.TextChanged += textBox8_TextChanged;
            // 
            // playPauseBtn
            // 
            playPauseBtn.Location = new Point(259, 428);
            playPauseBtn.Name = "playPauseBtn";
            playPauseBtn.Size = new Size(75, 23);
            playPauseBtn.TabIndex = 19;
            playPauseBtn.Text = "Play/Pause";
            playPauseBtn.UseVisualStyleBackColor = true;
            playPauseBtn.Click += button5_Click;
            // 
            // archiveBtn
            // 
            archiveBtn.Location = new Point(363, 399);
            archiveBtn.Name = "archiveBtn";
            archiveBtn.Size = new Size(75, 23);
            archiveBtn.TabIndex = 20;
            archiveBtn.Text = "Archive";
            archiveBtn.UseVisualStyleBackColor = true;
            archiveBtn.Click += button6_Click;
            // 
            // TestConn
            // 
            TestConn.Location = new Point(461, 399);
            TestConn.Name = "TestConn";
            TestConn.Size = new Size(141, 23);
            TestConn.TabIndex = 21;
            TestConn.Text = "Test Connection";
            TestConn.UseVisualStyleBackColor = true;
            TestConn.Click += button7_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(releaseDatePicker);
            groupBox1.Controls.Add(filepathTxt);
            groupBox1.Controls.Add(songIDTxt);
            groupBox1.Controls.Add(artistNameTxt);
            groupBox1.Controls.Add(songNameTxt);
            groupBox1.Controls.Add(genreTxt);
            groupBox1.Controls.Add(albumNameTxt);
            groupBox1.Controls.Add(userID_Txt);
            groupBox1.Controls.Add(languageTxt);
            groupBox1.Location = new Point(633, 9);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(295, 367);
            groupBox1.TabIndex = 22;
            groupBox1.TabStop = false;
            // 
            // releaseDatePicker
            // 
            releaseDatePicker.Location = new Point(59, 179);
            releaseDatePicker.Name = "releaseDatePicker";
            releaseDatePicker.Size = new Size(196, 23);
            releaseDatePicker.TabIndex = 23;
            // 
            // filepathTxt
            // 
            filepathTxt.Location = new Point(59, 266);
            filepathTxt.Name = "filepathTxt";
            filepathTxt.ReadOnly = true;
            filepathTxt.Size = new Size(196, 23);
            filepathTxt.TabIndex = 16;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1262, 749);
            Controls.Add(groupBox1);
            Controls.Add(TestConn);
            Controls.Add(archiveBtn);
            Controls.Add(playPauseBtn);
            Controls.Add(filepathBtn);
            Controls.Add(createBtn);
            Controls.Add(editBtn);
            Controls.Add(dataGridView1);
            Controls.Add(pictureBox1);
            Name = "MainForm";
            Text = "Form1";
            FormClosed += MainForm_FormClosed;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private DataGridView dataGridView1;
        private Button editBtn;
        private Button createBtn;
        private TextBox songIDTxt;
        private TextBox songNameTxt;
        private TextBox artistNameTxt;
        private TextBox albumNameTxt;
        private TextBox genreTxt;
        private TextBox releaseDateTxt;
        private TextBox languageTxt;
        private OpenFileDialog openFileDialog1;
        private Button filepathBtn;
        private TextBox userID_Txt;
        private Button playPauseBtn;
        private Button archiveBtn;
        private Button TestConn;
        private GroupBox groupBox1;
        private TextBox filepathTxt;
        private DateTimePicker releaseDatePicker;
    }
}
