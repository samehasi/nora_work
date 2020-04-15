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
    public partial class CoachForm : Form
    {
        private DataTable dt;
        private int count;
        private SqlConnection cnn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private DataSet ds = new DataSet();
        int _permi;
        public CoachForm(int p)
        {
            InitializeComponent();
            this._permi = p;
        }

        private void DisplayRecord(int i)
        {
            dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[0];
            textBox1.Text = dt.Rows[i]["IdCoach"].ToString();
            textBox4.Text = dt.Rows[i]["firstname"].ToString();
            textBox3.Text = dt.Rows[i]["lastname"].ToString();
            textBox3.Text = dt.Rows[i]["city"].ToString();
            textBox6.Text = dt.Rows[i]["address"].ToString();
            textBox9.Text = dt.Rows[i]["phone"].ToString();
            textBox8.Text = dt.Rows[i]["age"].ToString();
            textBox7.Text = dt.Rows[i]["gender"].ToString();
           
           

        }

        private void DisplayDataGridView()
        {
            DbCoach db = new DbCoach();

            dataGridView1.DataSource = db.GetAllCoach().Tables[0];
            dt = db.GetAllCoach1();
            count = 0;
        }

        

        private void CoachForm_Load(object sender, EventArgs e)
        {
          

        }

       

        private void button4_Click_1(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[0];
            textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            textBox4.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            textBox9.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            textBox8.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();
           
        }

       

        private void button9_Click_1(object sender, EventArgs e)
        {
            count = 0;
            DisplayRecord(count);
        }

       

        private void button8_Click(object sender, EventArgs e)
        {
            DisplayDataGridView();
        }

        //save button
        private void button1_Click(object sender, EventArgs e)
        {
            if (this._permi == 3)
            {
                MessageBox.Show("you do not have permission to access!!!");
                return;
            } 
            Coach c = new Coach();
            DbCoach db = new DbCoach();
            c.IdCoach = int.Parse(textBox1.Text);
            if (db.Found(c.IdCoach) == false)
            {

                c.Firstname = textBox4.Text;
                c.Lastname = textBox3.Text;
                c.City = textBox2.Text;
                c.Address = textBox6.Text;
                c.Phone = textBox9.Text;
                c.Age = int.Parse(textBox8.Text);
                c.Gender = textBox7.Text;
                db.insertsCoach(c);
                DisplayDataGridView();
                MessageBox.Show("add success", "Coach");
                dataGridView1.DataSource = db.GetAllCoach().Tables[0];
            }
            else
            {
                MessageBox.Show("this idCoach is exist try again");
            }
        }

        //delete button
        private void button2_Click(object sender, EventArgs e)
        {
            if (this._permi == 3)
            {
                MessageBox.Show("you do not have permission to access!!!");
                return;
            } 

            DialogResult ret = MessageBox.Show("Are You Sure To Delete Coach?", "Delete Coach", MessageBoxButtons.YesNoCancel);
            if (ret == DialogResult.Yes)
            {
                DbCoach db = new DbCoach();
                Coach c = new Coach();
                c.IdCoach = int.Parse(textBox1.Text);
                if (db.Found(c.IdCoach) == true)
                {
                    db.DeleteCoach(c);
                    DisplayDataGridView();
                    MessageBox.Show("coach delete succes!!", "Delete!!!");

                }
                else
                {
                    MessageBox.Show("this idCoach is not exist try again");
                }

            }
        }
        //edit button
        private void button4_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentCell.RowIndex;
            DisplayRecord(i);

        }
        //update button
        private void button3_Click(object sender, EventArgs e)
        {
            if (this._permi == 3)
            {
                MessageBox.Show("you do not have permission to access!!!");
                return;
            } 


            DialogResult ret = MessageBox.Show("Are You Sure To Update?", "update Coach", MessageBoxButtons.YesNoCancel);
            if (ret == DialogResult.Yes)
            {
                DbCoach db = new DbCoach();
                Coach c = new Coach();
                c.IdCoach = int.Parse(textBox1.Text);
                if (db.Found(c.IdCoach) == true)
                {
                    c.Firstname = textBox4.Text;
                    c.Lastname = textBox3.Text;
                    c.City = textBox2.Text;
                    c.Address = textBox6.Text;
                    c.Phone = textBox9.Text;
                    c.Age = int.Parse(textBox8.Text);
                    c.Gender = textBox7.Text;
                    db.UpdateCoach(c);
                    DisplayDataGridView();
                    MessageBox.Show("update record", "Coach");
                }
                else
                {
                    MessageBox.Show("this idCoach is not exist try again");
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

        private void button7_Click(object sender, EventArgs e)
        {
            DbCoach db = new DbCoach();
            Coach c = new Coach();
            try
            {
                if (comboBox3.SelectedIndex == 0)
                {
                    c.IdCoach = int.Parse(textBox5.Text);
                    if (db.Found(c.IdCoach) == false)
                    {
                        textBox1.Text = "NOT FOUND";
                        dataGridView1.DataSource = db.SearchCoachById(c.IdCoach).Tables[0];
                    }
                    else dataGridView1.DataSource = db.SearchCoachById(c.IdCoach).Tables[0];
                }

                if (comboBox3.SelectedIndex == 1)
                {
                    c.Firstname = (textBox5.Text);
                    if (db.FoundCoachByName(c.Firstname) == false)
                    {
                        textBox1.Text = "NOT FOUND";
                        dataGridView1.DataSource = db.SearchCoachByName(c.Firstname).Tables[0];
                    }
                    else dataGridView1.DataSource = db.SearchCoachByName(c.Firstname).Tables[0];
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ReportCoach frm = new ReportCoach();
            frm.Show();
        }

       
    }
}

   