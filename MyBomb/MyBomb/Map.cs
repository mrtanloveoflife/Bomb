using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;


namespace MyBomb
{
    class Map
    {
        Graphics buffer;
        Image Backmap;
        Image ExLock;
        Image SoLock;
        Image UI;
        Image Avatar;
        Image Score;
        Image BlackScore;

        private Image LoadImage(string Link)
        {
            Image img = new Bitmap(Link);
            return new Bitmap(img, 60, 60);
        }
        private Image LoadImage1(string Link)
        {
            Image img = new Bitmap(Link);
            return new Bitmap(img, 60, 45);
        }
        public Map(int[,] GameGrid, int Stage)
        {
            Backmap = LoadImage(@"Map\BackgroundTile.png");
            ExLock = LoadImage(@"Map\ExplodableBlock.png");
            SoLock = LoadImage(@"Map\SolidBlock.png");
            UI = LoadImage1(@"GamePlay\Lock.png");
            Avatar = LoadImage1(@"GamePlay\Avatar.png");
            Score = LoadImage1(@"GamePlay\Score.png");
            BlackScore = LoadImage1(@"GamePlay\End.png");
            

            getData(GameGrid, Stage);
        }
        public void getData(int[,] GameGrid, int Stage)
        {
            int rows = 0;
            String[] lines = File.ReadAllLines(@"Map\ExLock" + Stage.ToString() + ".txt");
            rows = lines.Length;
            for (int i = 0; i < rows; i++)
            {
                int ii = int.Parse(lines[i].Split(' ')[0]);
                int jj = int.Parse(lines[i].Split(' ')[1]);
                GameGrid[ii, jj] = 2;
            }
        }
        public void DrawMap(int[,] GameGrid, Graphics buffer, int Width, int Height)
        {
            for (int i = 0; i < (Height / 60); i++)
            {
                for (int j = 0; j < (Width / 60); j++)
                {
                    buffer.DrawImage(Backmap, j * 60, i * 60);
                    if (j % 2 == 0 && i % 2 == 0)
                    {
                        buffer.DrawImage(SoLock, j * 60, i * 60);
                        GameGrid[i, j] = 3;
                    }
                    if (i == 0 || j == (Width / 60) - 1 || j == 0 || i == (Height / 60) - 1)
                    {
                        buffer.DrawImage(SoLock, j * 60, i * 60);
                        GameGrid[i, j] = 3;
                    }



                }
            }
            for(int i = 8; i<=12;i++)
            {
                if (i == 8)
                    buffer.DrawImage(Avatar, i * 60, 0);
                else if (i == 11)
                    buffer.DrawImage(Score, i * 60, 0);
                else if (i == 12)
                    buffer.DrawImage(BlackScore, i * 60, 0);
                else
                    buffer.DrawImage(UI, i * 60, 0);
            }
            for (int i = 0; i < (Height / 60); i++)
                for (int j = 0; j < (Width / 60); j++)
                    if (GameGrid[i, j] == 2)
                        buffer.DrawImage(ExLock, j * 60, i * 60);


        }
    }
}