using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class Treatment
    {
        public int Id { set; get; }
        public int CustometId { set; get; }
        public string CustomerName { set; get; }
        public int WorkerId { set; get; }
        public string WorkerName { set; get; }
        public string Date { set; get; }
        public string Time { set; get; }

        public int CarId { set; get; }
        public string CarKind { set; get; }
        public int Total { set; get; }
    }
}
