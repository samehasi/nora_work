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
    public partial class training : Form
    {
         private DataTable dt;
        private int count;
        private SqlConnection cnn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private DataSet ds = new DataSet();
        int _permi;
        public training(int p )
        {
            InitializeComponent();
            this._permi = p;
        }

        private void DisplayRecord(int i)
        {

            textBox1.Text = dt.Rows[i]["IdTraining"].ToString();
            comboBox1.Text = dt.Rows[i]["IdCustomer"].ToString();
            textBox3.Text = dt.Rows[i]["Start"].ToString();
            textBox2.Text = dt.Rows[i]["Finish"].ToString();
            textBox6.Text = dt.Rows[i]["Active"].ToString();
            comboBox2.Text = dt.Rows[i]["IdCoach"].ToString();
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            DbTraining db = new DbTraining();
            training2 t = new training2();
             t.Idtraining= int.Parse(textBox1.Text);
            if (db.Found(t.Idtraining) == false)
            {

                t.Idcustomer = int.Parse(comboBox1.Text);
                t.start = textBox3.Text;
                t.finish = textBox2.Text;
                t.active = textBox6.Text;
                t.Idcoach = int.Parse(comboBox2.Text);
                db.insertsTraining(t);
                MessageBox.Show("Training Add");
                dataGridView1.DataSource = db.GetAllTraining().Tables[0];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            DialogResult ret = MessageBox.Show("Are You Sure To Delete Training?", "Delete Training", MessageBoxButtons.YesNoCancel);
            if (ret == DialogResult.Yes)
            {
                DbTraining db = new DbTraining();
                training2 t = new training2();
                int i = dataGridView1.CurrentCell.RowIndex;
                t.Idtraining = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                db.DeleteTraining(t);
                MessageBox.Show("Training delete succes!!", "Delete!!!");
                dataGridView1.DataSource = db.GetAllTraining().Tables[0];
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentCell.RowIndex;

            textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DbTraining db = new DbTraining();
            training2 t = new training2();
            t.Idtraining = int.Parse(textBox1.Text);
           // t.Idcustomer = int.Parse(comboBox1.Text);
            t.start = textBox3.Text;
            t.finish = textBox2.Text;
            t.active = textBox6.Text;
            t.Idcoach = int.Parse(comboBox2.Text);
            
            DialogResult ret = MessageBox.Show("Are You Sure To Update?", "Update training", MessageBoxButtons.YesNoCancel);
            if (ret == DialogResult.Yes)
            {
                db.UpdateTraining(t);
                MessageBox.Show("update record", "Training");
                db.UpdateTraining(t);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DbTraining db = new DbTraining();
            dataGridView1.DataSource = db.GetAllTraining().Tables[0];
        }

        private void button7_Click(object sender, EventArgs e)
        {
            training2 t = new training2();

            {
                if (comboBox3.SelectedIndex == 0)
                {

                    t.Idtraining = int.Parse(textBox5.Text);
                    DbTraining db = new DbTraining();
                    if (db.Found(t.Idtraining) == false)
                    {
                        textBox1.Text = "Training not found";
                        dataGridView1.DataSource = db.SearchTrainingById(t.Idtraining).Tables[0];
                    }
                    else dataGridView1.DataSource = db.SearchTrainingById(t.Idtraining).Tables[0];
                }
            }
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

        private void training_Load(object sender, EventArgs e)
        {
            DbTraining db = new DbTraining();
            dt = db.GetAllTraining1();
            count = 0;


            DbCustomer db1 = new DbCustomer();
            comboBox1.DataSource = db1.GetAllCustomer().Tables[0];
            comboBox1.ValueMember = "IdCustomer";

            DbCoach db2 = new DbCoach();
            comboBox2.DataSource = db1.GetAllCustomer().Tables[0];
            comboBox2.ValueMember = "IdCoach";
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }
    }
}
