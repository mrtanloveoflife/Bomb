using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Timers;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Drawing.Text;

namespace MyBomb
{
    class Sprites
    {
        int curPosition, Frame;
        Bitmap sprite;
        DateTime Timer;
        int Transfer_Time;
        bool isTransfering;
        public Sprites(string Link, int LoopTime, bool setTransfer)
        {
            curPosition = 0;
            LoadImage(Link);
            Frame = sprite.Width / 60;
            Transfer_Time = LoopTime / Frame;
            Timer = DateTime.Now.AddMilliseconds(Transfer_Time);
            isTransfering = setTransfer;
        }
        public void LoadImage(string Link)
        {
            sprite = new Bitmap(Link);
        }
        public void Draw(Graphics buffer, Point Position)
        {
            if (isTransfering && Timer <= DateTime.Now)
            {
                curPosition = (curPosition + 1) % Frame;
                Timer = DateTime.Now.AddMilliseconds(Transfer_Time);
            }
            Rectangle rec = new Rectangle(curPosition * 60, 0, 60, 60);
            Image image = new Bitmap(sprite.Clone(rec, PixelFormat.DontCare), 60, 60);
            buffer.DrawImage(image, Position.X, Position.Y);
            //buffer.DrawImage(sprite, Position.X, Position.Y, new Rectangle(curPosition * 60, 0, 60, 60), GraphicsUnit.Pixel);
        }
        public void setTransfer(bool b)
        {
            isTransfering = b;
            curPosition = 0;
        }
    }
}