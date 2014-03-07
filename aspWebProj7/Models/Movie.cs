using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aspWebProj7.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Starts { get; set; }
        public DateTime Ends { get; set; }
    }
}