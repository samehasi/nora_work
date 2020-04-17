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
    public partial class ShowTreatmentKind : Form
    {
        public ShowTreatmentKind()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbKindTreatments db = new DbKindTreatments();
            dataGridView1.DataSource = db.GetAllKindTreatments().Tables[0];
        }
    }
}
