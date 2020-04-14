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
    public partial class OrderForm : Form
    {
        private DataTable dt;
        private int count;
        private SqlConnection cnn = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private DataSet ds = new DataSet();
        int _permi;
        public OrderForm(int p)
        {
            InitializeComponent();
            this._permi = p;
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            DbCoach db = new DbCoach();

            comboBox1.ValueMember = "IdCoach";
            comboBox1.DisplayMember = "FirstName";
            comboBox1.DataSource = db.GetAllCoach1();
        }

        private void DisplayRecord(int i)
        {
            dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[0];
            textBox1.Text = dt.Rows[i]["idorder"].ToString();
            dateTimePicker1.Text  = dt.Rows[i]["dateord"].ToString();
            dateTimePicker2.Text = dt.Rows[i]["timeord"].ToString();
            comboBox1.SelectedValue  = dt.Rows[i]["idcoach"].ToString();
            textBox6.Text = dt.Rows[i]["codeappliance"].ToString();
            textBox8.Text = dt.Rows[i]["amountord"].ToString();
            textBox9.Text = dt.Rows[i]["noteord"].ToString();


            //MessageBox.Show(comboBox1.SelectedValue.ToString());// get value
          
            //comboBox1.SelectedValue = 1232;//selected

        }

        private void DisplayDataGridView()
        {
            DbOrder db = new DbOrder();

            dataGridView1.DataSource = db.GetAllOrder().Tables[0];
            dt = db.GetAllOrder1();
            count = 0;
        }
        //Button reset
        private void button8_Click(object sender, EventArgs e)
        {
            DisplayDataGridView();
        }
        //button edit
        private void button4_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentCell.RowIndex;
            DisplayRecord(i);
        }

        //button save
        private void button1_Click(object sender, EventArgs e)
        {
            if (this._permi == 3)
            {
                MessageBox.Show("you do not have permission to access!!!");
                return;
            }
            Order o = new Order();
            DbOrder db = new DbOrder();
            o.Idorder= int.Parse(textBox1.Text);

            if (db.Found(o.Idorder) == false)
            {
                o.Dateord = dateTimePicker1.Text;
                o.Timeord = dateTimePicker2.Text;
                o.Idcoach = int.Parse(comboBox1.SelectedValue.ToString());
                o.Codeappliance = textBox6.Text;
                o.Amountord = int.Parse(textBox8.Text);
                o.Noteord = textBox9.Text;
                db.insertsorder(o);
                DisplayDataGridView();

                MessageBox.Show("add order successfully !!");
            }
            else
            {
                MessageBox.Show("this order is exist try again");
            }

            
        }
        //button delete
        private void button2_Click(object sender, EventArgs e)
        {
            if (this._permi == 3)
            {
                MessageBox.Show("you do not have permission to access!!!");
                return;
            }
            DialogResult ret = MessageBox.Show("Are You Sure To Delete order?", "Delete order", MessageBoxButtons.YesNoCancel);
            if (ret == DialogResult.Yes)
            {
                Order o = new Order();
                DbOrder db = new DbOrder();
                o.Idorder = int.Parse(textBox1.Text);
                if (db.Found(o.Idorder) == true)
                {
                    db.DeleteOrder(o);
                    DisplayDataGridView();

                    MessageBox.Show("order delete succes!!", "Delete!!!");
                }
                else
                {
                    MessageBox.Show("this order is exist try again");
                }

            }
        }
        //button update
        private void button3_Click(object sender, EventArgs e)
        {
            if (this._permi == 3)
            {
                MessageBox.Show("you do not have permission to access!!!");
                return;
            } 
            DialogResult ret = MessageBox.Show("Are You Sure To Update?", "update order", MessageBoxButtons.YesNoCancel);
             if (ret == DialogResult.Yes)
             {
                Order o = new Order();
                DbOrder db = new DbOrder();
                o.Idorder = int.Parse(textBox1.Text);
                if (db.Found(o.Idorder) == true)
                {
                    o.Dateord = dateTimePicker1.Text;
                    o.Timeord = dateTimePicker2.Text;
                    o.Idcoach = int.Parse(comboBox1.SelectedValue.ToString());
                    o.Codeappliance = textBox6.Text;
                    o.Amountord = int.Parse(textBox8.Text);
                    o.Noteord = textBox9.Text;
                    db.UpdateOrder(o);
                    DisplayDataGridView();
                    MessageBox.Show("update order", "Order");
                }
                else
                {
                    MessageBox.Show("this IdOrder is not exist try again");
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
        //search
        private void button7_Click(object sender, EventArgs e)
        {

            Order o = new Order();
            DbOrder db = new DbOrder();
            if (comboBox3.SelectedIndex == 0)
            {
                //by id

                o.Idorder = int.Parse(textBox5.Text);
                if (db.Found(o.Idorder) == true)
                {
                    dataGridView1.DataSource = db.SearchOrderById(o.Idorder).Tables[0];
                }
                else
                {  
                    textBox5.Text = "NOT FOUND";
                    DisplayDataGridView();
                }

            }

            if (comboBox3.SelectedIndex == 1)
            {
                //by IdCoach
                o.Idcoach = int.Parse(textBox5.Text);
                
                if (db.FoundCoach(o.Idcoach) == true)
                {
                    dataGridView1.DataSource = db.SearchOrderByIdCoach(o.Idcoach).Tables[0];
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
