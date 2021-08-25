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
    public partial class Admin_portal : Form
    {
        public Admin_portal()
        {
            InitializeComponent();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            student_database obj = new student_database();
            obj.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Faculty_database obj = new Faculty_database();
            obj.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Payment obj = new Payment();
            obj.Show();
            this.Hide();
        }
    }
}
