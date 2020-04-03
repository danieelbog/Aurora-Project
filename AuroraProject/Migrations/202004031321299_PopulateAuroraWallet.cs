namespace AuroraProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateAuroraWallet : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO AuroraWallets(Balance) VALUES (1000)");

        }

        public override void Down()
        {
            Sql("DELETE FROM AuroraWallets WHERE Id IN (1)");

        }
    }
}
