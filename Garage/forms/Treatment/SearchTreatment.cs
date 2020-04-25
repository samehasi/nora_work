using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1.forms.Treatment
{
    public partial class SearchTreatment : Form
    {
        public SearchTreatment()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbTreatments db = new DbTreatments();

            try
            {

                WindowsFormsApplication1.Treatment w = new WindowsFormsApplication1.Treatment();
                

                if (comboBox1.SelectedIndex == 0)
                {
                    dataGridView1.DataSource = db.searchTreatmentById(int.Parse(textBox1.Text)).Tables[0];
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    dataGridView1.DataSource = db.searchTreatmentByClientName(textBox1.Text).Tables[0];
                }
                else
                {
                    dataGridView1.DataSource = db.searchTreatmentByCarId(int.Parse(textBox1.Text)).Tables[0];

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DbTreatments db = new DbTreatments();
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                if (r.Selected)
                {
                    int id = int.Parse(r.Cells["Idtreatment"].Value.ToString());
                    dataGridView2.DataSource = db.searchInvoiceByTreatmentId(id).Tables[0];
                }
            }
        }
    }
}
