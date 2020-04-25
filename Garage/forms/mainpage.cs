using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication1.forms;
using WindowsFormsApplication1.forms.Call;
using WindowsFormsApplication1.forms.Car;
using WindowsFormsApplication1.forms.Client;
using WindowsFormsApplication1.forms.Suppliers;
using WindowsFormsApplication1.forms.Treatment;
using WindowsFormsApplication1.forms.TreatmentKind;

namespace WindowsFormsApplication1
{
    public partial class mainpage : Form
    {
        int _permi;
        public mainpage(int p, string uname )
        {
            InitializeComponent();
            this._permi = p;

            label10.Text = "Welcome " + uname;
        }

        private void mainpage_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            OrderForm frm = new OrderForm(_permi);
            frm.Show();
            

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            CoachForm frm = new CoachForm(_permi);
            frm.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            ApplianceForm frm = new ApplianceForm(_permi);
            frm.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Clients frm = new Clients();
            frm.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            training frm = new training(_permi);
            frm.Show();

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (this._permi > 2)
            {
                MessageBox.Show("Access Denied");
                return;
            }

            forms.Worker.Worker frm = new forms.Worker.Worker();
            frm.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            CallForm f = new CallForm();
            f.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            CarsForm f = new CarsForm();
            f.Show();
        }

        private void Treatments_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            TreatmentKindForm f = new TreatmentKindForm();
            f.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            if (this._permi != 1)
            {
                MessageBox.Show("Access Denied");
                return;
            }
            UserForm frm = new UserForm(_permi);
            frm.Show();
        }

        private void pictureBox3_Click_3(object sender, EventArgs e)
        {
            SupliersForm f = new SupliersForm();
            f.Show();
           

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {
            TreatmentFormcs f = new TreatmentFormcs();
            f.Show();
        }

        private void pictureBox7_Click_1(object sender, EventArgs e)
        {
            if(_permi > 1)
            {
                MessageBox.Show("Access Denied");
                return;
            }
            MgmtQueries f = new MgmtQueries();
            f.Show();
        }
    }
}
