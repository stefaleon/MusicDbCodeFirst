namespace MusicDbCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BandPeopleManyToMany : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PersonBands",
                c => new
                    {
                        Person_Id = c.Int(nullable: false),
                        Band_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Person_Id, t.Band_Id })
                .ForeignKey("dbo.People", t => t.Person_Id, cascadeDelete: true)
                .ForeignKey("dbo.Bands", t => t.Band_Id, cascadeDelete: true)
                .Index(t => t.Person_Id)
                .Index(t => t.Band_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonBands", "Band_Id", "dbo.Bands");
            DropForeignKey("dbo.PersonBands", "Person_Id", "dbo.People");
            DropIndex("dbo.PersonBands", new[] { "Band_Id" });
            DropIndex("dbo.PersonBands", new[] { "Person_Id" });
            DropTable("dbo.PersonBands");
        }
    }
}
