using System;
using System.IO;
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

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(saveFileDialog1.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.Write(commandText.Text);
                }
            }

        }
    }
}
