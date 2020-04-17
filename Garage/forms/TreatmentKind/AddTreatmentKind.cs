using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1.forms.TreatmentKind
{
    public partial class AddTreatmentKind : Form
    {
        public AddTreatmentKind()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AddTreatmentKind_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbKindTreatments db = new DbKindTreatments();
            WindowsFormsApplication1.KindTreatment w = new WindowsFormsApplication1.KindTreatment();
            try
            {
                w.Id = int.Parse(textBox1.Text);
                w.Kind= textBox3.Text;
                w.Price = int.Parse(textBox2.Text);

            }
            catch (Exception exception)
            {
                MessageBox.Show("Invalid parameters", "Error");
                return;
            }

            if (db.KindTreatmentExist(w.Id))
            {
                MessageBox.Show("Treatment Kind already exist");
                return;

            }

            db.insertTreatmentKind(w);
            MessageBox.Show("add Treatment Kind Success");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
    }
}
