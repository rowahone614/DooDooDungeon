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
    public partial class InstructionsScreen : UserControl
    {
        public InstructionsScreen()
        {
            InitializeComponent();
        }
  
        private void menuButton_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            MenuScreen ms = new MenuScreen();

            f.Controls.Remove(this);
            f.Controls.Add(ms);

            ms.Focus();
        }

        private void menuButton_Enter(object sender, EventArgs e)
        {
            menuButton.BackColor = Color.Brown;
        }
    }
}
