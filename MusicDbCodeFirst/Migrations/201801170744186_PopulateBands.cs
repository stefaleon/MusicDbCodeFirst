namespace MusicDbCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateBands : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Bands (Name) VALUES ('AC/DC')");
            Sql("INSERT INTO Bands (Name) VALUES ('Motörhead')");
            Sql("INSERT INTO Bands (Name) VALUES ('Deep Purple')");
            Sql("INSERT INTO Bands (Name) VALUES ('Rainbow')");
        }
        
        public override void Down()
        {
        }
    }
}
