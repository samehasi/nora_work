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
    public partial class AddCar : Form
    {
        public AddCar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbCars db = new DbCars();
            WindowsFormsApplication1.Car w = new WindowsFormsApplication1.Car();
            try
            {
                w.Id = int.Parse(textBox1.Text);
                w.Kind = textBox3.Text;
                w.Color = textBox2.Text;
                w.ClientId = int.Parse(textBox4.Text);
                w.History = int.Parse(textBox5.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Invalid parameters", "Error");
                return;
            }


            DbClients cdb = new DbClients();

            if (!cdb.ClientExist(w.ClientId))
            {
                MessageBox.Show("Invalid Client", "Error");
                return;

            }



            db.insertCar(w);
            MessageBox.Show("add Car Success");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }
    }
}
