namespace AuroraProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateSpecificIndustry : DbMigration
    {
        public override void Up()
        {
            // 1 ('Technology')");
            // 2 ('Hobby')");
            // 3 ('Athletics')");
            // 4 ('Health')");
            // 5 ('Fashion')");
            // 6 ('Beauty')");
            // 7 ('Motor')");
            // 8 ('Food')");
            // 9 ('Home')");
            // 10 ('Teaching')");
            // 11 ('Children')");

            // 1 Specific Industries for technology
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Smarthphones', 1)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('PC Hardware/Software', 1)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Sound', 1)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Image', 1)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Consoles', 1)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Wearables', 1)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Electronics', 1)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Gadgets', 1)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Photography', 1)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Telephones', 1)");

            // 2 Specific Industries for hobby
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Hunting', 2)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Scubadiving', 2)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Guns', 2)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Music', 2)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Guitars', 2)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Bikes', 2)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Camping', 2)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Books', 2)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Modeling', 2)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Puzzles', 2)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Manga', 2)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('DIY', 2)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Fishing', 2)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Drones', 2)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Art', 2)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Sunbathing', 2)");

            // 3 Specific industries for Sports
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Gymnastics', 3)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Extreme Sports', 3)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Snow Sports', 3)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Sea Sports', 3)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Rural Sports', 3)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Football', 3)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('BasketBall', 3)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Hockey', 3)");

            // 4 Specific industries for health
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Dietary Supplements', 4)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Medicine', 4)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Adult Section', 4)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Personal Hygiene', 4)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Orthopedics', 4)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Optical', 4)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Fitness', 4)");

            // 5 Specific industries for Fashion
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Male', 5)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Female', 5)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Unisex', 5)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Bags', 5)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Watch', 5)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Jewelry', 5)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Sun Glasses', 5)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Accessories', 5)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Mariage', 5)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('General Fashion', 5)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Styling', 5)");

            // 6 Specific industries for Beauty
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Nails', 6)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Face', 6)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Eyes', 6)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Lips', 6)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Body', 6)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Perfumes', 6)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Hair', 6)");

            // 7 Specific industries for Motor
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Car', 7)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Motor-Bikes', 7)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Ship', 7)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Accessories', 7)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Parts', 7)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Airplanes', 7)");

            // 8 Specific industries for Food
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Fast Food', 8)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Restaurants', 8)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Country Food', 8)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Experimental', 8)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Sugar', 8)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Bistrau', 8)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Alternative', 8)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Tavern', 8)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Drinks', 8)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Ethnic Cousine', 8)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Tutorials', 8)");

            // 9 Specific industries for Home
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Property', 9)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Rent Property', 9)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Garage', 9)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Fernichures', 9)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Lights', 9)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Garden Equipment', 9)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Home Equipment', 9)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Cleaning Equipment', 9)");

            // 10 Specific industries for Industial
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Language', 10)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Painting', 10)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Music', 10)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Programming', 10)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Soft Skills', 10)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Sports', 10)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Gaming', 10)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Marketing', 10)");

            // 11 Specific industries for Kids
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Toys', 11)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Fashion', 11)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Home Equipment', 11)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Care & Hygiene', 11)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('School Equipment', 11)");
            Sql("INSERT INTO SpecificIndustries (Name, IndustryID) VALUES ('Baby Caring', 11)");


        }

        public override void Down()
        {
            Sql("DELETE * FROM SpecificIndustries");
        }
    }
}
