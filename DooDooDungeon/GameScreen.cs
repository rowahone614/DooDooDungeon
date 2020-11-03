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
        Boolean turnCounter;
        int rollStartX = 20;
        int rollStartY = 20;
        int rollSize = 40;
        int moveCounter = 0;
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (turnCounter)
            {
                if(wKeyDown)
                {
                    Roll.rollDirection = "Up";
                    turnCounter = false;
                }
                else if(aKeyDown)
                {
                    Roll.rollDirection = "Left";
                    turnCounter = false;
                }
                else if(sKeyDown)
                {
                    Roll.rollDirection = "Down";
                    turnCounter = false;
                }
                else if(dKeyDown)
                {
                    Roll.rollDirection = "Right";
                    turnCounter = false;
                }
            }
            if (turnCounter == false)
            {

            }
        }

        public void OnStart()
        {
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

        }
    }
}
