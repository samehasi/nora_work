using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1.forms.Car
{
    public partial class SearchCar : Form
    {
        public SearchCar()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbCars db = new DbCars();

            try
            {

                WindowsFormsApplication1.Car w = new WindowsFormsApplication1.Car();
                w.Id = int.Parse(textBox1.Text);

                if (comboBox1.SelectedIndex == 0)
                {
                    dataGridView1.DataSource = db.SearchCarByProductCode(w.Id).Tables[0];
                }
                else
                {
                    dataGridView1.DataSource = db.SearchCarByClientId(w.Id).Tables[0];

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
