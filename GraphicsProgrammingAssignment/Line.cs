using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsProgrammingAssignment
{
    class Line : Shapes
    { 
        public void drawLine(Graphics g, int x, int y)
        {

            g.DrawLine(color, this.x, this.y, x, y);
        }
        public Line(Shapes s)
        {
            this.x = s.x;
            this.y = s.y;
            color = Pens.Black;
        }
    }
}
