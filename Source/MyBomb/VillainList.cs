using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace MyBomb
{
    class VillainList
    {
        List<Villain> villains=new List<Villain>();  
        public VillainList(int n, int[,] GameGrid, int Stage)
        {
            getData(n, GameGrid, Stage);
        }
        public void getData(int n, int[,] GameGrid, int Stage)
        {
            int rows = 0;
            String[] lines = File.ReadAllLines(@"Map\Villains" + Stage.ToString() + ".txt");
            rows = lines.Length;
            for (int i = 0; i < rows; i++)
            {
                int ii = int.Parse(lines[i].Split(' ')[0]);
                int jj = int.Parse(lines[i].Split(' ')[1]);
                villains.Add(new Villain(n, jj * 60, ii * 60));
            }
        }
        public int Count()
        {
            return villains.Count();
        }
        public Point Coords(int i)
        {
            return villains[i].Coords();
        }
        public void draw(Graphics buffer)
        {
            for (int i = 0; i < villains.Count(); i++)
                villains[i].Draw(buffer); 
        }
        public int Direction(int i)
        {
            return villains[i].Direction;
        }
        public int StepNumber(int i)
        {
            return villains[i].Step_Before_Stand;
        }
        public bool isMoving(int i)
        {
            return villains[i].isMoving();
        }
        public bool ItsTimeToMove(int i)
        {
            return villains[i].ItsTimeToMove();
        }
        public void Move(int i)
        {
            villains[i].Move();
        }
        public void PrepareToMove(int i, int Direction)
        {
            villains[i].PrepareToMove(Direction);
        }
        public void FlickerVillain(int i)
        {
            if (villains[i].Heartt() - 1 == 0) villains.RemoveAt(i);
            else villains[i].FlickerVillain();
        }
        public bool isFlickering(int i)
        {
            return villains[i].isFlickering();
        }
        public bool isAllVillainDead()
        {
            return villains.Count() == 0;
        }
    }
}
