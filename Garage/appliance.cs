using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class Appliance
    {
        private int idAppliance;
        private string Active;
        private int IdWorkstation;
        private string Used;

        public int IdAppliance
        {
            get { return idAppliance; }
            set { idAppliance = value; }
        }
        public string active
        {
            get { return Active; }
            set { Active = value; }
        }

        public int idWorkstation
        {
            get { return IdWorkstation; }
            set { IdWorkstation = value; }
        }

        public string used
        {
            get { return Used; }
            set { Used = value; }
        }


    }
}