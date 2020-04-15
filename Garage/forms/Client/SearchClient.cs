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
    public partial class SearchClient : Form
    {
        public SearchClient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Db db = new Db();
            
            try
            {

              
                if (comboBox1.SelectedIndex == 0)
                {
                    WindowsFormsApplication1.Client w = new WindowsFormsApplication1.Client();
                    w.Id = int.Parse(textBox1.Text);
                    if (db.ClientExist(w.Id) == true)
                    {
                        dataGridView1.DataSource = db.SearchClientbyId(w.Id).Tables[0];
                    }
                }
                else
                {
                    dataGridView1.DataSource = db.SearchClientbyName(textBox3.Text).Tables[0];
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
