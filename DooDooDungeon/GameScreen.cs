﻿using System;
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

        int rollStartX = 20;
        int rollStartY = 20;

        int doodooStartX = 540;
        int doodooStartY = 440;

        int rollSize = 40;
        int doodooSize = 40;

        int moveCounter = 0;
        int tickCounter = 0;
        Roll roll;
        DooDoo doodoo;
        private void gameTimer_Tick(object sender, EventArgs e)
        {
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
                else if (sKeyDown && roll.y + 102 <= this.Height)
                {
                    roll.direction = "Down";
                    roll.Move();
                    moveCounter++;
                    turnCounter = false;
                }
                else if (dKeyDown && roll.x + 122 <= this.Width)
                {
                    roll.direction = "Right";
                    roll.Move();
                    moveCounter++;
                    turnCounter = false;
                }
            }
            if (turnCounter == false && moveCounter > 0)
            {
                if (upKeyDown && doodoo.y - 62 >= 0)
                {
                    doodoo.direction = "Up";
                    SwitchMove();
                }
                else if (leftKeyDown && doodoo.x - 75 >= 0)
                {
                    doodoo.direction = "Left";
                    SwitchMove();
                }
                else if (downKeyDown && doodoo.y + 122 <= this.Height)
                {
                    doodoo.direction = "Down";
                    SwitchMove();
                    
                }
                else if (rightKeyDown && doodoo.x + 122 <= this.Width)
                {
                    doodoo.direction = "Right";
                    SwitchMove();
                }
            }
            CollisionCheck();
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
        }
    }
}
