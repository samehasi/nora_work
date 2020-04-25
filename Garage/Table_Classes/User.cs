using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class User
    {
        private int userId;
        private string password;
        
        private int roleusr;
        public User()
        {  
        }

        public int UserId
        {
            get { return userId; }
            set { userId  = value; }
        }


        public string Password
        {
            get { return password; }
            set { password = value; }
        }


        public int Level
        {
            get { return roleusr; }
            set { roleusr = value; }
        }
        

    }
}