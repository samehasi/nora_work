using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class WorkStation
    {
        private int IdWorkStation;
        private string Name;
        private int Amount;
        private string Place;
        private string Floor;

        public int idworkstation
        {
            get { return IdWorkStation; }
            set { IdWorkStation = value; }
        }
        public int amount
        {
            get { return Amount; }
            set { Amount = value; }
        }

        public string place
        {
            get { return Place; }
            set { Place = value; }
        }

        public string floor
        {
            get { return Floor; }
            set { Floor = value; }
        }
        public string name
        {
            get { return Name; }
            set { Name = value; }
        }

    }
}