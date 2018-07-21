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
    public partial class Admin : Form
    {
        Form2 conn = new Form2();
        public Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("Select * from Admin_Login", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (textBox1.Text == dr["Admin_Uname"].ToString() && textBox2.Text == dr["Admin_password"].ToString())
                {
                    A1 admin = new A1(this);
                    this.Hide();
                    admin.Show();
                }
                else
                {
                    MessageBox.Show("Incorrect Username or Password!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            conn.sqlConnection1.Close();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
            AcceptButton = this.button1;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }
    }
}
