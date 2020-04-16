using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1.forms.Client
{
    public partial class UpdateClient : Form
    {
        public UpdateClient()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            WindowsFormsApplication1.Client w = new WindowsFormsApplication1.Client();
            DbClients db = new DbClients();
            DataSet ds = new DataSet();
            try
            {
                w.Id = int.Parse(textBox1.Text);
                if (db.ClientExist(w.Id) == true)
                {
                    ds = db.GetClientInfo(w);
                    textBox1.Text = ds.Tables[0].Rows[0]["ClientId"].ToString();
                    textBox3.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
                    textBox2.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
                    textBox4.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                    textBox5.Text = ds.Tables[0].Rows[0]["Phone"].ToString();
                }
                else textBox1.Text = "Client not found ";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WindowsFormsApplication1.Client w = new WindowsFormsApplication1.Client();
            DbClients db = new DbClients();
            w.Id = int.Parse(textBox1.Text);
            w.FirstName = textBox3.Text;
            w.LastName = textBox2.Text;
            w.Address = textBox4.Text;
            w.Phone = textBox5.Text;
            db.UpdateClient(w);
            MessageBox.Show("Successfully updated client");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }
    }
}
