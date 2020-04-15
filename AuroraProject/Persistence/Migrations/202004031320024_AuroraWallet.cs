namespace AuroraProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuroraWallet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuroraWallets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Balance = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AuroraWallets");
        }
    }
}
