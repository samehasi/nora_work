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
    public partial class ShowWorkers : Form
    {
        public ShowWorkers()
        {
            InitializeComponent();
        }
         
        private void button1_Click(object sender, EventArgs e)
        {
            DbWorker db = new DbWorker();
            dataGridView1.DataSource = db.GetAllWorkers().Tables[0];
        }
    }
}
