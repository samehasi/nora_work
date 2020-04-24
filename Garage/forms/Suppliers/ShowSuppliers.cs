using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication1.DB;

namespace WindowsFormsApplication1.forms.Suppliers
{
    public partial class ShowSuppliers : Form
    {
        public ShowSuppliers()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbSupplier db = new DbSupplier();
            dataGridView1.DataSource = db.GetAllSuppliers().Tables[0];
        }
    }
}
