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
    public partial class AddSupplier : Form
    {
        public AddSupplier()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbSupplier db = new DbSupplier();
            WindowsFormsApplication1.Supplier w = new WindowsFormsApplication1.Supplier();

            w.SupplierId = textBox1.Text;
            w.Name = textBox3.Text;
            w.Company = textBox2.Text;
            w.Address = textBox4.Text;
            w.Phone = textBox5.Text;
            w.Fax = textBox6.Text;




        }
    }
}
