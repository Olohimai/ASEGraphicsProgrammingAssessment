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
                                MessageBox.Show("invalid parameter");
                        }
                        break;
                    default:
                        break;
                }
            }
            this.draw();
        }
    }
}
