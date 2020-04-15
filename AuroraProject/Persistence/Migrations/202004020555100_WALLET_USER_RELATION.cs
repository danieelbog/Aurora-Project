namespace AuroraProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WALLET_USER_RELATION : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Wallets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Value = c.Single(nullable: false),
                        Owner_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.Owner_Id)
                .Index(t => t.Owner_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Wallets", "Owner_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Wallets", new[] { "Owner_Id" });
            DropTable("dbo.Wallets");
        }
    }
}
