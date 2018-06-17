using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace MyBomb
{ 
    public partial class GameEx : Form
    {
        
        //private const int Width = 1200, Height = 600;
        // Ratio between calculate and readlity: 60:75
        GameData gameData;
        Bitmap buffer;
        int Score, TotalScore, Heart, Stage;
        DateTime StopTime;
        DateTime CountDownTime;
        Graphics graphics;
        Sound sound;
        int [] HighScore;
        public GameEx()
        {
            InitializeComponent();
            this.Size = new Size(1260, 660);
            buffer = new Bitmap(Width, Height);
            Score = 0; TotalScore = 0; Heart = 3; Stage = 0;
            graphics = this.CreateGraphics();
            gameData = new GameData(Stage);
            sound = new Sound(@"Sound/ThemeSoundInGame.wav");
            sound.PlaySound();
            HighScore = new int[3];
            timer2.Start();
        }

        private void GameEx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                StopTime = DateTime.Now;
                timer1.Stop();
                timer2.Stop();
                Message message = new Message("Are you sure want to quit and return to menu?");
                message.ShowDialog();
                if (message.isYes())
                {
                    sound.StopSound();
                    this.Close();
                    
                }
                timer1.Start();
                timer2.Start();
                gameData.SetNewTimer(StopTime);
            }

            if (gameData.BombersStepNumber() == 0)
            {
                #region Catching move key
                if (e.KeyCode == Keys.Up) gameData.PrepareMoveBomber(0, Width, Height);
                if (e.KeyCode == Keys.Down) gameData.PrepareMoveBomber(1, Width, Height);
                if (e.KeyCode == Keys.Left) gameData.PrepareMoveBomber(2, Width, Height);
                if (e.KeyCode == Keys.Right) gameData.PrepareMoveBomber(3, Width, Height);
                #endregion
            }

            if (e.KeyCode == Keys.Space) gameData.DropBomb();

           
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

        private void OutputScore()
        {
            String[] lines = new string[3];
            for (int i = 0; i < 3; i++)
                lines[i] = HighScore[i].ToString();
            File.WriteAllLines(@"Menu\HighScore.txt", lines);
        }

        private void Heart_Label_Click(object sender, EventArgs e)
        {

        }

        private void CheckRank()
        {
            InputScore();
            for (int i = 0; i < 3; i++)
                if (HighScore[i] < TotalScore)
                {
                    for (int j = 1; j >= i; j--)
                        HighScore[j + 1] = HighScore[j];
                    HighScore[i] = TotalScore;
                   
                    break;
                }
            OutputScore();
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            
            int ss = Int32.Parse(S_Label.Text);
            int mm = Int32.Parse(M_Label.Text);
            ss--;
            if (ss < 0)
            {
                ss = 59;
                mm--;
            }
            if (ss < 10)
            {
                S_Label.Text = "0" + ss;
            }
            else
                S_Label.Text = ss + "";
            if (mm < 10)
            {
                M_Label.Text = "" + mm;
            }
            else
                M_Label.Text = mm + "";
            if (ss == 0 && mm == 0)
            {
                timer2.Stop();
                timer1.Stop();
                CheckRank();
                HighScore highScore = new HighScore(HighScore,true);
                highScore.ShowDialog();
                Message message = new Message("Game over!\nDo you want to play new game?");
                message.ShowDialog();
                if (message.isYes())
                {
                    Score = 0; TotalScore = 0; Heart = 3; Stage = 0;
                    gameData = new GameData(Stage);
                    timer1.Start();
                }
                else
                {
                    sound.StopSound();
                    this.Close();
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            Heart_Label.Text = Heart.ToString();
            Score_Label.Text = Score.ToString();
            #region Update and Drawing Game Progress
            if (Heart == 0)
            {
                timer1.Stop();
                timer2.Stop();
                CheckRank();
                HighScore highScore = new HighScore(HighScore,true);
                highScore.ShowDialog();
                Message message = new Message("Game over!\nDo you want to play new game?");
                message.ShowDialog();
                if (message.isYes())
                {
                    Score = 0; TotalScore = 0; Heart = 3; Stage = 0;
                    gameData = new GameData(Stage);
                    timer1.Start();
                }
                else
                {
                    sound.StopSound();
                    this.Close();
                }
            }
            if (gameData.CheckWin())
            {
                Score = 0; Heart +=1; Stage = Stage + 1 % 2;
                gameData = new GameData(Stage);
            }

            gameData.CheckImpact(ref Score, ref TotalScore, ref Heart);
            Graphics bufferGraphics = Graphics.FromImage(buffer);
            bufferGraphics.Clear(Color.White);
            gameData.Draw(bufferGraphics, Width, Height);
            graphics.DrawImageUnscaled(buffer, 0, 0);

            gameData.MoveVillain();
            if (gameData.isBomberMoving())
                gameData.MoveBomber();
            #endregion
        }
    }
}