using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyBomb
{
    class Bomb
    {
        private Point Position;
        DateTime Timer;
        Sprites sprite;
        bool BlowingUp;
        int Bomb_Length;
        public Bomb(Point point, int BombLength)
        {
            Position = point;
            sprite = LoadImage();
            BlowingUp = false;
            Timer = DateTime.Now.AddSeconds(3);
            Bomb_Length = BombLength;
        }
        private Sprites LoadImage()
        {
            Sprites sprite = new Sprites(@"Bomb/Bomb.png", 1000, true);
            return sprite;
        }
        public bool isBlowingUp()
        {
            return BlowingUp;
        }
        public void setBlowingUp()
        {
            BlowingUp = true;
        }
        public Point Coords()
        {
            return Position;
        }
        public void Draw(Graphics buffer)
        {
            sprite.Draw(buffer, Position);
        }
        public void SetNewTimer(DateTime StopTime)
        {
            DateTime timer = Timer;
            Timer = Timer.Add(DateTime.Now.Subtract(StopTime));
        }
        public bool CheckTimer()
        {
            return DateTime.Now >= Timer;
        }
        public int BombLength()
        {
            return Bomb_Length;
        }
    }
}
