using _20521363.Model;
using _20521363.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using WMPLib;
using static _20521363.Main;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _20521363
{
    public partial class Fruit_card : UserControl
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        int time_start, time_end;

        Ranking[] ranking = Main.ranking_fruit;
        Ranking tempt = new Ranking();
        
        public void swap_rank()
        {
            Ranking swap = new Ranking();
            for (int i = 0; i < 4; i++)
            {
                for (int j = i+1; j<5; j++)
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

        
        public Fruit_card()
        {
            InitializeComponent();
            button_check.BackColor = Color.Gainsboro;
            button_next.BackColor = Color.Gainsboro;
            button_replay.BackColor = Color.Gainsboro;
            button2.BackColor = Color.Gainsboro;
        }
        int Numrd, num1 = -1, count = 0;
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
            pictureBox1.Image = fruit_card[Numrd].Picture;
            label_name.Text = fruit_card[Numrd].Name;
            label_ipa.Text = fruit_card[Numrd].IPA;
            player.URL = fruit_card[Numrd].Sound;
            player.controls.play();
        }

        public void ranking_show()
        {
            swap_rank();
            label1_score.Text = ranking[0].score.ToString();
            label2_score.Text = ranking[1].score.ToString();
            label3_score.Text = ranking[2].score.ToString();
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

        List<Fruit> fruit_card = new List<Fruit>()
        {
            new Fruit("apple", "/ˈæpl/", Resources.apple,"pronunciation_en_apple.mp3"),
            new Fruit("avocado", "/ˌævəˈkɑːdəʊ/", Resources.avocado,"pronunciation_en_avocado.mp3"),
            new Fruit("banana", "/bəˈnɑːnə/", Resources.banana, "pronunciation_en_banana.mp3"),
            new Fruit ("cherry", "/ˈtʃeri/", Resources.cherry, "pronunciation_en_cherry.mp3"),
            new Fruit ("kiwi", "/ˈkiːwi/", Resources.kiwi, "pronunciation_en_kiwi.mp3"),
            new Fruit ("lemon", "/ˈlemən/", Resources.lemon, "pronunciation_en_lemon.mp3"),
            new Fruit ("mango","/ˈmæŋɡəʊ/", Resources.mango, "pronunciation_en_mango.mp3"),
            new Fruit ("orange","/ˈɒrɪndʒ/", Resources.orange, "pronunciation_en_orange.mp3"),
            new Fruit ("pear","/peə(r)/", Resources.pear, "pronunciation_en_pear.mp3"),
            new Fruit ("watermelon","/ˈwɔːtəmelən/", Resources.watermelon, "pronunciation_en_watermelon.mp3"),
        };

        int count_true = 0, count_false = 0, score = 0;
        private void button_check_Click_1(object sender, EventArgs e)
        {
            if (textBox_type.Text == label_name.Text)
            {
                count_true++;
                score += 2;
                textBox_type.BackColor = Color.Green;
                label_aws_correct.Text = count_true.ToString();
                label_result.Text = score.ToString(); 
            }
            else
            {
                count_false++;
                textBox_type.BackColor = Color.LightCoral;
                label_aws_incorrect.Text = count_false.ToString();
            }
            label_name.Visible = true;
            button_check.Visible = false;
        }

        private void button_next_Click(object sender, EventArgs e)
        {
            if (count < 4)
            {
                button_check.Visible = true;
                label_name.Visible = false;
                textBox_type.Text = String.Empty;
                if (textBox_type.BackColor == Color.White)
                {
                    count_false++;
                    label_aws_incorrect.Text = count_false.ToString();
                }
                textBox_type.BackColor = Color.White;
                textBox_type.Focus();
                random();
                count++;
            }
            else
            {
                if (textBox_type.BackColor == Color.White)
                {
                    count_false++;
                    label_aws_incorrect.Text = count_false.ToString();
                }
                button_next.Hide();
                button_check.Hide();
                button2.Visible = true;
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
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            player.URL = fruit_card[0].Sound;
            player.controls.play();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            player.URL = fruit_card[1].Sound;
            player.controls.play();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            player.URL = fruit_card[2].Sound;
            player.controls.play();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            player.URL = fruit_card[3].Sound;
            player.controls.play();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            player.URL = fruit_card[4].Sound;
            player.controls.play();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            player.URL = fruit_card[5].Sound;
            player.controls.play();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            player.URL = fruit_card[6].Sound;
            player.controls.play();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            player.URL = fruit_card[7].Sound;
            player.controls.play();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            player.URL = fruit_card[8].Sound;
            player.controls.play();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            player.URL = fruit_card[9].Sound;
            player.controls.play();
        }

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox4.BackColor = Color.DarkGray;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.Gainsboro;
        }

        private void pictureBox5_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox5.BackColor = Color.DarkGray;
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.BackColor = Color.Gainsboro;
        }

        private void pictureBox6_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox6.BackColor = Color.DarkGray;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Gainsboro;
        }

        private void pictureBox7_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox7.BackColor = Color.DarkGray;
        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            pictureBox7.BackColor = Color.Gainsboro;
        }

        private void pictureBox8_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox8.BackColor = Color.DarkGray;
        }

        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
            pictureBox8.BackColor = Color.Gainsboro;
        }

        private void pictureBox9_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox9.BackColor = Color.DarkGray;
        }

        private void pictureBox9_MouseLeave(object sender, EventArgs e)
        {
            pictureBox9.BackColor = Color.Gainsboro;
        }

        private void pictureBox10_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox10.BackColor = Color.DarkGray;
        }

        private void pictureBox10_MouseLeave(object sender, EventArgs e)
        {
            pictureBox10.BackColor = Color.Gainsboro;
        }

        private void pictureBox11_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox11.BackColor = Color.DarkGray;
        }

        private void pictureBox11_MouseLeave(object sender, EventArgs e)
        {
            pictureBox11.BackColor = Color.Gainsboro;
        }

        private void pictureBox12_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox12.BackColor = Color.DarkGray;
        }

        private void pictureBox12_MouseLeave(object sender, EventArgs e)
        {
            pictureBox12.BackColor = Color.Gainsboro;
        }

        private void pictureBox13_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox13.BackColor = Color.DarkGray;
        }

        private void pictureBox13_MouseLeave(object sender, EventArgs e)
        {
            pictureBox13.BackColor = Color.Gainsboro;
        }

        private void pictureBox_Sound_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox_Sound.BackColor = Color.DarkGray;
        }

        private void button_replay_Click(object sender, EventArgs e)
        {
            count_true = 0; count_false = 0; score = 0; count = 0;
            label_aws_correct.Text = count_true.ToString();
            label_aws_incorrect.Text = count_true.ToString();
            label_result.Text = score.ToString();
            label_name.Visible = false;
            textBox_type.BackColor = Color.White;
            textBox_type.Text = string.Empty;
            button_check.Visible = true;
            button_next.Visible = true;
            button2.Visible = false;
            button_replay.Visible = false;
            textBox_type.Visible = true;
            tableLayoutPanel2.Visible = false;
            textBox_type.Focus();
            random();
            tempt.start_time = DateTime.Now.ToLongTimeString();
            time_start = DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second;
        }

        private void pictureBox_Sound_MouseLeave(object sender, EventArgs e)
        {
            pictureBox_Sound.BackColor= Color.White;
        }

        private void button_rank_Click(object sender, EventArgs e)
        {
            ranking_show();
            tableLayoutPanel2.Visible = true;
            button_rank.Visible = false;
            button_list.Visible = false;
            button1.Visible = false;
            button_back.Visible = true;
            button_back.Focus();
        }

        private void Fruit_card_Load(object sender, EventArgs e)
        {
            ActiveControl = button1;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            count_true = 0; count_false = 0; score = 0; count = 0;
            label_aws_correct.Text = count_true.ToString();
            label_aws_incorrect.Text = count_false.ToString();
            label_result.Text = score.ToString();
            textBox_type.BackColor = Color.White;
            textBox_type.Text = string.Empty;
            random();
            player.controls.stop();
            button2.Visible = false;
            label_name.Visible = false;
            tableLayoutPanel1.Visible = false;
            button_rank.Visible = true;
            button_list.Visible = true;
            button1.Visible = true;
            button_back.Visible = false;
            label_correct.Visible = false;
            label_incorrect.Visible = false;
            label_score.Visible = false;
            label_aws_correct.Visible = false;
            label_aws_incorrect.Visible = false;
            label_result.Visible = false;
            label_ipa.Visible = false;
            textBox_type.Visible = false;
            pictureBox1.Visible = false;
            button_check.Visible = false;
            button_next.Visible = false;
            pictureBox_Sound.Visible = false;
            button_replay.Visible = false;
            tableLayoutPanel2.Visible = false;
            button1.Focus();
        }

        private void button_list_Click(object sender, EventArgs e)
        {
            label_name.Visible = false;
            tableLayoutPanel1.Visible = true;
            button_rank.Visible = false;
            button_list.Visible = false;
            button1.Visible = false;
            button_back.Visible = true;
            label_correct.Visible = false;
            label_incorrect.Visible = false;
            label_score.Visible = false;
            label_aws_correct.Visible = false;
            label_aws_incorrect.Visible = false;
            label_result.Visible = false;
            label_ipa.Visible = false;
            textBox_type.Visible = false;
            pictureBox1.Visible = false;
            button_check.Visible = false;
            button_next.Visible = false;
            pictureBox_Sound.Visible = false;
            button_back.Focus();
        }

        private void button_back_Click(object sender, EventArgs e)
        {
                count_true = 0; count_false = 0; score = 0; count = 0;
                label_aws_correct.Text = count_true.ToString();
                label_aws_incorrect.Text = count_false.ToString();
                label_result.Text = score.ToString();
                textBox_type.BackColor = Color.White;
                textBox_type.Text = string.Empty;
                random();
                player.controls.stop();
                button2.Visible = false;
                label_name.Visible = false;
                tableLayoutPanel1.Visible = false;
                button_rank.Visible = true;
                button_list.Visible = true;
                button1.Visible = true;
                button_back.Visible = false;
                label_correct.Visible = false;
                label_incorrect.Visible = false;
                label_score.Visible = false;
                label_aws_correct.Visible = false;
                label_aws_incorrect.Visible = false;
                label_result.Visible = false;
                label_ipa.Visible = false;
                textBox_type.Visible = false;
                pictureBox1.Visible = false;
                button_check.Visible = false;
                button_next.Visible = false;
                pictureBox_Sound.Visible = false;
                button_replay.Visible = false;
                tableLayoutPanel2.Visible = false;
                button1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            time_start = DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second;
            tempt.start = time_start;
            tempt.start_time = DateTime.Now.ToLongTimeString();
            label_name.Visible = false;
            random();
            tableLayoutPanel1.Visible = false;
            button_rank.Visible = false;
            button_list.Visible = false;
            button1.Visible = false;
            button_back.Visible = true;
            label_correct.Visible = true;
            label_incorrect.Visible = true;
            label_score.Visible = true;
            label_aws_correct.Visible = true;
            label_aws_incorrect.Visible = true;
            label_result.Visible = true;
            label_ipa.Visible = true;
            textBox_type.Visible = true;
            pictureBox1.Visible = true;
            button_check.Visible = true;
            button_next.Visible = true;
            pictureBox_Sound.Visible = true;
            textBox_type.Focus();
        }

        private void pictureBox_Sound_Click(object sender, EventArgs e)
        {
            player.controls.play();
        }
    }
}
