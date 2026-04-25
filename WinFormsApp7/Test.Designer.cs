namespace WinFormsApp7
{
    partial class btnTestConnection
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelTop = new Panel();
            label1 = new Label();
            lblLogo = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnAddTrack = new Button();
            panelLeft = new Panel();
            panelRight = new Panel();
            txtReleaseDate = new TextBox();
            txtGenre = new TextBox();
            txtAlbum = new TextBox();
            txtArtist = new TextBox();
            lblDuration = new Label();
            btnEdit = new Button();
            btnRemove = new Button();
            lblNowPlaying = new Label();
            picNowPlaying = new PictureBox();
            lblTrack = new Label();
            lblArtist = new Label();
            lblAlbum = new Label();
            lblGenre = new Label();
            lblReleaseDate = new Label();
            trackBar = new TrackBar();
            btnPrev = new Button();
            btnPauseMain = new Button();
            btnNext = new Button();
            panelCrud = new Panel();
            lblCrudTitle = new Label();
            lblCrudTrackName = new Label();
            txtCrudTrackName = new TextBox();
            lblCrudArtist = new Label();
            txtCrudArtist = new TextBox();
            lblCrudDuration = new Label();
            txtCrudDuration = new TextBox();
            lblCrudAlbum = new Label();
            txtCrudAlbum = new TextBox();
            lblCrudGenre = new Label();
            txtCrudGenre = new TextBox();
            lblCrudBpm = new Label();
            txtCrudBpm = new TextBox();
            lblCrudFormat = new Label();
            txtCrudFormat = new TextBox();
            lblCrudDate = new Label();
            txtCrudDate = new TextBox();
            btnCrudSave = new Button();
            btnCrudCancel = new Button();
            btnSave = new Button();
            panelTop.SuspendLayout();
            panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picNowPlaying).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar).BeginInit();
            panelCrud.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(26, 27, 50);
            panelTop.Controls.Add(label1);
            panelTop.Controls.Add(lblLogo);
            panelTop.Controls.Add(txtSearch);
            panelTop.Controls.Add(btnSearch);
            panelTop.Controls.Add(btnAddTrack);
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1160, 55);
            panelTop.TabIndex = 0;
            // 
            // label1
            // 
            label1.BackColor = Color.DimGray;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(1013, 14);
            label1.Name = "label1";
            label1.Size = new Size(133, 25);
            label1.TabIndex = 20;
            label1.Text = "Test Connection";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // lblLogo
            // 
            lblLogo.AutoSize = true;
            lblLogo.BackColor = Color.Transparent;
            lblLogo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblLogo.ForeColor = Color.White;
            lblLogo.Location = new Point(30, 10);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(121, 32);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "SpotiPlay";
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.FromArgb(50, 53, 90);
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.ForeColor = Color.FromArgb(120, 125, 170);
            txtSearch.Location = new Point(260, 14);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(380, 25);
            txtSearch.TabIndex = 1;
            txtSearch.Text = "Search tracks or artists...";
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(100, 100, 160);
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(648, 14);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(80, 26);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // btnAddTrack
            // 
            btnAddTrack.BackColor = Color.FromArgb(80, 200, 120);
            btnAddTrack.FlatAppearance.BorderSize = 0;
            btnAddTrack.FlatStyle = FlatStyle.Flat;
            btnAddTrack.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAddTrack.ForeColor = Color.White;
            btnAddTrack.Location = new Point(745, 12);
            btnAddTrack.Name = "btnAddTrack";
            btnAddTrack.Size = new Size(110, 30);
            btnAddTrack.TabIndex = 3;
            btnAddTrack.Text = "+ Add Track";
            btnAddTrack.UseVisualStyleBackColor = false;
            btnAddTrack.Click += btnAddTrack_Click;
            // 
            // panelLeft
            // 
            panelLeft.AutoScroll = true;
            panelLeft.BackColor = Color.FromArgb(40, 42, 74);
            panelLeft.Location = new Point(30, 65);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(784, 600);
            panelLeft.TabIndex = 1;
            panelLeft.Paint += panelLeft_Paint;
            // 
            // panelRight
            // 
            panelRight.BackColor = Color.FromArgb(40, 42, 74);
            panelRight.Controls.Add(btnSave);
            panelRight.Controls.Add(txtReleaseDate);
            panelRight.Controls.Add(txtGenre);
            panelRight.Controls.Add(txtAlbum);
            panelRight.Controls.Add(txtArtist);
            panelRight.Controls.Add(lblDuration);
            panelRight.Controls.Add(btnEdit);
            panelRight.Controls.Add(btnRemove);
            panelRight.Controls.Add(lblNowPlaying);
            panelRight.Controls.Add(picNowPlaying);
            panelRight.Controls.Add(lblTrack);
            panelRight.Controls.Add(lblArtist);
            panelRight.Controls.Add(lblAlbum);
            panelRight.Controls.Add(lblGenre);
            panelRight.Controls.Add(lblReleaseDate);
            panelRight.Controls.Add(trackBar);
            panelRight.Controls.Add(btnPrev);
            panelRight.Controls.Add(btnPauseMain);
            panelRight.Controls.Add(btnNext);
            panelRight.Location = new Point(839, 65);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(291, 600);
            panelRight.TabIndex = 2;
            // 
            // txtReleaseDate
            // 
            txtReleaseDate.BackColor = Color.FromArgb(40, 42, 74);
            txtReleaseDate.BorderStyle = BorderStyle.None;
            txtReleaseDate.Enabled = false;
            txtReleaseDate.ForeColor = Color.LightGray;
            txtReleaseDate.Location = new Point(168, 352);
            txtReleaseDate.Name = "txtReleaseDate";
            txtReleaseDate.Size = new Size(100, 16);
            txtReleaseDate.TabIndex = 27;
            txtReleaseDate.TextAlign = HorizontalAlignment.Right;
            // 
            // txtGenre
            // 
            txtGenre.BackColor = Color.FromArgb(40, 42, 74);
            txtGenre.BorderStyle = BorderStyle.None;
            txtGenre.Enabled = false;
            txtGenre.ForeColor = Color.LightGray;
            txtGenre.Location = new Point(166, 330);
            txtGenre.Name = "txtGenre";
            txtGenre.Size = new Size(100, 16);
            txtGenre.TabIndex = 26;
            txtGenre.TextAlign = HorizontalAlignment.Right;
            // 
            // txtAlbum
            // 
            txtAlbum.BackColor = Color.FromArgb(40, 42, 74);
            txtAlbum.BorderStyle = BorderStyle.None;
            txtAlbum.Enabled = false;
            txtAlbum.ForeColor = Color.LightGray;
            txtAlbum.Location = new Point(168, 301);
            txtAlbum.Name = "txtAlbum";
            txtAlbum.Size = new Size(100, 16);
            txtAlbum.TabIndex = 25;
            txtAlbum.TextAlign = HorizontalAlignment.Right;
            // 
            // txtArtist
            // 
            txtArtist.BackColor = Color.FromArgb(40, 42, 74);
            txtArtist.BorderStyle = BorderStyle.None;
            txtArtist.Enabled = false;
            txtArtist.ForeColor = Color.LightGray;
            txtArtist.Location = new Point(166, 279);
            txtArtist.Name = "txtArtist";
            txtArtist.Size = new Size(100, 16);
            txtArtist.TabIndex = 24;
            txtArtist.TextAlign = HorizontalAlignment.Right;
            // 
            // lblDuration
            // 
            lblDuration.BackColor = Color.Transparent;
            lblDuration.Font = new Font("Segoe UI", 8F);
            lblDuration.ForeColor = Color.FromArgb(160, 165, 210);
            lblDuration.Location = new Point(143, 406);
            lblDuration.Name = "lblDuration";
            lblDuration.Size = new Size(118, 18);
            lblDuration.TabIndex = 23;
            lblDuration.Text = "4: 01";
            lblDuration.TextAlign = ContentAlignment.TopRight;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(80, 200, 120);
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(26, 516);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(92, 33);
            btnEdit.TabIndex = 22;
            btnEdit.Text = "🖉 Edit";
            btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnRemove
            // 
            btnRemove.BackColor = Color.Red;
            btnRemove.FlatAppearance.BorderSize = 0;
            btnRemove.FlatStyle = FlatStyle.Flat;
            btnRemove.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRemove.ForeColor = Color.White;
            btnRemove.Location = new Point(166, 516);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(92, 33);
            btnRemove.TabIndex = 21;
            btnRemove.Text = "🗑 Remove";
            btnRemove.UseVisualStyleBackColor = false;
            // 
            // lblNowPlaying
            // 
            lblNowPlaying.BackColor = Color.White;
            lblNowPlaying.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNowPlaying.ForeColor = Color.FromArgb(26, 27, 50);
            lblNowPlaying.Location = new Point(15, 22);
            lblNowPlaying.Name = "lblNowPlaying";
            lblNowPlaying.Size = new Size(253, 32);
            lblNowPlaying.TabIndex = 0;
            lblNowPlaying.Text = "NOW PLAYING";
            lblNowPlaying.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picNowPlaying
            // 
            picNowPlaying.BackColor = Color.FromArgb(70, 73, 110);
            picNowPlaying.Location = new Point(15, 72);
            picNowPlaying.Name = "picNowPlaying";
            picNowPlaying.Size = new Size(253, 160);
            picNowPlaying.SizeMode = PictureBoxSizeMode.StretchImage;
            picNowPlaying.TabIndex = 1;
            picNowPlaying.TabStop = false;
            // 
            // lblTrack
            // 
            lblTrack.BackColor = Color.Transparent;
            lblTrack.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTrack.ForeColor = Color.White;
            lblTrack.Location = new Point(15, 244);
            lblTrack.Name = "lblTrack";
            lblTrack.Size = new Size(253, 28);
            lblTrack.TabIndex = 2;
            lblTrack.Text = "Song";
            // 
            // lblArtist
            // 
            lblArtist.BackColor = Color.Transparent;
            lblArtist.Font = new Font("Segoe UI", 8F);
            lblArtist.ForeColor = Color.FromArgb(160, 165, 210);
            lblArtist.Location = new Point(15, 284);
            lblArtist.Name = "lblArtist";
            lblArtist.Size = new Size(118, 18);
            lblArtist.TabIndex = 4;
            lblArtist.Text = "🎨 Artist";
            // 
            // lblAlbum
            // 
            lblAlbum.BackColor = Color.Transparent;
            lblAlbum.Font = new Font("Segoe UI", 8F);
            lblAlbum.ForeColor = Color.FromArgb(160, 165, 210);
            lblAlbum.Location = new Point(15, 306);
            lblAlbum.Name = "lblAlbum";
            lblAlbum.Size = new Size(118, 18);
            lblAlbum.TabIndex = 6;
            lblAlbum.Text = "🎵 Album";
            // 
            // lblGenre
            // 
            lblGenre.BackColor = Color.Transparent;
            lblGenre.Font = new Font("Segoe UI", 8F);
            lblGenre.ForeColor = Color.FromArgb(160, 165, 210);
            lblGenre.Location = new Point(15, 328);
            lblGenre.Name = "lblGenre";
            lblGenre.Size = new Size(118, 18);
            lblGenre.TabIndex = 8;
            lblGenre.Text = "🎸 Genre";
            // 
            // lblReleaseDate
            // 
            lblReleaseDate.BackColor = Color.Transparent;
            lblReleaseDate.Font = new Font("Segoe UI", 8F);
            lblReleaseDate.ForeColor = Color.FromArgb(160, 165, 210);
            lblReleaseDate.Location = new Point(15, 350);
            lblReleaseDate.Name = "lblReleaseDate";
            lblReleaseDate.Size = new Size(118, 18);
            lblReleaseDate.TabIndex = 10;
            lblReleaseDate.Text = "📅 Release Date";
            // 
            // trackBar
            // 
            trackBar.BackColor = Color.FromArgb(40, 42, 74);
            trackBar.Location = new Point(15, 381);
            trackBar.Maximum = 265;
            trackBar.Name = "trackBar";
            trackBar.Size = new Size(253, 45);
            trackBar.TabIndex = 14;
            trackBar.TickStyle = TickStyle.None;
            trackBar.Value = 133;
            // 
            // btnPrev
            // 
            btnPrev.BackColor = Color.Transparent;
            btnPrev.FlatAppearance.BorderSize = 0;
            btnPrev.FlatStyle = FlatStyle.Flat;
            btnPrev.Font = new Font("Segoe UI", 13F);
            btnPrev.ForeColor = Color.White;
            btnPrev.Location = new Point(74, 432);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(44, 44);
            btnPrev.TabIndex = 17;
            btnPrev.Text = "❮";
            btnPrev.UseVisualStyleBackColor = false;
            // 
            // btnPauseMain
            // 
            btnPauseMain.BackColor = Color.Transparent;
            btnPauseMain.FlatAppearance.BorderSize = 0;
            btnPauseMain.FlatStyle = FlatStyle.Flat;
            btnPauseMain.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPauseMain.ForeColor = Color.White;
            btnPauseMain.Location = new Point(103, 409);
            btnPauseMain.Name = "btnPauseMain";
            btnPauseMain.Size = new Size(80, 80);
            btnPauseMain.TabIndex = 18;
            btnPauseMain.Text = " ⏸";
            btnPauseMain.UseVisualStyleBackColor = false;
            // 
            // btnNext
            // 
            btnNext.BackColor = Color.Transparent;
            btnNext.FlatAppearance.BorderSize = 0;
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.Font = new Font("Segoe UI", 13F);
            btnNext.ForeColor = Color.White;
            btnNext.Location = new Point(174, 432);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(44, 44);
            btnNext.TabIndex = 19;
            btnNext.Text = "❯";
            btnNext.UseVisualStyleBackColor = false;
            // 
            // panelCrud
            // 
            panelCrud.BackColor = Color.FromArgb(33, 35, 62);
            panelCrud.BorderStyle = BorderStyle.FixedSingle;
            panelCrud.Controls.Add(lblCrudTitle);
            panelCrud.Controls.Add(lblCrudTrackName);
            panelCrud.Controls.Add(txtCrudTrackName);
            panelCrud.Controls.Add(lblCrudArtist);
            panelCrud.Controls.Add(txtCrudArtist);
            panelCrud.Controls.Add(lblCrudDuration);
            panelCrud.Controls.Add(txtCrudDuration);
            panelCrud.Controls.Add(lblCrudAlbum);
            panelCrud.Controls.Add(txtCrudAlbum);
            panelCrud.Controls.Add(lblCrudGenre);
            panelCrud.Controls.Add(txtCrudGenre);
            panelCrud.Controls.Add(lblCrudBpm);
            panelCrud.Controls.Add(txtCrudBpm);
            panelCrud.Controls.Add(lblCrudFormat);
            panelCrud.Controls.Add(txtCrudFormat);
            panelCrud.Controls.Add(lblCrudDate);
            panelCrud.Controls.Add(txtCrudDate);
            panelCrud.Controls.Add(btnCrudSave);
            panelCrud.Controls.Add(btnCrudCancel);
            panelCrud.Location = new Point(180, 120);
            panelCrud.Name = "panelCrud";
            panelCrud.Size = new Size(500, 480);
            panelCrud.TabIndex = 3;
            panelCrud.Visible = false;
            // 
            // lblCrudTitle
            // 
            lblCrudTitle.BackColor = Color.Transparent;
            lblCrudTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblCrudTitle.ForeColor = Color.White;
            lblCrudTitle.Location = new Point(20, 16);
            lblCrudTitle.Name = "lblCrudTitle";
            lblCrudTitle.Size = new Size(460, 30);
            lblCrudTitle.TabIndex = 0;
            lblCrudTitle.Text = "Add New Track";
            // 
            // lblCrudTrackName
            // 
            lblCrudTrackName.BackColor = Color.Transparent;
            lblCrudTrackName.Font = new Font("Segoe UI", 9F);
            lblCrudTrackName.ForeColor = Color.FromArgb(160, 165, 210);
            lblCrudTrackName.Location = new Point(20, 60);
            lblCrudTrackName.Name = "lblCrudTrackName";
            lblCrudTrackName.Size = new Size(120, 20);
            lblCrudTrackName.TabIndex = 1;
            lblCrudTrackName.Text = "Track Name";
            // 
            // txtCrudTrackName
            // 
            txtCrudTrackName.BackColor = Color.FromArgb(50, 53, 90);
            txtCrudTrackName.BorderStyle = BorderStyle.FixedSingle;
            txtCrudTrackName.Font = new Font("Segoe UI", 10F);
            txtCrudTrackName.ForeColor = Color.White;
            txtCrudTrackName.Location = new Point(20, 82);
            txtCrudTrackName.Name = "txtCrudTrackName";
            txtCrudTrackName.Size = new Size(458, 25);
            txtCrudTrackName.TabIndex = 2;
            // 
            // lblCrudArtist
            // 
            lblCrudArtist.BackColor = Color.Transparent;
            lblCrudArtist.Font = new Font("Segoe UI", 9F);
            lblCrudArtist.ForeColor = Color.FromArgb(160, 165, 210);
            lblCrudArtist.Location = new Point(20, 118);
            lblCrudArtist.Name = "lblCrudArtist";
            lblCrudArtist.Size = new Size(120, 20);
            lblCrudArtist.TabIndex = 3;
            lblCrudArtist.Text = "Artist";
            // 
            // txtCrudArtist
            // 
            txtCrudArtist.BackColor = Color.FromArgb(50, 53, 90);
            txtCrudArtist.BorderStyle = BorderStyle.FixedSingle;
            txtCrudArtist.Font = new Font("Segoe UI", 10F);
            txtCrudArtist.ForeColor = Color.White;
            txtCrudArtist.Location = new Point(20, 140);
            txtCrudArtist.Name = "txtCrudArtist";
            txtCrudArtist.Size = new Size(458, 25);
            txtCrudArtist.TabIndex = 4;
            // 
            // lblCrudDuration
            // 
            lblCrudDuration.BackColor = Color.Transparent;
            lblCrudDuration.Font = new Font("Segoe UI", 9F);
            lblCrudDuration.ForeColor = Color.FromArgb(160, 165, 210);
            lblCrudDuration.Location = new Point(20, 176);
            lblCrudDuration.Name = "lblCrudDuration";
            lblCrudDuration.Size = new Size(120, 20);
            lblCrudDuration.TabIndex = 5;
            lblCrudDuration.Text = "Duration (m:ss)";
            // 
            // txtCrudDuration
            // 
            txtCrudDuration.BackColor = Color.FromArgb(50, 53, 90);
            txtCrudDuration.BorderStyle = BorderStyle.FixedSingle;
            txtCrudDuration.Font = new Font("Segoe UI", 10F);
            txtCrudDuration.ForeColor = Color.White;
            txtCrudDuration.Location = new Point(20, 198);
            txtCrudDuration.Name = "txtCrudDuration";
            txtCrudDuration.Size = new Size(215, 25);
            txtCrudDuration.TabIndex = 6;
            // 
            // lblCrudAlbum
            // 
            lblCrudAlbum.BackColor = Color.Transparent;
            lblCrudAlbum.Font = new Font("Segoe UI", 9F);
            lblCrudAlbum.ForeColor = Color.FromArgb(160, 165, 210);
            lblCrudAlbum.Location = new Point(20, 234);
            lblCrudAlbum.Name = "lblCrudAlbum";
            lblCrudAlbum.Size = new Size(120, 20);
            lblCrudAlbum.TabIndex = 9;
            lblCrudAlbum.Text = "Album";
            // 
            // txtCrudAlbum
            // 
            txtCrudAlbum.BackColor = Color.FromArgb(50, 53, 90);
            txtCrudAlbum.BorderStyle = BorderStyle.FixedSingle;
            txtCrudAlbum.Font = new Font("Segoe UI", 10F);
            txtCrudAlbum.ForeColor = Color.White;
            txtCrudAlbum.Location = new Point(20, 256);
            txtCrudAlbum.Name = "txtCrudAlbum";
            txtCrudAlbum.Size = new Size(458, 25);
            txtCrudAlbum.TabIndex = 10;
            // 
            // lblCrudGenre
            // 
            lblCrudGenre.BackColor = Color.Transparent;
            lblCrudGenre.Font = new Font("Segoe UI", 9F);
            lblCrudGenre.ForeColor = Color.FromArgb(160, 165, 210);
            lblCrudGenre.Location = new Point(20, 292);
            lblCrudGenre.Name = "lblCrudGenre";
            lblCrudGenre.Size = new Size(80, 20);
            lblCrudGenre.TabIndex = 11;
            lblCrudGenre.Text = "Genre";
            // 
            // txtCrudGenre
            // 
            txtCrudGenre.BackColor = Color.FromArgb(50, 53, 90);
            txtCrudGenre.BorderStyle = BorderStyle.FixedSingle;
            txtCrudGenre.Font = new Font("Segoe UI", 10F);
            txtCrudGenre.ForeColor = Color.White;
            txtCrudGenre.Location = new Point(20, 314);
            txtCrudGenre.Name = "txtCrudGenre";
            txtCrudGenre.Size = new Size(215, 25);
            txtCrudGenre.TabIndex = 12;
            // 
            // lblCrudBpm
            // 
            lblCrudBpm.BackColor = Color.Transparent;
            lblCrudBpm.Font = new Font("Segoe UI", 9F);
            lblCrudBpm.ForeColor = Color.FromArgb(160, 165, 210);
            lblCrudBpm.Location = new Point(248, 176);
            lblCrudBpm.Name = "lblCrudBpm";
            lblCrudBpm.Size = new Size(80, 20);
            lblCrudBpm.TabIndex = 7;
            lblCrudBpm.Text = "BPM";
            // 
            // txtCrudBpm
            // 
            txtCrudBpm.BackColor = Color.FromArgb(50, 53, 90);
            txtCrudBpm.BorderStyle = BorderStyle.FixedSingle;
            txtCrudBpm.Font = new Font("Segoe UI", 10F);
            txtCrudBpm.ForeColor = Color.White;
            txtCrudBpm.Location = new Point(248, 198);
            txtCrudBpm.Name = "txtCrudBpm";
            txtCrudBpm.Size = new Size(230, 25);
            txtCrudBpm.TabIndex = 8;
            // 
            // lblCrudFormat
            // 
            lblCrudFormat.BackColor = Color.Transparent;
            lblCrudFormat.Font = new Font("Segoe UI", 9F);
            lblCrudFormat.ForeColor = Color.FromArgb(160, 165, 210);
            lblCrudFormat.Location = new Point(248, 292);
            lblCrudFormat.Name = "lblCrudFormat";
            lblCrudFormat.Size = new Size(80, 20);
            lblCrudFormat.TabIndex = 13;
            lblCrudFormat.Text = "Format";
            // 
            // txtCrudFormat
            // 
            txtCrudFormat.BackColor = Color.FromArgb(50, 53, 90);
            txtCrudFormat.BorderStyle = BorderStyle.FixedSingle;
            txtCrudFormat.Font = new Font("Segoe UI", 10F);
            txtCrudFormat.ForeColor = Color.White;
            txtCrudFormat.Location = new Point(248, 314);
            txtCrudFormat.Name = "txtCrudFormat";
            txtCrudFormat.Size = new Size(230, 25);
            txtCrudFormat.TabIndex = 14;
            // 
            // lblCrudDate
            // 
            lblCrudDate.BackColor = Color.Transparent;
            lblCrudDate.Font = new Font("Segoe UI", 9F);
            lblCrudDate.ForeColor = Color.FromArgb(160, 165, 210);
            lblCrudDate.Location = new Point(20, 350);
            lblCrudDate.Name = "lblCrudDate";
            lblCrudDate.Size = new Size(120, 20);
            lblCrudDate.TabIndex = 15;
            lblCrudDate.Text = "Date Created";
            // 
            // txtCrudDate
            // 
            txtCrudDate.BackColor = Color.FromArgb(50, 53, 90);
            txtCrudDate.BorderStyle = BorderStyle.FixedSingle;
            txtCrudDate.Font = new Font("Segoe UI", 10F);
            txtCrudDate.ForeColor = Color.White;
            txtCrudDate.Location = new Point(20, 372);
            txtCrudDate.Name = "txtCrudDate";
            txtCrudDate.Size = new Size(458, 25);
            txtCrudDate.TabIndex = 16;
            // 
            // btnCrudSave
            // 
            btnCrudSave.BackColor = Color.FromArgb(80, 200, 120);
            btnCrudSave.FlatAppearance.BorderSize = 0;
            btnCrudSave.FlatStyle = FlatStyle.Flat;
            btnCrudSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCrudSave.ForeColor = Color.White;
            btnCrudSave.Location = new Point(20, 420);
            btnCrudSave.Name = "btnCrudSave";
            btnCrudSave.Size = new Size(220, 36);
            btnCrudSave.TabIndex = 17;
            btnCrudSave.Text = "💾 Save";
            btnCrudSave.UseVisualStyleBackColor = false;
            // 
            // btnCrudCancel
            // 
            btnCrudCancel.BackColor = Color.FromArgb(100, 100, 120);
            btnCrudCancel.FlatAppearance.BorderSize = 0;
            btnCrudCancel.FlatStyle = FlatStyle.Flat;
            btnCrudCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCrudCancel.ForeColor = Color.White;
            btnCrudCancel.Location = new Point(258, 420);
            btnCrudCancel.Name = "btnCrudCancel";
            btnCrudCancel.Size = new Size(220, 36);
            btnCrudCancel.TabIndex = 18;
            btnCrudCancel.Text = "✕ Cancel";
            btnCrudCancel.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Gray;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(204, 244);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(64, 27);
            btnSave.TabIndex = 28;
            btnSave.Text = "💾 Save";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnTestConnection
            // 
            BackColor = Color.FromArgb(26, 27, 50);
            ClientSize = new Size(1158, 677);
            Controls.Add(panelTop);
            Controls.Add(panelLeft);
            Controls.Add(panelRight);
            Controls.Add(panelCrud);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "btnTestConnection";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SpotiPlay";
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelRight.ResumeLayout(false);
            panelRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picNowPlaying).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar).EndInit();
            panelCrud.ResumeLayout(false);
            panelCrud.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        // ── Top bar ──
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAddTrack;

        // ── Track list ──
        private System.Windows.Forms.Panel panelLeft;

        // ── Now Playing ──
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Label lblNowPlaying;
        private System.Windows.Forms.PictureBox picNowPlaying;
        private System.Windows.Forms.Label lblTrack;
        private System.Windows.Forms.Label lblArtist;
        private System.Windows.Forms.Label lblAlbum;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblReleaseDate;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnPauseMain;
        private System.Windows.Forms.Button btnNext;

        // ── CRUD overlay ──
        private System.Windows.Forms.Panel panelCrud;
        private System.Windows.Forms.Label lblCrudTitle;
        private System.Windows.Forms.Label lblCrudTrackName;
        private System.Windows.Forms.TextBox txtCrudTrackName;
        private System.Windows.Forms.Label lblCrudArtist;
        private System.Windows.Forms.TextBox txtCrudArtist;
        private System.Windows.Forms.Label lblCrudDuration;
        private System.Windows.Forms.TextBox txtCrudDuration;
        private System.Windows.Forms.Label lblCrudAlbum;
        private System.Windows.Forms.TextBox txtCrudAlbum;
        private System.Windows.Forms.Label lblCrudGenre;
        private System.Windows.Forms.TextBox txtCrudGenre;
        private System.Windows.Forms.Label lblCrudBpm;
        private System.Windows.Forms.TextBox txtCrudBpm;
        private System.Windows.Forms.Label lblCrudFormat;
        private System.Windows.Forms.TextBox txtCrudFormat;
        private System.Windows.Forms.Label lblCrudDate;
        private System.Windows.Forms.TextBox txtCrudDate;
        private System.Windows.Forms.Button btnCrudSave;
        private System.Windows.Forms.Button btnCrudCancel;
        private Label label1;
        private Button btnRemove;
        private Button btnEdit;
        private Label lblDuration;
        private TextBox txtArtist;
        private TextBox txtReleaseDate;
        private TextBox txtGenre;
        private TextBox txtAlbum;
        private Button btnSave;
    }
}