namespace AuroraProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuctionModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Auctions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Bet = c.Single(nullable: false),
                        PositionOnMarket = c.Int(nullable: false),
                        GigID = c.Int(nullable: false),
                        SpecificIndustryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Gigs", t => t.GigID, cascadeDelete: true)
                .Index(t => t.GigID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Auctions", "GigID", "dbo.Gigs");
            DropIndex("dbo.Auctions", new[] { "GigID" });
            DropTable("dbo.Auctions");
        }
    }
}
