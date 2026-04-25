using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using NAudio.Wave;
using System.Data;
using System.IO;
using System.Threading;
using System.Xml.Linq;
using TagLib;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using static WinFormsApp7.Program;

namespace WinFormsApp7
{
    public partial class btnTestConnection : Form
    {
        const string connString = "server=mysql-67-rhenzdaryl07111976-a59e.g.aivencloud.com;port=20563;database=Song_DB;uid=avnadmin;pwd=AVNS_385JfMsNN_Fh3urzWqr;SslMode=Required;";
        private SongRow _selectedSong = null;
        public btnTestConnection()
        {
            InitializeComponent();
            Session.CurrentUserId = 1;
            LoadTracks();

        }

        private class SongRow
        {
            public int SongId { get; set; }
            public string Title { get; set; }
            public string Artist { get; set; }
            public string Album { get; set; }
            public string Genre { get; set; }
            public string Duration { get; set; }
            public string FilePath { get; set; }
            public bool IsPreset { get; set; }
            public string Language { get; set; }
            public string ReleaseDate { get; set; }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnAddTrack_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Title = "Select a Song",
                Filter = "Audio Files|*.mp3;*.wav;*.flac;*.aac;*.m4a|All Files|*.*"
            };

            if (dialog.ShowDialog() != DialogResult.OK) return;

            string sourceFilePath = dialog.FileName;
            string extension = Path.GetExtension(sourceFilePath);
            string originalName = Path.GetFileNameWithoutExtension(sourceFilePath);

            // Generate unique filename to avoid collisions
            string newFileName = $"{Session.CurrentUserId}_{Guid.NewGuid()}{extension}";
            string destPath = Path.Combine(AppConfig.SongsFolder, newFileName);

            try
            {
                // 1. Ensure songs folder exists
                Directory.CreateDirectory(AppConfig.SongsFolder);

                // 2. Copy file to AppData
                System.IO.File.Copy(sourceFilePath, destPath);

                // 3. Save to database
                using var conn = new MySqlConnection(connString);
                conn.Open();

                string sql = @"
            INSERT INTO SongsTbl (user_id, title, artist, album, genre, file_path, is_preset, release_date)
            VALUES (@uid, @title, @artist, '', '', @filepath, 0, @releasedate)";

                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@uid", Session.CurrentUserId);
                cmd.Parameters.AddWithValue("@title", originalName); // use filename as default title
                cmd.Parameters.AddWithValue("@artist", "Unknown Artist");
                cmd.Parameters.AddWithValue("@filepath", newFileName);  // store only filename, not full path
                cmd.Parameters.AddWithValue("@releasedate", DateTime.Now);
                cmd.ExecuteNonQuery();

                // 4. Refresh the list
                LoadTracks(txtSearch.Text.Trim());

                MessageBox.Show($"\"{originalName}\" added successfully!\nYou can edit the details by clicking the song.",
                    "Track Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Clean up copied file if DB insert failed
                if (System.IO.File.Exists(destPath))
                    System.IO.File.Delete(destPath);

                MessageBox.Show($"Failed to add track:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void LoadTracks(string searchTerm = "")
        {
            // 1. Clear any previously generated cards
            panelLeft.Controls.Clear();

            int yOffset = 15; // starting Y position for first card

            string query = @"
                SELECT song_id, title, artist, album, genre, language, release_date, duration, file_path, is_preset
                FROM   SongsTbl
                WHERE  (is_preset = 1 OR user_id = @uid OR user_id IS NULL)
                AND    (title LIKE @search OR artist LIKE @search)
                ORDER  BY is_preset DESC, title ASC";

            try
            {
                MySqlConnection con = new(connString);
                con.Open();
                using var cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@uid", Session.CurrentUserId);
                cmd.Parameters.AddWithValue("@search", $"%{searchTerm}%");

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var song = new SongRow
                    {
                        SongId = reader.GetInt32("song_id"),
                        Title = reader.GetString("title"),
                        Artist = reader.GetString("artist"),
                        Album = reader.IsDBNull(reader.GetOrdinal("album")) ? "" : reader.GetString("album"),
                        Genre = reader.IsDBNull(reader.GetOrdinal("genre")) ? "" : reader.GetString("genre"),
                        Language = reader.IsDBNull(reader.GetOrdinal("language")) ? "" : reader.GetString("language"),
                        ReleaseDate = reader.IsDBNull(reader.GetOrdinal("release_date")) ? "" : reader.GetDateTime("release_date").ToString("MMM dd, yyyy"),
                        Duration = reader.IsDBNull(reader.GetOrdinal("duration")) ? "--:--" : reader.GetString("duration"),
                        FilePath = reader.IsDBNull(reader.GetOrdinal("file_path")) ? "" : reader.GetString("file_path"),
                        IsPreset = reader.GetBoolean("is_preset"),
                    };

                    // 2. Build card and position it
                    Panel card = BuildSongCard(song);
                    card.Location = new Point(15, yOffset);

                    // 3. Add to panelLeft
                    panelLeft.Controls.Add(card);

                    // 4. Move Y down for next card (card height 74 + 8px gap)
                    yOffset += 82;

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load tracks:\n{ex.Message}", "DB Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Panel BuildSongCard(SongRow song)
        {
            var card = new Panel
            {
                BackColor = Color.FromArgb(50, 53, 90),
                Size = new Size(790, 74),
                Margin = new Padding(15, 8, 15, 0),
                Tag = song   // store the full song data on the card
            };

            // Track name
            var lblName = new Label
            {
                Text = song.Title,
                Font = new Font("Segoe UI", 11f, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                Size = new Size(460, 24),
                Location = new Point(20, 12)
            };

            // Artist
            var lblArtist = new Label
            {
                Text = song.Artist,
                Font = new Font("Segoe UI", 9f),
                ForeColor = Color.FromArgb(160, 165, 210),
                BackColor = Color.Transparent,
                Size = new Size(300, 18),
                Location = new Point(20, 38)
            };

            // Duration / Format
            var lblDuration = new Label
            {
                Text = song.Duration,
                Font = new Font("Segoe UI", 10f),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                Size = new Size(60, 22),
                Location = new Point(630, 26),
                TextAlign = ContentAlignment.MiddleRight
            };


            card.Controls.AddRange(new Control[]
                {lblName, lblArtist, lblDuration});

            card.Click += (s, e) => ShowSongDetails(song);
            foreach (Control ctrl in card.Controls)
                ctrl.Click += (s, e) => ShowSongDetails(song);

            return card;
        }

        private void ShowSongDetails(SongRow song)
        {
            _selectedSong = song;

            // Populate right panel labels
            lblTrack.Text = song.Title;
            txtArtist.Text = song.Artist;
            txtAlbum.Text = song.Album ?? "N/A";
            txtGenre.Text = song.Genre;
            txtReleaseDate.Text = song.ReleaseDate;

            // Keep all fields DISABLED (read-only) by default
            SetDetailsEditable(false);

            // Show Edit button, hide Save button
            btnEdit.Visible = true;
            btnSave.Visible = false;
            btnRemove.Visible = !song.IsPreset; // hide Remove for preset songs
        }

        private void SetDetailsEditable(bool editable)
        {
            txtArtist.ReadOnly = !editable;
            txtGenre.ReadOnly = !editable;
            txtAlbum.ReadOnly = !editable;
            txtReleaseDate.ReadOnly = !editable;

        }





















        private void panelLeft_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    MessageBox.Show("Aiven Cloud is Connected!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Failed: " + ex.Message);
            }
        }

        private void lblAlbumValue_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void btnEdit_Click(object sender, EventArgs e)
        {


        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (_selectedSong == null)
            {
                MessageBox.Show("Please select a track first.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"Move \"{_selectedSong.Title}\" to archive?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using var conn = new MySqlConnection(connString);
                conn.Open();

                // 1. Copy from SongsTbl → ArchivedSongs
                string insertSql = @"
            INSERT INTO archiveTBL 
                (song_id, user_id, title, artist, album, genre, language, releasedate, duration, file_path, is_preset, created_at, updated_at)
            SELECT song_id, user_id, title, artist, album, genre, language, release_date, duration, file_path, is_preset, created_at, updated_at
            FROM   SongsTbl
            WHERE  song_id = @id";

                using var insertCmd = new MySqlCommand(insertSql, conn);
                insertCmd.Parameters.AddWithValue("@id", _selectedSong.SongId);
                insertCmd.ExecuteNonQuery();

                // 2. Delete from SongsTbl
                string deleteSql = "DELETE FROM SongsTbl WHERE song_id = @id";
                using var deleteCmd = new MySqlCommand(deleteSql, conn);
                deleteCmd.Parameters.AddWithValue("@id", _selectedSong.SongId);
                deleteCmd.ExecuteNonQuery();

                // 3. Clear right panel
                _selectedSong = null;
                lblTrack.Text = "Song";
                txtArtist.Text = "";
                txtAlbum.Text = "";
                txtGenre.Text = "";
                txtReleaseDate.Text = "";
                btnEdit.Visible = false;
                btnSave.Visible = false;
                btnRemove.Visible = false;

                // 4. Refresh the song list
                LoadTracks(txtSearch.ForeColor == Color.Gray ? "" : txtSearch.Text.Trim());

                MessageBox.Show($"Track moved to Trash!", "Moved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to archive:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
        }

        
    }
}
