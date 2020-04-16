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
    public partial class SearchWorker : Form
    {
        public SearchWorker()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbWorker db = new DbWorker();

            try
            {


                if (comboBox1.SelectedIndex == 0)
                {
                    WindowsFormsApplication1.Worker w = new WindowsFormsApplication1.Worker();
                    w.Id = int.Parse(textBox1.Text);
                    if (db.WorkerExist(w.Id) == true)
                    {
                        dataGridView1.DataSource = db.SearchWorkerById(w.Id).Tables[0];
                    }
                }
                else
                {
                    dataGridView1.DataSource = db.SearchWorkerByName(textBox3.Text).Tables[0];
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
