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
    public partial class RemoveCar : Form
    {
        public RemoveCar()
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
                if (db.CarExist(w.Id) == true)
                {
                    DialogResult dialogResult = MessageBox.Show("Are You Sure To Delete Car?", "Delete", MessageBoxButtons.YesNoCancel);
                    if (dialogResult == DialogResult.Yes)
                    {
                        db.DeleteCar(w);
                        MessageBox.Show("Car was deleted Successfully");
                    }
                }
                else MessageBox.Show("Car with similar ID was not found , try again", "Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
