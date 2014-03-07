namespace aspWebProj7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedPerson : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.People", "FirstName", c => c.String(nullable: false, maxLength: 4000));
            AlterColumn("dbo.People", "LastName", c => c.String(nullable: false, maxLength: 4000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.People", "LastName", c => c.String(maxLength: 4000));
            AlterColumn("dbo.People", "FirstName", c => c.String(maxLength: 4000));
        }
    }
}
