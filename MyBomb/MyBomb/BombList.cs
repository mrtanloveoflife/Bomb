using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyBomb
{
    class BombList
    {
        private List<Bomb> bombs = new List<Bomb>();
        const int Width = 1200, Height = 600;
        int Bomb_Length, Number_of_Bomb;
        int[] Number = new int[2] { 2, 1 }, Length = new int[2] { 1, 2 }, dx= new int[4] { 0, 0, -1, 1 }, dy= new int[4] { -1, 1, 0, 0 };
        public BombList(int Bomber_Number)
        {
            Bomb_Length = Length[Bomber_Number];
            Number_of_Bomb = Number[Bomber_Number];
        }
        public int Count()
        {
            return bombs.Count;
        }
        public int BombLength()
        {
            return Bomb_Length;
        }
        public bool CheckTimer(int i)
        {
            return bombs[i].CheckTimer();
        }
        public Point Coords(int i)
        {
            return bombs[i].Coords();
        }
        public void Draw(Graphics buffer)
        {
            for (int i = 0; i < bombs.Count; i++)
                bombs[i].Draw(buffer);
        }
        public void SetNewTimer(DateTime StopTime)
        {
            for (int i=0;i<bombs.Count;i++)
            {
                bombs[i].SetNewTimer(StopTime);
            }
        }
        public bool OutOfMap(int Direction, Point p, int Width, int Height)
        {
            switch (Direction)
            {
                case 0:
                    return p.Y - 60 < 0;
                case 1:
                    return p.Y + 60 * 2 >= Height;
                case 2:
                    return p.X - 60 < 0;
                case 3:
                    return p.X + 60 * 2 >= Width;
            }
            return false;
        }
        // Thực hiện nổ bomb đã hết giờ và các quả bomb nằm trên đường nổ.
        public void BOOM(int bomb_number, int[,] GameGrid, BombBangList bombBangList, int Bomb_Length)
        {
            Sound sound;
            Point point = bombs[bomb_number].Coords();
            GameGrid[point.Y / 60, point.X / 60] = 0;
            if (!bombs[bomb_number].isBlowingUp())
            {
                sound = new Sound(@"Sound/BomBang.wav");
                sound.PlaySound();
                bombBangList.Add(point, GameGrid, bombs[bomb_number].BombLength());
                for (int d = 0; d < 4; d++)
                {
                    bombs[bomb_number].setBlowingUp();
                    point = bombs[bomb_number].Coords();
                    for (int i = 0; i < Bomb_Length; i++)
                    {
                        if (OutOfMap(d, point, Width, Height)) break;
                        point.X += dx[d] * 60; point.Y += dy[d] * 60;
                        if (GameGrid[point.Y / 60, point.X / 60] == 1)
                        {
                            for (int j = 0; j < bombs.Count; j++)
                                if (point == bombs[j].Coords())
                                {
                                    BOOM(j, GameGrid, bombBangList, Bomb_Length);
                                    break;
                                }
                            break;
                        }
                        if (GameGrid[point.Y / 60, point.X / 60] > 1) break;
                    }
                }
                point = bombs[bomb_number].Coords();
                GameGrid[point.Y / 60, point.X / 60] = 0;
            }
            bombs.RemoveAt(bomb_number);
        }
        public bool isOutOfBomb()
        {
            return bombs.Count >= Number_of_Bomb;
        }
        public void DropBomb(Point point)
        {
                bombs.Add(new Bomb(point, Bomb_Length));
        }
        public void PlusLength()
        {
            Bomb_Length++;
        }
        public void PlusNumberOfBomb()
        {
            Number_of_Bomb++;
        }
    }
}
