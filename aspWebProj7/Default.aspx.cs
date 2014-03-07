using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using aspWebProj7.Models;

namespace aspWebProj7
{
    public partial class _Default : Page
    {
        private MovieDbContext ctx = new MovieDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            PeopleGridView.EnableDynamicData(typeof(Person));//To enable GridView to read these metadata (attributes)
            PeopleGridView.DataSource = ctx.People.ToList<Person>();
            PeopleGridView.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //userID would be 0 if no user has selected
            int personId = (PeopleGridView.SelectedDataKey == null) ? 0 : (int)PeopleGridView.SelectedDataKey.Value;
            Person p = (personId == 0) ?
            new Person() : //new user
            ctx.People.Find(personId); //modify older user, retrive the user state from database
            p.FirstName = txtFName.Text;
            p.LastName = txtLName.Text;
            p.Email = txtEmail.Text;
            p.Address = new Address()
            {
                Line1 = txtLine1.Text,
                Line2 = txtLine1.Text,
                ZIP = txtZIP.Text,
                City = txtCity.Text
            };
            //Add newly user object to database (still needed to be confirmed)
            if (p.Id == 0) ctx.People.Add(p); //only if we have new user
            //Confirm and save changes to database
            ctx.SaveChanges();
            //Redirect clients so they would not be able to send the same information twice by mistake.
            Response.Redirect(Request.RawUrl); //Request.RawUrl would be: "/Default.aspx"
        }

        protected void PeopleGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Get current user id from gridview
            int personId = (int)PeopleGridView.SelectedDataKey.Value;
            //perform a search by its primary key (User.ID)
            //the following line is equavalant to:
            //var user = ctx.Users.First(x=>x.ID == UserID)
            var person = ctx.People.Find(personId);
            //Placing data from database on page
            txtFName.Text = person.FirstName;
            txtLName.Text = person.LastName;
            txtEmail.Text = person.Email;
            txtLine1.Text = person.Address.Line1;
            txtLine2.Text = person.Address.Line2;
            txtZIP.Text = person.Address.ZIP;
            txtCity.Text = person.Address.City;
            //change button caption
            btnSubmit.Text = "Edit";
        }

        protected void PeopleGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //Get current user id from gridview
            int personId = (int)e.Keys[0];
            //Find the user
            var person = ctx.People.Find(personId);
            //Mark the user to be removed
            ctx.People.Remove(person);
            //Confirm changes
            ctx.SaveChanges();
            //Redirect clients on every POST request (only if they succeeded)
            Response.Redirect(Request.RawUrl);
        }
    }
}
/* PROJECT NOTES
 * ^^^^^^^^^^^^^^
 * 
 * MIGRATIONS
 * Enabling migration for changing dataschemes for db tables without losing data:
 * In package manager console>
 * Enable-Migrations-ContextTypeName aspWebProj7.Models.MovieDbContext 
 * 
 * If the model and the database is not in synch go to the “Package Manager Console”. Write “Add-Migration Updatedx”
 * where x= updated class. for ex: "Migration Add-Migration UpdatedPerson”
 * 
 * When all migrations have been created update db by: "Update-Database"
 * Keep in mind every time you change your model and want to update the database, rebuild the project first.
 */