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

namespace SalaryMS
{
    public partial class Ausername : Form
    {
        A1 admin;
        Form2 conn = new Form2();
        public Ausername()
        {
            InitializeComponent();
        }
        public Ausername(A1 ad2)
        {
            admin = ad2;
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd1 = new SqlCommand("Update Admin_login set Admin_Uname=@Admin_Uname where Admin_id='" + admin.textBox6.Text + "'", conn.sqlConnection1);
            cmd1.Parameters.AddWithValue("@Admin_Uname", textBox2.Text);
            cmd1.ExecuteNonQuery();
            conn.sqlConnection1.Close();
        }

        private void Ausername_Load(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("Select Admin_Uname from Admin_Login where Admin_id='" + admin.textBox6.Text + "'", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox1.Text = dr["Admin_Uname"].ToString();
            }
            conn.sqlConnection1.Close();
        }
    }
}
