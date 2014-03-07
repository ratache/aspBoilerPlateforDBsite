using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aspWebProj7.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public virtual Person Person { get; set; }
        public virtual Movie Movie { get; set; }
        public int PersonId { get; set; }
        public int MovieId { get; set; }
    }
}