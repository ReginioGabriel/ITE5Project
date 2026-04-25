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
            StyleGrid();
            Session.CurrentUserId = 1;
            LoadTracks();
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
        SELECT archiveNumID   AS 'Archived ID',
               title        AS 'Title',
               artist       AS 'Artist',
               album        AS 'Album',
               genre        AS 'Genre',
               duration     AS 'Duration',
               file_path    AS 'Filepath',
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
                int rowcount = dt.Rows.Count + 1;
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
            int archiveId = GetSelectedArchiveId();
            if (archiveId == -1) return;

            string title = GetSelectedTitle();
            int count = dataGridView1.SelectedRows.Count;
            var confirm = MessageBox.Show(
                $"Permanently delete \"{title}\"? This cannot be undone!", "Permanent Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using var conn = new MySqlConnection(connString);
                conn.Open();

                string sql = "DELETE FROM archiveTBL WHERE archiveNumID = @id";
                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", archiveId);
                cmd.ExecuteNonQuery();

                LoadTracks();

                MessageBox.Show($"\"{title}\" permanently deleted.", "Deleted",
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
            int archiveId = GetSelectedArchiveId();
            if (archiveId == -1) return;

            string title = GetSelectedTitle();
            var confirm = MessageBox.Show(
                $"Restore \"{title}\" back to your library?", "Confirm Restore",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            int count = dataGridView1.SelectedRows.Count;
            if (confirm != DialogResult.Yes) return;

            try
            {
                using var conn = new MySqlConnection(connString);
                conn.Open();

                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    int archiveIdd = Convert.ToInt32(row.Cells["ID"].Value);
                    // 1. Copy back to SongsTbl
                    string insertSql = @"
            INSERT INTO SongsTbl 
                (song_id, user_id, title, artist, album, genre, language, release_date, duration, file_path, is_preset)
            SELECT song_id, user_id, title, artist, album, genre, language, releasedate, duration, file_path, is_preset
            FROM   archiveTBL
            WHERE  archiveNumID = @id";

                    using var insertCmd = new MySqlCommand(insertSql, conn);
                    insertCmd.Parameters.AddWithValue("@id", archiveId);
                    insertCmd.ExecuteNonQuery();

                    // 2. Remove from ArchivedSongs
                    string deleteSql = "DELETE FROM archiveTBL WHERE archiveNumID = @id";
                    using var deleteCmd = new MySqlCommand(deleteSql, conn);
                    deleteCmd.Parameters.AddWithValue("@id", archiveId);
                    deleteCmd.ExecuteNonQuery();

                }
                // 3. Refresh
                LoadTracks();

                MessageBox.Show($"\"{title}\" restored to library!", "Restored",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to restore:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var test = new btnTestConnection();
            test.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.SelectAll();
        }
    }
}
