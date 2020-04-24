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
    public partial class RemoveSuppliers : Form
    {
        public RemoveSuppliers()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbSupplier db = new DbSupplier();
            WindowsFormsApplication1.Supplier w = new WindowsFormsApplication1.Supplier();
            try
            {
                w.SupplierId = textBox1.Text;
                if (db.SupplierExist(w.SupplierId) == true)
                {
                    DialogResult dialogResult = MessageBox.Show("Are You Sure To Delete Supplier?", "Delete", MessageBoxButtons.YesNoCancel);
                    if (dialogResult == DialogResult.Yes)
                    {
                        db.DeleteSupplier(w);
                        MessageBox.Show("Call was deleted Successfully");
                    }
                }
                else MessageBox.Show("Supplier with similar ID was not found , try again", "Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
