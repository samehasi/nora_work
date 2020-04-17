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
    public partial class TreatmentKindForm : Form
    {
        public TreatmentKindForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AddTreatmentKind F = new AddTreatmentKind();
            F.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            UpdateTreatmentKind f = new UpdateTreatmentKind();
            f.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            SearchTreatmentKind f = new SearchTreatmentKind();
            f.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ShowTreatmentKind f = new ShowTreatmentKind();
            f.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            RemoveTreatmentKind f = new RemoveTreatmentKind();
            f.Show();
        }
    }
}
