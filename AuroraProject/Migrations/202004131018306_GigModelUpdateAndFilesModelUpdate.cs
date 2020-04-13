namespace AuroraProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GigModelUpdateAndFilesModelUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Files", "InfluencerID", "dbo.Influencers");
            DropIndex("dbo.Files", new[] { "InfluencerID" });
            CreateTable(
                "dbo.FileUploads",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        InfluencerID = c.Int(),
                        GigID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Gigs", t => t.GigID)
                .ForeignKey("dbo.Influencers", t => t.InfluencerID)
                .Index(t => t.InfluencerID)
                .Index(t => t.GigID);
            
            DropColumn("dbo.Gigs", "GigWallpaper");
            DropTable("dbo.Files");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.FileId);
            
            AddColumn("dbo.Gigs", "GigWallpaper", c => c.String(nullable: false));
            DropForeignKey("dbo.FileUploads", "InfluencerID", "dbo.Influencers");
            DropForeignKey("dbo.FileUploads", "GigID", "dbo.Gigs");
            DropIndex("dbo.FileUploads", new[] { "GigID" });
            DropIndex("dbo.FileUploads", new[] { "InfluencerID" });
            DropTable("dbo.FileUploads");
            CreateIndex("dbo.Files", "InfluencerID");
            AddForeignKey("dbo.Files", "InfluencerID", "dbo.Influencers", "ID", cascadeDelete: true);
        }
    }
}
