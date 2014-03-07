using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aspWebProj7.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string ZIP { get; set; }
        public string City { get; set; }
        public override string ToString()
        {
            return string.Format("{0}<br/>{1}<br/>{2} {3}", Line1, Line2, ZIP, City);
        }
    }
}