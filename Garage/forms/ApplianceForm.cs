using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class ApplianceForm : Form
    {
        
        private DataTable dt;
        private int count;
        private SqlConnection cnn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private DataSet ds = new DataSet();
        int _permi;
        public ApplianceForm(int p)
        {
            InitializeComponent();
            this._permi = p;
        }


        private void DisplayRecord(int i)
        {

            textBox1.Text = dt.Rows[i]["IdAppliance"].ToString();
            textBox2.Text = dt.Rows[i]["Active"].ToString();
            comboBox4.Text = dt.Rows[i]["IdWorkStation"].ToString();
            textBox3.Text = dt.Rows[i]["Used"].ToString();
        }
     
        

        private void button7_Click(object sender, EventArgs e)
        {
            Appliance a = new Appliance();
            
            {
                if (comboBox3.SelectedIndex == 0)
                {

                    a.IdAppliance = int.Parse(textBox5.Text);
                    DbAppliance db = new DbAppliance();
                    if (db.Found(a.IdAppliance) == false)
                    {
                        textBox1.Text = "Appliance not found";
                        dataGridView1.DataSource = db.SearchApplianceById(a.IdAppliance).Tables[0];
                    }
                    else dataGridView1.DataSource = db.SearchApplianceById(a.IdAppliance).Tables[0];
                }
            }

         
        }
        

        private void button1_Click(object sender, EventArgs e)
        {

            if (this._permi == 3)
            {
                MessageBox.Show("you do not have permission to access!!!");
                return;
            }
            DbAppliance db = new DbAppliance();
            Appliance a = new Appliance();
            a.IdAppliance = int.Parse(textBox1.Text);
            if (db.Found(a.IdAppliance) == false)
            {

                a.active = textBox2.Text;
                a.idWorkstation = int.Parse(comboBox4.Text);
                a.used = textBox3.Text;
                db.insertsAppliance(a);
                MessageBox.Show("Appliance Add");
                dataGridView1.DataSource = db.GetAllAppliance().Tables[0];
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ApplianceForm_Load(object sender, EventArgs e)
        {
            DbAppliance db = new DbAppliance();
            dt = db.GetAllAppliance1();
            count = 0;


            DbClients db1 = new DbClients();
            //comboBox4.DataSource = db1.GetAllWorkStation().Tables[0];
            comboBox4.ValueMember = "IdWorkStation";
            //comboBox4.DisplayMember = "IdWorkstation";

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (this._permi == 3)
            {
                MessageBox.Show("you do not have permission to access!!!");
                return;
            } 
            
            DialogResult ret = MessageBox.Show("Are You Sure To Delete Appliance?", "Delete Appliance", MessageBoxButtons.YesNoCancel);
            if (ret == DialogResult.Yes)
            {
                DbAppliance db = new DbAppliance();
                Appliance a = new Appliance();
                int i = dataGridView1.CurrentCell.RowIndex;
                a.IdAppliance = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                db.DeleteAppliance(a);
                MessageBox.Show("user delete succes!!", "Delete!!!");
                dataGridView1.DataSource = db.GetAllAppliance().Tables[0];
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            int i = dataGridView1.CurrentCell.RowIndex;

            textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            comboBox4.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this._permi == 3)
            {
                MessageBox.Show("you do not have permission to access!!!");
                return;
            } 
            
            DbAppliance db = new DbAppliance();
            Appliance a = new Appliance();
            a.IdAppliance = int.Parse(textBox1.Text);
            a.active = textBox2.Text;
            a.idWorkstation = int.Parse(comboBox4.Text);
            a.used = textBox3.Text;
            DialogResult ret = MessageBox.Show("Are You Sure To Update?", "Update Appliance", MessageBoxButtons.YesNoCancel);
            if (ret == DialogResult.Yes)
            {
                db.UpdateAppliance(a);
                MessageBox.Show("update record", "Appliance");
                db.UpdateAppliance(a);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DbAppliance db = new DbAppliance();
            dataGridView1.DataSource = db.GetAllAppliance().Tables[0];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (count > 0)
                DisplayRecord(--count);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (count < dt.Rows.Count - 1)
                DisplayRecord(++count);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            count = 0;
            DisplayRecord(count);

        }

        private void button10_Click(object sender, EventArgs e)
        {
            count = dt.Rows.Count - 1;
            DisplayRecord(count);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
