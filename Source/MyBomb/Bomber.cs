using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MyBomb
{
    class Bomber : MovingObject
    {
        private int Bomber_Number;
        bool Flickering;
        DateTime FlickerTime;
        public Bomber(int n, int xx, int yy) // Khởi tạo với nhân vật n được chọn
        {
            Bomber_Number = n;
            Position = new Point(xx, yy);
            sprite = new Sprites(@"Characters/Bomber/Bomber_Down.PNG", 500, false);
            Moving_Speed = Speed[n];
            Step_Before_Stand = 0;
            Moving_Time = DateTime.Now;
            Flickering = false;
            FlickerTime = DateTime.Now;
        }
        public int BomberNumber()
        {
            return Bomber_Number;
        }
        public int StepNumber()
        {
            return Step_Before_Stand;
        }
        public Point Coords()
        {
            return Position;
        }
        public void Draw(Graphics buffer)
        {
            if (Flickering && DateTime.Now >= FlickerTime) Flickering = false;
            if (Flickering && DateTime.Now.Ticks % 2 == 0) return;
            sprite.Draw(buffer, Position);
        }
        #region Handling Moving Progress
        #region Handling Moving Direction
        private void Move_Up(int Next_Position)
        {
            Position.Y -= Next_Position;
        }
        private void Move_Down(int Next_Position)
        {
            Position.Y += Next_Position;
        }
        private void Move_Left(int Next_Position)
        {
            Point point = new Point(Position.X, Position.Y - Next_Position);
            Position.X -= Next_Position;
        }
        private void Move_Right(int Next_Position)
        {
            Position.X += Next_Position;
        }
        #endregion
        public bool isMoving()
        {
            return Step_Before_Stand > 0 && ItsTimeToMove();
        }
        public void PrepareToMove(int Direct)
        {
            Direction = Direct;
            Step_Before_Stand = Frame_Per_Move;
            Moving_Time = DateTime.Now.AddMilliseconds(Default_Move_Time / Moving_Speed);
            switch (Direction)
            {
                case 0:
                    sprite.LoadImage(@"Characters/Bomber/Bomber_Up.PNG");
                    break;
                case 1:
                    sprite.LoadImage(@"Characters/Bomber/Bomber_Down.PNG");
                    break;
                case 2:
                    sprite.LoadImage(@"Characters/Bomber/Bomber_Left.PNG");
                    break;
                case 3:
                    sprite.LoadImage(@"Characters/Bomber/Bomber_Right.PNG");
                    break;
            }
            sprite.setTransfer(true);
        }
        public bool ItsTimeToMove()
        {
            return DateTime.Now >= Moving_Time;
        }
        public void Move()
        {
            Step_Before_Stand--;
            switch (Direction)
            {
                case 0:
                    Move_Up(Pix_Per_Step);
                    break;
                case 1:
                    Move_Down(Pix_Per_Step);
                    break;
                case 2:
                    Move_Left(Pix_Per_Step);
                    break;
                case 3:
                    Move_Right(Pix_Per_Step);
                    break;
            }
            Moving_Time = DateTime.Now.AddMilliseconds(Default_Move_Time / Moving_Speed);
            if (Step_Before_Stand == 0) sprite.setTransfer(false);
        }
        #endregion
        public bool isFlickering()
        {
            return Flickering;
        }
        public void FlickerBomber(ref int Heart)
        {
            Heart--;
            Flickering = true;
            FlickerTime = DateTime.Now.AddSeconds(2);
        }
    }

}