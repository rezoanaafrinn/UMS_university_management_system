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
    public partial class Payment : Form
    {
        private bool isNew = false;
        public Payment()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Admin_portal obj = new Admin_portal();
            obj.Show();
            this.Hide();
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

        private void Payment_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-CH3OF0Q;Initial Catalog=UMS;Integrated Security=True");
            conn.Open();
            string query = "select * from Payment";
            DataTable dt = LoadDatabase(query);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            conn.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int P_ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-CH3OF0Q;Initial Catalog=UMS;Integrated Security=True");
                conn.Open();
                string query = "select * from Payment where P_ID=" + P_ID;
                DataTable dt = LoadDatabase(query);
               
                textBox1.Text = dt.Rows[0]["P_ID"].ToString();
                textBox2.Text = dt.Rows[0]["St_ID"].ToString();
                textBox3.Text = dt.Rows[0]["Name"].ToString();
                textBox4.Text = dt.Rows[0]["Pay_time"].ToString();
                textBox5.Text = dt.Rows[0]["Amount"].ToString();

                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string St_ID,Name,Pay_time,Amount;

            St_ID= textBox2.Text;
            Name = textBox3.Text;
            Pay_time = textBox4.Text;
            Amount = textBox5.Text;
            
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-CH3OF0Q;Initial Catalog=UMS;Integrated Security=True");
            conn.Open();
            string query;
            if (isNew == true)
            {
                query = "Insert into Payment(St_ID,Name,Pay_time,Amount) VALUES('" +St_ID+ "','" +Name+ "','" +Pay_time+ "','" +Amount+ "')";

                isNew = false;
            }
            else
            {
                int P_ID = Convert.ToInt32(textBox1.Text);
                query = "update Payment set St_ID= '" + St_ID + "',Name= '" + Name + "',Pay_time ='" + Pay_time + "',Amount ='" + Amount + "' where P_ID =" + P_ID;

            }

            SqlCommand cmd = new SqlCommand(query, conn);
            int row = cmd.ExecuteNonQuery();
            if (row > 0)
            {
                MessageBox.Show("update successfull");
                query = "select * from Payment";
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

            isNew = true;
        }
    }
}
