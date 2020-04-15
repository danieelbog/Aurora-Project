namespace AuroraProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GigWithSellingPackages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdvancedPackages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Price = c.Int(nullable: false),
                        PackageName = c.String(nullable: false),
                        PackageDescreption = c.String(nullable: false, maxLength: 255),
                        DeliveryTime = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BasicPackages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Price = c.Int(nullable: false),
                        PackageName = c.String(nullable: false),
                        PackageDescreption = c.String(nullable: false, maxLength: 255),
                        DeliveryTime = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Gigs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IsDisabled = c.Boolean(nullable: false),
                        UserRating = c.Byte(nullable: false),
                        GigName = c.String(nullable: false),
                        GigWallpaper = c.String(nullable: false),
                        Descreption = c.String(nullable: false, maxLength: 255),
                        BasicPackageID = c.Int(nullable: false),
                        AdvancedPackageID = c.Int(nullable: false),
                        PremiumPackageID = c.Int(nullable: false),
                        UserID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AdvancedPackages", t => t.AdvancedPackageID, cascadeDelete: true)
                .ForeignKey("dbo.BasicPackages", t => t.BasicPackageID, cascadeDelete: true)
                .ForeignKey("dbo.PremiumPackages", t => t.PremiumPackageID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID, cascadeDelete: true)
                .Index(t => t.BasicPackageID)
                .Index(t => t.AdvancedPackageID)
                .Index(t => t.PremiumPackageID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.PremiumPackages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Price = c.Int(nullable: false),
                        PackageName = c.String(nullable: false),
                        PackageDescreption = c.String(nullable: false, maxLength: 255),
                        DeliveryTime = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gigs", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Gigs", "PremiumPackageID", "dbo.PremiumPackages");
            DropForeignKey("dbo.Gigs", "BasicPackageID", "dbo.BasicPackages");
            DropForeignKey("dbo.Gigs", "AdvancedPackageID", "dbo.AdvancedPackages");
            DropIndex("dbo.Gigs", new[] { "UserID" });
            DropIndex("dbo.Gigs", new[] { "PremiumPackageID" });
            DropIndex("dbo.Gigs", new[] { "AdvancedPackageID" });
            DropIndex("dbo.Gigs", new[] { "BasicPackageID" });
            DropTable("dbo.PremiumPackages");
            DropTable("dbo.Gigs");
            DropTable("dbo.BasicPackages");
            DropTable("dbo.AdvancedPackages");
        }
    }
}
