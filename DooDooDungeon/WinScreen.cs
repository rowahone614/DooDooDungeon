using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace DooDooDungeon
{
    public partial class WinScreen : UserControl
    {
        public WinScreen()
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

        private void menuButton_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            MenuScreen ms = new MenuScreen();

            f.Controls.Remove(this);
            f.Controls.Add(ms);

            ms.Focus();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void playAgainButton_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            GameScreen gs = new GameScreen();

            f.Controls.Remove(this);
            f.Controls.Add(gs);

            gs.Focus();
        }

        private void WinScreen_Load(object sender, EventArgs e)
        {
            Form1.themeSound.Play();
        }
    }
}