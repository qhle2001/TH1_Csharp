using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20521363
{
    public partial class Music : UserControl
    {
        public Music()
        {
            InitializeComponent();
        }
        OpenFileDialog openFileDialog;
        string[] filePaths;
        string[] fileNames;
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Mp3 files, mp4 files (*.mp3, *mp4)|*.mp*";
            openFileDialog.Multiselect = true;
            openFileDialog.Title = "Open";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePaths = openFileDialog.FileNames; //lay cai duong dan
                fileNames = openFileDialog.SafeFileNames; //Lay ten file
                foreach (var item in fileNames)
                {
                    this.list_music.Items.Add(item);
                }
            }
        }

        private void list_music_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void list_music_DoubleClick(object sender, EventArgs e)
        {
            if  (list_music.SelectedItems.Count != -1)
            {
                int choose = list_music.SelectedIndex;
                axWindowsMediaPlayer1.URL = filePaths[choose];
                this.textBox1.Text = fileNames[choose];
            }
  
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Music_Load(object sender, EventArgs e)
        {

        }
    }
}
