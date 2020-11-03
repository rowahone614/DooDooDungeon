using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DooDooDungeon
{
    class Roll
    {
        public static int rollX, rollY, rollSize;
        public static string rollDirection;

        public Roll(int _rollX, int _rollY, int _rollSize, string _rollDirection)
        {
            _rollX = rollX;
            _rollY = rollY;
            _rollSize = rollSize;
            _rollDirection = rollDirection;
        }

        public void Move(string direction)
        { 
            if (direction == "Right")
            {
                rollX += 30;
            }
            else if (direction == "Left")
            {
                rollX -= 30;
            }
            else if (direction == "Up")
            {
                rollY -= 30;
            }
            else if (direction == "Down")
            {
                rollY += 30;
            }
        }
    }
}
