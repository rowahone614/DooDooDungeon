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
using System.Threading;
using System.Media;

namespace DooDooDungeon
{
    public partial class GameScreen : UserControl
    {
        public GameScreen()
        {
            InitializeComponent();
            OnStart();
        }

        Boolean leftKeyDown, rightKeyDown, downKeyDown, upKeyDown, wKeyDown, aKeyDown, sKeyDown, dKeyDown, spaceKeyDown, rKeyDown;
        Boolean turnCounter = true;
        Boolean levelLabelVisible = true;
        Boolean doodooTopCollision = false;
        Boolean doodooBottomCollision = false;
        Boolean doodooRightCollision = false;
        Boolean doodooLeftCollision = false;
        Boolean rollTopCollision = false;
        Boolean rollBottomCollision = false;
        Boolean rollRightCollision = false;
        Boolean rollLeftCollision = false;
        Boolean wallPlaced = false;

        int rollStartX = 20;
        int rollStartY = 20;

        int doodooStartX = 470;
        int doodooStartY = 447;

        int rollSize = 40;
        int doodooSize = 40;

        int moveCounter = 0;

        int wallOrientation;

        int grateX;
        int grateY;
        int grateWidth;
        int grateHeight;

        int levelNumber = 1;

        List<Wall> wallList = new List<Wall>();

        //used to draw walls on screen
        SolidBrush wallBrush = new SolidBrush(Color.Black);
        SolidBrush redBrush = new SolidBrush(Color.Red);

        Rectangle rightDooDooRec;
        Rectangle leftDooDooRec;
        Rectangle bottomDooDooRec;
        Rectangle topDooDooRec;
        Rectangle rightRollRec;
        Rectangle leftRollRec;
        Rectangle bottomRollRec;
        Rectangle topRollRec;

        int tickCounter = 0;

        Roll roll;
        DooDoo doodoo;
        SpecialWall specialWall;

        SoundPlayer moveSound = new SoundPlayer(Properties.Resources.MoveSound);
        SoundPlayer fartSound = new SoundPlayer(Properties.Resources.FartSound);
        SoundPlayer errorSound = new SoundPlayer(Properties.Resources.ErrorSound);
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            DooDooWallHitBox();
            RollWallHitBox();
            GrateHitBox();
            if (wallPlaced == false)
            {
                if (wKeyDown && specialWall.y > 70)
                {
                    specialWall.direction = "Up";
                    specialWall.Move();
                }
                else if (aKeyDown && specialWall.x > 20)
                {
                    specialWall.direction = "Left";
                    specialWall.Move();
                }
                else if (sKeyDown && specialWall.y < 430)
                {
                    specialWall.direction = "Down";
                    specialWall.Move();
                }
                else if (dKeyDown && specialWall.x < 510)
                {
                    specialWall.direction = "Right";
                    specialWall.Move();
                }
                else if (spaceKeyDown)
                {
                    wallPlaced = true;
                }
                else if (rKeyDown)
                {
                    wallOrientation++;
                    switch (wallOrientation)
                    {
                        case 0:
                            specialWall.orientation = "Horizontal Left";
                            specialWall.Orient();
                            break;
                        case 1:
                            specialWall.orientation = "Vertical Bottom";
                            specialWall.Orient();
                            break;
                        case 2:
                            specialWall.orientation = "Horizontal Right";
                            specialWall.Orient();
                            break;
                        case 3:
                            specialWall.orientation = "Vertical Top";
                            specialWall.Orient();
                            break;
                        case 4:
                            wallOrientation = 0;
                            break;
                    }
                }
            }
            else
            {
                if (turnCounter && moveCounter == 0)
                {
                    if (wKeyDown && roll.y - 62 >= 0 && rollTopCollision == false)
                    {
                        roll.direction = "Up";
                        RollMove();
                    }
                    else if (aKeyDown && roll.x - 75 >= 0 && rollLeftCollision == false)
                    {
                        roll.direction = "Left";
                        RollMove();
                    }
                    else if (sKeyDown && roll.y + 102 <= 500 && rollBottomCollision == false)
                    {
                        roll.direction = "Down";
                        RollMove();
                    }
                    else if (dKeyDown && roll.x + 122 <= 600 && rollRightCollision == false)
                    {
                        roll.direction = "Right";
                        RollMove();
                    }
                    CollisionNotice(rollTopCollision, wKeyDown, roll.x, roll.y);
                    CollisionNotice(rollLeftCollision, aKeyDown, roll.x, roll.y);
                    CollisionNotice(rollBottomCollision, sKeyDown, roll.x, roll.y);
                    CollisionNotice(rollRightCollision, dKeyDown, roll.x, roll.y);
                }
            }
            if (turnCounter == false && moveCounter > 0 && tickCounter > 10)
            {
                if (upKeyDown && doodoo.y - 62 >= 0 && doodooTopCollision == false)
                {
                    doodoo.direction = "Up";
                    DooDooMove();
                }
                else if (leftKeyDown && doodoo.x - 75 >= 0 && doodooLeftCollision == false)
                {
                    doodoo.direction = "Left";
                    DooDooMove();
                }
                else if (downKeyDown && doodoo.y + 102 <= 500 && doodooBottomCollision == false)
                {
                    doodoo.direction = "Down";
                    DooDooMove();
                }
                else if (rightKeyDown && doodoo.x + 122 <= 600 && doodooRightCollision == false)
                {
                    doodoo.direction = "Right";
                    DooDooMove();
                }
                CollisionNotice(doodooTopCollision, upKeyDown, doodoo.x, doodoo.y);
                CollisionNotice(doodooLeftCollision, leftKeyDown, doodoo.x, doodoo.y);
                CollisionNotice(doodooBottomCollision, downKeyDown, doodoo.x, doodoo.y);
                CollisionNotice(doodooRightCollision, rightKeyDown, doodoo.x, doodoo.y);
                tickCounter = 0;
            }

            if (levelLabelVisible)
            {
                levelLabel.Visible = true;
            }
            else
            {
                levelLabel.Visible = false;
            }

            if (turnCounter)
            {
                turnLabel.Text = "Roll's Turn \n";
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

        public void RollMove()
        {
            moveSound.Play();
            roll.Move();
            moveCounter++;
            turnCounter = false;
            levelLabelVisible = false;
        }
        public void DooDooMove()
        {
            fartSound.Play();
            levelLabelVisible = false;
            SwitchMove();
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
        public void CollisionNotice(bool collision, bool keydown, int x, int y)
        {
            Graphics g = this.CreateGraphics();
            if (collision && keydown)
            {
                errorSound.Play();
                g.FillRectangle(redBrush, x, y, 40, 40);
                Thread.Sleep(200);
            }
        }

        public void OnStart()
        {
            levelLabel.Text = "Level 1";

            roll = new Roll(rollStartX, rollStartY, rollSize, "None");
            doodoo = new DooDoo(doodooStartX, doodooStartY, doodooSize, "None");
            specialWall = new SpecialWall(74, 59, 77, 10, "None", "None");

            turnCounter = true;

            GrateHitBox();
            LevelReading();            
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
                case Keys.Space:
                    spaceKeyDown = false;
                    break;
                case Keys.R:
                    rKeyDown = false;
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
                case Keys.Space:
                    spaceKeyDown = true;
                    break;
                case Keys.R:
                    rKeyDown = true;
                    break;
            }
        }
        #endregion

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Properties.Resources.escapeGrate, grateX, grateY, grateWidth, grateHeight);
             
            e.Graphics.DrawImage(Properties.Resources.New_Piskel__2_, roll.x, roll.y, roll.size, roll.size);
            e.Graphics.DrawImage(Properties.Resources.Waste_Warroir, doodoo.x, doodoo.y, doodoo.size, doodoo.size);
            e.Graphics.FillRectangle(redBrush, specialWall.x, specialWall.y, specialWall.width, specialWall.height);

            //e.Graphics.FillRectangle(redBrush, rightDooDooRec);
            //e.Graphics.FillRectangle(redBrush, leftDooDooRec);
            //e.Graphics.FillRectangle(redBrush, bottomDooDooRec);
            //e.Graphics.FillRectangle(redBrush, topDooDooRec);

            //e.Graphics.FillRectangle(redBrush, rightRollRec);
            //e.Graphics.FillRectangle(redBrush, leftRollRec);
            //e.Graphics.FillRectangle(redBrush, bottomRollRec);
            //e.Graphics.FillRectangle(redBrush, topRollRec);

            //draw walls to screen
            foreach (Wall w in wallList)
            {
                e.Graphics.FillRectangle(wallBrush, w.x, w.y, w.Width, w.Height);
            }
        }

        public void LevelReading()
        {
            if (levelNumber < 4)
            {
                XmlReader reader = XmlReader.Create("Resources/Level" + Convert.ToString(levelNumber) + ".xml", null);

                reader.ReadToFollowing("x");
                roll.x = Convert.ToInt32(reader.ReadString());
                reader.ReadToFollowing("y");
                roll.y = Convert.ToInt32(reader.ReadString());

                reader.ReadToFollowing("x");
                doodoo.x = Convert.ToInt32(reader.ReadString());
                reader.ReadToFollowing("y");
                doodoo.y = Convert.ToInt32(reader.ReadString());

                reader.ReadToFollowing("x");
                grateX = Convert.ToInt32(reader.ReadString());
                reader.ReadToFollowing("y");
                grateY = Convert.ToInt32(reader.ReadString());
                reader.ReadToFollowing("Width");
                grateWidth = Convert.ToInt32(reader.ReadString());
                reader.ReadToFollowing("Height");
                grateHeight = Convert.ToInt32(reader.ReadString());

                reader.ReadToFollowing("walls");

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
        }
        
        public void DooDooWallHitBox()
        {
            doodooRightCollision = doodooLeftCollision = doodooBottomCollision = doodooTopCollision = false;

             rightDooDooRec = new Rectangle(doodoo.x + 53, doodoo.y + 18, 10, 10);
             leftDooDooRec = new Rectangle(doodoo.x - 24, doodoo.y + 18, 10, 10);
             bottomDooDooRec = new Rectangle(doodoo.x + 15, doodoo.y + 48, 10, 10);
             topDooDooRec = new Rectangle(doodoo.x + 15, doodoo.y - 14, 10, 10);

            Rectangle specialWallRec = new Rectangle(specialWall.x, specialWall.y, specialWall.width, specialWall.height);

            foreach (Wall w in wallList)
            {
                Rectangle wallRec = new Rectangle(w.x, w.y, w.Width, w.Height);
                
                if (rightDooDooRec.IntersectsWith(wallRec) || rightDooDooRec.IntersectsWith(specialWallRec) && doodooRightCollision == false)
                {
                    doodooRightCollision = true;
                }
                if (leftDooDooRec.IntersectsWith(wallRec) || leftDooDooRec.IntersectsWith(specialWallRec) && doodooLeftCollision == false)
                {
                    doodooLeftCollision = true;
                }
                if (topDooDooRec.IntersectsWith(wallRec) || topDooDooRec.IntersectsWith(specialWallRec) && doodooTopCollision == false)
                {
                    doodooTopCollision = true;
                }
                if (bottomDooDooRec.IntersectsWith(wallRec) || bottomDooDooRec.IntersectsWith(specialWallRec) && doodooBottomCollision == false)
                {
                    doodooBottomCollision = true;
                }
            }
        }
        public void LevelChange()
        {
            levelLabelVisible = true;
            switch (levelNumber)
            {
                case 2:
                    levelLabel.Text = "Level 2";
                    break;
                case 3:
                    levelLabel.Text = "Level 3";
                    break;
            }
            dKeyDown = false;
            turnCounter = true;
            wallPlaced = false;
            moveCounter = 0;
        }
        public void RollWallHitBox()
        {
            rollTopCollision = rollBottomCollision = rollLeftCollision = rollRightCollision = false;

            rightRollRec = new Rectangle(roll.x + 50, roll.y + 8, 10, 10);
            leftRollRec = new Rectangle(roll.x - 24, roll.y + 8, 10, 10);
            bottomRollRec = new Rectangle(roll.x + 11, roll.y + 40, 10, 10);
            topRollRec = new Rectangle(roll.x + 11, roll.y - 24, 10, 10);

            Rectangle specialWallRec = new Rectangle(specialWall.x, specialWall.y, specialWall.width, specialWall.height);

            foreach (Wall w in wallList)
            {
                Rectangle wallRec = new Rectangle(w.x, w.y, w.Width, w.Height);

                if (rightRollRec.IntersectsWith(wallRec) || rightRollRec.IntersectsWith(specialWallRec) && rollRightCollision == false)
                {
                    rollRightCollision = true;
                }
                if (leftRollRec.IntersectsWith(wallRec) || leftRollRec.IntersectsWith(specialWallRec) && rollLeftCollision == false)
                {
                    rollLeftCollision = true;
                }
                if (topRollRec.IntersectsWith(wallRec) || topRollRec.IntersectsWith(specialWallRec) && rollTopCollision == false)
                {
                    rollTopCollision = true;
                }
                if (bottomRollRec.IntersectsWith(wallRec) || bottomRollRec.IntersectsWith(specialWallRec) && rollBottomCollision == false)
                {
                    rollBottomCollision = true;
                }
            }
        }
        public void GrateHitBox()
        {
            Rectangle grateRec = new Rectangle(grateX, grateY, grateWidth, grateHeight);
            Rectangle rollRec = new Rectangle(roll.x, roll.y, roll.size, roll.size);

            if (rollRec.IntersectsWith(grateRec))
            {
                wallList.Clear();
                levelNumber++;

                if (levelNumber == 4)
                {
                    //Change to Win Screen
                    Form f = this.FindForm();
                    WinScreen ws = new WinScreen();

                    f.Controls.Remove(this);
                    f.Controls.Add(ws);

                    ws.Focus();
                }
                else
                {
                    LevelChange();
                    LevelReading();
                }
            }
        }
    }
}
