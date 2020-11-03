using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DooDooDungeon
{
    class DooDoo
    {
        public static int doodooX, doodooY, doodooSize;
        public static string doodooDirection;

        public DooDoo(int _doodooX, int _doodooY, int _doodooSize, string _doodooDirection)
        {
            _doodooX = doodooX;
            _doodooY = doodooY;
            _doodooSize = doodooSize;
            _doodooDirection = doodooDirection;
        }

        public void Move(string direction)
        {
            if (direction == "Right")
            {
                doodooX += 30;
            }
            else if (direction == "Left")
            {
                doodooX -= 30;
            }
            else if (direction == "Up")
            {
                doodooY -= 30;
            }
            else if (direction == "Down")
            {
                doodooY += 30;
            }
        }
    }
}
