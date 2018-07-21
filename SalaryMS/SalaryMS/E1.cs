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
    public partial class E1 : Form
    {
        Form2 conn = new Form2();
        Employee emp;
        public E1()
        {
            InitializeComponent();
        }
        public E1(Employee e11)
        {
            emp = e11;
            InitializeComponent();
        }

        private void E1_Load(object sender, EventArgs e)
        {
            tabControl1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = true;
            tabControl1.SelectedTab = EmpProfile;
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("Select Emp_id from Emp_Login where Emp_username='" + emp.textBox1.Text + "'", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.textBox1.Text = dr["Emp_id"].ToString();
            }
            conn.sqlConnection1.Close();

            conn.sqlConnection1.Open();
            SqlCommand cmd1 = new SqlCommand("Select * from Employee where Emp_id='" + textBox1.Text + "'", conn.sqlConnection1);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.Read())
            {
                this.textBox2.Text = dr1["Emp_name"].ToString();
                this.textBox3.Text = dr1["Emp_MonthlyS"].ToString();
                this.textBox4.Text = dr1["Emp_Phone#"].ToString();
                this.textBox5.Text = dr1["Emp_Email"].ToString();
                this.textBox6.Text = dr1["S_status"].ToString();
                this.textBox7.Text = dr1["Emp_designation"].ToString();
            }
            conn.sqlConnection1.Close();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int count = 0;
            tabControl1.Visible = true;
            tabControl1.SelectedTab = EmpBonus;

            //conn.sqlConnection1.Open();
            //SqlCommand cmd2 = new SqlCommand("Select * from employee where Emp_id='" + emp.textBox1.Text + "'", conn.sqlConnection1);
            //SqlDataReader dr2 = cmd2.ExecuteReader();
            //if (dr2.Read())
            //{
            //    textBox10.Text = dr2["Emp_name"].ToString();
            //    textBox11.Text = dr2["S_status"].ToString();
            //}
            //conn.sqlConnection1.Close();

            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("Select Emp_id from Emp_Login where Emp_username='" + emp.textBox1.Text + "'", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.textBox8.Text = dr["Emp_id"].ToString();
            }
            conn.sqlConnection1.Close();

            conn.sqlConnection1.Open();
            SqlCommand cmd2 = new SqlCommand("Select * from employee where Emp_id='" + textBox8.Text + "'", conn.sqlConnection1);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            if (dr2.Read())
            {
                textBox10.Text = dr2["Emp_name"].ToString();
                textBox11.Text = dr2["S_status"].ToString();
            }
            conn.sqlConnection1.Close();

            conn.sqlConnection1.Open();
            //SqlCommand cmd = new SqlCommand("Select Count(Emp_id) from Emp_bonus where Emp_id='" + textBox1.Text + "'", conn.sqlConnection1);
            SqlCommand cmd1 = new SqlCommand("Select bonus from Emp_bonus where Emp_id='" + textBox8.Text + "'", conn.sqlConnection1);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.Read())
            {
                textBox9.Text = dr1["Bonus"].ToString();
            }
            else
            {
                label10.Visible = true;
                label10.Text = "There is no Bonus";
            }
            conn.sqlConnection1.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = true;
            tabControl1.SelectedTab = EmpEdit;
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("Select Emp_id from Emp_Login where Emp_Username='" + emp.textBox1.Text + "'", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox12.Text = dr["Emp_id"].ToString();
            }
            conn.sqlConnection1.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Eusername empuser = new Eusername(this);
            this.Hide();
            empuser.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Epassword emppass = new Epassword();
            this.Hide();
            emppass.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd1 = new SqlCommand("Insert into Emp_requests(Emp_id, Emp_name, Emp_Sstatus) values(@Emp_id, @Emp_name, @Emp_Sstatus)", conn.sqlConnection1);
            cmd1.Parameters.AddWithValue("@Emp_id", textBox8.Text);
            cmd1.Parameters.AddWithValue("@Emp_name", textBox10.Text);
            cmd1.Parameters.AddWithValue("@Emp_Sstatus", textBox11.Text);
            MessageBox.Show("Request Forward!");
            cmd1.ExecuteNonQuery();
            conn.sqlConnection1.Close();
        }
    }
}
