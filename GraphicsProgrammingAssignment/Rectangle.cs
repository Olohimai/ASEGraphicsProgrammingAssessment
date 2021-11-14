using System.Drawing;

namespace GraphicsProgrammingAssignment
{
    /// <summary>
    /// 
    /// </summary>
    class Rectangle : Shapes
    {
        /// <summary>
        ///   Draw a Rectangle using an array of points and fills the interior when fill is on
        /// </summary>
        /// <param name="g">a graphics class to draw shape to </param>
        /// <param name="width">takes width of the rectangle</param>
        /// <param name="height">takes the height of the rectangle</param>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
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
