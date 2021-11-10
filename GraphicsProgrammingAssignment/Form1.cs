using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsProgrammingAssignment
{
    public partial class Form1 : Form
    {
        CommandParser commandParser;
        public Form1()
        {
            InitializeComponent();
            commandParser = new CommandParser(pictureBox1);
        }

        private void calculateShape(object sender, EventArgs e)
        {
            commandParser.parseCommand(commandText.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            commandParser.parseCommand(syntaxInput.Text);
        }
    }
}
