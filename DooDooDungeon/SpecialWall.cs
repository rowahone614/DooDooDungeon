using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DooDooDungeon
{
    class SpecialWall
    {
        public int x, y, width, height;
        public string direction, orientation;

        public SpecialWall(int _x, int _y, int _width, int _height, string _direction, string _orientation)
        {
            x = _x;
            y = _y;
            width = _width;
            height = _height;
            direction = _direction;
            orientation = _orientation;
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

        public void Orient()
        {
            if (orientation == "Horizontal")
            {
                width = 77;
                height = 10;
            }
            else if (orientation == "Vertical")
            {
                width = 10;
                height = 69;
            }
        }
    }
}
