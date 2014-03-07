namespace aspWebProj7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedPerson1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.People", "Email", c => c.String(nullable: false, maxLength: 4000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.People", "Email", c => c.String(maxLength: 4000));
        }
    }
}
