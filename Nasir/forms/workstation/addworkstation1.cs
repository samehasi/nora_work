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
    public partial class addworkstation1 : Form
    {
        public addworkstation1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Floor_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Db db = new Db();
            WorkStation w = new WorkStation();
            w.idworkstation = int.Parse(textBox1.Text);
            w.name = textBox3.Text;
            w.amount = int.Parse(textBox2.Text);
            w.place = textBox4.Text;
            w.floor = textBox5.Text;
            db.InsertTeacher(w);
            MessageBox.Show("add workstation Success");


            
            
            
            
            
          
        }
    }
}
