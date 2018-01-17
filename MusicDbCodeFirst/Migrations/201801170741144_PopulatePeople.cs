namespace MusicDbCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatePeople : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO People (Name) VALUES ('Bon Scott')");
            Sql("INSERT INTO People (Name) VALUES ('Angus Young')");
            Sql("INSERT INTO People (Name) VALUES ('Lemmy')");
            Sql("INSERT INTO People (Name) VALUES ('Ritchie Blackmore')");
            Sql("INSERT INTO People (Name) VALUES ('Ronnie James Dio')");
        }
        
        public override void Down()
        {
        }
    }
}
