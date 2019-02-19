using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbilitySummit2017_WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void processToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var processForm = new ProcessForm();
            processForm.ShowDialog(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
