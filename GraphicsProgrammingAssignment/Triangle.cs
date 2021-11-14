using System.Drawing;

namespace GraphicsProgrammingAssignment
{
    class Triangle : Shapes
    {
        /// <summary>
        ///  Draw a triangle using an array of points and fills the interior when fill is on 
        /// </summary>
        /// <param name="g">// Sets g to a graphics object representing the drawing surface of the  
        /// control or form g is a member of. </param>
        /// <param name="point1">Define  the first point array to draw a triangle:</param>
        /// <param name="point2">Define  the second point array to draw a triangle:</param>
        /// <param name="point3">Define the third point array to draw a triangle:</param>
        public void drawTriangle(Graphics g, Point point1, Point point2, Point point3)
        {
            // Define point array to draw a triangle:
            Point[] pnt = new Point[3];
            pnt[0] = point1;
            pnt[1] = point2;
            pnt[2] = point3;

            if (fill)
            {
                // Fill triangle to screen.
                g.FillPolygon(solid, pnt);
            }
            else
            {
                // Draw triangle to screen:
                g.DrawPolygon(color, pnt);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        public Triangle(Shapes s)
        {
            this.x = s.x;
            this.y = s.y;
            color = Pens.Black;
            this.fill = s.fill;
            this.solid = new SolidBrush(s.color.Color);
        }
    }
}
