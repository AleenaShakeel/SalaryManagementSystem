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
    public partial class Eusername : Form
    {
        Form2 conn = new Form2();
        E1 emp;
        public Eusername()
        {
            InitializeComponent();
        }
        public Eusername(E1 e11)
        {
            emp = e11;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            emp.Show();
        }

        private void Eusername_Load(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("Select Emp_username from Emp_Login where Emp_id='" + emp.textBox12.Text + "'", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox1.Text = dr["Emp_username"].ToString();
            }
            conn.sqlConnection1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd1 = new SqlCommand("Update Emp_login set Emp_Username=@Emp_Username where Emp_id='" + emp.textBox12.Text + "'", conn.sqlConnection1);
            cmd1.Parameters.AddWithValue("@Emp_username", textBox2.Text);
            cmd1.ExecuteNonQuery();
            conn.sqlConnection1.Close();
        }
    }
}
