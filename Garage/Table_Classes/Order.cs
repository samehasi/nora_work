using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class Order
    { 
        private int idorder;
        private string dateord;
        private string timeord;
        private int idcoach;
        private string codeappliance;
        private int amountord;
        private string noteord;


        public int Idorder
        {
            get { return idorder; }
            set { idorder = value; }
        }
        public string Dateord
        {
            get { return dateord; }
            set { dateord = value; }
        }
        public string Timeord
        {
            get { return timeord; }
            set { timeord = value; }
        }
        public int Idcoach
        {
            get { return idcoach; }
            set { idcoach = value; }
        }
        public string Codeappliance
        {
            get { return codeappliance; }
            set { codeappliance = value; }
        }
        public int Amountord
        {
            get { return amountord; }
            set { amountord = value; }
        }
        public string Noteord
        {
            get { return noteord; }
            set { noteord = value; }
        }

    }
}