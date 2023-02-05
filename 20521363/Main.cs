using _20521363.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;
using WMPLib;

namespace _20521363
{
    public partial class Main : Form
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        Boolean isplay = true;
        public struct Ranking
        {
            public int score;
            public string start_time;
            public int start;
            public string end_time;
            public int lead_time;
        }
        public static Ranking[] ranking_fruit = new Ranking[5];
        public static Ranking[] ranking_animal = new Ranking[5];
        public static Ranking[] ranking_vehicle = new Ranking[5];

        public Main()
        {

            InitializeComponent();
            Home uc = new Home();
            addUserControl(uc);
            LoadSound();
            //this.Text = string.Empty;
            this.ControlBox = false;
            //this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
        }
        public void LoadSound()
        {
            player.URL = "Spring in My Step (Official Music Video).mp3";
            player.controls.play();

            player.settings.setMode("loop", true);

            pictureBox1.Image = Resources._3669408_volume_up_ic_icon;
        }
        private void change_color_fruit()
        {
            button_fuit.ForeColor = Color.Red;
            button_animal.ForeColor = Color.White;
            button_vehicle.ForeColor = Color.White;
        }
        private void change_color_animal()
        {
            button_fuit.ForeColor = Color.White;
            button_animal.ForeColor = Color.Red;
            button_vehicle.ForeColor = Color.White;
        }
        private void change_color_vehicle()
        {
            button_fuit.ForeColor = Color.White;
            button_animal.ForeColor = Color.White;
            button_vehicle.ForeColor = Color.Red;
        }
        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            //panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void button_fuit_Click(object sender, EventArgs e)
        {
            Fruit_card uc = new Fruit_card();
            addUserControl(uc);
            change_color_fruit();
        }

        private void button_animal_Click(object sender, EventArgs e)
        {
            animal uc = new animal();
            addUserControl(uc);
            change_color_animal();
        }

        private void button_vehicle_Click(object sender, EventArgs e)
        {
            vehicle uc = new vehicle();
            addUserControl(uc);
            change_color_vehicle();
        }

        private void fruitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fruit_card uc = new Fruit_card();
            addUserControl(uc);
            change_color_fruit();
        }

        private void animalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            animal uc = new animal();
            addUserControl(uc);
            change_color_animal();
        }

        private void vehicleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vehicle uc = new vehicle();
            addUserControl(uc);
            change_color_vehicle();
        }

        private void multipleMusicToolStripMenuItem1_Click(object sender, EventArgs e) //home
        {
            Home uc = new Home();
            addUserControl(uc);
            button_fuit.ForeColor = Color.White;
            button_animal.ForeColor = Color.White;
            button_vehicle.ForeColor = Color.White;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            if (isplay)
            {
                pictureBox1.Image = Resources._352214_off_volume_icon;
                player.controls.stop();
                isplay = false;
            }
            else
            {
                player.controls.play();
                isplay = true;
                pictureBox1.Image = Resources._3669408_volume_up_ic_icon;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            ActiveControl = button_fuit;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox1.BackColor = Color.DarkGray;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Fuchsia;
        }

        private void button_fuit_MouseMove(object sender, MouseEventArgs e)
        {
            button_fuit.BackColor = Color.DimGray;
        }

        private void button_fuit_MouseLeave(object sender, EventArgs e)
        {
            button_fuit.BackColor = Color.Black;
        }

        private void button_animal_MouseMove(object sender, MouseEventArgs e)
        {
            button_animal.BackColor = Color.DimGray;
        }

        private void button_animal_MouseLeave(object sender, EventArgs e)
        {
            button_animal.BackColor = Color.Black;
        }

        private void button_vehicle_MouseMove(object sender, MouseEventArgs e)
        {
            button_vehicle.BackColor = Color.DimGray;
        }

        private void button_vehicle_MouseLeave(object sender, EventArgs e)
        {
            button_vehicle.BackColor = Color.Black;
        }
    }
}
