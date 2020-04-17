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
    public partial class RemoveTreatmentKind : Form
    {
        public RemoveTreatmentKind()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbKindTreatments db = new DbKindTreatments();
            WindowsFormsApplication1.KindTreatment w = new WindowsFormsApplication1.KindTreatment();
            try
            {
                w.Id = int.Parse(textBox1.Text);
                if (db.KindTreatmentExist(w.Id) == true)
                {
                    DialogResult dialogResult = MessageBox.Show("Are You Sure To Delete Treatment Kind?", "Delete", MessageBoxButtons.YesNoCancel);
                    if (dialogResult == DialogResult.Yes)
                    {
                        db.DeleteKindTreatment(w);
                        MessageBox.Show("Treatment Kind was deleted Successfully");
                    }
                }
                else MessageBox.Show("Treatment Kind with similar ID was not found , try again", "Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
