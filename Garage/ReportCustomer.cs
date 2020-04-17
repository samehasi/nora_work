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
    public partial class ReportCustomer : Form
    {
        public ReportCustomer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbCustomer db = new DbCustomer();
            string sql = string.Format("select * from Customer where firstname='{0}'", textBox1.Text);
            dataGridView1.DataSource = db.ReturnDS(sql).Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
