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
    public partial class ReportCoach : Form
    {
        public ReportCoach()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbCoach db = new DbCoach();
            string sql = string.Format("select * from couch where firstname='{0}'", textBox1.Text);
            dataGridView1.DataSource = db.ReturnDS(sql).Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DbCoach db = new DbCoach();
            string sql = string.Format("select * from couch where city='{0}'", comboBox1.Text);
            dataGridView1.DataSource = db.ReturnDS(sql).Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DbCoach db = new DbCoach();
            string sql = string.Format("select * from couch where age>={0} and age<={1}", int.Parse(textBox2.Text),int.Parse(textBox3.Text));
            dataGridView1.DataSource = db.ReturnDS(sql).Tables[0];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DbCoach db = new DbCoach();
            string sql = string.Format("select * from couch where gender='{0}'", comboBox2.Text);
            dataGridView1.DataSource = db.ReturnDS(sql).Tables[0];
        }
    }
}
