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
    public partial class UpdateTreatmentKind : Form
    {
        public UpdateTreatmentKind()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {


            WindowsFormsApplication1.KindTreatment w = new WindowsFormsApplication1.KindTreatment();

            DbKindTreatments db = new DbKindTreatments();
            DataSet ds = new DataSet();


            try
            {
                w.Id = int.Parse(textBox1.Text);

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();


                if (db.KindTreatmentExist(w.Id) == true)
                {
                    ds = db.getKindTreatmentInfo(w);

                    textBox1.Text = ds.Tables[0].Rows[0]["Number"].ToString();
                    textBox3.Text = ds.Tables[0].Rows[0]["KindTreatment"].ToString();
                    textBox2.Text = ds.Tables[0].Rows[0]["Price"].ToString();

                }
                else
                {
                    textBox1.Text = "Id does not exist";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WindowsFormsApplication1.KindTreatment w = new WindowsFormsApplication1.KindTreatment();
            DbKindTreatments db = new DbKindTreatments();
            w.Id = int.Parse(textBox1.Text);
            w.Kind = textBox3.Text;
            w.Price = int.Parse(textBox2.Text);


            db.UpdateKindTreatment(w);
            MessageBox.Show("Successfully updated Treatment Kind");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
    }
}
