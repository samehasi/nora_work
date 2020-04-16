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
    public partial class RemoveWorker : Form
    {
        public RemoveWorker()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbWorker db = new DbWorker();
            WindowsFormsApplication1.Worker w = new WindowsFormsApplication1.Worker();
            try
            {
                w.Id = int.Parse(textBox1.Text);
                if (db.WorkerExist(w.Id) == true)
                {
                    DialogResult dialogResult = MessageBox.Show("Are You Sure To Delete Worker?", "Delete", MessageBoxButtons.YesNoCancel);
                    if (dialogResult == DialogResult.Yes)
                    {
                        db.DeleteWorker(w);
                        MessageBox.Show("Worker was deleted Successfully");
                    }
                }
                else MessageBox.Show("Worker with similar ID was not found , try again", "Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
