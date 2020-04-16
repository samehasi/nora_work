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
    public partial class UpdateWorker : Form
    {
        public UpdateWorker()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WindowsFormsApplication1.Worker w = new WindowsFormsApplication1.Worker();
            DbWorker db = new DbWorker();
            DataSet ds = new DataSet();
            try
            {
                w.Id = int.Parse(textBox1.Text);
                if (db.WorkerExist(w.Id) == true)
                {
                    ds = db.getWorkerInfo(w);
                    textBox1.Text = ds.Tables[0].Rows[0]["WorkerId"].ToString();
                    textBox3.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
                    textBox2.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
                    textBox4.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                    textBox5.Text = ds.Tables[0].Rows[0]["Phone"].ToString();
                    textBox6.Text = ds.Tables[0].Rows[0]["BirthDate"].ToString();
                }
                else textBox1.Text = "Worker not found ";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WindowsFormsApplication1.Worker w = new WindowsFormsApplication1.Worker();
            DbWorker db = new DbWorker();
            w.Id = int.Parse(textBox1.Text);
            w.FirstName = textBox3.Text;
            w.LastName = textBox2.Text;
            w.Address = textBox4.Text;
            w.Phone = textBox5.Text;
            w.BirthDate  = textBox6.Text;
            db.UpdateWorker(w);
            MessageBox.Show("Successfully updated Worker");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
