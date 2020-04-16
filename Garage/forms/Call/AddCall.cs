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
    public partial class AddCall : Form
    {
        public AddCall()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbCalls db = new DbCalls();
            WindowsFormsApplication1.Call w = new WindowsFormsApplication1.Call();
            try
            {
                w.Id = int.Parse(textBox1.Text);
                w.CallDate = textBox3.Text;
                w.CallTime = textBox2.Text;
                w.WorkerId = int.Parse(textBox4.Text);
                w.ClientId = int.Parse(textBox5.Text);
                w.Description = textBox6.Text;


                DbWorker wdb = new DbWorker();
                DbClients cdb = new DbClients();

                if (!wdb.WorkerExist(w.WorkerId))
                {
                    MessageBox.Show("Invalid Worker", "Error");
                    return;

                }

                if (!cdb.ClientExist(w.ClientId))
                {
                    MessageBox.Show("Invalid Client", "Error");
                    return;

                }

            }
            catch (Exception exception)
            {
                MessageBox.Show("Invalid parameters", "Error");
                return;
            }
            db.insertCall(w);
            MessageBox.Show("add workstation Success");
        }
    }
}
