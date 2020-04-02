namespace AuroraProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FavouriteGig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FavouriteGigs",
                c => new
                    {
                        ActionerID = c.String(nullable: false, maxLength: 128),
                        GigID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ActionerID, t.GigID })
                .ForeignKey("dbo.AspNetUsers", t => t.ActionerID)
                .ForeignKey("dbo.Gigs", t => t.GigID, cascadeDelete: true)
                .Index(t => t.ActionerID)
                .Index(t => t.GigID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FavouriteGigs", "GigID", "dbo.Gigs");
            DropForeignKey("dbo.FavouriteGigs", "ActionerID", "dbo.AspNetUsers");
            DropIndex("dbo.FavouriteGigs", new[] { "GigID" });
            DropIndex("dbo.FavouriteGigs", new[] { "ActionerID" });
            DropTable("dbo.FavouriteGigs");
        }
    }
}
