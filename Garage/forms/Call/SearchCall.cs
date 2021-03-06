﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1.forms.Call
{
    public partial class SearchCall : Form
    {
        public SearchCall()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbCalls db = new DbCalls();

            try
            {

                WindowsFormsApplication1.Call w = new WindowsFormsApplication1.Call();
                w.Id = int.Parse(textBox1.Text);

                if (comboBox1.SelectedIndex == 0)
                {
                    dataGridView1.DataSource = db.SearchCallByCallId(w.Id).Tables[0];
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    dataGridView1.DataSource = db.SearchCallByWorkerId(w.Id).Tables[0];
                }
                else
                {
                    dataGridView1.DataSource = db.SearchCallByClientId(w.Id).Tables[0];

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
