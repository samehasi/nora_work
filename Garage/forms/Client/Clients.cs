using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1.forms.Client
{
    public partial class Clients : Form
    {
        public Clients()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ShowClients frm = new ShowClients();
            frm.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            SearchClient frm = new SearchClient();
            frm.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            UpdateClient frm = new UpdateClient();
            frm.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            RemoveClient frm = new RemoveClient();
            frm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AddClient frm = new AddClient();
            frm.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
