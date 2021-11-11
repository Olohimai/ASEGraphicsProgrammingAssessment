using System;
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

        private void input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                commandParser.parseCommand(syntaxInput.Text);
            }
        }
    }
}
