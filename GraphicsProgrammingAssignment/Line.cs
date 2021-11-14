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
        /// <summary>
        /// Constructor to  Drawline a on the picturebox
        /// </summary>
        /// <param name="g">graphics</param>
        /// <param name="x">frist point of line</param>
        /// <param name="y">end point of line</param>
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
