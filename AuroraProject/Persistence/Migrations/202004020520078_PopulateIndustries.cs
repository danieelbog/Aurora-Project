namespace AuroraProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateIndustries : DbMigration
    {
        public override void Up()
        {
            // 11 Industries are here. Carefull what to add and what to delete.
            Sql("INSERT INTO Industries (IndustryName) VALUES ('Technology')");
            Sql("INSERT INTO Industries (IndustryName) VALUES ('Hobby')");
            Sql("INSERT INTO Industries (IndustryName) VALUES ('Athletics')");
            Sql("INSERT INTO Industries (IndustryName) VALUES ('Health')");
            Sql("INSERT INTO Industries (IndustryName) VALUES ('Fashion')");
            Sql("INSERT INTO Industries (IndustryName) VALUES ('Beauty')");
            Sql("INSERT INTO Industries (IndustryName) VALUES ('Motor')");
            Sql("INSERT INTO Industries (IndustryName) VALUES ('Food')");
            Sql("INSERT INTO Industries (IndustryName) VALUES ('Home')");
            Sql("INSERT INTO Industries (IndustryName) VALUES ('Teaching')");
            Sql("INSERT INTO Industries (IndustryName) VALUES ('Children')");
        }

        public override void Down()
        {
            Sql("DELETE FROM Industries ID IN (1,2,3,4,5,6,7,8,9,10,11)");
        }
    }
}
