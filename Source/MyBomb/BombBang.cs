using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyBomb
{
    class BombBang
    {
        DateTime Timer;
        Point Position;
        int[] dx = new int[4] { 0, 0, -1, 1 }, dy = new int[4] { -1, 1, 0, 0 };
        string[] End_Of_Fire = new string[4] { "EndUp", "EndDown", "EndLeft", "EndRight" }, Full_Fire = new string[2] { "UpAndDown", "LeftAndRight" };
        List<Point> points;
        bool DrawnOnce;
        List<Sprites> sprites;
        int Bomb_Length;
        public BombBang(DateTime Time, Point point, int[,] GameGrid, int BombLength)
        {
            Timer = Time.AddSeconds(0.4);
            Position = point;
            points = new List<Point>();
            DrawnOnce = false;
            sprites = new List<Sprites>();
            Bomb_Length = BombLength;
        }
        private Image LoadImage(string Link)
        {
            Image img = new Bitmap(Link);
            return new Bitmap(img, 60, 60);
        }
        public bool CheckNextPosition(int[,] GameGrid, int Direction, Point point, int Width, int Height)
        {
            Point p = point;
            p.X += dx[Direction] * 60; p.Y += dy[Direction] * 60;
            if (p.Y < 0 || p.Y + 60 >= Height || p.X < 0 || p.X + 60 >= Width) return true;
            return GameGrid[p.Y / 60, p.X / 60] == 3;
        }
        public void Draw(int[,] GameGrid, int[,] FireGrid, int[,] ItemGrid, Graphics buffer, int Width, int Height)
        {
            Point point;
            if (!DrawnOnce)
            {
                sprites.Add(new Sprites((@"Bomb/BombBang_Center.png"), 400, true));
                points.Add(Position);
                ItemGrid[Position.Y / 60, Position.X / 60] = 0;
                for (int d = 0; d < 4; d++)
                {
                    point = Position;
                    if (!CheckNextPosition(GameGrid, d, point, Width, Height))
                        for (int i = 1; i <= Bomb_Length; i++)
                        {
                            point.X += dx[d] * 60; point.Y += dy[d] * 60;
                            points.Add(point);
                            if (CheckNextPosition(GameGrid, d, point, Width, Height) || GameGrid[point.Y / 60, point.X / 60] == 2 || i == Bomb_Length)
                            {
                                if (GameGrid[point.Y / 60, point.X / 60] == 0) ItemGrid[point.Y / 60, point.X / 60] = 0;
                                GameGrid[point.Y / 60, point.X / 60] = 0;
                                sprites.Add(new Sprites(@"Bomb/BombBang_" + End_Of_Fire[d] + ".png", 400, true));
                                break;
                            }
                            ItemGrid[point.Y / 60, point.X / 60] = 0;
                            sprites.Add(new Sprites(@"Bomb/BombBang_" + Full_Fire[d / 2] + ".png", 400, true));
                        }
                }
            }
            for (int i = 0; i < sprites.Count(); i++)
            {
                FireGrid[points[i].Y / 60, points[i].X / 60] = 1;
                sprites[i].Draw(buffer, points[i]);
            }
            DrawnOnce = true;
        }
        public bool CheckTimer()
        {
            return DateTime.Now >= Timer;
        }
        public Point Coords()
        {
            return Position;
        }
    }
}