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
    }
}
