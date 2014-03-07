using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace aspWebProj7.Models
{
    public class Person
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required, Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required, DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required, EmailAddress(ErrorMessage="Please enter a valid Email address")]
        public string Email { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}