using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1.forms.Call
{
    public partial class RemoveCall : Form
    {
        public RemoveCall()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbCalls db = new DbCalls();
            WindowsFormsApplication1.Call w = new WindowsFormsApplication1.Call();
            try
            {
                w.Id = int.Parse(textBox1.Text);
                if (db.CallExist(w.Id) == true)
                {
                    DialogResult dialogResult = MessageBox.Show("Are You Sure To Delete Call?", "Delete", MessageBoxButtons.YesNoCancel);
                    if (dialogResult == DialogResult.Yes)
                    {
                        db.DeleteCall(w);
                        MessageBox.Show("Call was deleted Successfully");
                    }
                }
                else MessageBox.Show("Call with similar ID was not found , try again", "Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
