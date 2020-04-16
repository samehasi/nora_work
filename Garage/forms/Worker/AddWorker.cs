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
    public partial class AddWorker : Form
    {
        public AddWorker()
        {
            InitializeComponent();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbWorker db = new DbWorker();
            WindowsFormsApplication1.Worker w = new WindowsFormsApplication1.Worker();
            try
            {
                w.Id = int.Parse(textBox1.Text);
                w.FirstName = textBox3.Text;
                w.LastName = textBox2.Text;
                w.Address = textBox4.Text;
                w.Phone = textBox5.Text;
                w.BirthDate = textBox6.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Invalid parameters", "Error");
                return;
            }
            db.insertWorker(w);
            MessageBox.Show("add workstation Success");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }
    }
}
