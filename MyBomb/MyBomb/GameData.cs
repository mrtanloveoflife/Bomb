using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace MyBomb
{
    class GameData
    {
        const int MaxX = 21, MaxY = 11;
        int[] dx = new int[4]{ 0, 0, -1, 1 }, dy= new int[4] { -1, 1, 0, 0 };
        private Bomber bomber;
        BombList bombList;
        // GameGrid chứa dữ liệu của các vật thể đứng yên trong map, bao gồm: 
        // 0: ô trống, 1: bomb, 2: vật cản phá được, 3: vật cản không phá được.
        int[,] GameGrid = new int[MaxY,MaxX];
        // FireGrid chứa dữ liệu đường nổ, bao gồm:
        // 0: không nổ, 1: nổ;
        int[,] FireGrid = new int[MaxY, MaxX];
        // ItemGrid chứa dữ liệu item, bao gồm:
        // 0: ô trống, 1: thêm bomb, 2: chạy nhanh, 3: tăng độ dài bomb.
        int[,] ItemGrid = new int[MaxY, MaxX];
        BombBangList bombBangList;
        VillainList villainlist;
        Map map;
        Item item;
        Sound soundHit = new Sound(@"Sound\Hit.wav");
        Sound soundUpItem = new Sound(@"Sound\UpItem.wav");
        
        public GameData(int Stage)
        {

            villainlist = new VillainList(1, GameGrid, Stage);
            bomber = new Bomber(0, 60, 60);
            bombList = new BombList(bomber.BomberNumber());
            bombBangList = new BombBangList();
            for (int i = 0; i < MaxY; i++)
                for (int j = 0; j < MaxX; j++) GameGrid[i, j] = 0;
            for(int i = 0; i < MaxY; i++)
                for (int j = 0; j < MaxX; j++) FireGrid[i, j] = 0;
            for (int i = 0; i < MaxY; i++)
                for (int j = 0; j < MaxX; j++) ItemGrid[i, j] = 0;
            map = new Map(GameGrid, Stage);
            item = new Item(ItemGrid, Stage);
            
        }

        public void Draw(Graphics buffer, int Width, int Height)
        {
            map.DrawMap(GameGrid, buffer, Width, Height);
            item.Draw(buffer, GameGrid, ItemGrid);
            CheckTimerAndBlowUp(buffer);
            bombBangList.Draw(GameGrid, FireGrid, ItemGrid, buffer, Width, Height);
            bombList.Draw(buffer);
            bomber.Draw(buffer);
            villainlist.draw(buffer);
        }
        public Point PointOnGrid(Point point)
        {
            Point New_Point = new Point();
            int x = point.X, y = point.Y;
            New_Point.X = x / 60 * 60;
            if (x - New_Point.X >= 30) New_Point.X += 60;
            New_Point.Y = y / 60 * 60;
            if (y - New_Point.Y >= 30) New_Point.Y += 60;
            return New_Point;
        }
        #region Progress Moving
        public void MoveBomber()
        {
            bomber.Move();
        }
        private bool OnlyGoStraght(Point Coords, int Direction)
        {
            if (EmptyPoint(Coords, Direction))
                if (Direction / 2 == 0) return !EmptyPoint(Coords, 2) && !EmptyPoint(Coords, 3);
                else  return !EmptyPoint(Coords, 0) && !EmptyPoint(Coords, 1);
            return false;
        }

        // Hàm NearGamer trả về giá trị là hướng của quái cần di chuyển nếu nó ở gần nhân vật, ngược lại trả về -1.
        public int NearGamer(Point VCoords, Point BCoords, int[,] GameGrid)
        {
            int subX = VCoords.X / 60 - BCoords.X / 60, subY = VCoords.Y / 60 - BCoords.Y / 60;
            if (((subX == 0) && (Math.Abs(subY) >= 1) && (Math.Abs(subY) <= 2)) ||
                ((subY == 0) && (Math.Abs(subX) >= 1) && (Math.Abs(subX) <= 2)))
            {
                if (subX == 0)
                    if ((subY >= 1) && (subY <= 2) && EmptyPoint(VCoords, 0)) return 0;
                    else if (EmptyPoint(VCoords, 1)) return 1;
                if (subY == 0)
                    if ((subX >= 1) && (subX <= 2) && EmptyPoint(VCoords, 2)) return 2;
                    else if (EmptyPoint(VCoords, 3)) return 3;
            }
            return -1;
        }
        public void MoveVillain()
        {
            for (int i = 0; i < villainlist.Count(); i++)
            {
                if (villainlist.StepNumber(i) <= 0)
                {
                    Point Coords = villainlist.Coords(i);
                    int PreDirection = villainlist.Direction(i);
                    int j, d, k;
                    for (j = 0; j < 4; j++)
                        if (EmptyPoint(Coords, j)) break;
                    if (j == 4) continue;
                    // AI: Nếu chỉ có đường thẳng thì quái sẽ đi theo hướng trước đó đã đi
                    // Nếu đến ngã ba ngược ngã tư thì sẽ random hướng bất kể hướng trước đó là gì
                    // Nếu nhân vật đến gần quái trong phạm vi 1, 2 ô thì quái sẽ quay hướng đến người chơi ngay lập tức.
                    k = NearGamer(PointOnGrid(Coords), PointOnGrid(bomber.Coords()), GameGrid);
                    if (k >= 0) villainlist.PrepareToMove(i, k);
                    else if (OnlyGoStraght(Coords, PreDirection)) villainlist.PrepareToMove(i, PreDirection);
                    else
                    {
                        Random r = new Random();
                        d = r.Next(0, 4);
                        while (!EmptyPoint(Coords, d))
                            d = r.Next(0, 4);
                        villainlist.PrepareToMove(i, d);
                    }
                }
                if (villainlist.isMoving(i)) villainlist.Move(i);
            }
        }
        public bool EmptyPoint(Point p, int Direction)
        {
            int i = (p.Y + dy[Direction] * 60) / 60;
            int j = (p.X + dx[Direction] * 60) / 60;
            if (i < 0 || i > MaxY) return false;
            if (j < 0 || j > MaxX) return false;
            return GameGrid[i, j] == 0;
        }
        public void PrepareMoveBomber(int Direction, int Width, int Height)
        {
            if (EmptyPoint(bomber.Coords(), Direction))
                bomber.PrepareToMove(Direction);
        }
        public int BombersStepNumber()
        {
            return bomber.StepNumber();
        }
        public bool isBomberMoving()
        {
            return bomber.isMoving();
        }
        public bool isVillainMoving(int i)
        {
            return villainlist.isMoving(i);
        }
        #endregion
        #region Progress Bomb
        public void DropBomb()
        {
            Point Position = PointOnGrid(bomber.Coords());
            Sound soundDrop = new Sound(@"Sound/DropBom.wav");
            if (GameGrid[Position.Y / 60, Position.X / 60] == 0 && !bombList.isOutOfBomb())
            {
                GameGrid[Position.Y / 60, Position.X / 60] = 1;
                bombList.DropBomb(Position);
                soundDrop.PlaySound();

            }
        }
        public void SetNewTimer(DateTime StopTime)
        {
            bombList.SetNewTimer(StopTime);
        }
        public void CheckTimerAndBlowUp(Graphics buffer)
        {
            int i = 0;
            while (i < bombList.Count())
            {
                if (bombList.CheckTimer(i))
                    bombList.BOOM(i, GameGrid, bombBangList, bombList.BombLength());
                else i++;
            }
            i = 0;
            while (i < bombBangList.Count())
            {
                if (bombBangList.CheckTimer(i))
                {
                    bombBangList.Remove(i, ref GameGrid);
                }
                else i++;
            }
        }
        #endregion
        public void CheckImpact(ref int Score, ref int TotalScore, ref int Heart)
        {
            Point Coords;
            // Tương tác giữa bomb với người chơi
            if (!bomber.isFlickering())
            {
                Coords = PointOnGrid(bomber.Coords());
                if (FireGrid[Coords.Y / 60, Coords.X / 60] == 1)
                {
                    soundHit.PlaySound();
                    bomber.FlickerBomber(ref Heart);

                }
            }
            // Tương tác giữa bomb với quái
            for (int i = 0; i < villainlist.Count(); i++)
                if (!villainlist.isFlickering(i))
                {
                    Coords = PointOnGrid(villainlist.Coords(i));
                    if (FireGrid[Coords.Y / 60, Coords.X / 60] == 1)
                    {
                        villainlist.FlickerVillain(i);
                        Score += 10; TotalScore += 10;
                    }
                }
            // Tương tác giữa người chơi với quái
            if (!bomber.isFlickering())
                for (int i = 0; i < villainlist.Count(); i++)
                    if (PointOnGrid(bomber.Coords()) == PointOnGrid(villainlist.Coords(i)))
                    {
                        soundHit.PlaySound();
                        bomber.FlickerBomber(ref Heart);
                    }
            for (int i = 0; i < MaxY; i++)
                for (int j = 0; j < MaxX; j++) FireGrid[i, j] = 0;
            // Tương tác giữa người chơi với item
            for (int i = 0; i < item.Count(); i++)
            {
                Point coords = item.Coords(i);
                if (PointOnGrid(bomber.Coords()) == coords)
                {
                    switch (ItemGrid[coords.Y / 60, coords.X / 60])
                    {
                        case 1:
                            bombList.PlusNumberOfBomb();
                            break;
                        case 2:
                            bomber.Moving_Speed += 5;
                            break;
                        case 3:
                            bombList.PlusLength();
                            break;
                    }
                    ItemGrid[coords.Y / 60, coords.X / 60] = 0;
                    soundUpItem.PlaySound();
                }
            }
            // Tương tác giữa bomb với vật cản phá được, giữa bomb với item nằm trong class BombBang.
        }
        public bool CheckWin()
        {
            return villainlist.isAllVillainDead();
        }
    }
}