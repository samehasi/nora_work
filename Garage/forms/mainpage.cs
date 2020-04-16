using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication1.forms.Call;
using WindowsFormsApplication1.forms.Client;

namespace WindowsFormsApplication1
{
    public partial class mainpage : Form
    {
        int _permi;
        public mainpage(int p, string uname )
        {
            InitializeComponent();
            this._permi = p;

            label10.Text = "Welcome " + uname;
        }

        private void mainpage_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            OrderForm frm = new OrderForm(_permi);
             
             frm.Show();
            

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            CoachForm frm = new CoachForm(_permi);
            frm.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            ApplianceForm frm = new ApplianceForm(_permi);
            frm.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Clients frm = new Clients();
            frm.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            training frm = new training(_permi);
            frm.Show();

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            forms.Worker.Worker frm = new forms.Worker.Worker();
            frm.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            if (this._permi != 1)
            {
                MessageBox.Show("you do not have permission to access!!!");
                return;
            }
            UserForm frm = new UserForm(_permi);
            frm.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            CallForm f = new CallForm();
            f.Show();
        }
    }
}
