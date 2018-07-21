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
    public partial class Epassword : Form
    {
        public Epassword()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            E1 emp = new E1();
            this.Hide();
            emp.Show();
        }
    }
}
