using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using _20521363.Model;
using _20521363.Properties;
using static _20521363.Main;

namespace _20521363
{
    public partial class vehicle : UserControl
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        Ranking[] ranking = Main.ranking_vehicle;
        Ranking tempt = new Ranking();
        public vehicle()
        {
            InitializeComponent();
            label_ipa.BackColor = Color.WhiteSmoke;
            label_name.BackColor = Color.WhiteSmoke;
            button_replay.BackColor = Color.WhiteSmoke;
            button_finish.BackColor = Color.WhiteSmoke;
        }
        int time_start, time_end;
        
        public void swap_rank()
        {
            Ranking swap = new Ranking();
            for (int i = 0; i < 4; i++)
            {
                for (int j = i + 1; j < 5; j++)
                {
                    if (ranking[i].score < ranking[j].score)
                    {
                        swap = ranking[i];
                        ranking[i] = ranking[j];
                        ranking[j] = swap;
                    }
                    else if (ranking[i].score == ranking[j].score && ranking[i].lead_time > ranking[j].lead_time)
                    {
                        swap = ranking[i];
                        ranking[i] = ranking[j];
                        ranking[j] = swap;
                    }
                }
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = i + 1; j < 5; j++)
                {
                    if (ranking[i].score == 0 && ranking[i].lead_time == 0 && ranking[j].lead_time != 0)
                    {
                        swap = ranking[i];
                        ranking[i] = ranking[j];
                        ranking[j] = swap;
                    }
                }
            }

        }

        public void ranking_show()
        {
            swap_rank();
            label1_score.Text = ranking[0].score.ToString();
            label2_score.Text = ranking[1].score.ToString();
            label33_score.Text = ranking[2].score.ToString();
            label4_score.Text = ranking[3].score.ToString();
            label5_score.Text = ranking[4].score.ToString();
            label6_score.Text = tempt.score.ToString();
            label1_start.Text = ranking[0].start_time;
            label2_start.Text = ranking[1].start_time;
            label3_start.Text = ranking[2].start_time;
            label4_start.Text = ranking[3].start_time;
            label5_start.Text = ranking[4].start_time;
            label6_start.Text = tempt.start_time;
            label1_end.Text = ranking[0].end_time;
            label2_end.Text = ranking[1].end_time;
            label3_end.Text = ranking[2].end_time;
            label4_end.Text = ranking[3].end_time;
            label5_end.Text = ranking[4].end_time;
            label6_end.Text = tempt.end_time;
            label1_lead.Text = ranking[0].lead_time.ToString() + " s";
            label2_lead.Text = ranking[1].lead_time.ToString() + " s";
            label3_lead.Text = ranking[2].lead_time.ToString() + " s";
            label4_lead.Text = ranking[3].lead_time.ToString() + " s";
            label5_lead.Text = ranking[4].lead_time.ToString() + " s";
            label6_lead.Text = tempt.lead_time.ToString() + " s";
        }

        List<Vehicles> vehicles = new List<Vehicles>()
        {
            new Vehicles("bike", "/baɪk/", Resources.bike, "pronunciation_en_bike.mp3"),
            new Vehicles("boat", "/bəʊt/", Resources.boat, "pronunciation_en_boat.mp3"),
            new Vehicles("bus", "/bʌs/", Resources.bus, "pronunciation_en_bus.mp3"),
            new Vehicles("car", "/kɑː(r)/", Resources.car, "pronunciation_en_car.mp3"),
            new Vehicles("motorbike", "/ˈməʊtəbaɪk/", Resources.motobike, "pronunciation_en_motorbike.mp3"),
            new Vehicles("plane", "/pleɪn/", Resources.plane, "pronunciation_en_plane.mp3"),
            new Vehicles("sailing", "/ˈseɪlɪŋ/", Resources.sailing, "pronunciation_en_sailing.mp3"),
            new Vehicles("ship", "/ʃɪp/", Resources.ship, "pronunciation_en_ship.mp3"),
            new Vehicles("train", "/treɪn/", Resources.train, "pronunciation_en_train.mp3"),
            new Vehicles("truck", "/trʌk/", Resources.truck, "pronunciation_en_truck.mp3"),
        };
        int Numrd, num1 = -1;
        private void random()
        {
            Random rd = new Random();
            while (true)
            {
                Numrd = rd.Next(0, 10);
                if (Numrd != num1)
                {
                    num1 = Numrd;
                    break;
                }
            }
            pictureBox_image.Image = vehicles[Numrd].Picture;
            label_name.Text = vehicles[Numrd].Name;
            label_ipa.Text = vehicles[Numrd].IPA;
            player.URL = vehicles[Numrd].Sound;
            player.controls.play();
        }

        int count_true = 0, count_false = 0, score = 0, count = 0;

        private void button_check_Click(object sender, EventArgs e)
        {
            if (textBox_type.Text == label_name.Text)
            {
                count_true++;
                score += 2;
                textBox_type.BackColor = Color.Green;
                label_correct.Text = count_true.ToString();
                label_score.Text = score.ToString();
            }
            else
            {
                count_false++;
                textBox_type.BackColor = Color.LightCoral;
                label_incorrect.Text = count_false.ToString();
            }
            label_name.Visible = true;
            button_check.Visible = false;
        }

        private void button_replay_Click(object sender, EventArgs e)
        {
            count_true = 0; count_false = 0; score = 0; count = 0;
            label_correct.Text = count_true.ToString();
            label_incorrect.Text = count_false.ToString();
            label_score.Text = score.ToString();
            label_name.Visible = false;
            button_check.Visible = true;
            button_finish.Visible = false;
            button_replay.Visible = false;
            button_next.Visible = true;
            textBox_type.Text = string.Empty;
            textBox_type.Visible = true;
            textBox_type.BackColor = Color.WhiteSmoke;
            tableLayoutPanel2.Visible = false;
            textBox_type.Focus();
            random();
            tempt.start_time = DateTime.Now.ToLongTimeString();
            time_start = DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second;
        }

        private void button_next_Click(object sender, EventArgs e)
        {
            if (count < 4)
            {
                button_check.Visible = true;
                label_name.Visible = false;
                textBox_type.Text = String.Empty;
                if (textBox_type.BackColor == Color.WhiteSmoke)
                {
                    count_false++;
                    label_incorrect.Text = count_false.ToString();
                }
                textBox_type.BackColor = Color.WhiteSmoke;
                textBox_type.Focus();
                random();
                count++;
            }
            else
            {
                if (textBox_type.BackColor == Color.WhiteSmoke)
                {
                    count_false++;
                    label_incorrect.Text = count_false.ToString();
                }
                button_next.Hide();
                button_check.Hide();
                button_finish.Visible = true;
                button_replay.Visible = true;
                textBox_type.Visible = false;
                tempt.score = score;
                tempt.end_time = DateTime.Now.ToLongTimeString();
                time_end = DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second;
                tempt.lead_time = time_end - time_start;
                if (tempt.lead_time != 0 && ranking[4].lead_time == 0)
                {
                    ranking[4] = tempt;
                }
                if (tempt.score > ranking[4].score)
                {
                    ranking[4] = tempt;
                }
                else if (tempt.score == ranking[4].score && tempt.lead_time < ranking[4].lead_time)
                {
                    ranking[4] = tempt;
                }
                ranking_show();
                tableLayoutPanel2.Visible = true;
                tableLayoutPanel2.BringToFront();
            }
        }

        private void button_finish_Click(object sender, EventArgs e)
        {
            count_true = 0; count_false = 0; score = 0; count = 0;
            label_correct.Text = count_true.ToString();
            label_incorrect.Text = count_false.ToString();
            label_score.Text = score.ToString();
            textBox_type.BackColor = Color.WhiteSmoke;
            textBox_type.Text = string.Empty;
            random();
            player.controls.stop();
            button_finish.Visible = false;
            label_name.Visible = false;
            tableLayoutPanel2.Visible = false;
            button_rank.Visible = true;
            button_list.Visible = true;
            button_play.Visible = true;
            button_back.Visible = false;
            label_correct.Visible = false;
            label_incorrect.Visible = false;
            label_score.Visible = false;
            Correct.Visible = false;
            Incorrect.Visible = false;
            label3_score.Visible = false;
            label_ipa.Visible = false;
            textBox_type.Visible = false;
            pictureBox_image.Visible = false;
            button_check.Visible = false;
            button_next.Visible = false;
            pictureBox_sound.Visible = false;
            button_replay.Visible = false;
            tableLayoutPanel2.Visible = false;
            button_play.Focus();
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            count_true = 0; count_false = 0; score = 0; count = 0;
            label_correct.Text = count_true.ToString();
            label_incorrect.Text = count_false.ToString();
            label_score.Text = score.ToString();
            textBox_type.BackColor = Color.WhiteSmoke;
            textBox_type.Text = string.Empty;
            random();
            player.controls.stop();
            button_finish.Visible = false;
            label_name.Visible = false;
            tableLayoutPanel_list.Visible = false;
            button_rank.Visible = true;
            button_list.Visible = true;
            button_play.Visible = true;
            button_back.Visible = false;
            label_correct.Visible = false;
            label_incorrect.Visible = false;
            label_score.Visible = false;
            Correct.Visible = false;
            Incorrect.Visible = false;
            label3_score.Visible = false;
            label_ipa.Visible = false;
            textBox_type.Visible = false;
            pictureBox_image.Visible = false;
            button_check.Visible = false;
            button_next.Visible = false;
            pictureBox_sound.Visible = false;
            button_replay.Visible = false;
            tableLayoutPanel2.Visible = false;
            button_play.Focus();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            player.URL = vehicles[0].Sound;
            player.controls.play();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            player.URL = vehicles[1].Sound;
            player.controls.play();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            player.URL = vehicles[2].Sound;
            player.controls.play();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            player.URL = vehicles[3].Sound;
            player.controls.play();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            player.URL = vehicles[4].Sound;
            player.controls.play();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            player.URL = vehicles[5].Sound;
            player.controls.play();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            player.URL = vehicles[6].Sound;
            player.controls.play();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            player.URL = vehicles[7].Sound;
            player.controls.play();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            player.URL = vehicles[8].Sound;
            player.controls.play();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            player.URL = vehicles[9].Sound;
            player.controls.play();
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox2.BackColor = Color.DarkGray;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.WhiteSmoke;
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox3.BackColor = Color.DarkGray;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.WhiteSmoke;
        }

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox4.BackColor = Color.DarkGray;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.WhiteSmoke;
        }

        private void pictureBox5_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox5.BackColor = Color.DarkGray;
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.BackColor = Color.WhiteSmoke;
        }

        private void pictureBox6_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox6.BackColor = Color.DarkGray;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.WhiteSmoke;
        }

        private void pictureBox7_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox7.BackColor = Color.DarkGray;
        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            pictureBox7.BackColor = Color.WhiteSmoke;
        }

        private void pictureBox8_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox8.BackColor = Color.DarkGray;
        }

        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
            pictureBox8.BackColor = Color.WhiteSmoke;
        }

        private void pictureBox9_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox9.BackColor = Color.DarkGray;
        }

        private void pictureBox9_MouseLeave(object sender, EventArgs e)
        {
            pictureBox9.BackColor = Color.WhiteSmoke;
        }

        private void pictureBox10_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox10.BackColor = Color.DarkGray;
        }

        private void pictureBox10_MouseLeave(object sender, EventArgs e)
        {
            pictureBox10.BackColor = Color.WhiteSmoke;
        }

        private void pictureBox11_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox11.BackColor = Color.DarkGray;
        }

        private void pictureBox11_MouseLeave(object sender, EventArgs e)
        {
            pictureBox11.BackColor = Color.WhiteSmoke;
        }

        private void vehicle_Load(object sender, EventArgs e)
        {
            ActiveControl = button_play;
        }

        private void pictureBox_sound_Click(object sender, EventArgs e)
        {
            player.controls.play();
        }

        private void pictureBox_sound_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox_sound.BackColor = Color.DarkGray;
        }

        private void pictureBox_sound_MouseLeave(object sender, EventArgs e)
        {
            pictureBox_sound.BackColor = Color.WhiteSmoke;
        }

        private void button_rank_Click(object sender, EventArgs e)
        {
            ranking_show();
            tableLayoutPanel2.Visible = true;
            button_rank.Visible = false;
            button_list.Visible = false;
            button_play.Visible = false;
            button_back.Visible = true;
            button_back.Focus();
        }

        private void button_list_Click(object sender, EventArgs e)
        {
            label_name.Visible = false;
            tableLayoutPanel_list.Visible = true;
            button_rank.Visible = false;
            button_list.Visible = false;
            button_play.Visible = false;
            button_back.Visible = true;
            label_correct.Visible = false;
            label_incorrect.Visible = false;
            label_score.Visible = false;
            Correct.Visible = false;
            Incorrect.Visible = false;
            label3_score.Visible = false;
            label_ipa.Visible = false;
            textBox_type.Visible = false;
            pictureBox_image.Visible = false;
            button_check.Visible = false;
            button_next.Visible = false;
            pictureBox_sound.Visible = false;
            button_back.Focus();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button_play_Click(object sender, EventArgs e)
        {
            time_start = DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second;
            tempt.start = time_start;
            tempt.start_time = DateTime.Now.ToLongTimeString();
            label_name.Visible = false;
            random();
            tableLayoutPanel_list.Visible = false;
            button_rank.Visible = false;
            button_list.Visible = false;
            button_play.Visible = false;
            button_back.Visible = true;
            label_correct.Visible = true;
            label_incorrect.Visible = true;
            label_score.Visible = true;
            Correct.Visible = true;
            Incorrect.Visible = true;
            label3_score.Visible = true;
            label_ipa.Visible = true;
            textBox_type.Visible = true;
            pictureBox_image.Visible = true;
            button_check.Visible = true;
            button_next.Visible = true;
            pictureBox_sound.Visible = true;
            textBox_type.Focus();
        }
    }
}
