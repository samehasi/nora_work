using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class training
    {
        private int IdTraining;
        private int IdCustomer;
        private string Start;
        private string Finish;
        private string Active;
        private int IdCoach;

        public int IdTraining
        {
            get { return IdTraining; }
            set { IdTraining = value; }
        }
        public int IdCustomer
        {
            get { return IdCustomer; }
            set { IdCustomer = value; }
        }

        public string Start
        {
            get { return Start; }
            set { Start = value; }
        }

        public string Finish
        {
            get { return Finish; }
            set { Finish = value; }
        }

        public string Active
        {
            get { return Finish; }
            set { Finish = value; }
        }

        public int IdCoach
        {
            get { return IdCoach; }
            set { IdCOach = value; }
        }



    }
}