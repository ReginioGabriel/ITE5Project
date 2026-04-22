using MySql.Data.MySqlClient;
using NAudio.Wave;
using System.Data;
using System.Xml.Linq;
using System.Threading;
using TagLib;
namespace WinFormsApp7
{

    public partial class MainForm : Form
    {
        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;
        public MainForm()
        {
            InitializeComponent();
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
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "MP3 Files (.mp3)|.mp3|All Files (.)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                // ✅ Step 1: Validate the file is truly an MP3 (see below)
                if (!IsValidMp3(filePath))
                {
                    MessageBox.Show("The selected file is not a valid MP3 file.", "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ✅ Step 2: Read metadata using TagLib
                TagLib.File tagFile = TagLib.File.Create(filePath);

                // --- Tag properties (ID3 metadata) ---
                string title = tagFile.Tag.Title;
                string artist = tagFile.Tag.FirstPerformer;
                string album = tagFile.Tag.Album;
                uint year = tagFile.Tag.Year;          // Year the song was recorded/released
                string genre = tagFile.Tag.FirstGenre;
                string comment = tagFile.Tag.Comment;
                uint track = tagFile.Tag.Track;         // Track number

                // --- Audio properties ---
                TimeSpan duration = tagFile.Properties.Duration;   // Song length
                int bitrate = tagFile.Properties.AudioBitrate;   // e.g., 320 kbps
                int sampleRate = tagFile.Properties.AudioSampleRate; // e.g., 44100 Hz
                int channels = tagFile.Properties.AudioChannels;   // 1 = Mono, 2 = Stereo

                // --- File system info ---
                var fileInfo = new System.IO.FileInfo(filePath);
                long fileSize = fileInfo.Length;           // Size in bytes
                DateTime dateCreated = fileInfo.CreationTime;
                DateTime dateModified = fileInfo.LastWriteTime;

                // ✅ Display results
                textBox1.Text = $"Title: {title}";
                textBox2.Text = $"Artist: {artist}";
                textBox3.Text = $"Album: {album}";
                textBox4.Text = $"Year: {year}";
                textBox5.Text = $"Duration: {duration:mm\\:ss}";
                textBox6.Text = $"File Size: {fileSize / 1024} KB";
                textBox7.Text = $"Date Created: {dateCreated}";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string constring = "server=localhost;database=song_db;user id=root;password=050708Gab";
            using (MySqlConnection con = new MySqlConnection(constring))
            {
                try
                {
                    con.Open();
                    MessageBox.Show("Connection Successful");
                    string query = "SELECT * FROM songs";
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

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
                textBox5.Text = row.Cells[4].Value.ToString();
                textBox6.Text = row.Cells[5].Value.ToString();
                textBox7.Text = row.Cells[6].Value.ToString();
                textBox8.Text = row.Cells[7].Value.ToString();

            }
            //dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            string connString = "server=localhost;database=song_db;uid=root;pwd=050708Gab;";

            // 1. Define the SQL Update statement
            string query = "UPDATE songs SET Title = @val1, Artist = @val2, Album = @val3, Genre = @val4, ReleaseYear = @val5, Duration = @val6, FilePath = @val7 WHERE SongID = @id";

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    // 2. Map Textboxes to the parameters
                    cmd.Parameters.AddWithValue("@val1", textBox2.Text);
                    cmd.Parameters.AddWithValue("@val2", textBox3.Text);
                    cmd.Parameters.AddWithValue("@val3", textBox4.Text);
                    cmd.Parameters.AddWithValue("@val4", textBox5.Text);
                    cmd.Parameters.AddWithValue("@val5", textBox6.Text);
                    cmd.Parameters.AddWithValue("@val6", textBox7.Text);
                    cmd.Parameters.AddWithValue("@val7", textBox8.Text);
                    cmd.Parameters.AddWithValue("@id", textBox1.Text); // The Primary Key is vital!

                    try
                    {
                        conn.Open();
                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            MessageBox.Show("Record Updated successfully!");
                            // 3. Optional: Refresh your DataGridView to show the new data
                            //LoadDataIntoGrid();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox8.Text = ofd.FileName; // copies full file path to textbox
            }
        }

        string currentSong = "";
        bool playing = true;
        private void button5_Click(object sender, EventArgs e)
        {

            if (currentSong == textBox8.Text && playing == true) //Same song, playing
            {
                outputDevice?.Pause();
                playing = false; // pause the song
            }
            else if (currentSong == textBox8.Text && playing == false) //Same song, but paused
            {
                outputDevice?.Play();
                playing = true; // resume the song
            }
            else if (currentSong != textBox8.Text) // different song
            {
                currentSong = textBox8.Text; // update the current song to the new one
                outputDevice?.Stop();
                outputDevice?.Dispose();
                audioFile?.Dispose();

                Thread.Sleep(100);
                audioFile = new AudioFileReader(textBox8.Text);
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

            string connString = "server=mysql-67-rhenzdaryl07111976-a59e.g.aivencloud.com;port=20563;database=Song_DB;uid=avnadmin;pwd=AVNS_385JfMsNN_Fh3urzWqr;SslMode=Required;";
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
    }
}
