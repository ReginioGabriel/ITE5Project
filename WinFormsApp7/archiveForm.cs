using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using MySqlConnector;
using System.Windows.Forms;

namespace WinFormsApp7
{
    public partial class archiveForm : Form
    {
        const string connString = "server=mysql-67-rhenzdaryl07111976-a59e.g.aivencloud.com;port=20563;database=Song_DB;uid=avnadmin;pwd=AVNS_385JfMsNN_Fh3urzWqr;SslMode=Required;";

        public archiveForm()
        {
            InitializeComponent();

            _searchTimer.Interval = 400;
            _searchTimer.Tick += (s, e) =>
            {
                _searchTimer.Stop(); // stop so it only fires once
                LoadTracks(txtSearch.ForeColor == Color.Gray ? "" : txtSearch.Text.Trim());
            };
            Session.CurrentUserId = 1;
            LoadTracks();
            StyleGrid();
            toolbartracker();
        }
        private int GetSelectedArchiveId()
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a track first.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }

            return Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Archived ID"].Value);
        }


        private string GetSelectedTitle()
        {
            if (dataGridView1.SelectedRows.Count == 0) return "";
            return dataGridView1.SelectedRows[0].Cells["title"].Value.ToString();
        }
        private void StyleGrid()
        {
            dataGridView1.Columns["archiveNumID"].Visible = false;
            dataGridView1.BackgroundColor = Color.FromArgb(30, 34, 57);
            dataGridView1.GridColor = Color.FromArgb(50, 54, 80);
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.EnableHeadersVisualStyles = false;

            // Row style
            dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(38, 42, 68);
            dataGridView1.DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10f);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(80, 100, 200);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);
            dataGridView1.RowTemplate.Height = 45;

            // Alternating row
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(44, 48, 75);

            // Header style
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(25, 28, 50);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(150, 180, 255);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10f);
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersHeight = 50;

            // Hide the ID column (needed for restore/delete but ugly to show)
            if (dataGridView1.Columns["Archived ID"] != null)
                dataGridView1.Columns["Archived ID"].Visible = false;
        }
        private void LoadTracks(string searchTerm = "")
        {
            string query = @"
        SELECT archiveNumID,
               title        AS 'Title',
               artist       AS 'Artist',
               album        AS 'Album',
               genre        AS 'Genre',
               duration     AS 'Duration',
               file_path    AS 'Filepath',
               file_pathImg AS 'Image Filepath',
               archived_at  AS 'Archived On'
        FROM   archiveTBL  
        WHERE  user_id = @uid
        AND    (title LIKE @search OR artist LIKE @search)
        ORDER  BY archived_at DESC";

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

                // Show empty message
                int rowcount = dt.Rows.Count;
                lblCount.Text = dt.Rows.Count == 0
                    ? "No archived tracks found."
                    : $"{rowcount} archived track(s)";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load archive:\n{ex.Message}", "DB Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void archiveForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select at least one track.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int count = dataGridView1.SelectedRows.Count;
            var confirm = MessageBox.Show(
                $"Permanently delete {count} track(s)? This cannot be undone!", "Permanent Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using var conn = new MySqlConnection(connString);
                conn.Open();

                int deleted = 0;
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    int archiveId = Convert.ToInt32(row.Cells["archiveNumID"].Value); // ← per row

                    string sql = "DELETE FROM archiveTBL WHERE archiveNumID = @id";
                    using var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", archiveId); // ← per row
                    cmd.ExecuteNonQuery();

                    deleted++;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select at least one track.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int count = dataGridView1.SelectedRows.Count;
            var confirm = MessageBox.Show(
                $"Restore {count} track(s) back to your library?", "Confirm Restore",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using var conn = new MySqlConnection(connString);
                conn.Open();

                int restored = 0;
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    int archiveId = Convert.ToInt32(row.Cells["archiveNumID"].Value); // ← use THIS per row

                    // 1. Copy back to SongsTbl
                    string insertSql = @"
                INSERT INTO SongsTbl 
                    (song_id, user_id, title, artist, album, genre, language, release_date, duration, file_path, is_preset)
                SELECT song_id, user_id, title, artist, album, genre, language, releasedate, duration, file_path, is_preset
                FROM   archiveTBL
                WHERE  archiveNumID = @id";

                    using var insertCmd = new MySqlCommand(insertSql, conn);
                    insertCmd.Parameters.AddWithValue("@id", archiveId); // ← per row id
                    insertCmd.ExecuteNonQuery();

                    // 2. Remove from archiveTBL
                    string deleteSql = "DELETE FROM archiveTBL WHERE archiveNumID = @id";
                    using var deleteCmd = new MySqlCommand(deleteSql, conn);
                    deleteCmd.Parameters.AddWithValue("@id", archiveId); // ← per row id
                    deleteCmd.ExecuteNonQuery();

                    restored++;
                }

                // 3. Refresh
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

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.SelectAll();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            _searchTimer.Stop();// para di lag previous kasi kada letter load ng tracks so eto nag wait for user to stop typing then load tracks
            _searchTimer.Start();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var test = new MainForm();
            test.Show();
            this.Hide();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
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
        private string GetUsername(int userId)
        {
            try
            {
                using var conn = new MySqlConnection(connString);
                conn.Open();

                string sql = "SELECT Username FROM UserTbl WHERE UserID = @id";
                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", userId);

                var result = cmd.ExecuteScalar();
                return result?.ToString() ?? "Unknown";
            }
            catch
            {
                return "Unknown";
            }
        }
        private void toolbartracker()
        {
            toolStripLabel2.Text = $"Logged in as: {GetUsername(Session.CurrentUserId)}";
            toolStripLabel2.ForeColor = Color.White;
            toolStripLabel1.Text = $"Total Archived Songs: {dataGridView1.Rows.Count}";
            toolStripLabel1.ForeColor = Color.White;
        }
    }
}
