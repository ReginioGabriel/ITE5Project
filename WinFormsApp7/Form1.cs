using MySql.Data.MySqlClient;
using NAudio.Wave;
using System.Data;
using System.Xml.Linq;

namespace WinFormsApp7
{

    public partial class Form1 : Form
    {
        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;
        public Form1()
        {
            InitializeComponent();
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

        private void button5_Click(object sender, EventArgs e)
        {

            if (textBox8.Text == "") return;

            // stop any currently playing audio first
            outputDevice?.Stop();
            outputDevice?.Dispose();
            audioFile?.Dispose();

            audioFile = new AudioFileReader(textBox8.Text);
            outputDevice = new WaveOutEvent();
            outputDevice.Init(audioFile);
            outputDevice.Play();
        }

        private void waveformPainter3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            outputDevice.Stop();
        }
    }
}
