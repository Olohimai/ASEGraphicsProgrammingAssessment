using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GraphicsProgrammingAssignment
{
    /// <summary>
    /// Declearing variables for Bitmap,Graphics and pictureBox
    /// </summary>
    public class CommandParser
    {
        Dictionary<string, int> variables;
        Bitmap bitmap;
        Graphics g;
        PictureBox pictureBox;

        /// <summary>
        /// The commandParser method creates a blank bitmap the size as the original
        /// and gets a graphics object from the new image
        /// </summary>
        /// <param name="pictureBox">To refer to the fields of the current class the PictureBox is 
        /// used to display graphics from a bitmap</param>
        public CommandParser(PictureBox pictureBox)
        {
            variables = new Dictionary<string, int>();
            bitmap = new Bitmap(pictureBox.Size.Width, pictureBox.Size.Height);
            g = Graphics.FromImage(bitmap);
            this.pictureBox = pictureBox;
            draw();
        }
        /// <summary>
        /// this method trys to use Refresh method to update the picturebox the user draws.
        /// </summary>
        public void draw()
        {
            pictureBox.Image = bitmap;
            pictureBox.Refresh();
        }
        /// <summary> this method shows a  ParsePoint method  whereby the coordinates entered by 
        /// the user are seperated by a comma  using split function if the lenght of points is not
        /// equals to 2 it throws an exception if its less
        /// </summary>
        /// <param name="point">A string containing a number to convert.</param>
        /// <returns>The value of x and y coordinates</returns>
        /// <exception cref="Exception">Thrown when one parameter is not equals to 2</exception>
        public (int, int) ParsePoint(string point)
        {
            string[] points = point.Split(',');
            if (points.Length != 2)
            {
                throw new Exception();
            }

            if (ValueEvaluate(points[0], out int x) && ValueEvaluate(points[1], out int y))
            {
                return (x, y);
            }

            else
            {
                throw new Exception();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public Point ParseTriangle(string point)
        {
            var (x, y) = ParsePoint(point);
            return new Point(x, y);
        }
        public bool ValueEvaluate(string input, out int result)
        {
            if (int.TryParse(input, out int value))
            {
                result = value;
                return true;
            }
            else if (variables.ContainsKey(input))
            {
                result = variables[input];
                return true; 
            }
            else
            {
                result = 0;
                return false;
            }
        }
        public string varReplace (string equation)
        {
            foreach (KeyValuePair<string, int>variable in variables)
            {
                if (equation.Contains(variable.Key))
                {
                    equation = equation.Replace(variable.Key, variable.Value.ToString());
                }
            }
            return equation;
        }
        /// <summary>
        /// A method,that run the users command which is  separated by a newline.
        /// function to execute a command enterd by the user contained within a string
        /// </summary>
        /// <param name="userInput">A string containing a number to convert.</param>
        public void parseCommand(string userInput)
        {
            //Split  method on spaces.
            string[] userInputArray = userInput.Split(new string[] { Environment.NewLine },
                StringSplitOptions.RemoveEmptyEntries);
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
                        if (commandParts.Length == 3)
                        {
                            // Create a position for the circle TryParse coordinates of points using a helper function.
                            (int, int) point = ParsePoint(commandParts[1]);
                            if (ValueEvaluate(commandParts[2], out int radius))
                            {
                                new Circle(draw).DrawCircle(g, radius);
                            }

                            else
                            {
                                // therefore if the radius of circle isnt parsed it throws an invalid commmand exception
                                throw new Exception("Invalid Command Entered, Enter a Valid Command");
                            }
                        }
                        // if the shape has just two arguments the position is not
                        // included and the current position should be used instead

                        else if (commandParts.Length == 2)
                        {
                            if (ValueEvaluate(commandParts[1], out int radius))
                            {
                                new Circle(draw).DrawCircle(g, radius);
                            }

                            else
                            {
                                MessageBox.Show("Invalid Command Entered, Enter a Valid Command");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid parameter Entered, Enter a Valid parameter");
                        }
                        break;
                    //   the shape triangle has three points therefore it needs three arguments parsed
                    case "triangle":
                        if (commandParts.Length == 4)
                        {
                            // three points are parsed using the helper function using The try catch statement which consists of a try
                            // which call drawTriangle if the points are 3 
                            // followed by one  catch clauses and else, which specifies for a different exception.
                            try
                            {
                                Point point1 = ParseTriangle(commandParts[1]);
                                Point point2 = ParseTriangle(commandParts[2]);
                                Point point3 = ParseTriangle(commandParts[3]);
                                new Triangle(draw).drawTriangle(g, point1, point2, point3);
                            }
                            catch
                            {
                                MessageBox.Show("Invalid coordinate Entered, Enter a Valid coordinates");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid parameter Entered,Enter a valid parameter");
                        }
                        break;

                    case "rectangle":
                        // rectangle can have either three or two arguments
                        if (commandParts.Length == 3)
                        {
                            // parse the width and height and throw an exception if they are invalid 
                            // Create a position for the rectangle TryParse coordinates of points using a helper function.
                            if (ValueEvaluate(commandParts[1], out int x) && ValueEvaluate(commandParts[2], out int y))
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
                                MessageBox.Show("Invalid coordinate  enter a valid coordinate");
                            }
                        }
                        else
                        {
                            MessageBox.Show("invalid parameter enter a valid parameter");
                        }
                        break;
                    // this command that takes an argument for the position for draw to
                    case "drawto":
                        if (commandParts.Length == 3)
                        {
                            if (ValueEvaluate(commandParts[1], out int x) && ValueEvaluate(commandParts[2], out int y))
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
                        //by parsing the point using the helper function and sets the position to the users moveto input
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
                        switch (commandParts[1].ToLower())
                        {
                            case "on":  // case Fill shape is on it fills the shape
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
                        // Clears screen with white background.
                        g.Clear(System.Drawing.Color.White);
                        break;
                    case "reset":
                        // Resets the location of the coordinates to its initial coordinate.
                        draw.x = 0;
                        draw.y = 0;
                        draw.color = Pens.Black;
                        break;
                    default:
                        if (userInputArray[i].Contains("="))
                        {
                            int position = userInputArray[i].IndexOf("=");
                            string variableName = userInputArray[i].Substring(0, position).Trim();
                            string variableString = userInputArray[i].Substring(position + 1).Trim();
                            if (int.TryParse(variableString, out int value))
                            {
                                variables[variableName] = value;
                            }
                            else
                            {
                                try
                                {
                                    DataTable dt = new DataTable();
                                    variableString = varReplace(variableString);
                                    value = Convert.ToInt32(dt.Compute(variableString, ""));
                                    variables[variableName] = value;
                                }
                                catch
                                {
                                    MessageBox.Show("invalid variable");
                                }
                            }
                        }

                        else
                        {
                            MessageBox.Show("invalid Parameter Entered, enter a valid Parameter");

                        }
                        break;
                }
            }
            this.draw();
        }
    }
}
