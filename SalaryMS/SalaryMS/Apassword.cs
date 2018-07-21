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
    public partial class Apassword : Form
    {
        Form2 conn = new Form2();
        A1 admin;
        public Apassword()
        {
            InitializeComponent();
        }
        public Apassword(A1 ad)
        {
            admin = ad;
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
            SqlCommand cmd = new SqlCommand("Select Admin_password from Admin_Login where Admin_id='" + admin.textBox6.Text + "'", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (textBox1.Text == dr["Admin_password"].ToString())
                {
                    SqlCommand cmd1 = new SqlCommand("Update Admin_password set Admin_passowrd=@Admin_password where Admin_id='" + admin.textBox6.Text + "'", conn.sqlConnection1);
                    cmd1.Parameters.AddWithValue("@Admin_password", textBox2.Text);
                    MessageBox.Show("Password Changed!");
                    cmd1.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Incorrect Passowrd!");
                }
            }
            conn.sqlConnection1.Close();
        }
    }
}
