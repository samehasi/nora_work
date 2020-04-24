using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1.forms.Treatment
{
    public partial class TreatmentFormcs : Form
    {
        public TreatmentFormcs()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AddTreatment f = new AddTreatment();
            f.Show();
        }
    }
}
