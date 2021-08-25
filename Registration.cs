using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace University_management_system
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Name, Gender = " ", Address, Email_ID, Contact_No, Fathers_Name, Mothers_Name, Department = " ";
            DateTime Date_of_Birth = Convert.ToDateTime(dateTimePicker1.Text);
            Name = textBox1.Text;
            if (radioButton1.Checked)
            {
                Gender = "Male";
            }
            else if (radioButton2.Checked)
            {
                Gender = "Female";
            }
            else if (radioButton3.Checked)
            {
                Gender = "Others";
            }

            Address = textBox3.Text;
            Email_ID = textBox4.Text;
            Contact_No = textBox5.Text;
            Fathers_Name = textBox6.Text;
            Mothers_Name = textBox7.Text;
            if (checkBox1.Checked)
                Department += "Computer Science and Engineering";
            if (checkBox2.Checked)
                Department += "Electrical and Electronic Engineering";
            if (checkBox3.Checked)
                Department += "Business Administration";
            if (checkBox4.Checked)
                Department += "Architecture";
            if (checkBox5.Checked)
                Department += "English";

            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-CH3OF0Q;Initial Catalog=UMS;Integrated Security=True");

            string query =
                "Insert into registration(Name,Date_of_Birth,Gender,Address,Email_ID,Contact_No,Fathers_Name,Mothers_Name,Department) VALUES('" + Name + "','" + Date_of_Birth + "','" + Gender + "','" + Address + "','" + Email_ID + "','" + Contact_No + "','" + Fathers_Name + "','" + Mothers_Name + "','" + Department + "')";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            int row = cmd.ExecuteNonQuery();
            if (row > 0)
            {
                MessageBox.Show(row + " ");
                conn.Close();
            }
            else
                MessageBox.Show("not successfull");

            MessageBox.Show("Information submitted!!");
            MessageBox.Show("Authority will provide your ID and password.");
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
        }
    }
}
