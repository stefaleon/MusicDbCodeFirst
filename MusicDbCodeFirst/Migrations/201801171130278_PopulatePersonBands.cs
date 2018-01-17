namespace MusicDbCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using static MusicDbCodeFirst.Program;

    public partial class PopulatePersonBands : DbMigration
    {
        public override void Up()
        {
            var database = new db();           
            Band currentBand;
            Person currentPerson;

            currentBand = database.Bands.Where(b => b.Name == "AC/DC").SingleOrDefault();
            currentPerson = database.People.Where(p => p.Name == "Bon Scott").SingleOrDefault();
            Sql($"INSERT INTO PersonBands (Person_Id, Band_Id) VALUES ({currentPerson.Id}, {currentBand.Id})");

            currentBand = database.Bands.Where(b => b.Name == "AC/DC").SingleOrDefault();
            currentPerson = database.People.Where(p => p.Name == "Angus Young").SingleOrDefault();
            Sql($"INSERT INTO PersonBands (Person_Id, Band_Id) VALUES ({currentPerson.Id}, {currentBand.Id})");

            currentBand = database.Bands.Where(b => b.Name == "Motörhead").SingleOrDefault();
            currentPerson = database.People.Where(p => p.Name == "Lemmy").SingleOrDefault();
            Sql($"INSERT INTO PersonBands (Person_Id, Band_Id) VALUES ({currentPerson.Id}, {currentBand.Id})");

            currentBand = database.Bands.Where(b => b.Name == "Deep Purple").SingleOrDefault();
            currentPerson = database.People.Where(p => p.Name == "Ritchie Blackmore").SingleOrDefault();
            Sql($"INSERT INTO PersonBands (Person_Id, Band_Id) VALUES ({currentPerson.Id}, {currentBand.Id})");

            currentBand = database.Bands.Where(b => b.Name == "Rainbow").SingleOrDefault();
            currentPerson = database.People.Where(p => p.Name == "Ritchie Blackmore").SingleOrDefault();
            Sql($"INSERT INTO PersonBands (Person_Id, Band_Id) VALUES ({currentPerson.Id}, {currentBand.Id})");

            currentBand = database.Bands.Where(b => b.Name == "Rainbow").SingleOrDefault();
            currentPerson = database.People.Where(p => p.Name == "Ronnie James Dio").SingleOrDefault();
            Sql($"INSERT INTO PersonBands (Person_Id, Band_Id) VALUES ({currentPerson.Id}, {currentBand.Id})");
        }

        public override void Down()
        {
        }
    }
}