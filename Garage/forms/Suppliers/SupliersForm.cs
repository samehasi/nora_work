using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1.forms.Suppliers
{
    public partial class SupliersForm : Form
    {
        public SupliersForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AddSupplier f = new AddSupplier();
            f.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            UpdateSuppliers f = new UpdateSuppliers();
            f.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            SearchSupplier f = new SearchSupplier();
            f.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ShowSuppliers f = new ShowSuppliers();
            f.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            RemoveSuppliers f = new RemoveSuppliers();
            f.Show();
        }
    }
}
