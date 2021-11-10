using System;
using System.Drawing;
using System.Windows.Forms;

namespace GraphicsProgrammingAssignment
{
    public class CommandParser
    {
        Bitmap bitmap;
        Graphics g;
        PictureBox pictureBox;
        public CommandParser(PictureBox pictureBox)
        {
            //create a blank bitmap the same size as original
            bitmap = new Bitmap(pictureBox.Size.Width, pictureBox.Size.Height);

            //get a graphics object from the new image
            g = Graphics.FromImage(bitmap);
            this.pictureBox = pictureBox;
            draw();
        }
        public void draw()
        {
            pictureBox.Image = bitmap;
            pictureBox.Refresh();
        }

        public (int, int) ParsePoint(string point)
        {
            string[] points = point.Split(',');
            if (points.Length != 2)
            {
                throw new Exception();
            }
            if (int.TryParse(points[0], out int x) && int.TryParse(points[1], out int y))
            {
                return (x, y);
            }
            else
            {
                throw new Exception();
            }
        }

        public Point ParseToMSPoint(string point)
        {
            var (x, y) = ParsePoint(point);
            return new Point(x, y);
        }
        public void parseCommand(string userInput)
        {
            //String.Split method
            string[] userInputArray = userInput.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            Shapes draw = new Shapes();
            draw.x = 0;//initial x-coordinate axis 
            draw.y = 0;//initial y-coordinate axis
            draw.color = Pens.Black; //sets default color black 

            for (int i = 0; i < userInputArray.Length; i++)
            {
                string[] commandParts = userInputArray[i].Split(' ');

                switch (commandParts[0].ToLower())
                {
                    case "circle":
                        // Create circle coordinates of points that define circle.

                        if (commandParts.Length == 2)
                        {
                            //ParsePoint call in a try catch
                            if (int.TryParse(commandParts[1], out int radius))
                                new Circle(draw).DrawCircle(g, radius);
                            else
                                MessageBox.Show("Invalid parameter Entered, Enter a Valid Parameter");
                        }
                        break;
                    case "triangle":
                        if (commandParts.Length == 4)
                        {
                            try
                            {
                                Point point1 = ParseToMSPoint(commandParts[1]);
                                Point point2 = ParseToMSPoint(commandParts[2]);
                                Point point3 = ParseToMSPoint(commandParts[3]);
                                new Triangle(draw).drawTriangle(g, point1, point2, point3);
                            }
                            catch
                            {
                                MessageBox.Show("Invalid coordinate Entered, Enter a Valid coordinates");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid parameter Entered");
                        }
                        break;

                    case "rectangle":
                        // Create rectangle.
                        if (commandParts.Length == 3)
                        {
                            if (int.TryParse(commandParts[1], out int x) && int.TryParse(commandParts[2], out int y))
                                new Rectangle(draw).drawRectangle(g, x, y);

                            else
                                MessageBox.Show("invalid parameter");
                        }
                        else if (commandParts.Length == 2)
                        {
                            try
                            {
                                var (x, y) = ParsePoint(commandParts[1]);
                                new Rectangle(draw).drawRectangle(g, x, y);
                            }
                            catch
                            {
                                MessageBox.Show("invalid coordinate");
                            }
                        }
                        else
                        {
                            MessageBox.Show("invalid parameter enter a valid parameter");
                        }
                        break;

                    case "drawto":
                        if (commandParts.Length == 3)
                        {
                            if (int.TryParse(commandParts[1], out int x) && int.TryParse(commandParts[2], out int y))
                                new Line(draw).drawLine(g, x, y);

                            else
                                MessageBox.Show("Invalid parameter, Enter a Valid Parameter");
                        }
                        else if (commandParts.Length == 2)
                        {
                            try
                            {
                                var (x, y) = ParsePoint(commandParts[1]);
                                new Line(draw).drawLine(g, x, y);
                            }
                            catch
                            {
                                MessageBox.Show("Invalid coordinate, Enter a Valid coordinate");
                            }
                        }
                        else
                        {
                            MessageBox.Show("invalid parameter, Enter a Valid Parameter");
                        }

                        break;

                    case "moveto":
                        //Moves the shape to the specified coordinates on the screen.
                        try
                        {
                            (draw.x, draw.y) = ParsePoint(commandParts[1]);
                        }
                        catch
                        {
                            MessageBox.Show("invalid coordinate, Enter valid coordinates");
                        }
                        break;
                    case "fill":
                        switch (commandParts[1])
                        {
                            case "on":  // case Fill shape is on
                                draw.fill = true;
                                break;
                            case "off": // case Fill shape is off
                                draw.fill = false;
                                break;
                        }
                        break;
                    case "pen":
                        switch (commandParts[1].ToLower())
                        {
                            //Sets the Pen object to a defined set of color
                            case "yellow":
                                draw.color = Pens.Yellow;
                                break;
                            case "red":
                                draw.color = Pens.Red;
                                break;
                            case "black":
                                draw.color = Pens.Black;
                                break;
                            case "blue":
                                draw.color = Pens.Blue;
                                break;
                            default:
                                draw.color = Pens.Black;
                                break;
                        }
                        break;
                    case "clear":
                        // Clears screen with Gray background.
                        g.Clear(System.Drawing.Color.White);
                        break;
                    case "reset":
                        // Resets the location of the shape to its initial coordinate.
                        draw.x = 0;
                        draw.y = 0;
                        draw.color = Pens.Black;
                        break;
                    default:
                        break;
                }
            }
            this.draw();
        }
    }
}
