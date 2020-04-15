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
    public class Customer
    {
        private int IdCustomer;
        private string FirstName;
        private string LastName;
        private string City;
        private string Street;
        private byte[] Picture;
        private string Date;
        private string DateStart;
        private string DateEnd;
        private string Age;
        private string PelephoneNumber;
        private int idcoach;

        public int idCustomer
        {
            get { return IdCustomer; }
            set { IdCustomer = value; }
        }
        public string firstName
        {
            get { return FirstName; }
            set { FirstName = value; }
        }

        public string lastname
        {
            get { return LastName; }
            set { LastName = value; }
        }

        public string city
        {
            get { return City; }
            set { City = value; }
        }
        public string street
        {
            get { return Street; }
            set { Street = value; }
        }
        public byte[] picture
        {
            get { return Picture; }
            set { Picture = value; }
        }
        public string date
        {
            get { return Date; }
            set { Date = value; }
        }
        public string dateStart
        {
            get { return DateStart; }
            set { DateStart = value; }
        }
        public string dateEnd
        {
            get { return DateEnd; }
            set { DateEnd = value; }
        }
        public string age
        {
            get { return Age; }
            set { Age = value; }
        }
        public string pelephoneNumber
        {
            get { return PelephoneNumber; }
            set { PelephoneNumber = value; }
        }
        public int IdCoach
        {
            get { return idcoach; }
            set { idcoach = value; }
        }

    }
}
