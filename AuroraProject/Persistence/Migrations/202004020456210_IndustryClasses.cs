namespace AuroraProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IndustryClasses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SpecificIndustries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phrase = c.String(),
                        IndustryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Industries", t => t.IndustryID, cascadeDelete: true)
                .Index(t => t.IndustryID);
            
            CreateTable(
                "dbo.Industries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IndustryName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Gigs", "SpecificIndustryID", c => c.Int(nullable: false));
            CreateIndex("dbo.Gigs", "SpecificIndustryID");
            AddForeignKey("dbo.Gigs", "SpecificIndustryID", "dbo.SpecificIndustries", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gigs", "SpecificIndustryID", "dbo.SpecificIndustries");
            DropForeignKey("dbo.SpecificIndustries", "IndustryID", "dbo.Industries");
            DropIndex("dbo.SpecificIndustries", new[] { "IndustryID" });
            DropIndex("dbo.Gigs", new[] { "SpecificIndustryID" });
            DropColumn("dbo.Gigs", "SpecificIndustryID");
            DropTable("dbo.Industries");
            DropTable("dbo.SpecificIndustries");
        }
    }
}
