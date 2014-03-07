namespace aspWebProj7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 4000),
                        Starts = c.DateTime(nullable: false),
                        Ends = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 4000),
                        LastName = c.String(maxLength: 4000),
                        Email = c.String(maxLength: 4000),
                        Address_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .Index(t => t.Address_Id);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Line1 = c.String(maxLength: 4000),
                        Line2 = c.String(maxLength: 4000),
                        ZIP = c.String(maxLength: 4000),
                        City = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.PersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "PersonId", "dbo.People");
            DropForeignKey("dbo.Tickets", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.People", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.Tickets", new[] { "PersonId" });
            DropIndex("dbo.Tickets", new[] { "MovieId" });
            DropIndex("dbo.People", new[] { "Address_Id" });
            DropTable("dbo.Tickets");
            DropTable("dbo.Addresses");
            DropTable("dbo.People");
            DropTable("dbo.Movies");
        }
    }
}
