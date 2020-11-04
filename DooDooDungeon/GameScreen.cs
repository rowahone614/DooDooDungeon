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

        int x = 0;
        int y = 0;
        int Width = 0;
        int Height = 0;

        int levelNumber = 1;

        List<Wall> wallList = new List<Wall>();

        //used to draw walls on screen
        SolidBrush wallBrush = new SolidBrush(Color.Black);

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (turnCounter)
            {
                if (wKeyDown)
                {
                    Roll.rollDirection = "Up";
                    turnCounter = false;
                }
                else if (aKeyDown)
                {
                    Roll.rollDirection = "Left";
                    turnCounter = false;
                }
                else if (sKeyDown)
                {
                    Roll.rollDirection = "Down";
                    turnCounter = false;
                }
                else if (dKeyDown)
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

        public void HitBoxCreation()
        {
            foreach (Wall w in wallList)
            {
                Rectangle wallRec = new Rectangle(w.x, w.y, w.Width, w.Height);
            }

            Rectangle rollRec = new Rectangle(Roll.rollX, Roll.rollY, Roll.rollSize, Roll.rollSize);
        }

    }

}





