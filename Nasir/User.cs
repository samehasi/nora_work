using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class User
    {
        private int idusr;
        private string password;
        private string firstname;
        
        private string lastname;
        private string phone;
        private string datestart;
        private int roleusr;
        public User()
        {  
        }

        public int Idusr
        {
            get { return idusr; }
            set { idusr  = value; }
        }


        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }
        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        public string Datestart
        {
            get { return datestart; }
            set { datestart = value; }
        }

        public int Roleusr
        {
            get { return roleusr; }
            set { roleusr = value; }
        }
        

    }
}