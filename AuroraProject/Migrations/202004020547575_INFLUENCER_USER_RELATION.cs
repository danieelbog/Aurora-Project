namespace AuroraProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class INFLUENCER_USER_RELATION : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Influencers", "User_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Influencers", "User_Id");
            AddForeignKey("dbo.Influencers", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Influencers", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Influencers", new[] { "User_Id" });
            DropColumn("dbo.Influencers", "User_Id");
        }
    }
}
