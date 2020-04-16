using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1.forms.Call
{
    public partial class CallForm : Form
    {
        public CallForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AddCall f = new AddCall();
            f.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            UpdateCall f = new UpdateCall();
            f.Show( );
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            RemoveCall f = new RemoveCall();
            f.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            SearchCall f = new SearchCall();
            f.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ShowCalls f = new ShowCalls();
            f.Show();
        }
    }
}
