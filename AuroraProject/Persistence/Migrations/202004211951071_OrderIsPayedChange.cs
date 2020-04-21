namespace AuroraProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderIsPayedChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "IsPayed", c => c.Boolean(nullable: false));
            DropColumn("dbo.ShoppingCarts", "IsPayed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ShoppingCarts", "IsPayed", c => c.Boolean(nullable: false));
            DropColumn("dbo.Orders", "IsPayed");
        }
    }
}
