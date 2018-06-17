using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace MyBomb
{
    class Item
    {
        private string[] Effect = new string[3] { "BonusBomb", "BonusSpeed", "BonusLength" };
        List<Point> points;
        List<Sprites> sprites;
        public Item(int[,] ItemGrid, int Stage)
        {
            points = new List<Point>();
            sprites = new List<Sprites>();
            getData(ItemGrid, Stage);
        }
        public void getData(int[,] ItemGrid, int Stage)
        {
            int rows = 0;
            String[] lines = File.ReadAllLines(@"Map/Items" + Stage.ToString() + ".txt");
            rows = lines.Length;
            for (int i = 0; i < rows; i++)
            {
                int kk = int.Parse(lines[i].Split(' ')[0]);
                int ii = int.Parse(lines[i].Split(' ')[1]);
                int jj = int.Parse(lines[i].Split(' ')[2]);
                ItemGrid[ii, jj] = kk + 1;
                Point point = new Point(jj * 60, ii * 60);
                points.Add(point);
                sprites.Add(new Sprites(@"Map/Item_" + Effect[kk] + ".png", 1000, true));
            }
        }
        public void Draw(Graphics buffer, int[,] GameGrid, int[,] ItemGrid)
        {
            int i = 0;
            while (i < points.Count())
                if (ItemGrid[points[i].Y / 60, points[i].X / 60] == 0)
                {
                    points.RemoveAt(i);
                    sprites.RemoveAt(i);
                }
                else
                {
                    if (GameGrid[points[i].Y / 60, points[i].X / 60] == 0)
                        sprites[i].Draw(buffer, points[i]);
                    i++;
                }
        }
        public int Count()
        {
            return points.Count();
        }
        public Point Coords(int i)
        {
            return points[i];
        }
    }
}
