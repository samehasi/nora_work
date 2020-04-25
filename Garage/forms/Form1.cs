using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                SystemSounds.Beep.Play(); 
                MessageBox.Show("Please enter a iduser");
                return;
            }
            if (textBox2.Text == "")
            {
                //SystemSounds.Beep.Play();
                MessageBox.Show("Please enter a password");
                return;
            }
            
            DbUser db = new DbUser();
            int a = int.Parse(textBox1.Text);
            string b = (textBox2.Text);

            //user id : 123123123
            //password : adminadmin
            if (a == 123123123 && b == "adminadmin")
            {
                mainpage frm = new mainpage(1, "administrator");
                SystemSounds.Asterisk.Play(); 
                this.Visible = false;
                frm.ShowDialog();
                this.Close();
            }


            if (db.ChkeLogin(a, b))
            {
                
                DataSet ds = db.SearchUserById(a);

                int permi = (int)(ds.Tables[0].Rows[0]["Level"]);

                SystemSounds.Asterisk.Play();
                
                mainpage frm = new mainpage(permi, "user");
                

                this.Visible = false;
                frm.ShowDialog();
                this.Close();
            }
            else
            {
                SystemSounds.Beep.Play(); 
                MessageBox.Show("username or password error try again");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
    }
}
