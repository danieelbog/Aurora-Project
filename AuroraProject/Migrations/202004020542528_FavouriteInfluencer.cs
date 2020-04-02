namespace AuroraProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FavouriteInfluencer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FavouriteGigs", "GigID", "dbo.Gigs");
            CreateTable(
                "dbo.FavouriteInfluencers",
                c => new
                    {
                        FollowerID = c.String(nullable: false, maxLength: 128),
                        InfluencerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FollowerID, t.InfluencerID })
                .ForeignKey("dbo.AspNetUsers", t => t.FollowerID, cascadeDelete: true)
                .ForeignKey("dbo.Influencers", t => t.InfluencerID, cascadeDelete: true)
                .Index(t => t.FollowerID)
                .Index(t => t.InfluencerID);
            
            AddForeignKey("dbo.FavouriteGigs", "GigID", "dbo.Gigs", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FavouriteGigs", "GigID", "dbo.Gigs");
            DropForeignKey("dbo.FavouriteInfluencers", "InfluencerID", "dbo.Influencers");
            DropForeignKey("dbo.FavouriteInfluencers", "FollowerID", "dbo.AspNetUsers");
            DropIndex("dbo.FavouriteInfluencers", new[] { "InfluencerID" });
            DropIndex("dbo.FavouriteInfluencers", new[] { "FollowerID" });
            DropTable("dbo.FavouriteInfluencers");
            AddForeignKey("dbo.FavouriteGigs", "GigID", "dbo.Gigs", "ID", cascadeDelete: true);
        }
    }
}
