using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Data.SqlClient;

namespace SalaryMS
{
    public partial class A1 : Form
    {
        Admin ad;
        Form2 conn = new Form2();
        public A1()
        {
            InitializeComponent();
        }
        public A1(Admin ad1)
        {
            ad = ad1;
            InitializeComponent();
        }
        private void A1_Load(object sender, EventArgs e)
        {
            this.tabControl1.Visible = false;
            //this.label2.Text = "W e l c o m e   " + ad.textBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = true;
            tabControl1.SelectedTab = PaySalary;

            //PaySalary ComboBox
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("Select Emp_id from employee where S_status='Unpaid'", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr["Emp_id"]);
            }
            conn.sqlConnection1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = true;
            tabControl1.SelectedTab = EmpEdit;

            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("Select Emp_id from employee", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["Emp_id"]);
            }
            conn.sqlConnection1.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = true;
            tabControl1.SelectedTab = Bonus;
            //Employee ID combo
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("Select Emp_id from employee", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox4.Items.Add(dr["Emp_id"]);
            }
            conn.sqlConnection1.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = true;
            tabControl1.SelectedTab = Aprofile;
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("Select Admin_id from Admin_Login where Admin_Uname='" + ad.textBox1.Text + "'", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox6.Text = dr["Admin_id"].ToString();
            }
            conn.sqlConnection1.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            Ausername au = new Ausername(this);
            this.Hide();
            au.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Apassword ap = new Apassword(this);
            this.Hide();
            ap.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("Select * from employee where Emp_id='" + comboBox1.Text + "'", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr["Emp_name"].ToString();
                textBox2.Text = dr["Emp_designation"].ToString();
                textBox3.Text = dr["Emp_MonthlyS"].ToString();
                textBox4.Text = dr["Emp_phone#"].ToString();
                textBox5.Text = dr["Emp_email"].ToString();
                textBox16.Text = dr["S_status"].ToString();
                //textBox17.Text = dr["Emp_bonus"].ToString();
            }
            conn.sqlConnection1.Close();

            //conn.sqlConnection1.Open();
            //SqlCommand cmd1 = new SqlCommand("Select Bonus from Emp_Bonus where Emp_id='" + comboBox1.Text + "'", conn.sqlConnection1);
            //SqlDataReader dr1 = cmd.ExecuteReader();
            //if (dr1.Read())
            //{
            //    textBox17.Text = dr["Bonus"].ToString();
            //}
            //conn.sqlConnection1.Close();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("Select * from employee where Emp_id='" + comboBox2.Text + "'", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox7.Text = dr["Emp_name"].ToString();
                textBox8.Text = dr["Emp_designation"].ToString();
                textBox9.Text = dr["Emp_salary"].ToString();
                textBox11.Text = dr["S_status"].ToString();
                textBox10.Text = dr["Emp_MonthlyS"].ToString();
            }
            conn.sqlConnection1.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int a, b, c, d,i;
            d = Convert.ToInt32(textBox10.Text);
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("Update employee set Emp_salary=@Emp_salary, S_status=@S_status where Emp_id='" + comboBox2.Text + "'", conn.sqlConnection1);
            if (textBox8.Text == "IT Officer")
            {
                a = d + 25000;
                cmd.Parameters.AddWithValue("Emp_salary", a.ToString());
                cmd.Parameters.AddWithValue("S_status", "Paid");
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();
                textBox11.Clear();
            }
            else if (textBox8.Text == "Manager")
            {
                b = d + 50000;
                cmd.Parameters.AddWithValue("Emp_salary", b.ToString());
                cmd.Parameters.AddWithValue("S_status", "Paid");
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();
                textBox11.Clear();
            }
            else if (textBox8.Text == "Accountant")
            {
                i = d + 30000;
                cmd.Parameters.AddWithValue("Emp_salary", i.ToString());
                cmd.Parameters.AddWithValue("S_status", "Paid");
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();
                textBox11.Clear();
            }
            else if (textBox8.Text == "Purchasing Manager")
            {
                c = d + 20000;
                cmd.Parameters.AddWithValue("Emp_salary", c.ToString());
                cmd.Parameters.AddWithValue("S_status", "Paid");
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();
                textBox11.Clear();
            }
            cmd.ExecuteNonQuery();
            MessageBox.Show("Salary Paid!", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            conn.sqlConnection1.Close();

            conn.sqlConnection1.Open();
            SqlCommand cmd1 = new SqlCommand("Select Emp_id from employee where S_status='Unpaid'", conn.sqlConnection1);
            SqlDataReader dr1 = cmd.ExecuteReader();
            while (dr1.Read())
            {
                comboBox2.Items.Add(dr1["Emp_id"]);
            }
            conn.sqlConnection1.Close();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Bonus Combo (DESIGNATION)
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("Select * from employee where Emp_id='" + comboBox4.Text + "'", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox12.Text = dr["Emp_name"].ToString();
                textBox13.Text = dr["Emp_salary"].ToString();
                textBox15.Text = dr["S_status"].ToString();
                textBox19.Text = dr["Emp_designation"].ToString();
                textBox18.Text = dr["Emp_MonthlyS"].ToString();
            }
            conn.sqlConnection1.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            int a, b, c, d, i;
            a = Convert.ToInt32(textBox13.Text);
            i = Convert.ToInt32(textBox18.Text);
            conn.sqlConnection1.Open();
            if (radioButton1.Checked == true)
            {
                b = a + 10000;
                SqlCommand cmd = new SqlCommand("Update employee set Emp_salary=@Emp_salary where Emp_id='" + comboBox4.Text + "'", conn.sqlConnection1);
                cmd.Parameters.AddWithValue("@Emp_salary", b.ToString());
                MessageBox.Show("Bonus Sucessfully Load!", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                cmd.ExecuteNonQuery();
            }
            else if (radioButton2.Checked == true)
            {
                c = a + 15000;
                SqlCommand cmd = new SqlCommand("Update employee set Emp_salary=@Emp_salary where Emp_id='" + comboBox4.Text + "'", conn.sqlConnection1);
                cmd.Parameters.AddWithValue("@Emp_salary", c.ToString());
                MessageBox.Show("Bonus Sucessfully Load!", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                cmd.ExecuteNonQuery();
            }
            else if (radioButton3.Checked == true)
            {
                d = i * 2;
                SqlCommand cmd = new SqlCommand("Update employee set Emp_MonthlyS=@Emp_MonthlyS where Emp_id='" + comboBox4.Text + "'", conn.sqlConnection1);
                cmd.Parameters.AddWithValue("@Emp_MonthlyS", d.ToString());
                MessageBox.Show("Bonus Sucessfully Load!", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                cmd.ExecuteNonQuery();
            }
            //else
            //{
            //    MessageBox.Show("Select Any Bonus Option!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            conn.sqlConnection1.Close();

            //Bonus ADD
            conn.sqlConnection1.Open();
            if (radioButton1.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("Insert into Emp_bonus(Emp_id, Emp_name, Bonus) values(@Emp_id, @Emp_name, @Bonus)", conn.sqlConnection1);
                cmd.Parameters.AddWithValue("@Emp_id", comboBox4.Text);
                cmd.Parameters.AddWithValue("@Emp_name", textBox12.Text);
                cmd.Parameters.AddWithValue("@Bonus", "Weekly Bonus");
                cmd.ExecuteNonQuery();
            }
            else if (radioButton2.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("Insert into Emp_bonus(Emp_id, Emp_name, Bonus) values(@Emp_id, @Emp_name, @Bonus)", conn.sqlConnection1);
                cmd.Parameters.AddWithValue("@Emp_id", comboBox4.Text);
                cmd.Parameters.AddWithValue("@Emp_name", textBox12.Text);
                cmd.Parameters.AddWithValue("@Bonus", "Monthly Bonus");
                cmd.ExecuteNonQuery();
            }
            else if (radioButton3.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("Insert into Emp_bonus(Emp_id, Emp_name, Bonus) values(@Emp_id, @Emp_name, @Bonus)", conn.sqlConnection1);
                cmd.Parameters.AddWithValue("@Emp_id", comboBox4.Text);
                cmd.Parameters.AddWithValue("@Emp_name", textBox12.Text);
                cmd.Parameters.AddWithValue("@Bonus", "Promotion");
                cmd.ExecuteNonQuery();
            }
            //else
            //{
            //    MessageBox.Show("Select Any Bonus Option!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            conn.sqlConnection1.Close();
        }

        private void A1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to Logout?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dr == DialogResult.Yes)
            {
                Form1 f1 = new Form1();
                this.Hide();
                f1.Show();
            }
            else if (dr == DialogResult.No)
            {
                this.Show();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = true;
            tabControl1.SelectedTab = EmpRequest;

            //DataGridView
            SqlDataAdapter da = new SqlDataAdapter("Select * from Emp_requests", conn.sqlConnection1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("Select Emp_id from employee", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox3.Items.Add(dr["Emp_id"]);
            }
            conn.sqlConnection1.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("Select * from employee where Emp_id='" + comboBox3.Text + "'", conn.sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox23.Text = dr["Emp_name"].ToString();
                textBox22.Text = dr["Emp_designation"].ToString();
                textBox21.Text = dr["Emp_MonthlyS"].ToString();
                textBox14.Text = dr["S_status"].ToString();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            conn.sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("Update employee set S_status=@S_status where Emp_id='" + comboBox3.Text + "'", conn.sqlConnection1);
            cmd.Parameters.AddWithValue("@S_status", "Unpaid");
            MessageBox.Show("Salary allowed To Pay Again!");
            cmd.ExecuteNonQuery();
            conn.sqlConnection1.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Salary not Allowed to Pay");
        }
    }
}
