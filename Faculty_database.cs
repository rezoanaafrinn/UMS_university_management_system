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
    public partial class Faculty_database : Form
    {
        private bool isNew = false;
        public Faculty_database()
        {
            InitializeComponent();
        }

        private DataTable LoadDatabase(string query)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-CH3OF0Q;Initial Catalog=UMS;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            DataTable dt = ds.Tables[0];
            return dt;


        }

        private void Faculty_database_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-CH3OF0Q;Initial Catalog=UMS;Integrated Security=True");
            conn.Open();
            string query = "select * from faculty_database";
            DataTable dt = LoadDatabase(query);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            conn.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-CH3OF0Q;Initial Catalog=UMS;Integrated Security=True");
                conn.Open();
                string query = "select * from faculty_database where ID=" + ID;
                DataTable dt = LoadDatabase(query);
                textBox1.Text = dt.Rows[0]["ID"].ToString();
                textBox2.Text = dt.Rows[0]["Name"].ToString();
                textBox3.Text = dt.Rows[0]["Gender"].ToString();
                textBox4.Text = dt.Rows[0]["DOB"].ToString();
                textBox5.Text = dt.Rows[0]["Course"].ToString();
                textBox6.Text = dt.Rows[0]["Phone_no"].ToString();
                textBox7.Text = dt.Rows[0]["Address"].ToString();

                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Name, Gender, DOB, Course, Phone_no,Address;

            Name = textBox2.Text;
            Gender = textBox3.Text;
            DOB = textBox4.Text;
            Course = textBox5.Text;
            Phone_no = textBox6.Text;
            Address = textBox7.Text;
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-CH3OF0Q;Initial Catalog=UMS;Integrated Security=True");
            conn.Open();
            string query;
            if (isNew == true)
            {
                query = "Insert into faculty_database(Name,Gender,DOB,Course,Phone_no,Address) VALUES('" + Name + "','" + Gender + "','" + DOB + "','" +Course+ "','" +Phone_no+ "','"+Address+"')";

                isNew = false;
            }
            else
            {
                int ID = Convert.ToInt32(textBox6.Text);
                query = "UPDATE faculty_database set Name= '" + Name + "', Gender= '" + Gender + "',DOB ='" + DOB + "',Course ='" + Course + "',Phone_no='" + Phone_no + "',Address='" +Address+ "'where ID =" + ID;
                
            }

            SqlCommand cmd = new SqlCommand(query, conn);
            int row = cmd.ExecuteNonQuery();
            if (row > 0)
            {
                MessageBox.Show("update successfull");
                query = "select * from faculty_database";
                cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();
            }
            conn.Close();
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
            textBox5.Text = " ";
            textBox6.Text = " ";
            textBox7.Text = " ";

            isNew = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-CH3OF0Q;Initial Catalog=UMS;Integrated Security=True");
            conn.Open();
            string query;
            int ID = Convert.ToInt32(textBox6.Text);
            query = "Delete from faculty_database where ID =" + ID;

            SqlCommand cmd = new SqlCommand(query, conn);
            int row = cmd.ExecuteNonQuery();
            if (row > 0)
            {
                MessageBox.Show("operation successfull");
                query = "select * from faculty_database";
                cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();
                
                textBox1.Text = " ";
                textBox2.Text = " ";
                textBox3.Text = " ";
                textBox4.Text = " ";
                textBox5.Text = " ";
                textBox6.Text = " ";
                textBox7.Text = " ";
            }
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Admin_portal obj = new Admin_portal();
            obj.Show();
            this.Hide();
        }
    }
}
