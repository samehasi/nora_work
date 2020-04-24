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
    public partial class UpdateSuppliers : Form
    {
        public UpdateSuppliers()
        {
            InitializeComponent();
        }

        private void UpdateSuppliers_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            WindowsFormsApplication1.Supplier w = new WindowsFormsApplication1.Supplier();
            DbSupplier db = new DbSupplier();
            w.SupplierId = textBox1.Text;
            w.SupplierId = textBox3.Text;
            w.Name = textBox2.Text;
            w.Company = textBox4.Text;
            w.Address = textBox5.Text;
            w.Phone = textBox6.Text;
            db.UpdateSupplier(w);
            MessageBox.Show("Successfully updated Supplier");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Floor_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            WindowsFormsApplication1.Supplier w = new WindowsFormsApplication1.Supplier();
            DbSupplier db = new DbSupplier();
            DataSet ds = new DataSet();
        }
    }
}
