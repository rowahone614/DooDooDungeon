using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DooDooDungeon
{
    

    public class Wall
    {
        public int x, y, Width, Height;

        public Wall(int _x, int _y, int _Width, int _Height)
        {
            x = _x;
            y = _y;
            Width = _Width;
            Height = _Height;
        }
    }
}
