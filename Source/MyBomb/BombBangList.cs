using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyBomb
{
    class BombBangList
    {
        List<BombBang> BombBangs;
        public BombBangList()
        {
            BombBangs = new List<BombBang>();
        }
        public int Count()
        {
            return BombBangs.Count();
        }
        public Point Coords(int i)
        {
            return BombBangs[i].Coords();
        }
        public void Add(Point point, int[,] GameGrid, int Bomb_Length)
        {
            BombBangs.Add(new BombBang(DateTime.Now, point, GameGrid, Bomb_Length));
        }
        public bool CheckTimer(int i)
        {
            return BombBangs[i].CheckTimer();
        }
        public void Remove(int ii, ref int[,] GameGrid)
        {
            BombBangs.RemoveAt(ii);
        }
        public void Draw(int[,] GameGrid, int[,] FireGrid, int[,] ItemGrid, Graphics buffer, int Width, int Height)
        {
            for (int i = 0; i < BombBangs.Count(); i++)
                BombBangs[i].Draw(GameGrid, FireGrid, ItemGrid, buffer, Width, Height);
        }
    }
}
