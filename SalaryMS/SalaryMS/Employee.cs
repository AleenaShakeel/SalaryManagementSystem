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
    public partial class Employee : Form
    {
        Form2 conn = new Form2();
        public Employee()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("Select * from Emp_Login", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (textBox1.Text == dr["Emp_username"].ToString() && textBox2.Text == dr["Emp_password"].ToString())
                {
                    E1 emp = new E1(this);
                    this.Hide();
                    emp.Show();
                }
                else
                {
                    MessageBox.Show("Incorrect Username or Password!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            conn.sqlConnection1.Close();

        }
    }
}
