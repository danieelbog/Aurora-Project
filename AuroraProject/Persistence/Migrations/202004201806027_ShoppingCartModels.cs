namespace AuroraProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShoppingCartModels : DbMigration
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
                        Name = c.String(),
                        Count = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        Descreption = c.String(),
                        Coupon = c.String(),
                        SellerInstructions = c.String(),
                        DateOrdered = c.DateTime(nullable: false),
                        ShoppingCartID = c.Int(nullable: false),
                        GigID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Gigs", t => t.GigID, cascadeDelete: true)
                .ForeignKey("dbo.ShoppingCarts", t => t.ShoppingCartID, cascadeDelete: true)
                .Index(t => t.ShoppingCartID)
                .Index(t => t.GigID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingCarts", "Owner_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Orders", "ShoppingCartID", "dbo.ShoppingCarts");
            DropForeignKey("dbo.Orders", "GigID", "dbo.Gigs");
            DropIndex("dbo.Orders", new[] { "GigID" });
            DropIndex("dbo.Orders", new[] { "ShoppingCartID" });
            DropIndex("dbo.ShoppingCarts", new[] { "Owner_Id" });
            DropTable("dbo.Orders");
            DropTable("dbo.ShoppingCarts");
        }
    }
}
