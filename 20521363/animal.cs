using _20521363.Model;
using _20521363.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using WMPLib;
using static _20521363.Main;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;


namespace _20521363
{
    public partial class animal : UserControl
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        Ranking[] ranking = Main.ranking_animal;
        Ranking tempt = new Ranking();
        public animal()
        {
            InitializeComponent();
            button_replay.BackColor = Color.Aqua;
            button_finish.BackColor = Color.Aqua;
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

        List<Animals> animals = new List<Animals>()
        {
            new Animals("bear", "/beə(r)/", Resources.bear, "pronunciation_en_bear.mp3"),
            new Animals("deer", "/dɪə(r)/", Resources.deer, "pronunciation_en_deer.mp3"),
            new Animals("kangaroo", "/ˌkæŋɡəˈruː/", Resources.kangaro, "pronunciation_en_kangaroo.mp3"),
            new Animals("koala", "/kəʊˈɑːlə/", Resources.koala, "pronunciation_en_koala.mp3"),
            new Animals("lion", "/ˈlaɪən/", Resources.lion, "pronunciation_en_lion.mp3"),
            new Animals("monkey", "/ˈmʌŋki/", Resources.monkey, "pronunciation_en_monkey.mp3"),
            new Animals("panda", "/ˈpændə/", Resources.panda, "pronunciation_en_panda.mp3"),
            new Animals("tiger", "/ˈtaɪɡə(r)/", Resources.tiger, "pronunciation_en_tiger.mp3"),
            new Animals("wolf", "/wʊlf/", Resources.wolf, "pronunciation_en_wolf.mp3"),
            new Animals("zebra", "/ˈzebrə/", Resources.zebra, "pronunciation_en_zebra.mp3"),
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
            pictureBox_image.Image = animals[Numrd].Picture;
            label_name.Text = animals[Numrd].Name;
            label_ipa.Text = animals[Numrd].IPA;
            player.URL = animals[Numrd].Sound;
            player.controls.play();
        }

        int count_true = 0, count_false = 0, score = 0, count = 0;

        private void button_ranking_Click(object sender, EventArgs e)
        {
            ranking_show();
            tableLayoutPanel1.Visible = true;
            button_ranking.Visible = false;
            button_list_words.Visible = false;
            button_play.Visible = false;
            button_back.Visible = true;
            ActiveControl = button_back;
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
            button_finish.Visible = false;
            label_name.Visible = false;
            tableLayoutPanel_list.Visible = false;
            button_ranking.Visible = true;
            button_list_words.Visible = true;
            button_play.Visible = true;
            button_back.Visible = false;
            label_correct.Visible = false;
            label_incorrect.Visible = false;
            label_score.Visible = false;
            label_aws_correct.Visible = false;
            label_aws_incorrect.Visible = false;
            label_result.Visible = false;
            label_ipa.Visible = false;
            textBox_type.Visible = false;
            pictureBox_image.Visible = false;
            button_check.Visible = false;
            button_Next.Visible = false;
            pictureBox_sound.Visible = false;
            button_replay.Visible = false;
            tableLayoutPanel1.Visible = false;
        }

        private void button_check_Click(object sender, EventArgs e)
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
        private void button_Next_Click(object sender, EventArgs e)
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
                button_Next.Hide();
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
                tableLayoutPanel1.Visible = true;
                tableLayoutPanel1.BringToFront();
            }
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
            pictureBox_sound.BackColor = Color.White;
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            player.URL = animals[0].Sound;
            player.controls.play();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            player.URL = animals[1].Sound;
            player.controls.play();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            player.URL = animals[2].Sound;
            player.controls.play();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            player.URL = animals[3].Sound;
            player.controls.play();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            player.URL = animals[4].Sound;
            player.controls.play();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            player.URL = animals[5].Sound;
            player.controls.play();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            player.URL = animals[6].Sound;
            player.controls.play();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            player.URL = animals[7].Sound;
            player.controls.play();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            player.URL = animals[8].Sound;
            player.controls.play();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            player.URL = animals[9].Sound;
            player.controls.play();
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox2.BackColor = Color.DarkGray;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Aqua;
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox3.BackColor = Color.DarkGray;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.Aqua;
        }

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox4.BackColor = Color.DarkGray;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.Aqua;
        }

        private void pictureBox5_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox5.BackColor = Color.DarkGray;
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.BackColor = Color.Aqua;
        }

        private void pictureBox6_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox6.BackColor = Color.DarkGray;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Aqua;
        }

        private void pictureBox7_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox7.BackColor = Color.DarkGray;
        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            pictureBox7.BackColor = Color.Aqua;
        }

        private void pictureBox8_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox8.BackColor = Color.DarkGray;
        }

        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
            pictureBox8.BackColor = Color.Aqua;
        }

        private void pictureBox9_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox9.BackColor = Color.DarkGray;
        }

        private void pictureBox9_MouseLeave(object sender, EventArgs e)
        {
            pictureBox9.BackColor = Color.Aqua;
        }

        private void pictureBox10_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox10.BackColor = Color.DarkGray;
        }

        private void pictureBox10_MouseLeave(object sender, EventArgs e)
        {
            pictureBox10.BackColor = Color.Aqua;
        }

        private void pictureBox11_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox11.BackColor = Color.DarkGray;
        }

        private void button_finish_Click(object sender, EventArgs e)
        {
            count_true = 0; count_false = 0; score = 0; count = 0;
            label_aws_correct.Text = count_true.ToString();
            label_aws_incorrect.Text = count_false.ToString();
            label_result.Text = score.ToString();
            textBox_type.BackColor = Color.White;
            textBox_type.Text = string.Empty;
            random();
            player.controls.stop();
            button_finish.Visible = false;
            label_name.Visible = false;
            tableLayoutPanel1.Visible = false;
            button_ranking.Visible = true;
            button_list_words.Visible = true;
            button_play.Visible = true;
            button_back.Visible = false;
            label_correct.Visible = false;
            label_incorrect.Visible = false;
            label_score.Visible = false;
            label_aws_correct.Visible = false;
            label_aws_incorrect.Visible = false;
            label_result.Visible = false;
            label_ipa.Visible = false;
            textBox_type.Visible = false;
            pictureBox_image.Visible = false;
            button_check.Visible = false;
            button_Next.Visible = false;
            pictureBox_sound.Visible = false;
            button_replay.Visible = false;
            button_play.Focus();
        }

        private void animal_Load(object sender, EventArgs e)
        {
            ActiveControl = button_play;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_replay_Click(object sender, EventArgs e)
        {
            count_true = 0; count_false = 0; score = 0; count = 0;
            label_aws_correct.Text = count_true.ToString();
            label_aws_incorrect.Text = count_false.ToString();
            label_result.Text = score.ToString();
            label_name.Visible = false;
            button_check.Visible = true;
            button_finish.Visible = false;
            button_replay.Visible = false;
            button_Next.Visible = true;
            textBox_type.Text = string.Empty;
            textBox_type.Visible = true;
            textBox_type.BackColor = Color.White;
            tableLayoutPanel1.Visible = false;
            textBox_type.Focus();
            random();
            tempt.start_time = DateTime.Now.ToLongTimeString();
            time_start = DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second;
        }

        private void pictureBox11_MouseLeave(object sender, EventArgs e)
        {
            pictureBox11.BackColor = Color.Aqua;
        }

        private void button_list_words_Click(object sender, EventArgs e)
        {
            label_name.Visible = false;
            tableLayoutPanel_list.Visible = true;
            button_ranking.Visible = false;
            button_list_words.Visible = false;
            button_play.Visible = false;
            button_back.Visible = true;
            label_correct.Visible = false;
            label_incorrect.Visible = false;
            label_score.Visible = false;
            label_aws_correct.Visible = false;
            label_aws_incorrect.Visible = false;
            label_result.Visible = false;
            label_ipa.Visible = false;
            textBox_type.Visible = false;
            pictureBox_image.Visible = false;
            button_check.Visible = false;
            button_Next.Visible = false;
            pictureBox_sound.Visible = false;
            button_back.Focus();
        }

        private void button_play_Click(object sender, EventArgs e)
        {
            time_start = DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second;
            tempt.start = time_start;
            tempt.start_time = DateTime.Now.ToLongTimeString();
            label_name.Visible = false;
            random();
            tableLayoutPanel_list.Visible = false;
            button_ranking.Visible = false;
            button_list_words.Visible = false;
            button_play.Visible = false;
            button_back.Visible = true;
            label_correct.Visible = true;
            label_incorrect.Visible = true;
            label_score.Visible = true;
            label_aws_correct.Visible = true;
            label_aws_incorrect.Visible = true;
            label_result.Visible = true;
            label_ipa.Visible = true;
            textBox_type.Visible = true;
            pictureBox_image.Visible = true;
            button_check.Visible = true;
            button_Next.Visible = true;
            pictureBox_sound.Visible = true;
            textBox_type.Focus();
        }
    }
}
