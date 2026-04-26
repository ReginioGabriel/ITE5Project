using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class MainForm : Form
    {
        const string connString = "server=mysql-67-rhenzdaryl07111976-a59e.g.aivencloud.com;port=20563;database=Song_DB;uid=avnadmin;pwd=AVNS_385JfMsNN_Fh3urzWqr;SslMode=Required;";

        private SongRow _selectedSong = null;

        //Audio Controls
        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;
        private SongRow _currentlyPlayingSong;
        private bool _isDragging = false;

        private FlowLayoutPanel flowPanel;
        public MainForm()
        {
            InitializeComponent();
            trackpad.Interval = 500;
            trackpad.Tick += (s, e) =>
            {
                if (audioFile == null || _isDragging) return;

                trackBar.Maximum = (int)audioFile.TotalTime.TotalSeconds;
                trackBar.Value = Math.Min((int)audioFile.CurrentTime.TotalSeconds, trackBar.Maximum);
            };
            // Create inner flow panel once — never recreate it
            flowPanel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Width = panelLeft.Width - 20,
                BackColor = panelLeft.BackColor,
                Location = new Point(0, 0),
                Padding = new Padding(15, 15, 0, 15)
            };

            panelLeft.AutoScroll = true;
            panelLeft.Controls.Add(flowPanel);

            LoadTracks();
            TrackSession();

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            StopAndDisposeAudio();
            base.OnFormClosing(e);
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
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
            public string CoverPath { get; set; }
            public bool IsPreset { get; set; }
            public string Language { get; set; }
            public DateTime? ReleaseDate { get; set; }
        }


        #region Song Build Functions
        private void LoadTracks(string searchTerm = "")
        {
            StopAndDisposeAudio();
            flowPanel.Controls.Clear();

            string query = @"
        SELECT s.song_id, s.user_id, s.title, s.artist, s.album, s.release_date,
               s.genre, s.language, s.file_path, s.duration, s.is_preset
        FROM SongsTbl s
        WHERE
            (
                (
                    s.is_preset = 1
                    AND NOT EXISTS (
                        SELECT 1
                        FROM archiveTBL a
                        WHERE a.song_id = s.song_id
                          AND a.user_id = @uid
                          AND a.is_preset = 1
                    )
                )
                OR
                (
                    s.is_preset = 0
                    AND s.user_id = @uid
                )
            )
            AND
            (
                @term = ''
                OR s.title LIKE @search
                OR s.artist LIKE @search
                OR s.album LIKE @search
                OR s.genre LIKE @search
                OR s.language LIKE @search
            )
        ORDER BY s.is_preset DESC, s.title ASC;";

            try
            {
                using var con = new MySqlConnection(connString);
                con.Open();

                using var cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@uid", Session.CurrentUserId);
                cmd.Parameters.AddWithValue("@term", searchTerm.Trim());
                cmd.Parameters.AddWithValue("@search", $"%{searchTerm.Trim()}%");

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var song = new SongRow
                    {
                        SongId = reader.GetInt32("song_id"),
                        Title = reader.IsDBNull(reader.GetOrdinal("title")) ? "N/A" : reader.GetString("title"),
                        Artist = reader.IsDBNull(reader.GetOrdinal("artist")) ? "N/A" : reader.GetString("artist"),
                        Album = reader.IsDBNull(reader.GetOrdinal("album")) ? "N/A" : reader.GetString("album"),
                        Genre = reader.IsDBNull(reader.GetOrdinal("genre")) ? "N/A" : reader.GetString("genre"),
                        Language = reader.IsDBNull(reader.GetOrdinal("language")) ? "N/A" : reader.GetString("language"),
                        ReleaseDate = reader.IsDBNull(reader.GetOrdinal("release_date"))
                            ? (DateTime?)null
                            : reader.GetDateTime("release_date"),
                        Duration = reader.IsDBNull(reader.GetOrdinal("duration")) ? "N/A" : reader.GetString("duration"),
                        FilePath = reader.IsDBNull(reader.GetOrdinal("file_path")) ? "" : reader.GetString("file_path"),
                        IsPreset = reader.GetBoolean("is_preset")
                    };

                    flowPanel.Controls.Add(BuildSongCard(song));
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
                Size = new Size(730, 74),
                Margin = new Padding(0, 0, 0, 8),  // 8px gap between cards
                Tag = song
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

            if (song == null) return;

            _selectedSong = song;

            // Populate right panel labels
            lblTrack.Text = song.Title;
            txtArtist.Text = song.Artist;
            txtAlbum.Text = song.Album;
            txtGenre.Text = song.Genre;
            txtLanguage.Text = song.Language;
            lblDuration.Text = song.Duration;

            dtpReleaseDate.Visible = true;
            dtpReleaseDate.Format = DateTimePickerFormat.Custom;

            if (song.ReleaseDate.HasValue)
            {
                dtpReleaseDate.Checked = true;
                dtpReleaseDate.CustomFormat = "MM/dd/yy";
                dtpReleaseDate.Value = song.ReleaseDate.Value;
            }
            else
            {
                dtpReleaseDate.Checked = false;
                dtpReleaseDate.CustomFormat = " ";
                dtpReleaseDate.Value = DateTime.Today;
            }

            SetEditMode(false);
            btnPlayPause.Enabled = true;
        }
        private void SetEditMode(bool editing)
        {
            lblTrack.ReadOnly = !editing;
            txtArtist.ReadOnly = !editing;
            txtAlbum.ReadOnly = !editing;
            txtGenre.ReadOnly = !editing;
            txtLanguage.ReadOnly = !editing;

            dtpReleaseDate.Enabled = editing;
            btnSave.Visible = editing;
            picNowPlaying.Visible = true;
        }


        #endregion

        #region Add Track Button
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
            string newFileName = $"{Session.CurrentUserId}_{Guid.NewGuid()}{extension}";
            string destPath = Path.Combine(AppConfig.SongsFolder, newFileName);

            try
            {
                // ── 1. Read metadata from the file using TagLib ──────────────
                string autoTitle = "N/A";
                string autoArtist = "N/A";
                string autoAlbum = "N/A";
                string autoGenre = "N/A";
                string autoDuration = "N/A";

                using (var tagFile = TagLib.File.Create(sourceFilePath))
                {
                    // Duration → format as m:ss (e.g. 4:05)
                    TimeSpan dur = tagFile.Properties.Duration;
                    autoDuration = dur.TotalSeconds > 0
                        ? $"{(int)dur.TotalMinutes}:{dur.Seconds:D2}"
                        : "N/A";

                    // Title — fall back to filename if tag is empty
                    autoTitle = string.IsNullOrWhiteSpace(tagFile.Tag.Title)
                        ? Path.GetFileNameWithoutExtension(sourceFilePath)
                        : tagFile.Tag.Title;

                    // Artist
                    autoArtist = tagFile.Tag.Performers?.Length > 0
                        && !string.IsNullOrWhiteSpace(tagFile.Tag.Performers[0])
                        ? tagFile.Tag.Performers[0]
                        : "N/A";

                    // Album
                    autoAlbum = string.IsNullOrWhiteSpace(tagFile.Tag.Album)
                        ? "N/A"
                        : tagFile.Tag.Album;

                    // Genre
                    autoGenre = tagFile.Tag.Genres?.Length > 0
                        && !string.IsNullOrWhiteSpace(tagFile.Tag.Genres[0])
                        ? tagFile.Tag.Genres[0]
                        : "N/A";
                }

                // ── 2. Copy file to AppData ───────────────────────────────────
                Directory.CreateDirectory(AppConfig.SongsFolder);
                System.IO.File.Copy(sourceFilePath, destPath);

                // ── 3. Save to database ───────────────────────────────────────
                using var conn = new MySqlConnection(connString);
                conn.Open();

                string sql = @"
                INSERT INTO SongsTbl 
                    (user_id, title, artist, album, genre, duration, file_path, is_preset)
                VALUES 
                    (@uid, @title, @artist, @album, @genre, @duration, @filepath, 0)";

                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@uid", Session.CurrentUserId);
                cmd.Parameters.AddWithValue("@title", autoTitle);
                cmd.Parameters.AddWithValue("@artist", autoArtist);
                cmd.Parameters.AddWithValue("@album", autoAlbum);
                cmd.Parameters.AddWithValue("@genre", autoGenre);
                cmd.Parameters.AddWithValue("@duration", autoDuration);
                cmd.Parameters.AddWithValue("@filepath", newFileName);
                cmd.ExecuteNonQuery();

                MessageBox.Show(
                    $"✅ Track added!\n\nTitle: {autoTitle}\nArtist: {autoArtist}\nAlbum: {autoAlbum}\nDuration: {autoDuration}\nRelease Date: N/A \n\nYou can edit the details by clicking the song.",
                    "Track Added", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // ── 4. Refresh list ───────────────────────────────────────────
                LoadTracks();
            }
            catch (Exception ex)
            {
                if (System.IO.File.Exists(destPath))
                    System.IO.File.Delete(destPath);

                MessageBox.Show($"Failed to add track:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Remove Track Button
        private void btnRemove_Click_1(object sender, EventArgs e)
        {
            if (_selectedSong == null)
            {
                MessageBox.Show("Please select a song first.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RemoveTrack(_selectedSong);
        }

        private void RemoveTrack(SongRow song)
        {
            if (song == null) return;

            string message = song.IsPreset
                ? $"Archive preset song \"{song.Title}\" from your list?"
                : $"Archive \"{song.Title}\" from your library?\nThis can be restored using the archives.";

            var confirm = MessageBox.Show(
                message,
                "Confirm Archive",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using var conn = new MySqlConnection(connString);
                conn.Open();

                using var tx = conn.BeginTransaction();

                if (song.IsPreset)
                {
                    string presetArchiveSql = @"
                INSERT INTO archiveTBL
                    (song_id, user_id, title, artist, album, releasedate, genre, language, file_path, duration, is_preset, archived_at)
                SELECT
                    s.song_id,
                    @uid,
                    s.title,
                    s.artist,
                    s.album,
                    s.release_date,
                    s.genre,
                    s.language,
                    s.file_path,
                    s.duration,
                    1,
                    NOW()
                FROM SongsTbl s
                WHERE s.song_id = @id
                  AND s.is_preset = 1
                  AND NOT EXISTS (
                      SELECT 1
                      FROM archiveTBL a
                      WHERE a.song_id = s.song_id
                        AND a.user_id = @uid
                        AND a.is_preset = 1
                  );";

                    using var cmd = new MySqlCommand(presetArchiveSql, conn, tx);
                    cmd.Parameters.AddWithValue("@uid", Session.CurrentUserId);
                    cmd.Parameters.AddWithValue("@id", song.SongId);

                    int inserted = cmd.ExecuteNonQuery();
                    tx.Commit();

                    if (inserted > 0)
                    {
                        MessageBox.Show("Preset song moved to archive.", "Archived",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Preset song is already archived for this user.", "Already Archived",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    string archiveSql = @"
                INSERT INTO archiveTBL
                    (song_id, user_id, title, artist, album, releasedate, genre, language, file_path, duration, is_preset, archived_at)
                SELECT
                    s.song_id,
                    s.user_id,
                    s.title,
                    s.artist,
                    s.album,
                    s.release_date,
                    s.genre,
                    s.language,
                    s.file_path,
                    s.duration,
                    0,
                    NOW()
                FROM SongsTbl s
                WHERE s.song_id = @id
                  AND s.user_id = @uid
                  AND s.is_preset = 0;";

                    using var archiveCmd = new MySqlCommand(archiveSql, conn, tx);
                    archiveCmd.Parameters.AddWithValue("@id", song.SongId);
                    archiveCmd.Parameters.AddWithValue("@uid", Session.CurrentUserId);

                    int archived = archiveCmd.ExecuteNonQuery();
                    if (archived == 0)
                        throw new Exception("Song could not be archived.");

                    string deleteSql = @"
                DELETE FROM SongsTbl
                WHERE song_id = @id
                  AND user_id = @uid
                  AND is_preset = 0;";

                    using var deleteCmd = new MySqlCommand(deleteSql, conn, tx);
                    deleteCmd.Parameters.AddWithValue("@id", song.SongId);
                    deleteCmd.Parameters.AddWithValue("@uid", Session.CurrentUserId);

                    int deleted = deleteCmd.ExecuteNonQuery();
                    if (deleted == 0)
                        throw new Exception("Song was archived but not removed from SongsTbl.");

                    tx.Commit();

                    MessageBox.Show($"\"{song.Title}\" moved to archive.", "Archived",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                _selectedSong = null;
                LoadTracks();
                ClearSongDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Archive failed:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearSongDetails()
        {
            lblTrack.Text = "No song selected";
            txtArtist.Clear();
            txtAlbum.Clear();
            txtGenre.Clear();
            txtLanguage.Clear();
            lblDuration.Text = "";
            dtpReleaseDate.CustomFormat = " ";
        }

        #endregion

        #region Play/Pause Buttons
        private void btnPlayPause_Click(object sender, EventArgs e)
        {

            if (_selectedSong == null)
            {
                MessageBox.Show("Please select a song first.", "No Song Selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string fullPath = GetSongFullPath(_selectedSong);

            if (string.IsNullOrWhiteSpace(fullPath) || !System.IO.File.Exists(fullPath))
            {
                MessageBox.Show("Song file not found.", "Missing File",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (_currentlyPlayingSong != null &&
                    _currentlyPlayingSong.SongId == _selectedSong.SongId &&
                    outputDevice != null)
                {
                    if (outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        outputDevice.Pause();
                        trackpad.Stop();
                        btnPlayPause.Text = "▶";
                        return;
                    }

                    if (outputDevice.PlaybackState == PlaybackState.Paused)
                    {
                        outputDevice.Play();
                        trackpad.Start();
                        btnPlayPause.Text = "⏸";
                        return;
                    }
                }

                StopAndDisposeAudio();

                audioFile = new AudioFileReader(fullPath);
                outputDevice = new WaveOutEvent();
                outputDevice.Init(audioFile);
                outputDevice.PlaybackStopped += OutputDevice_PlaybackStopped;
                outputDevice.Play();
                trackpad.Start();

                _currentlyPlayingSong = _selectedSong;
                btnPlayPause.Text = "⏸";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Playback failed:\n{ex.Message}", "Audio Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetSongFullPath(SongRow song)
        {
            if (song == null || string.IsNullOrWhiteSpace(song.FilePath))
                return null;

            if (song.IsPreset)
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "presets", song.FilePath);

            return Path.Combine(AppConfig.SongsFolder, song.FilePath);
        }
        private void trackBar_MouseDown(object sender, MouseEventArgs e)
        {
            _isDragging = true; // pause timer updates while dragging
        }

        private void trackBar_MouseUp(object sender, MouseEventArgs e)
        {
            if (audioFile == null) { _isDragging = false; return; }

            audioFile.CurrentTime = TimeSpan.FromSeconds(trackBar.Value);
            _isDragging = false; // resume timer
        }

        // Replace your empty trackBar_Scroll with this
        private void trackBar_Scroll(object sender, EventArgs e)
        {
            // Optional: show current time while dragging
            // lblCurrentTime.Text = TimeSpan.FromSeconds(trackBar.Value).ToString(@"m\:ss");
        }
        //Cleanup helper
        private void StopAndDisposeAudio()
        {
            if (outputDevice != null)
            {
                outputDevice.PlaybackStopped -= OutputDevice_PlaybackStopped;
                outputDevice.Stop();
                trackpad.Stop();
                outputDevice.Dispose();
                outputDevice = null;
            }

            if (audioFile != null)
            {
                audioFile.Dispose();
                audioFile = null;
            }

            _currentlyPlayingSong = null;
            //reset trackbar
            if (trackBar.InvokeRequired)
                trackBar.Invoke(new Action(() => trackBar.Value = 0));
            else
                trackBar.Value = 0;
        }

        //When the song finishes naturally, reset the button
        private void OutputDevice_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => OutputDevice_PlaybackStopped(sender, e)));
                return;
            }

            btnPlayPause.Text = "▶";

            if (audioFile != null && audioFile.Position >= audioFile.Length)
            {
                StopAndDisposeAudio();
            }
        }


        #endregion

        #region Search Button
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            _selectedSong = null;
            ClearSongDetails();
            LoadTracks(keyword);
        }
        #endregion

        #region Edit Btn
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_selectedSong == null)
            {
                MessageBox.Show("Please select a song first.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_selectedSong.IsPreset)
            {
                MessageBox.Show("Only songs you have added can be edited.", "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SetEditMode(true);
            picNowPlaying.Enabled = true;
            dtpReleaseDate.Format = DateTimePickerFormat.Short;
            txtArtist.Focus();
        }
        #endregion

        #region Test Connection Btn
        private void btnTest_Click(object sender, EventArgs e)
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
        #endregion

        #region Save Button
        private void btnSave_Click(object sender, EventArgs e)
        {

            string title = lblTrack.Text.Trim();
            string artist = txtArtist.Text.Trim();
            string album = txtAlbum.Text.Trim();
            string genre = txtGenre.Text.Trim();
            string language = txtLanguage.Text.Trim();
            picNowPlaying.Enabled = false;


            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Title is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lblTrack.Focus();
                return;
            }

            object releaseDateValue = dtpReleaseDate.Checked
                ? dtpReleaseDate.Value.Date
                : DBNull.Value;

            string query = @"
                UPDATE SongsTbl
                SET
                    title = @title,
                    artist = @artist,
                    album = @album,
                    genre = @genre,
                    language = @language,
                    release_date = @release_date
                WHERE song_id = @song_id
                  AND user_id = @user_id
                  AND is_preset = 0";

            try
            {
                using var conn = new MySqlConnection(connString);
                using var cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@artist", string.IsNullOrWhiteSpace(artist) ? DBNull.Value : artist);
                cmd.Parameters.AddWithValue("@album", string.IsNullOrWhiteSpace(album) ? DBNull.Value : album);
                cmd.Parameters.AddWithValue("@genre", string.IsNullOrWhiteSpace(genre) ? DBNull.Value : genre);
                cmd.Parameters.AddWithValue("@language", string.IsNullOrWhiteSpace(language) ? DBNull.Value : language);
                cmd.Parameters.AddWithValue("@release_date", releaseDateValue);
                cmd.Parameters.AddWithValue("@song_id", _selectedSong.SongId);
                cmd.Parameters.AddWithValue("@user_id", Session.CurrentUserId);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    _selectedSong.Title = title;
                    _selectedSong.Artist = artist;
                    _selectedSong.Album = album;
                    _selectedSong.Genre = genre;
                    _selectedSong.Language = language;
                    _selectedSong.ReleaseDate = dtpReleaseDate.Checked ? dtpReleaseDate.Value.Date : (DateTime?)null;

                    MessageBox.Show("Song updated successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    SetEditMode(false);
                    LoadTracks();
                }
                else
                {
                    MessageBox.Show("No record was updated. The song may not belong to this user.",
                        "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Failed to update song:\n{ex.Message}", "Database Error",
                //    MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.ToString(), "Full Error");
            }
        }
        #endregion

        #region Menu Strip
        private void MenuArchive_Click(object sender, EventArgs e)
        {
            StopAndDisposeAudio();
            var archiveForm = new archiveForm(this);
            archiveForm.Show();

            this.Hide();
        }

        private void MenuLogOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Confirm Logout",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == result)
            {
                StopAndDisposeAudio();
                Session.CurrentUserId = -1; // Reset session
                var loginForm = new LoginForm();
                loginForm.Show();
                this.Hide();
            }
        }
        private void TrackSession()
        {
            toolStripLabel2.Text = $"Logged in as: {Session.CurrentUsername}";
            toolStripLabel2.ForeColor = Color.White;
            toolStripLabel1.Text = $"Total Tracks: {flowPanel.Controls.Count}";
            toolStripLabel1.ForeColor = Color.White;
        }

        #endregion

        #region Refresh Button
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadTracks();
        }
        #endregion
    }
}
