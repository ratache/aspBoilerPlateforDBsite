using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace aspWebProj7.Models
{
    public class MySeedingStrategy:DropCreateDatabaseIfModelChanges<MovieDbContext>
    {
        protected override void Seed(MovieDbContext context)
        {
            context.People.Add(new Person()
            {
                FirstName = "Mikael",
                LastName = "Ohlsson",
                Email = "mikael.ohlsson@mah.se",
                Address = new Address()
                {
                    Line1 = "Testgatan 81",
                    City = "Testarby",
                    ZIP = "11212"
                }
            });
            context.People.Add(new Person()
            {
                FirstName = "Farid",
                LastName = "Naisan",
                Email = "farid.naisan@mah.se",
                Address = new Address()
                {
                    Line1 = "Testgatan 1337",
                    City = "MinBy",
                    ZIP = "11111"
                }
            });
            base.Seed(context);
        }
    }
}