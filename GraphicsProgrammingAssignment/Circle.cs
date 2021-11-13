using System.Drawing;

namespace GraphicsProgrammingAssignment
{
    /// <summary>
    /// 
    /// </summary>
    class Circle : Shapes
    {
        public void DrawCircle(Graphics g, int radius)
        {
            if (fill)
            {
                // Fill circle .
                g.FillEllipse(solid, x, y, radius, radius);
            }

            else
            {
                // Draws circle to screen:
                g.DrawEllipse(color, x, y, radius, radius);
            }
        }
        /// <summary>
        /// This method will parse a given command and outs the required shape on success:
        /// </summary>
        /// <param name="s"> </param>
        public Circle(Shapes s)
        {
            //Calls Draw class and sets the parameters of the Shape.
            this.x = s.x;
            this.y = s.y;
            color = Pens.Black;
            this.fill = s.fill;
            // Create solid brush.
            this.solid = new SolidBrush(s.color.Color);
        }
    }
}
