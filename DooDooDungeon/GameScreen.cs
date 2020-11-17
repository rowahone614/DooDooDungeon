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
        Boolean wallPlaced = true;
        Boolean horizontal = true;
        Boolean redpowerupEnabled = true;
        Boolean bluepowerupEnabled = true;
        Boolean bluepowerupCompleted = false;

       // int rollStartX = 20;
       // int rollStartY = 20;

        //int doodooStartX = 470;
       // int doodooStartY = 447;

        int rollSize = 40;
        int doodooSize = 40;

        int moveCounter = 0;
        int rollMoveCounter = 0;

        int grateX;
        int grateY;
        int grateWidth;
        int grateHeight;

        int redpowerupX;
        int redpowerupY;

        int bluepowerupX;
        int bluepowerupY;

        int powerupSize;
        
        int levelNumber = 1;

        List<Grate> grateList = new List<Grate>();
        List<Wall> wallList = new List<Wall>();

        //used to draw walls on screen
        SolidBrush blueBrush = new SolidBrush(Color.Blue);
        SolidBrush redBrush = new SolidBrush(Color.Red);

        Rectangle rightDooDooRec;
        Rectangle leftDooDooRec;
        Rectangle bottomDooDooRec;
        Rectangle topDooDooRec;
        Rectangle rightRollRec;
        Rectangle leftRollRec;
        Rectangle bottomRollRec;
        Rectangle topRollRec;
        Rectangle redpowerupRec;
        Rectangle bluepowerupRec;

        int tickCounter = 0;
        int frameCounter = 0;
        int orientControl = 0;

        Roll roll;
        DooDoo doodoo;
        SpecialWall specialWall;
        Grate grate;
        Grate grate2;

        SoundPlayer moveSound = new SoundPlayer(Properties.Resources.MoveSound);
        SoundPlayer fartSound = new SoundPlayer(Properties.Resources.FartSound);
        SoundPlayer errorSound = new SoundPlayer(Properties.Resources.ErrorSound);
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            DooDooWallHitBox();
            RollWallHitBox();
            GrateHitBox();

            if (wallPlaced == false && redpowerupEnabled == false)
            {
                if (wKeyDown && (specialWall.y > 75 || (specialWall.orientation == "Vertical" && specialWall.y > 0)) && frameCounter > 10)
                {
                    specialWall.direction = "Up";
                    specialWall.Move();
                    frameCounter = 0;
                }
                else if (aKeyDown && specialWall.x > 20 && frameCounter > 10)
                {
                    specialWall.direction = "Left";
                    specialWall.Move();
                    frameCounter = 0;
                }
                else if (sKeyDown && specialWall.y < 430 && frameCounter > 10)
                {
                    specialWall.direction = "Down";
                    specialWall.Move();
                    frameCounter = 0;
                }
                else if (dKeyDown && specialWall.x < 510 && frameCounter > 10)
                {
                    specialWall.direction = "Right";
                    specialWall.Move();
                    frameCounter = 0;
                }
                else if (spaceKeyDown)
                {
                    wallPlaced = true;
                    turnCounter = false;
                }
                else if (rKeyDown)
                {
                    if (horizontal && orientControl > 10 && specialWall.y > 0)
                    {
                        specialWall.orientation = "Horizontal";
                        specialWall.Orient();
                        orientControl = 0;
                        horizontal = false;
                    }
                    else if (horizontal == false && orientControl > 10)
                    {
                        specialWall.orientation = "Vertical";
                        specialWall.Orient();
                        orientControl = 0;
                        horizontal = true;
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

            if (wallPlaced == false)
            {
                turnLabel.Text = "Place the wall";
            }
            else if (turnCounter && wallPlaced == true)
            {
                turnLabel.Text = "Roll's Turn";
            }
            else if (turnCounter == false)
            {
                turnLabel.Text = "Waste Warrior's Turn";
            }
            CollisionCheck();
            tickCounter++;
            frameCounter++;
            orientControl++;
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
            if (redpowerupEnabled)
            {
                redpowerupRec = new Rectangle(redpowerupX, redpowerupY, powerupSize, powerupSize);
                if (roll.Collision(redpowerupRec))
                {
                    wallPlaced = false;
                    redpowerupEnabled = false;
                    turnCounter = true;
                }
            }
            if (bluepowerupEnabled)
            {
                bluepowerupRec = new Rectangle(bluepowerupX, bluepowerupY, powerupSize, powerupSize);
                if (roll.Collision(bluepowerupRec))
                {
                    bluepowerupEnabled = false;
                }
            }
        }

        public void RollMove()
        {
            moveSound.Play();

            if (bluepowerupEnabled || bluepowerupCompleted)
            {
                roll.Move();
                moveCounter++;
                turnCounter = false;
            }
            else
            {
                roll.Move();
                rollMoveCounter++;
                if (rollMoveCounter == 1)
                {
                    bluepowerupCompleted = true;
                }
            }
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
            specialWall = new SpecialWall(72, 59, 77, 10, "None", "Horizontal");

            turnCounter = true;

            //GrateHitBox();
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
            e.Graphics.DrawImage(Properties.Resources.New_Piskel__2_, roll.x, roll.y, roll.size, roll.size);
            e.Graphics.DrawImage(Properties.Resources.Waste_Warroir, doodoo.x, doodoo.y, doodoo.size, doodoo.size);

            if (redpowerupEnabled)
            {
                e.Graphics.FillRectangle(redBrush, redpowerupX, redpowerupY, powerupSize, powerupSize);
            }
            else
            {
                e.Graphics.FillRectangle(redBrush, specialWall.x, specialWall.y, specialWall.width, specialWall.height);
            }

            if (bluepowerupEnabled)
            {
                e.Graphics.FillRectangle(blueBrush, bluepowerupX, bluepowerupY, powerupSize, powerupSize);
            }

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
                e.Graphics.DrawImage(Properties.Resources.Wall, w.x, w.y, w.Width, w.Height);
            }

                e.Graphics.DrawImage(Properties.Resources.escapeGrate, grate.x, grate.y, grate.size, grate.size);

                e.Graphics.DrawImage(Properties.Resources.escapeGrate, grate2.x, grate2.y, grate2.size, grate2.size);

        }

        public void LevelReading()
        {
            if (levelNumber < 4)
            {
                XmlReader reader = XmlReader.Create("Resources/Level" + Convert.ToString(levelNumber) + ".xml", null);

                reader.ReadToFollowing("x");
                int rollStartX = Convert.ToInt32(reader.ReadString());
                reader.ReadToFollowing("y");
                int rollStartY = Convert.ToInt32(reader.ReadString());

                roll = new Roll(rollStartX, rollStartY, rollSize, "None");
               
                reader.ReadToFollowing("x");
                int doodooStartX = Convert.ToInt32(reader.ReadString());
                reader.ReadToFollowing("y");
                int doodooStartY = Convert.ToInt32(reader.ReadString());

                doodoo = new DooDoo(doodooStartX, doodooStartY, doodooSize, "None");

                reader.ReadToFollowing("x");
                int grateX = Convert.ToInt32(reader.ReadString());
                reader.ReadToFollowing("y");
                int grateY = Convert.ToInt32(reader.ReadString());
                reader.ReadToFollowing("Size");
                int grateSize = Convert.ToInt32(reader.ReadString());

                grate = new Grate(grateX, grateY, grateSize);

                reader.ReadToFollowing("x");
                int grateX2 = Convert.ToInt32(reader.ReadString());
                reader.ReadToFollowing("y");
                int grateY2 = Convert.ToInt32(reader.ReadString());
                reader.ReadToFollowing("Size");
                int grateSize2 = Convert.ToInt32(reader.ReadString());

                grate2 = new Grate(grateX2, grateY2, grateSize2);

                reader.ReadToFollowing("x");
                redpowerupX = Convert.ToInt32(reader.ReadString());
                reader.ReadToFollowing("y");
                redpowerupY = Convert.ToInt32(reader.ReadString());
                reader.ReadToFollowing("Size");
                powerupSize = Convert.ToInt32(reader.ReadString());

                reader.ReadToFollowing("x");
                bluepowerupX = Convert.ToInt32(reader.ReadString());
                reader.ReadToFollowing("y");
                bluepowerupY = Convert.ToInt32(reader.ReadString());


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

                if (rightDooDooRec.IntersectsWith(wallRec) || (rightDooDooRec.IntersectsWith(specialWallRec) && redpowerupEnabled == false) && doodooRightCollision == false)
                {
                    doodooRightCollision = true;
                }
                if (leftDooDooRec.IntersectsWith(wallRec) || (leftDooDooRec.IntersectsWith(specialWallRec) && redpowerupEnabled == false) && doodooLeftCollision == false)
                {
                    doodooLeftCollision = true;
                }
                if (topDooDooRec.IntersectsWith(wallRec) || (topDooDooRec.IntersectsWith(specialWallRec) && redpowerupEnabled == false) && doodooTopCollision == false)
                {
                    doodooTopCollision = true;
                }
                if (bottomDooDooRec.IntersectsWith(wallRec) || (bottomDooDooRec.IntersectsWith(specialWallRec) && redpowerupEnabled == false) && doodooBottomCollision == false)
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

            specialWall = new SpecialWall(72, 59, 77, 10, "None", "Horizontal");

            dKeyDown = false;
            turnCounter = true;
            redpowerupEnabled = true;
            bluepowerupEnabled = true;
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

                if (rightRollRec.IntersectsWith(wallRec) || (rightRollRec.IntersectsWith(specialWallRec) && redpowerupEnabled == false) && rollRightCollision == false)
                {
                    rollRightCollision = true;
                }
                if (leftRollRec.IntersectsWith(wallRec) || (leftRollRec.IntersectsWith(specialWallRec) && redpowerupEnabled == false) && rollLeftCollision == false)
                {
                    rollLeftCollision = true;
                }
                if (topRollRec.IntersectsWith(wallRec) || (topRollRec.IntersectsWith(specialWallRec) && redpowerupEnabled == false) && rollTopCollision == false)
                {
                    rollTopCollision = true;
                }
                if (bottomRollRec.IntersectsWith(wallRec) || (bottomRollRec.IntersectsWith(specialWallRec) && redpowerupEnabled == false) && rollBottomCollision == false)
                {
                    rollBottomCollision = true;
                }
            }
        }
        public void GrateHitBox()
        {
            Rectangle grateRec = new Rectangle(grate.x, grate.y, grate.size, grate.size);
            Rectangle grateRec2 = new Rectangle(grate2.x, grate2.y, grate2.size, grate2.size);
            Rectangle rollRec = new Rectangle(roll.x, roll.y, roll.size, roll.size);

            if (rollRec.IntersectsWith(grateRec) || rollRec.IntersectsWith(grateRec2))
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
