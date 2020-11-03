using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DooDooDungeon
{
    public partial class GameOverScreen : UserControl
    {
        public GameOverScreen()
        {
            InitializeComponent();
        }

        private void menuButton_Enter(object sender, EventArgs e)
        {
            menuButton.BackColor = Color.Brown;
            exitButton.BackColor = Color.LightGray;
            playAgainButton.BackColor = Color.LightGray;
        }

        private void exitButton_Enter(object sender, EventArgs e)
        {
            menuButton.BackColor = Color.LightGray;
            exitButton.BackColor = Color.Brown;
            playAgainButton.BackColor = Color.LightGray;
        }

        private void playAgainButton_Enter(object sender, EventArgs e)
        {
            menuButton.BackColor = Color.LightGray;
            exitButton.BackColor = Color.LightGray;
            playAgainButton.BackColor = Color.Brown;
        }
    }
}
