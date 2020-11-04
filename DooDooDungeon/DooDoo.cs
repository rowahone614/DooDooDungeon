using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DooDooDungeon
{
    public class DooDoo
    {
        public int x, y, size;
        public string direction;

        public DooDoo(int _doodooX, int _doodooY, int _doodooSize, string _doodooDirection)
        {
            x = _doodooX;
            y = _doodooY;
            size = _doodooSize;
            direction = _doodooDirection;
        }

        public void Move()
        {
            if (direction == "Right")
            {
                x += 75;
            }
            else if (direction == "Left")
            {
                x -= 75;
            }
            else if (direction == "Up")
            {
                y -= 62;
            }
            else if (direction == "Down")
            {
                y += 62;
            }
        }

        public Boolean Collision(Roll r)
        {
            Rectangle rollRec = new Rectangle(r.x, r.y, r.size, r.size);
            Rectangle wasteRec = new Rectangle(x, y, size, size);

            return wasteRec.IntersectsWith(rollRec);
        }
    }
}
