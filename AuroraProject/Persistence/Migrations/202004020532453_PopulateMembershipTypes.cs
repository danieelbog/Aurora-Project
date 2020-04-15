namespace AuroraProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes(Name, Price, DurationInDays, Discount) VALUES ('Basic', 20, 30, 0)");
            Sql("INSERT INTO MembershipTypes(Name, Price, DurationInDays, Discount) VALUES ('Basic Plus', 50, 90, 10)");
            Sql("INSERT INTO MembershipTypes(Name, Price, DurationInDays, Discount) VALUES ('Advanced', 190, 365, 15)");
            Sql("INSERT INTO MembershipTypes(Name, Price, DurationInDays, Discount) VALUES ('Premium', 500, 365, 20)");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM MembershipTypes WHERE Id IN (1, 2, 3, 4)");
        }
    }
}
