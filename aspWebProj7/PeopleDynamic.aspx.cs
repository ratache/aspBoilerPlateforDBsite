using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using aspWebProj7.Models;

namespace aspWebProj7
{
    public partial class PeopleDynamic : System.Web.UI.Page
    {
        public MovieDbContext ctx = new MovieDbContext();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //Enable Anotation lookup
            peopleGridView.EnableDynamicData(typeof(Person));
            //Binding users data to UserGridView on this page
            peopleGridView.DataSource = ctx.People.ToList();
            peopleGridView.DataBind();
        }
        public void InsertPerson(Person person)
        {
            ctx.People.Add(person);
            //Since we have not implement address boxes...
            person.Address = new Address();
            ctx.SaveChanges();
            //Redirect clients on every POST request (only if they succeeded)
            Response.Redirect(Request.RawUrl);
        }
        public Person SelectPerson()
        {
            int id = (int)ViewState["personId"];
            return ctx.People.Find(id);
        }
        public void UpdatePerson(Person personUpdated)
        {
            var person = ctx.People.Find(personUpdated.Id);
            person.FirstName = personUpdated.FirstName;
            person.LastName = personUpdated.LastName;
            person.Email = personUpdated.Email;
            ctx.SaveChanges();
            //Redirect clients on every POST request (only if they succeeded)
            Response.Redirect(Request.RawUrl);
        }
        protected void PeopleGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["personId"] = peopleGridView.SelectedDataKey.Value;
            PeopleFormView.ChangeMode(FormViewMode.Edit);
        }
        protected void PeopleGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int personId = (int)e.Keys[0];
            var person = ctx.People.Find(personId);
            ctx.People.Remove(person);
            ctx.SaveChanges();
            Response.Redirect(Request.RawUrl);
        }

        public override void Dispose()
        {
            ctx.Dispose();
            base.Dispose();
        }
    }
}