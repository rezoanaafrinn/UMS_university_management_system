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
    public partial class Login : Form
    {
        private string id = "19-4444-1";
        private string password = "1234";
        private string id1 = "20-4444-1";
        private string password1 = "1234";
        private string id2 = "21-4444-1";
        private string password2 = "1234";
        public Login()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (id == textBox1.Text && password == textBox2.Text)
            {
                MessageBox.Show("Successful Log In");
                Student_portal obj = new Student_portal();
                obj.Show();
                this.Hide();
            }
            else if (id1 == textBox1.Text && password1 == textBox2.Text)
            {
                MessageBox.Show("Successful Log In");
                Faculty_portal obj = new Faculty_portal();
                obj.Show();
                this.Hide();
            }
            else if (id2 == textBox1.Text && password2 == textBox2.Text)
            {
                MessageBox.Show("Successful Log In");
                Admin_portal obj = new Admin_portal();
                obj.Show();
                this.Hide();
            }
            else

                MessageBox.Show("Invalid ID or Password");
        }
    }
}
