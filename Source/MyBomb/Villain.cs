using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBomb
{
    class Villain : MovingObject
    {
        private int Villain_Number;
        bool Flickering;
        DateTime FlickerTime;
        int Heart;
        public Villain(int n, int xx, int yy) // Khởi tạo với nhân vật n được chọn
        {
            Villain_Number = n - 1;
            sprite = new Sprites(@"Characters/Villain 0/Villain_down.png", 500, false);
            Position = new Point(xx, yy);
            Moving_Speed = Speed[n];
            Step_Before_Stand = 0;
            Moving_Time = DateTime.Now;
            Flickering = false;
            FlickerTime = DateTime.Now;
            Heart = 1;
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
                    sprite.LoadImage(@"Characters/Villain 0/Villain_up.png");
                    break;
                case 1:
                    sprite.LoadImage(@"Characters/Villain 0/Villain_down.png");
                    break;
                case 2:
                    sprite.LoadImage(@"Characters/Villain 0/Villain_left.png");
                    break;
                case 3:
                    sprite.LoadImage(@"Characters/Villain 0/Villain_right.png");
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
        }
        #endregion
        public int Heartt()
        {
            return Heart;
        }
        public bool isFlickering()
        {
            return Flickering;
        }
        public void FlickerVillain()
        {
            Heart--;
            Flickering = true;
            FlickerTime = DateTime.Now.AddSeconds(2);
        }
    }
}

