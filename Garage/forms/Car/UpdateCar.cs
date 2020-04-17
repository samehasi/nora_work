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
    public partial class UpdateCar : Form
    {
        public UpdateCar()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WindowsFormsApplication1.Car w = new WindowsFormsApplication1.Car();
            DbCars db = new DbCars();
            DataSet ds = new DataSet();
            try
            {
                w.Id = int.Parse(textBox1.Text);
                if (db.CarExist(w.Id) == true)
                {
                    ds = db.getCarInfo(w);
                    textBox1.Text = ds.Tables[0].Rows[0]["ProductCode"].ToString();
                    textBox3.Text = ds.Tables[0].Rows[0]["Kind"].ToString();
                    textBox2.Text = ds.Tables[0].Rows[0]["Color"].ToString();
                    textBox4.Text = ds.Tables[0].Rows[0]["ClientId"].ToString();
                    textBox5.Text = ds.Tables[0].Rows[0]["History"].ToString();
                }
                else textBox1.Text = "Car not found ";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                WindowsFormsApplication1.Car w = new WindowsFormsApplication1.Car();
                DbCars db = new DbCars();
                w.Id = int.Parse(textBox1.Text);
                w.Kind = textBox3.Text;
                w.Color = textBox2.Text;
                w.ClientId = int.Parse(textBox4.Text);
                w.History = int.Parse(textBox5.Text);

                DbClients cdb  = new DbClients();


                if (!cdb.ClientExist(w.ClientId))
                {
                    MessageBox.Show("Client Does not exist");
                    return;
                }

                db.UpdateCar(w);
                MessageBox.Show("Successfully updated Car");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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
