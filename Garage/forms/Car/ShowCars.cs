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
    public partial class ShowCars : Form
    {
        public ShowCars()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbCars db = new DbCars();
            dataGridView1.DataSource = db.GetAllCars().Tables[0];
        }
    }
}
