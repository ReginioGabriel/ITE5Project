using MySql.Data.MySqlClient;
using NAudio.Wave;
using System.Data;
using System.IO;
using System.Threading;
using System.Xml.Linq;
using TagLib;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
namespace WinFormsApp7
{

    public partial class MainForm : Form
    {
        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;
        const string connString = "server=mysql-67-rhenzdaryl07111976-a59e.g.aivencloud.com;port=20563;database=Song_DB;uid=avnadmin;pwd=AVNS_385JfMsNN_Fh3urzWqr;SslMode=Required;";

        public MainForm()
        {
            InitializeComponent();
            loadTable(null, null); // Load data into DataGridView on form load

        }

        private bool IsValidMp3(string filePath)
        {
            try
            {
                byte[] header = new byte[3];
                using (var fs = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    fs.Read(header, 0, 3);
                }

                // Check for ID3 tag header: 0x49 0x44 0x33 = "ID3"
                bool hasId3Header = header[0] == 0x49 && header[1] == 0x44 && header[2] == 0x33;

                // Check for raw MPEG frame sync: 0xFF 0xFB or 0xFF 0xFA
                bool hasMpegSync = header[0] == 0xFF && (header[1] == 0xFB || header[1] == 0xFA || header[1] == 0xF3);

                return hasId3Header || hasMpegSync;
            }
            catch
            {
                return false;
            }
        }
        private void loadTable(object sender, EventArgs e)
        {

            using (MySqlConnection con = new MySqlConnection(connString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT * FROM SongsTbl";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            songIDTxt.Text = row.Cells[0].Value.ToString();
            songNameTxt.Text = row.Cells[1].Value.ToString();
            artistNameTxt.Text = row.Cells[2].Value.ToString();
            albumNameTxt.Text = row.Cells[3].Value.ToString();
            genreTxt.Text = row.Cells[4].Value.ToString();
            releaseDatePicker.Value = Convert.ToDateTime(row.Cells[5].Value);
            languageTxt.Text = row.Cells[6].Value.ToString();
            userID_Txt.Text = row.Cells[9].Value.ToString();
            filepathTxt.Text = row.Cells[10].Value.ToString();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {

            // 1. Define the SQL Update statement
            string query = "UPDATE SongsTbl SET title = @val1, artist = @val2, album = @val3, genre = @val4, release_date = @val5, language = @val6, user_id = @val7, file_path = @val8 WHERE song_id = @id";

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    // 2. Map Textboxes to the parameters
                    cmd.Parameters.AddWithValue("@val1", songNameTxt.Text);
                    cmd.Parameters.AddWithValue("@val2", artistNameTxt.Text);
                    cmd.Parameters.AddWithValue("@val3", albumNameTxt.Text);
                    cmd.Parameters.AddWithValue("@val4", genreTxt.Text);
                    cmd.Parameters.AddWithValue("@val5", releaseDatePicker.Value.Date);
                    cmd.Parameters.AddWithValue("@val6", languageTxt.Text);
                    cmd.Parameters.AddWithValue("@val7", userID_Txt.Text);
                    cmd.Parameters.AddWithValue("@val8", filepathTxt.Text);
                    cmd.Parameters.AddWithValue("@id", songIDTxt.Text); // The Primary Key is vital!

                    try
                    {
                        conn.Open();
                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            loadTable(null, null); // Refresh the DataGridView to show updated data
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Audio Files (*.mp3;*.wav;*.flac;*.m4a)|*.mp3;*.wav;*.flac;*.m4a|MP3 Files (*.mp3)|*.mp3|WAV Files (*.wav)|*.wav|All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                // ✅ Step 1: Validate the file is truly an MP3 (see below)
                if (!IsValidMp3(filePath))
                {
                    MessageBox.Show("The selected file is not a valid MP3 file.", "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string sourcePath = openFileDialog.FileName; // original file location
                string resourcesFolder = Path.Combine(Application.StartupPath, "Resources");

                // Create Resources folder if it doesn't exist
                if (!Directory.Exists(resourcesFolder))
                    Directory.CreateDirectory(resourcesFolder);

                // Copy file into Resources folder
                string fileName = Path.GetFileName(sourcePath);
                string destPath = Path.Combine(resourcesFolder, fileName);
                
                System.IO.File.Copy(sourcePath, destPath, overwrite: true);

                // Set the textbox to the new path
                filepathTxt.Text = destPath;
            }
        }

        string currentSong = "";
        bool playing = true;
        private void button5_Click(object sender, EventArgs e)
        {

            if (currentSong == filepathTxt.Text && playing == true) //Same song, playing
            {
                outputDevice?.Pause();
                playing = false; // pause the song
            }
            else if (currentSong == filepathTxt.Text && playing == false) //Same song, but paused
            {
                outputDevice?.Play();
                playing = true; // resume the song
            }
            else if (currentSong != filepathTxt.Text && !string.IsNullOrEmpty(filepathTxt.Text)) // different song
            {
                currentSong = filepathTxt.Text; // update the current song to the new one
                outputDevice?.Stop();
                outputDevice?.Dispose();
                audioFile?.Dispose();

                Thread.Sleep(100);
                audioFile = new AudioFileReader(filepathTxt?.Text);
                outputDevice = new WaveOutEvent();
                outputDevice.Init(audioFile);
                outputDevice.Play();
            }
        }

        private void waveformPainter3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
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

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); // Ensure the entire application closes when the main form is closed
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            songIDTxt.Text = row.Cells[0].Value.ToString();
            songNameTxt.Text = row.Cells[1].Value.ToString();
            artistNameTxt.Text = row.Cells[2].Value.ToString();
            albumNameTxt.Text = row.Cells[3].Value.ToString();
            genreTxt.Text = row.Cells[4].Value.ToString();
            releaseDatePicker.Value = Convert.ToDateTime(row.Cells[5].Value);
            languageTxt.Text = row.Cells[6].Value.ToString();
            userID_Txt.Text = row.Cells[9].Value.ToString();
            filepathTxt.Text = row.Cells[10].Value.ToString();
        }

        int createCounter = 0;

        private void createBtn_Click(object sender, EventArgs e)
        {
            if (createCounter == 0)
            {
                DialogResult result = MessageBox.Show("Create another Record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if(result == DialogResult.Yes)
                {
                    createCounter++;
                    // Clear textboxes for new entry
                    songIDTxt.Clear();
                    songNameTxt.Clear();
                    artistNameTxt.Clear();
                    albumNameTxt.Clear();
                    genreTxt.Clear();
                    releaseDatePicker.Value = DateTime.Now;
                    languageTxt.Clear();
                    userID_Txt.Clear();
                    filepathTxt.Clear();
                    userID_Txt.ReadOnly = false; // Allow user to enter new user ID
                    MessageBox.Show("Fill up the form and then click the create button to confirm");
                }
                else
                {
                    return; // Exit the method if user chooses not to create another record
                }
            }
            else if(createCounter == 1)
            {
                if(string.IsNullOrWhiteSpace(songNameTxt.Text) || string.IsNullOrWhiteSpace(artistNameTxt.Text) || string.IsNullOrWhiteSpace(albumNameTxt.Text) ||
                    string.IsNullOrWhiteSpace(genreTxt.Text) || string.IsNullOrWhiteSpace(languageTxt.Text))
                {
                    MessageBox.Show("Please fill in all fields before creating a record.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string query = "INSERT INTO SongsTbl (title, artist, album, genre, release_date, language, user_id, file_path) VALUES (@val1, @val2, @val3, @val4, @val5, @val6, @val7, @val8)";

                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // 2. Map Textboxes to the parameters
                        cmd.Parameters.AddWithValue("@val1", songNameTxt.Text);
                        cmd.Parameters.AddWithValue("@val2", artistNameTxt.Text);
                        cmd.Parameters.AddWithValue("@val3", albumNameTxt.Text);
                        cmd.Parameters.AddWithValue("@val4", genreTxt.Text);
                        cmd.Parameters.AddWithValue("@val5", releaseDatePicker.Value.Date);
                        cmd.Parameters.AddWithValue("@val6", languageTxt.Text);
                        cmd.Parameters.AddWithValue("@val7", userID_Txt.Text);
                        cmd.Parameters.AddWithValue("@val8", filepathTxt.Text);
                        cmd.Parameters.AddWithValue("@id", songIDTxt.Text); // The Primary Key is vital!

                        try
                        {
                            conn.Open();
                            int rows = cmd.ExecuteNonQuery();

                            if (rows > 0)
                            {
                                loadTable(null, null); // Refresh the DataGridView to show updated data
                                songIDTxt.Clear();
                                songNameTxt.Clear();
                                artistNameTxt.Clear();
                                albumNameTxt.Clear();
                                genreTxt.Clear();
                                releaseDatePicker.Value = DateTime.Now;
                                languageTxt.Clear();
                                userID_Txt.Clear();
                                filepathTxt.Clear();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                }
            }
        }
    }
}
