using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1.forms.Client
{
    public partial class RemoveClient : Form
    {
        public RemoveClient()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Db db = new Db();
            WindowsFormsApplication1.Client w = new WindowsFormsApplication1.Client();
            try
            {
                w.Id = int.Parse(textBox1.Text);
                if (db.ClientExist(w.Id) == true)
                {
                    DialogResult dialogResult = MessageBox.Show("Are You Sure To Delete Client?", "Delete", MessageBoxButtons.YesNoCancel);
                    if (dialogResult == DialogResult.Yes)
                    {
                        db.DeleteClient(w);
                        MessageBox.Show("Delete Client");
                    }
                }
                else MessageBox.Show("Client with similar ID wat not found , try again", "Error");
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
    }
}
