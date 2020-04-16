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
    public partial class ExerciseForm : Form
    {
        private DataTable dt;
        private int count;
        private SqlConnection cnn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private DataSet ds = new DataSet();
        int _permi;
        public ExerciseForm(int p)
        {
            InitializeComponent();
            this._permi = p;
        }

        private void DisplayRecord(int i)
        {
            DbExercise db = new DbExercise();

            dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[0];

            textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            textBox4.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            comboBox1.SelectedValue = dataGridView1.Rows[i].Cells[2].Value.ToString();


            //pictureBox1.Image = null;
            DataSet ds = db.SearchExerciseById(int.Parse(textBox1.Text));
            byte[] data = (byte[])(ds.Tables[0].Rows[0]["Picture"]);
            MemoryStream ms = new MemoryStream(data);
            pictureBox1.Image = Image.FromStream(ms);
            ms.Close();

        }

        private void DisplayDataGridView()
        {
            DbExercise db = new DbExercise();

            dataGridView1.DataSource = db.GetAllExercise().Tables[0];
            dt = db.GetAllExercise1();
            count = 0;
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

        //delete button
        private void button2_Click(object sender, EventArgs e)
        {
           

            DialogResult ret = MessageBox.Show("Are You Sure To Delete Exercise?", "Delete Exercise", MessageBoxButtons.YesNoCancel);
            if (ret == DialogResult.Yes)
            {
                DbExercise db = new DbExercise();
                Exercise ee = new Exercise();
                ee.idexercise = int.Parse(textBox1.Text);

                if (db.Found(ee.idexercise) == true)
                {
                    db.DeleteExercise(ee);
                    DisplayDataGridView();
                    MessageBox.Show("Exercise delete succes!!", "Delete!!!");
                }
                else
                {
                    MessageBox.Show("this idexercise is not exist try again");
                }
            }
        }
        //edit button
        private void button4_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentCell.RowIndex;
            DisplayRecord(i);
        }

        //save button
        private void button1_Click(object sender, EventArgs e)
        {
            
            DbExercise db = new DbExercise();
            Exercise ee = new Exercise();

            if (textBox1.Text == "")
            {
                SystemSounds.Hand.Play();
                MessageBox.Show("plesse insert Idexercise for Exercise");
                pictureBox1.Image = null;
                return;
            }

            if (comboBox1.SelectedValue.ToString() == "")
            {
                SystemSounds.Hand.Play();
                MessageBox.Show("plesse Choose workstation for Exercise");
                pictureBox1.Image = null;
                return;
            }


            if (textBox4.Text == "")
            {
                SystemSounds.Hand.Play();
                MessageBox.Show("plesse insert exerciseName  for Exercise");
                pictureBox1.Image = null;
                return;
            }

            if (txtImagePath1.Text == "")
            {
                SystemSounds.Hand.Play();
                MessageBox.Show("plesse Choose Image for Exercise");
                pictureBox1.Image = null;
                return;
            }


            ee.idexercise = int.Parse(textBox1.Text);

            if (db.Found(ee.idexercise) == false)
            {
                
                ee.exerciseName = textBox4.Text;
                ee.workstation = int.Parse(comboBox1.SelectedValue.ToString());
                ee.picture = ReadFile(txtImagePath1.Text);
                db.InsertExercise(ee);
                DisplayDataGridView();
                SystemSounds.Exclamation.Play();
                MessageBox.Show("add Exercise successfully !!");
            }
            else
            {
                MessageBox.Show("this idexercise is exist try again");
            }

        }

        //update button
        private void button3_Click(object sender, EventArgs e)
        {
            
            DbExercise db = new DbExercise();
            Exercise ee = new Exercise();
            ee.idexercise = int.Parse(textBox1.Text);
            if (db.Found(ee.idexercise) == true)
            {
                ee.exerciseName = textBox4.Text;
                ee.workstation = int.Parse(comboBox1.SelectedValue.ToString());
                if (txtImagePath1.Text != "")
                {
                    ee.picture = ReadFile(txtImagePath1.Text);
                }

                db.UpdateExercise(ee);
                DisplayDataGridView();
                MessageBox.Show("update Exercise successfully !!");
            }
            else
            {
                MessageBox.Show("this idexercise is not exist try again");
            }

        }
        //reset button
        private void button8_Click(object sender, EventArgs e)
        {
            DisplayDataGridView();
        }

        private void ExerciseForm_Load(object sender, EventArgs e)
        {
            DbClients db = new DbClients();

            comboBox1.ValueMember = "IdWorkStation";
            comboBox1.DisplayMember = "name";
           // comboBox1.DataSource = db.GetAllWorkStationdt();

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
        //<
        private void button5_Click(object sender, EventArgs e)
        {
            if (count > 0)
                DisplayRecord(--count);
        }
        //>
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
    }
}