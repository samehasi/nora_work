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
    public partial class UpdateWorkStation : Form
    {
        public UpdateWorkStation()
        {
            InitializeComponent();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            WorkStation w = new WorkStation();
            Db db = new Db();
            DataSet ds = new DataSet();
            try
            {
                w.idworkstation = int.Parse(textBox1.Text);
                if (db.Found(w.idworkstation) == true)
                {
                    ds = db.GetworkstaionInfo(w);
                    textBox1.Text = ds.Tables[0].Rows[0]["idworkstation"].ToString();
                    textBox3.Text = ds.Tables[0].Rows[0]["name"].ToString();
                    textBox2.Text = ds.Tables[0].Rows[0]["amount"].ToString();
                    textBox4.Text = ds.Tables[0].Rows[0]["place"].ToString();
                    textBox5.Text = ds.Tables[0].Rows[0]["floor"].ToString();
                }
                else textBox1.Text = "workstation not found ";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
           private void button1_Click(object sender, EventArgs e)
           {

            WorkStation w = new WorkStation();
            Db db = new Db();
            w.idworkstation = int.Parse(textBox1.Text);
            w.name = textBox3.Text;
            w.amount = int.Parse(textBox2.Text);
            w.place = textBox4.Text;
            w.floor = textBox5.Text;
            db.UpdateTeacher(w);
            MessageBox.Show("עדכן בהצלחה");

        }

        

        
    }
}
           

