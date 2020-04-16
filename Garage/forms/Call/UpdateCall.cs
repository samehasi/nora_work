using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1.forms.Call
{
    public partial class UpdateCall : Form
    {
        public UpdateCall()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {



            WindowsFormsApplication1.Call w = new WindowsFormsApplication1.Call();
            DbCalls db = new DbCalls();
            DataSet ds = new DataSet();




            try
            {
                w.Id = int.Parse(textBox1.Text);

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();


                if (db.CallExist(w.Id) == true)
                {
                    ds = db.getCallInfo(w);

                    textBox1.Text = ds.Tables[0].Rows[0]["CallCode"].ToString();
                    textBox3.Text = ds.Tables[0].Rows[0]["CallDate"].ToString();
                    textBox2.Text = ds.Tables[0].Rows[0]["CallTime"].ToString();
                    textBox4.Text = ds.Tables[0].Rows[0]["WorkerId"].ToString();
                    textBox5.Text = ds.Tables[0].Rows[0]["ClientId"].ToString();
                    textBox6.Text = ds.Tables[0].Rows[0]["Description"].ToString();
                }
                else
                {
                    textBox1.Text = "Id does not exist";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WindowsFormsApplication1.Call w = new WindowsFormsApplication1.Call();
            DbCalls db = new DbCalls();
            w.Id = int.Parse(textBox1.Text);
            w.CallDate = textBox3.Text;
            w.CallTime = textBox2.Text;
            w.WorkerId = int.Parse(textBox4.Text);
            w.ClientId = int.Parse(textBox5.Text);
            w.Description = textBox6.Text;
            db.UpdateCall(w);
            MessageBox.Show("Successfully updated Call");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }
    }
}
