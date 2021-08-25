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
    public partial class spring : Form
    {
        public spring()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student_portal obj = new Student_portal();
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

        private DataTable LoadDatabase1(string query1)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-CH3OF0Q;Initial Catalog=UMS;Integrated Security=True");
            conn.Open();
            SqlCommand cmd1 = new SqlCommand(query1, conn);
            cmd1.ExecuteNonQuery();
            SqlDataAdapter adp = new SqlDataAdapter(cmd1);
            DataSet ds1 = new DataSet();
            adp.Fill(ds1);

            DataTable dt1 = ds1.Tables[0];
            return dt1;


        }

        private void spring_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-CH3OF0Q;Initial Catalog=UMS;Integrated Security=True");
            conn.Open();
            string query = "select * from class_timeS";
            DataTable dt = LoadDatabase(query);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            conn.Close();

            conn = new SqlConnection(@"Data Source=DESKTOP-CH3OF0Q;Initial Catalog=UMS;Integrated Security=True");
            conn.Open();
            string query1 = "select * from Grade_reportS";
            DataTable dt1 = LoadDatabase1(query1);
            dataGridView2.DataSource = dt1;
            dataGridView2.Refresh();
            conn.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int C_No = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-CH3OF0Q;Initial Catalog=UMS;Integrated Security=True");
                conn.Open();
                string query = "select * from class_timeS where C_No=" + C_No;
                DataTable dt = LoadDatabase(query);
                textBox1.Text = dt.Rows[0]["Course"].ToString();
                textBox2.Text = dt.Rows[0]["Time"].ToString();
                textBox3.Text = dt.Rows[0]["Room_no"].ToString();

                conn.Close();
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int No = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());

                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-CH3OF0Q;Initial Catalog=UMS;Integrated Security=True");
                conn.Open();
                string query1 = "select * from Grade_reportS where No=" + No;
                DataTable dt1 = LoadDatabase1(query1);
                textBox4.Text = dt1.Rows[0]["Course"].ToString();
                textBox5.Text = dt1.Rows[0]["Grade"].ToString();


                conn.Close();
            }
        }
    }
}
