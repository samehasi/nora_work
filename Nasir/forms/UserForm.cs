using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class UserForm : Form
    {
        private DataTable dt;
        private int count;
        private SqlConnection cnn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private DataSet ds = new DataSet();
        int _permi;
        public UserForm(int p)
        {
            InitializeComponent();
            this._permi = p;
            DisplayDataGridView();
            
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            
        }

        private void DisplayRecord(int i)
        {
            dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[0];
            textBox1.Text = dt.Rows[i]["idusr"].ToString();

            textBox2.Text = dt.Rows[i]["Password"].ToString();
            textBox6.Text = dt.Rows[i]["firstname"].ToString();
            textBox8.Text = dt.Rows[i]["lastname"].ToString();
            textBox9.Text = dt.Rows[i]["phone"].ToString();
            dateTimePicker1.Text = dt.Rows[i]["datestart"].ToString();

            int a = int.Parse(dt.Rows[i]["roleusr"].ToString());
            switch (a)
            {
                case 1:
                    comboBox1.Text = "management";
                    break;
                case 2:
                    comboBox1.Text = "Secretariat";
                    break;
                case 3:
                    comboBox1.Text = "worker";
                    break;
            }
            //management
            //secretariat
            //worker

            //MessageBox.Show(comboBox1.SelectedValue.ToString());// get value

            //comboBox1.SelectedValue = 1232;//selected

        }

        private void DisplayDataGridView()
        {
            DbUser db = new DbUser();

            dataGridView1.DataSource = db.GetAllUser().Tables[0];
            dt = db.GetAllUser1();
            count = 0;
        }
        //reset
        private void button8_Click(object sender, EventArgs e)
        {
            DisplayDataGridView();
        }
        //edit
        private void button4_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentCell.RowIndex;
            DisplayRecord(i);
        }
        //save
        private void button1_Click(object sender, EventArgs e)
        {
            
            //omboBox1.Text = "Secretariat";
            //MessageBox.Show(comboBox1.SelectedIndex.ToString());

            
            User u = new User();
            DbUser db = new DbUser();
            u.Idusr = int.Parse(textBox1.Text);

            if (db.Found(u.Idusr) == false)
            {
                if (comboBox1.SelectedIndex.ToString() == "-1")
                {
                    MessageBox.Show("please choose role");
                    return;

                }
                int aa = int.Parse(comboBox1.SelectedIndex.ToString());
                u.Password = textBox2.Text;
                u.Firstname = textBox6.Text;
                u.Lastname = textBox8.Text;
                u.Phone = textBox9.Text;
                u.Datestart = dateTimePicker1.Text;
                u.Roleusr = aa + 1;
                db.insertUser(u);
                DisplayDataGridView();
                MessageBox.Show("add user successfully !!");
            }
            else
            {
                MessageBox.Show("this user is exist try again");
            }
        }
        //update
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Are You Sure To Update?", "update user", MessageBoxButtons.YesNoCancel);
            if (ret == DialogResult.Yes)
            {
            User u = new User();
            DbUser db = new DbUser();
            u.Idusr = int.Parse(textBox1.Text);

            if (db.Found(u.Idusr) == true)
            {
                if (comboBox1.SelectedIndex.ToString() == "-1")
                {
                    MessageBox.Show("please choose role");
                    return;
                }
                int aa = int.Parse(comboBox1.SelectedIndex.ToString());
                u.Password = textBox2.Text;
                u.Firstname = textBox6.Text;
                u.Lastname = textBox8.Text;
                u.Phone = textBox9.Text;
                u.Datestart = dateTimePicker1.Text;
                u.Roleusr = aa + 1;
                db.UpdateUser(u);
                DisplayDataGridView();
                    MessageBox.Show("update user", "User");
                }
                else
                {
                    MessageBox.Show("this Iduser is not exist try again");
                }

            }
        }
        //delete
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Are You Sure To Delete order?", "Delete order", MessageBoxButtons.YesNoCancel);
            if (ret == DialogResult.Yes)
            {
                User u = new User();
            DbUser db = new DbUser();
            u.Idusr = int.Parse(textBox1.Text);

            if (db.Found(u.Idusr) == true)
            {

                db.DeleteUser(u);
                DisplayDataGridView();
                MessageBox.Show("user delete succes!!", "Delete!!!");
             }
                else
                {
                    MessageBox.Show("this user is not exist try again");
                }

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
        //<<
        private void button9_Click(object sender, EventArgs e)
        {
            count = 0;
            DisplayRecord(count);
        }
        //>>
        private void button10_Click(object sender, EventArgs e)
        {
            count = dt.Rows.Count - 1;
            DisplayRecord(count);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            User u = new User();
            DbUser db = new DbUser();
            if (comboBox3.SelectedIndex == 0)
            {
                //by id
                u.Idusr = int.Parse(textBox5.Text);
                if (db.Found(u.Idusr) == true)
                {
                    dataGridView1.DataSource = db.SearchUserById(u.Idusr).Tables[0];
                }
                else
                {
                    textBox5.Text = "NOT FOUND";
                    DisplayDataGridView();
                }

            }

            if (comboBox3.SelectedIndex == 1)
            {
                //by FirstName
                u.Firstname= textBox5.Text;

                if (db.FoundFname(u.Firstname) == true)
                {
                    dataGridView1.DataSource = db.SearchFirstNmae(u.Firstname).Tables[0];
                }
                else
                {
                    textBox5.Text = "NOT FOUND";
                    DisplayDataGridView();
                }

            }
        }

       

        
    }
}
