using System.Drawing;

namespace GraphicsProgrammingAssignment
{
    /// <summary>
    /// 
    /// </summary>
    class Rectangle : Shapes
    {
        public void drawRectangle(Graphics g, int width, int height)
        {
            if (fill)
            {
                // Fill Rectangle to screen:  
                g.FillRectangle(solid, x, y, width, height);
            }
            else
            {
                // Draw rectangle to screen:
                g.DrawRectangle(color, x, y, width, height);
            }
        }
        public Rectangle(Shapes s)
        {
            this.x = s.x;
            this.y = s.y;
            this.color = s.color;
            this.fill = s.fill;
            this.solid = new SolidBrush(s.color.Color);
        }
    }
}
