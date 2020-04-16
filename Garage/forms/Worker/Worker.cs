using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1.forms.Worker
{
    public partial class Worker : Form
    {
        public Worker()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AddWorker frm = new AddWorker();
            frm.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            UpdateWorker frm = new UpdateWorker();
            frm.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            SearchWorker frm = new SearchWorker();
            frm.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ShowWorkers frm = new ShowWorkers();
            frm.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            RemoveWorker frm = new RemoveWorker();
            frm.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void Worker_Load(object sender, EventArgs e)
        {
        }
    }
}
