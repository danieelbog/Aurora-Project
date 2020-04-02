namespace AuroraProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GIG_INFLUENCER_RELATION : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gigs", "InfluencerID", c => c.Int(nullable: false));
            CreateIndex("dbo.Gigs", "InfluencerID");
            AddForeignKey("dbo.Gigs", "InfluencerID", "dbo.Influencers", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gigs", "InfluencerID", "dbo.Influencers");
            DropIndex("dbo.Gigs", new[] { "InfluencerID" });
            DropColumn("dbo.Gigs", "InfluencerID");
        }
    }
}
