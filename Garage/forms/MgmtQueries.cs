using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1.forms
{
    public partial class MgmtQueries : Form
    {
        public MgmtQueries()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DbWorker db = new DbWorker();
            dataGridView1.DataSource = db.GetAllWorkers().Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DbCars db = new DbCars();
            dataGridView1.DataSource = db.GetAllCars().Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DbWorker db = new DbWorker();

            try
            {

                if (comboBox1.SelectedIndex == 0)
                {
                    dataGridView1.DataSource = db.GetAllWorkersSorted("FirstName").Tables[0];
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    dataGridView1.DataSource = db.GetAllWorkersSorted("LastName").Tables[0];
                }
                else
                {
                    dataGridView1.DataSource = db.GetAllWorkersSorted("Address").Tables[0];

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbWorker db = new DbWorker();
            dataGridView1.DataSource = db.FoundWorkerNameStartsWith(textBox1.Text).Tables[0];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DbWorker db = new DbWorker();
            dataGridView1.DataSource = db.FoundWorkerbyAddress(textBox2.Text).Tables[0];
        }

        private void MgmtQueries_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;

            comboBox1.SelectedIndex = 0;
        }
    }
}
