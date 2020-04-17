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
    public partial class CarsForm : Form
    {
        public CarsForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AddCar f = new AddCar();
            f.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            UpdateCar f = new UpdateCar();
            f.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            SearchCar f = new SearchCar();
            f.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ShowCars f = new ShowCars();
            f.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            RemoveCar f = new RemoveCar();
            f.Show();
        }
    }
}
