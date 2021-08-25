using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace University_management_system
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int startpos = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            startpos += 1;
            progressBar1.Value = startpos;
            if (progressBar1.Value==100)
            {
                progressBar1.Value = 0;
                timer1.Stop();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void logInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void registrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registration obj = new Registration();
            obj.Show();
            this.Hide();
        }
    }
}
