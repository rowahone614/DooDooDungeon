using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DooDooDungeon
{
    public partial class GameScreen : UserControl
    {
        public GameScreen()
        {
            InitializeComponent();
            OnStart();
        }

        Boolean leftKeyDown, rightKeyDown, downKeyDown, upKeyDown, wKeyDown, aKeyDown, sKeyDown, dKeyDown;
        Boolean turnCounter = true;
        Boolean doodooTopCollision = false;
        Boolean doodooBottomCollision = false;
        Boolean doodooRightCollision = false;
        Boolean doodooLeftCollision = false;

        int rollStartX = 20;
        int rollStartY = 20;

        int doodooStartX = 470;
        int doodooStartY = 447;

        int rollSize = 40;
        int doodooSize = 40;

        int moveCounter = 0;

        int x;
        int y;
        int Width = 0;
        int Height = 0;

        int levelNumber = 1;

        List<Wall> wallList = new List<Wall>();
        List<Rectangle> wallRecList = new List<Rectangle>();

        //used to draw walls on screen
        SolidBrush wallBrush = new SolidBrush(Color.Black);
        SolidBrush redBrush = new SolidBrush(Color.Red);

        int tickCounter = 0;

        Roll roll;
        DooDoo doodoo;
        private void gameTimer_Tick(object sender, EventArgs e)
        {

            x = roll.x;
            y = roll.y;

            DooDooWallHitBox();

            if (turnCounter && moveCounter == 0)
            {
                if (wKeyDown && roll.y - 62 >= 0)
                {
                    roll.direction = "Up";
                    roll.Move();
                    moveCounter++;
                    turnCounter = false;
                }
                else if (aKeyDown && roll.x - 75 >= 0)
                {
                    roll.direction = "Left";
                    roll.Move();
                    moveCounter++;
                    turnCounter = false;
                }
                else if (sKeyDown && roll.y + 102 <= 500)
                {
                    roll.direction = "Down";
                    roll.Move();
                    moveCounter++;
                    turnCounter = false;
                }
                else if (dKeyDown && roll.x + 122 <= 600)
                {
                    roll.direction = "Right";
                    roll.Move();
                    moveCounter++;
                    turnCounter = false;
                }
            }
            if (turnCounter == false && moveCounter > 0 && tickCounter > 10)
            {
                if (upKeyDown && doodoo.y - 62 >= 0 && doodooTopCollision == false)
                {
                    doodoo.direction = "Up";
                    SwitchMove();
                }
                else if (leftKeyDown && doodoo.x - 75 >= 0 && doodooLeftCollision == false)
                {
                    doodoo.direction = "Left";
                    SwitchMove();
                }
                else if (downKeyDown && doodoo.y + 102 <= 500 && doodooBottomCollision == false)
                {
                    doodoo.direction = "Down";
                    SwitchMove();

                }
                else if (rightKeyDown && doodoo.x + 122 <= 600 && doodooRightCollision == false)
                {
                    doodoo.direction = "Right";
                    SwitchMove();
                }
                tickCounter = 0;
            }


            if (turnCounter)
            {
                turnLabel.Text = "Roll's Turn";
            }
            else if (turnCounter == false)
            {
                turnLabel.Text = "Waste Warrior's Turn";
            }
            CollisionCheck();
            tickCounter++;
            Refresh();
        }

        public void CollisionCheck()
        {
            if (doodoo.Collision(roll))
            {
                gameTimer.Enabled = false;

                Form f = this.FindForm();
                GameOverScreen gos = new GameOverScreen();

                f.Controls.Remove(this);
                f.Controls.Add(gos);

                gos.Focus();
            }
        }

        public void SwitchMove()
        {
            doodoo.Move();
            moveCounter++;
            if (moveCounter == 3)
            {
                moveCounter = 0;
                turnCounter = true;
            }
        }
        public void OnStart()
        {
            LevelReading();

            roll = new Roll(rollStartX, rollStartY, rollSize, "None");
            doodoo = new DooDoo(doodooStartX, doodooStartY, doodooSize, "None");
        }
        #region Key Declaration
        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftKeyDown = false;
                    break;
                case Keys.Right:
                    rightKeyDown = false;
                    break;
                case Keys.Down:
                    downKeyDown = false;
                    break;
                case Keys.Up:
                    upKeyDown = false;
                    break;
                case Keys.W:
                    wKeyDown = false;
                    break;
                case Keys.A:
                    aKeyDown = false;
                    break;
                case Keys.S:
                    sKeyDown = false;
                    break;
                case Keys.D:
                    dKeyDown = false;
                    break;
            }
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftKeyDown = true;
                    break;
                case Keys.Right:
                    rightKeyDown = true;
                    break;
                case Keys.Down:
                    downKeyDown = true;
                    break;
                case Keys.Up:
                    upKeyDown = true;
                    break;
                case Keys.W:
                    wKeyDown = true;
                    break;
                case Keys.A:
                    aKeyDown = true;
                    break;
                case Keys.S:
                    sKeyDown = true;
                    break;
                case Keys.D:
                    dKeyDown = true;
                    break;
            }
        }
        #endregion

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Properties.Resources.New_Piskel__2_, roll.x, roll.y, roll.size, roll.size);
            e.Graphics.DrawImage(Properties.Resources.Waste_Warroir, doodoo.x, doodoo.y, doodoo.size, doodoo.size);

            Rectangle rightDooDooRec = new Rectangle(doodoo.x + 53, doodoo.y + 18, 10, 10);
            Rectangle leftDooDooRec = new Rectangle(doodoo.x - 24, doodoo.y + 18, 10, 10);
            Rectangle bottomDooDooRec = new Rectangle(doodoo.x + 15, doodoo.y - 14, 10, 10);
            Rectangle topDooDooRec = new Rectangle(doodoo.x + 15, doodoo.y + 48, 10, 10);

            e.Graphics.FillRectangle(redBrush, rightDooDooRec);
            e.Graphics.FillRectangle(redBrush, leftDooDooRec);
            e.Graphics.FillRectangle(redBrush, bottomDooDooRec);
            e.Graphics.FillRectangle(redBrush, topDooDooRec);

            //draw walls to screen
            foreach (Wall w in wallList)
            {
                e.Graphics.FillRectangle(wallBrush, w.x, w.y, w.Width, w.Height);
            }
        }

        public void LevelReading()
        {
            XmlReader reader = XmlReader.Create("Resources/Level" + Convert.ToString(levelNumber) + ".xml", null);

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Text)
                {
                    int x = Convert.ToInt16(reader.ReadString());

                    reader.ReadToFollowing("y");
                    int y = Convert.ToInt16(reader.ReadString());

                    reader.ReadToFollowing("Width");
                    int Width = Convert.ToInt16(reader.ReadString());

                    reader.ReadToFollowing("Height");
                    int Height = Convert.ToInt16(reader.ReadString());

                    Wall w = new Wall(x, y, Width, Height);

                    wallList.Add(w);
                }
            }
            reader.Close();
        }
    
        public void DooDooWallHitBox()
        {
            Rectangle rightDooDooRec = new Rectangle(doodoo.x + 53, doodoo.y + 18, 10, 10);
            Rectangle leftDooDooRec = new Rectangle(doodoo.x - 24, doodoo.y + 18, 10, 10);
            Rectangle bottomDooDooRec = new Rectangle(doodoo.x + 15, doodoo.y - 14, 10, 10);
            Rectangle topDooDooRec = new Rectangle(doodoo.x + 15, doodoo.y + 48, 10, 10);

            foreach (Wall l in wallList)
            {
                Rectangle wallRec = new Rectangle(l.x, l.y, l.Width, l.Height);
                wallRecList.Add(wallRec);
            }
            foreach (Rectangle r in wallRecList)
            {
                if(rightDooDooRec.IntersectsWith(r))
                {
                    doodooRightCollision = true;
                }
                else
                {
                    doodooRightCollision = false;
                }
            }
            foreach (Rectangle r in wallRecList)
            {
                if(leftDooDooRec.IntersectsWith(r))
                {
                    doodooLeftCollision = true;
                }
                else
                {
                    doodooLeftCollision = false;
                }
            }
            foreach (Rectangle r in wallRecList)
            {
                if (bottomDooDooRec.IntersectsWith(r))
                {
                    doodooBottomCollision = true;
                }
                else
                {
                    doodooBottomCollision = false;
                }
            }
            foreach (Rectangle r in wallRecList)
            {
                if (topDooDooRec.IntersectsWith(r))
                {
                    doodooTopCollision = true;
                }
                else
                {
                    doodooTopCollision = false;
                }
            }
        }

        //public void rollWallHitBox()
        //{

        //    Rectangle rightrollRec = new Rectangle(roll.x + 60, roll.y - 20, 10, 10);
        //    Rectangle leftrollRec = new Rectangle(roll.x - 60, roll.y - 20, 10, 10);
        //    Rectangle bottomrollRec = new Rectangle(roll.x + 20, roll.y - 60, 10, 10);
        //    Rectangle toprollRec = new Rectangle(roll.x + 20, roll.y + 20, 10, 10);

        //    foreach (Wall l in wallList)
        //    {
        //        Rectangle wallRec = new Rectangle(l.x, l.y, l.Width, l.Height);
        //        wallRecList.Add(wallRec);
        //    }
        //    foreach (Rectangle r in wallRecList)
        //    {
        //        if (rightrrollRec.IntersectsWith(r))
        //        {
        //            rollRightCollision = true;
        //        }
        //    }
        //}
    }
}
