namespace AuroraProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FilesAndRelationWithInfluencer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        InfluencerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.Influencers", t => t.InfluencerID, cascadeDelete: true)
                .Index(t => t.InfluencerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Files", "InfluencerID", "dbo.Influencers");
            DropIndex("dbo.Files", new[] { "InfluencerID" });
            DropTable("dbo.Files");
        }
    }
}
