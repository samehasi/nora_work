using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class searchworkstation : Form
    {
        public searchworkstation()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Db db = new Db();
            WorkStation w = new WorkStation();
            try
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    w.idworkstation = int.Parse(textBox1.Text);
                    if (db.Found(w.idworkstation) == false)
                    {
                        textBox1.Text = "NOT FOUND";
                        dataGridView1.DataSource = db.SearchWorkStationbycode(w.idworkstation).Tables[0];
                    }
                    else dataGridView1.DataSource = db.SearchWorkStationbycode(w.idworkstation).Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }







        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
