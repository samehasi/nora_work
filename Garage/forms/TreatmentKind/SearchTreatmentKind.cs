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
    public partial class SearchTreatmentKind : Form
    {
        public SearchTreatmentKind()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbKindTreatments db = new DbKindTreatments();


            try
            {

                WindowsFormsApplication1.KindTreatment w = new WindowsFormsApplication1.KindTreatment();

                if (comboBox1.SelectedIndex == 0)
                {
                    w.Id = int.Parse(textBox1.Text);

                    dataGridView1.DataSource = db.SearchKindTreatmentByKindTreatmentId(w.Id).Tables[0];
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    dataGridView1.DataSource = db.SearchKindTreatmentByName(textBox1.Text).Tables[0];
                }
                else
                {
                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
