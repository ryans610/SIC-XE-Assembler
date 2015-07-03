using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            openProgram.InitialDirectory = Application.StartupPath;
            openOperators.InitialDirectory = Application.StartupPath;
            openASCII.InitialDirectory = Application.StartupPath;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(InputFile.Text) || string.IsNullOrEmpty(OutputFile.Text) || string.IsNullOrEmpty(programName.Text))
            {
                MessageBox.Show("Please text the Program Name, Input and Output File Name!", "Error");
            }
            else
            {
                CompileForm newForm = new CompileForm(this, InputFile.Text, OutputFile.Text, programName.Text, !string.IsNullOrEmpty(OPFile.Text), OPFile.Text, !string.IsNullOrEmpty(ASCFile.Text), ASCFile.Text, !string.IsNullOrEmpty(SymbolTableFile.Text), SymbolTableFile.Text);
                this.Enabled = false;
                newForm.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openProgram.ShowDialog() == DialogResult.OK)
            {
                InputFile.Text = openProgram.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openOperators.ShowDialog() == DialogResult.OK)
            {
                OPFile.Text = openOperators.FileName;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (openASCII.ShowDialog() == DialogResult.OK)
            {
                ASCFile.Text = openASCII.FileName;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (saveST.ShowDialog() == DialogResult.OK)
            {
                SymbolTableFile.Text = saveST.FileName;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (saveProgram.ShowDialog() == DialogResult.OK)
            {
                OutputFile.Text = saveProgram.FileName;
            }
        }
    }
}
