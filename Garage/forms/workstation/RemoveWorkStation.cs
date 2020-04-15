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
    public partial class RemoveWorkStation : Form
    {
        public RemoveWorkStation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Db db = new Db();
            WorkStation w = new WorkStation();
            try
            {
                w.idworkstation = int.Parse(textBox1.Text);
                if (db.Found(w.idworkstation) == true)
                {
                    DialogResult dialogResult = MessageBox.Show("Are You Sure To Delete Teacher?", "Delete", MessageBoxButtons.YesNoCancel);
                    if (dialogResult == DialogResult.Yes)
                    {
                        db.DeleteWorkStation(w);
                        MessageBox.Show("Delete WorkStation");
                    }
                }
                else MessageBox.Show("Id WorkStation Not Found Try Again", "Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            {
                Db db1 = new Db();
                dataGridView1.DataSource = db1.GetAllWorkStation().Tables[0];
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
