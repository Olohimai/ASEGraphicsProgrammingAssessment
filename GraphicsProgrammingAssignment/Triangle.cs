using System.Drawing;

namespace GraphicsProgrammingAssignment
{
    /// <summary>
    /// 
    /// </summary>
    class Triangle : Shapes
    {
        public void drawTriangle(Graphics g, Point point1, Point point2, Point point3)
        {
            // Create points that defines the polygon.
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
