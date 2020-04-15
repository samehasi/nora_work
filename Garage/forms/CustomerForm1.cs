using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Media;

namespace WindowsFormsApplication1
{
    public partial class CustomerForm1 : Form
    {
        private DataTable dt;
        private int count;
        private SqlConnection cnn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private DataSet ds = new DataSet();
        int _permi;
        public CustomerForm1(int p)
        {
            InitializeComponent();
            this._permi = p;
        }

        private void DisplayRecord(int i)
        {
            DbCustomer db = new DbCustomer();

            dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[0];
            textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            textBox4.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
            dateTimePicker2.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();
            dateTimePicker3.Text = dataGridView1.Rows[i].Cells[8].Value.ToString();
            textBox8.Text = dataGridView1.Rows[i].Cells[9].Value.ToString();
            textBox10.Text = dataGridView1.Rows[i].Cells[10].Value.ToString();
            comboBox1.SelectedValue = dataGridView1.Rows[i].Cells[11].Value.ToString();

            //pictureBox1.Image = null;
            DataSet ds = db.SearchCustomerById(int.Parse(textBox1.Text));
            byte[] data = (byte[])(ds.Tables[0].Rows[0]["Picture1"]);
            MemoryStream ms = new MemoryStream(data);
            pictureBox1.Image = Image.FromStream(ms);
            ms.Close(); 

        }

        private void DisplayDataGridView()
        {
            DbCustomer db = new DbCustomer();

            dataGridView1.DataSource = db.GetAllCustomer().Tables[0];
            dt = db.GetAllCustomer1();
            count = 0;
        }
        //save button
        private void button1_Click(object sender, EventArgs e)
        {
            if (this._permi == 3)
            {
                MessageBox.Show("you do not have permission to access!!!");
                return;
            }

            DbCustomer db = new DbCustomer();
            Customer c = new Customer();
            c.idCustomer = int.Parse(textBox1.Text);

            if (db.Found(c.idCustomer) == false)
            {
                if (txtImagePath1.Text == "")
                {
                    SystemSounds.Hand.Play();
                    MessageBox.Show("plesse Choose Image for customer");
                    pictureBox1.Image = null;
                    return;
                }

                c.firstName = textBox4.Text;
                c.lastname = textBox3.Text;
                c.city = textBox2.Text;
                c.street = textBox6.Text;
                c.picture = ReadFile(txtImagePath1.Text);
                c.date = dateTimePicker1.Text;
                c.dateStart = dateTimePicker2.Text;
                c.dateEnd = dateTimePicker3.Text;
                c.age = textBox8.Text;
                c.pelephoneNumber = textBox10.Text;
                c.IdCoach = int.Parse(comboBox1.SelectedValue.ToString());
                db.InsertCustomer(c);

                DisplayDataGridView();
                SystemSounds.Beep.Play();
                MessageBox.Show("add customer successfully !!");
            }
            else
            {
                SystemSounds.Hand.Play();
                MessageBox.Show("this idCustomer is exist try again");
            }
        }
            


        byte[] ReadFile(string sPath)
        {
            //Initialize byte array with a null value initially.
            byte[] data = null;

            //Use FileInfo object to get file size.
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;

            //Open FileStream to read file
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);

            //Use BinaryReader to read file stream into byte array.
            BinaryReader br = new BinaryReader(fStream);

            //When you use BinaryReader, you need to supply number of bytes to read from file.
            //In this case we want to read entire file. So supplying total number of bytes.
            data = br.ReadBytes((int)numBytes);
            return data;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            DialogResult dlgRes = dlg.ShowDialog();
            if (dlgRes != DialogResult.Cancel)
            {
                //Set image in picture box
                pictureBox1.ImageLocation = dlg.FileName;
                //Provide file path in txtImagePath text box.
                txtImagePath1.Text = dlg.FileName;
            }
        }

        private void CustomerForm1_Load(object sender, EventArgs e)
        {
            DbCoach db = new DbCoach();
            comboBox1.ValueMember = "IdCoach";
            comboBox1.DisplayMember = "FirstName";
            comboBox1.DataSource = db.GetAllCoach1();

            DisplayDataGridView();
        }


        //edit button
        private void button4_Click(object sender, EventArgs e)
        {

            int i = dataGridView1.CurrentCell.RowIndex;
            DisplayRecord(i);
        }

        //delete button
        private void button2_Click(object sender, EventArgs e)
        {
            if (this._permi == 3)
            {
                MessageBox.Show("you do not have permission to access!!!");
                return;
            }
            DialogResult ret = MessageBox.Show("Are You Sure To Delete Customer?", "Delete Customer", MessageBoxButtons.YesNoCancel);
            if (ret == DialogResult.Yes)
            {
                DbCustomer db = new DbCustomer();
                Customer c = new Customer();
                
                c.idCustomer = int.Parse(textBox1.Text);
                if (db.Found(c.idCustomer) == true)
                {
                    db.DeleteCustomer(c);
                    DisplayDataGridView();
                    SystemSounds.Beep.Play();
                    MessageBox.Show("Customer delete succes!!", "Delete!!!");
                }
                else
                {
                    SystemSounds.Hand.Play();
                    MessageBox.Show("this idCustomer is not exist try again");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (count > 0)
                DisplayRecord(--count);
        }
        //update button
        private void button3_Click(object sender, EventArgs e)
        {
            if (this._permi == 3)
            {
                MessageBox.Show("you do not have permission to access!!!");
                return;
            }
            DbCustomer db = new DbCustomer();
            Customer c = new Customer();
            c.idCustomer = int.Parse(textBox1.Text);
            if (db.Found(c.idCustomer) == true)
            {

                c.firstName = textBox4.Text;
                c.lastname = textBox3.Text;
                c.city = textBox2.Text;
                c.street = textBox6.Text;
                if (txtImagePath1.Text != "")
                {
                    c.picture = ReadFile(txtImagePath1.Text);
                }
                
                   
                c.date = dateTimePicker1.Text;
                c.dateStart = dateTimePicker2.Text;
                c.dateEnd = dateTimePicker3.Text;
                c.age = textBox8.Text;
                c.pelephoneNumber = textBox10.Text;
                c.IdCoach = int.Parse(comboBox1.SelectedValue.ToString());
                db.UpdateCustomer(c);

                DisplayDataGridView();
                SystemSounds.Beep.Play();
                MessageBox.Show("update Customer successfully !!");
            }
            else
            {
                SystemSounds.Hand.Play();
                MessageBox.Show("this idCustomer is not exist try again");
            }
             
        }
        //reset
        private void button8_Click(object sender, EventArgs e)
        {
            DisplayDataGridView();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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

        private void button7_Click_1(object sender, EventArgs e)
        {
            ReportCustomer frm = new ReportCustomer();
            frm.Show();
        }
    }
}
