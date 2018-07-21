using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalaryMS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //ovalShape2.Visible = false;
        }

        private void ovalShape1_Click(object sender, EventArgs e)
        {
            ovalShape4.Visible = false;
            label7.Visible = false;
            ovalShape5.Visible = true;
            ovalShape6.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ovalShape5_MouseClick(object sender, MouseEventArgs e)
        {
            Admin adm = new Admin();
            this.Hide();
            adm.Show();
        }

        private void ovalShape6_MouseClick(object sender, MouseEventArgs e)
        {
            Employee emp = new Employee();
            this.Hide();
            emp.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            ovalShape4.Visible = false;
            label7.Visible = false;
            ovalShape5.Visible = true;
            ovalShape6.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Admin adm = new Admin();
            this.Hide();
            adm.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            this.Hide();
            emp.Show();
        }
    }
}
