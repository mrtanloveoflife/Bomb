using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using WMPLib;
namespace MyBomb
{
    public partial class GameUI_Form : Form
    {
        Sound sound;
        Sound soundPlay;
        Sound soundExit;
        int[] HighScore = new int[3];
        public GameUI_Form()
        {
            InitializeComponent();

            Back_Button.Hide();
            sound = new Sound(@"Sound/ThemeSound.wav");
            sound.PlaySound();
            soundPlay = new Sound(@"Sound/GameStart.wav");
            soundExit = new Sound(@"Sound/ByeBye.wav");
        }
        
        private void Quit_Button_Click(object sender, EventArgs e)
        {
            Message message = new Message("Are you sure want to quit the game?");
            message.ShowDialog();
            if (message.isYes())
            {
                DateTime timer = DateTime.Now.AddSeconds(1);
                while (timer >= DateTime.Now) soundExit.PlaySound();
                Application.Exit();
            }


        }
        private void Guide_Button_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = new Bitmap(@"Menu/Guide_Background.png");
            Play_Button.Hide(); HiScore_Button.Hide(); Guide_Button.Hide(); Quit_Button.Hide();
            Back_Button.Show();
        }

        private void Play_Button_Click(object sender, EventArgs e)
        {
            DateTime timer = DateTime.Now.AddSeconds(1);
            while (timer >= DateTime.Now) soundPlay.PlaySound();
            this.Hide();
            sound.StopSound();
            GameEx gameEx = new GameEx();
            gameEx.ShowDialog();
            this.Show();
            sound.PlaySound();
        }
        private void InputScore()
        {
            String[] lines;
            if (File.Exists(@"Menu\HighScore.txt"))
            {
                lines = File.ReadAllLines(@"Menu\HighScore.txt");
                for (int i = 0; i < 3; i++)
                    HighScore[i] = int.Parse(lines[i]);
            }
            else
            {
                lines = new string[3];
                for (int i = 0; i < 3; i++)
                    HighScore[i] = (3 - i) * 10;
            }
        }
        private void HiScore_Button_Click(object sender, EventArgs e)
        {
            InputScore();
            HighScore highscore = new HighScore(HighScore, false);
            highscore.ShowDialog();
        }
        private void Back_Button_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = new Bitmap(@"Menu/Menu_Background.jpg");
            Play_Button.Show(); HiScore_Button.Show(); Guide_Button.Show(); Quit_Button.Show();
            Back_Button.Hide();
        }


    }
}
