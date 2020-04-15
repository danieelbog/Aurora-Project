namespace AuroraProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BasicInfluencerAndMembershipTypes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Influencers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MainLanguage = c.String(nullable: false),
                        MainPlatform = c.String(nullable: false),
                        Exposure = c.String(nullable: false),
                        MainTopic = c.String(nullable: false),
                        AudienceAge = c.String(nullable: false),
                        AudienceMainCountry = c.String(nullable: false),
                        AudienceMainState = c.String(),
                        AudienceMainTrait = c.String(nullable: false),
                        AboutTheInfluencer = c.String(nullable: false),
                        MembershipTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MembershipTypes", t => t.MembershipTypeID, cascadeDelete: true)
                .Index(t => t.MembershipTypeID);
            
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Single(nullable: false),
                        DurationInDays = c.Int(nullable: false),
                        Discount = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Influencers", "MembershipTypeID", "dbo.MembershipTypes");
            DropIndex("dbo.Influencers", new[] { "MembershipTypeID" });
            DropTable("dbo.MembershipTypes");
            DropTable("dbo.Influencers");
        }
    }
}
