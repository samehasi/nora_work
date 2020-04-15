using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Workstation1 : Form
    {
        int _permi;
        public Workstation1(int p)
        {
            InitializeComponent();
            this._permi = p;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            addworkstation1 frm = new addworkstation1();
            frm.Show();

        }

        private void label4_Click(object sender, EventArgs e)
        {
            searchworkstation frm=new searchworkstation();
            frm.Show();



        }

        private void label3_Click(object sender, EventArgs e)
        {
            ShowWorkStation frm = new ShowWorkStation();
            frm.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            searchworkstation frm = new searchworkstation();
            frm.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ShowWorkStation frm = new ShowWorkStation();
            frm.Show();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            addworkstation1 frm = new addworkstation1();
            frm.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            UpdateWorkStation frm = new UpdateWorkStation();
            frm.Show();

       
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            RemoveWorkStation frm = new RemoveWorkStation();
            frm.Show();

        }

        private void Workstation1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
