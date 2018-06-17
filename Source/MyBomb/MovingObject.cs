using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyBomb
{
    class MovingObject
    {
        public const int Add_Coords = 60, Frame_Per_Move = 6, Pix_Per_Step = Add_Coords / Frame_Per_Move, Default_Move_Time = 60; // Tọa độ di chuyển trong form, số khung hình trung gian
        public Point Position; // Tọa độ nhân vật
        public int Direction; // Hướng nhân vật
        public DateTime Moving_Time;
        public int Moving_Speed; // Tốc độ chạy
        public int[] Speed = new int[2] { 2, 1 }; // Tốc độ chạy từng nhân vật
        public int Step_Before_Stand; // Số bước đi trước khi dừng
        public Sprites sprite; // Hình ảnh nhân vật

        /*public Point Position { get { return Pos; } set { Pos = value; } }
        public int Direction { get { return Direct; } set { Direct = value; } }
        public DateTime MovingTime { get { return Time_To_Move; } set { Time_To_Move = value; } }
        public int MovingSpeed { get { return Character_Speed; } set { Character_Speed = value; } }
        public int StepBeforeStand { get { return Step_Before_Stand; } set { Step_Before_Stand = value; } }
        public int[]  Speed { get { return SpeedArr; }}
        public Image Image { get { return IMG; } set { IMG = value; } }*/
    }
}
