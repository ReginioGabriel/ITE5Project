using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static WinFormsApp7.Program;

namespace WinFormsApp7
{
    public partial class archiveForm : Form
    {
        const string connString = "server=mysql-67-rhenzdaryl07111976-a59e.g.aivencloud.com;port=20563;database=Song_DB;uid=avnadmin;pwd=AVNS_385JfMsNN_Fh3urzWqr;SslMode=Required;";
        private MainForm _mainform;
        public archiveForm(MainForm mainform)
        {
            InitializeComponent();
            _mainform = mainform;

            _searchTimer.Interval = 400;
            _searchTimer.Tick += (s, e) =>
            {
                _searchTimer.Stop();
                LoadTracks(txtSearch.ForeColor == Color.Gray ? "" : txtSearch.Text.Trim());
            };

            LoadTracks();
            TrackSession();
        }
        #region styles and load
        private void StyleGrid()
        {
            dataGridView1.BackgroundColor = Color.FromArgb(30, 34, 57);
            dataGridView1.GridColor = Color.FromArgb(50, 54, 80);
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = true;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(38, 42, 68);
            dataGridView1.DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10f);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(80, 100, 200);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);
            dataGridView1.RowTemplate.Height = 45;

            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(44, 48, 75);

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(25, 28, 50);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(150, 180, 255);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10f);
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersHeight = 50;

            if (dataGridView1.Columns["archiveNumID"] != null)
                dataGridView1.Columns["archiveNumID"].Visible = false;

            if (dataGridView1.Columns["song_id"] != null)
                dataGridView1.Columns["song_id"].Visible = false;

            if (dataGridView1.Columns["user_id"] != null)
                dataGridView1.Columns["user_id"].Visible = false;

            if (dataGridView1.Columns["is_preset"] != null)
                dataGridView1.Columns["is_preset"].Visible = false;

            if (dataGridView1.Columns["releasedate"] != null)
                dataGridView1.Columns["releasedate"].Visible = false;

            if (dataGridView1.Columns["language"] != null)
                dataGridView1.Columns["language"].Visible = false;

            if (dataGridView1.Columns["file_path"] != null)
                dataGridView1.Columns["file_path"].Visible = false;
        }

        private void LoadTracks(string searchTerm = "")
        {
            string query = @"
        SELECT archiveNumID,
               song_id,
               user_id,
               is_preset,
               releasedate,
               language,
               file_path,
               title       AS Title,
               artist      AS Artist,
               album       AS Album,
               genre       AS Genre,
               duration    AS Duration,
               archived_at AS 'Archived On'
        FROM archiveTBL
        WHERE user_id = @uid
          AND (title LIKE @search OR artist LIKE @search)
        ORDER BY archived_at DESC;";

            try
            {
                using var conn = new MySqlConnection(connString);
                conn.Open();

                using var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@uid", Session.CurrentUserId);
                cmd.Parameters.AddWithValue("@search", $"%{searchTerm}%");

                var dt = new DataTable();
                new MySqlDataAdapter(cmd).Fill(dt);

                dataGridView1.DataSource = dt;
                StyleGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load archive:\n{ex.Message}", "DB Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region Buttons
        #region delete button
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select at least one track.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int count = dataGridView1.SelectedRows.Count;
            var confirm = MessageBox.Show(
                $"Permanently delete {count} track(s)? This cannot be undone!",
                "Permanent Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using var conn = new MySqlConnection(connString);
                conn.Open();

                using var tx = conn.BeginTransaction();

                var filesToDelete = new List<string>();
                int deleted = 0;

                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    int archiveId = Convert.ToInt32(row.Cells["archiveNumID"].Value);
                    bool isPreset = Convert.ToBoolean(row.Cells["is_preset"].Value);
                    string fileName = Convert.ToString(row.Cells["file_path"].Value) ?? "";

                    string sql = @"
                DELETE FROM archiveTBL
                WHERE archiveNumID = @id
                  AND user_id = @uid";

                    using var cmd = new MySqlCommand(sql, conn, tx);
                    cmd.Parameters.AddWithValue("@id", archiveId);
                    cmd.Parameters.AddWithValue("@uid", Session.CurrentUserId);

                    int affected = cmd.ExecuteNonQuery();
                    if (affected > 0)
                    {
                        deleted++;

                        if (!isPreset && !string.IsNullOrWhiteSpace(fileName))
                        {
                            string fullPath = Path.Combine(AppConfig.SongsFolder, fileName);
                            filesToDelete.Add(fullPath);
                        }
                    }
                }

                tx.Commit();

                foreach (string fullPath in filesToDelete.Distinct())
                {
                    try
                    {
                        if (File.Exists(fullPath))
                            File.Delete(fullPath);
                    }
                    catch
                    {
                        // Optional: log this if you have logging
                    }
                }

                LoadTracks();

                MessageBox.Show($"{deleted} track(s) permanently deleted.", "Deleted",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to delete:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region Retrieve Button
        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select at least one track.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int count = dataGridView1.SelectedRows.Count;
            var confirm = MessageBox.Show(
                $"Restore {count} track(s) back to your library?",
                "Confirm Restore",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using var conn = new MySqlConnection(connString);
                conn.Open();

                using var tx = conn.BeginTransaction();

                int restored = 0;

                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    int archiveId = Convert.ToInt32(row.Cells["archiveNumID"].Value);
                    bool isPreset = Convert.ToBoolean(row.Cells["is_preset"].Value);

                    if (isPreset)
                    {
                        // Preset song already exists in SongsTbl.
                        // Restoring means removing this user's archive entry only.
                        string unarchivePresetSql = @"
                    DELETE FROM archiveTBL
                    WHERE archiveNumID = @id
                      AND user_id = @uid
                      AND is_preset = 1";

                        using var presetCmd = new MySqlCommand(unarchivePresetSql, conn, tx);
                        presetCmd.Parameters.AddWithValue("@id", archiveId);
                        presetCmd.Parameters.AddWithValue("@uid", Session.CurrentUserId);

                        int affected = presetCmd.ExecuteNonQuery();
                        if (affected > 0)
                            restored++;
                    }
                    else
                    {
                        string insertSql = @"
                    INSERT INTO SongsTbl
                        (song_id, user_id, title, artist, album, genre, language, release_date, duration, file_path, is_preset)
                    SELECT a.song_id, a.user_id, a.title, a.artist, a.album, a.genre, a.language, a.releasedate,
                           a.duration, a.file_path, 0
                    FROM archiveTBL a
                    WHERE a.archiveNumID = @id
                      AND a.user_id = @uid
                      AND a.is_preset = 0
                      AND NOT EXISTS (
                          SELECT 1
                          FROM SongsTbl s
                          WHERE s.song_id = a.song_id
                      );";

                        using var insertCmd = new MySqlCommand(insertSql, conn, tx);
                        insertCmd.Parameters.AddWithValue("@id", archiveId);
                        insertCmd.Parameters.AddWithValue("@uid", Session.CurrentUserId);

                        int inserted = insertCmd.ExecuteNonQuery();
                        if (inserted == 0)
                            throw new Exception("One of the selected uploaded tracks could not be restored.");

                        string deleteSql = @"
                    DELETE FROM archiveTBL
                    WHERE archiveNumID = @id
                      AND user_id = @uid
                      AND is_preset = 0";

                        using var deleteCmd = new MySqlCommand(deleteSql, conn, tx);
                        deleteCmd.Parameters.AddWithValue("@id", archiveId);
                        deleteCmd.Parameters.AddWithValue("@uid", Session.CurrentUserId);
                        deleteCmd.ExecuteNonQuery();

                        restored++;
                    }
                }

                tx.Commit();

                LoadTracks();

                MessageBox.Show($"{restored} track(s) restored to library!", "Restored",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to restore:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region Select All Button
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            dataGridView1.SelectAll();
        }
        #endregion
        #region Search Bar
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            _searchTimer.Stop();// para di lag previous kasi kada letter load ng tracks so eto nag wait for user to stop typing then load tracks
            _searchTimer.Start();
        }
        #endregion
        #region Return Button
        private void btnReturn_Click(object sender, EventArgs e)
        {
            _mainform.Show();
            this.Hide();
        }
        #endregion
        #endregion

        #region Menu Bar
        private void MenuCollection_Click(object sender, EventArgs e)
        {
            _mainform.Show();
            this.Hide();
        }
        private void MenuLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Confirm Logout",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == result)
            {

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
            toolStripLabel1.Text = $"Total Archived Songs: {dataGridView1.Rows.Count}";
            toolStripLabel1.ForeColor = Color.White;
        }
        #endregion


    }
}
