using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication1;

namespace WindowsFormsApplication1.forms.Client
{
    public partial class AddClient : Form
    {
        public AddClient()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbClients db = new DbClients();
            WindowsFormsApplication1.Client w = new WindowsFormsApplication1.Client();
            try
            {
                w.Id = int.Parse(textBox1.Text);
                w.FirstName = textBox3.Text;
                w.LastName = textBox2.Text;
                w.Address = textBox4.Text;
                w.Phone = textBox5.Text;
            }
            catch (Exception exception)
            { 
                MessageBox.Show("Invalid parameters", "Error");
                return;
            }
            db.InsertClient(w);
            MessageBox.Show("add workstation Success");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }
    }
}
