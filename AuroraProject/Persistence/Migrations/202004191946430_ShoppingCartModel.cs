namespace AuroraProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShoppingCartModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShoppingCarts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IsPayed = c.Boolean(nullable: false),
                        Owner_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.Owner_Id)
                .Index(t => t.Owner_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BasicPackageID = c.Int(),
                        AdvancedPackageID = c.Int(),
                        PremiumPackageID = c.Int(),
                        Count = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        DateOrdered = c.DateTime(nullable: false),
                        UserID = c.String(nullable: false, maxLength: 128),
                        ShoppingCartID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AdvancedPackages", t => t.AdvancedPackageID)
                .ForeignKey("dbo.BasicPackages", t => t.BasicPackageID)
                .ForeignKey("dbo.PremiumPackages", t => t.PremiumPackageID)
                .ForeignKey("dbo.ShoppingCarts", t => t.ShoppingCartID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID, cascadeDelete: true)
                .Index(t => t.BasicPackageID)
                .Index(t => t.AdvancedPackageID)
                .Index(t => t.PremiumPackageID)
                .Index(t => t.UserID)
                .Index(t => t.ShoppingCartID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingCarts", "Owner_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Orders", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Orders", "ShoppingCartID", "dbo.ShoppingCarts");
            DropForeignKey("dbo.Orders", "PremiumPackageID", "dbo.PremiumPackages");
            DropForeignKey("dbo.Orders", "BasicPackageID", "dbo.BasicPackages");
            DropForeignKey("dbo.Orders", "AdvancedPackageID", "dbo.AdvancedPackages");
            DropIndex("dbo.Orders", new[] { "ShoppingCartID" });
            DropIndex("dbo.Orders", new[] { "UserID" });
            DropIndex("dbo.Orders", new[] { "PremiumPackageID" });
            DropIndex("dbo.Orders", new[] { "AdvancedPackageID" });
            DropIndex("dbo.Orders", new[] { "BasicPackageID" });
            DropIndex("dbo.ShoppingCarts", new[] { "Owner_Id" });
            DropTable("dbo.Orders");
            DropTable("dbo.ShoppingCarts");
        }
    }
}
