## Music Database Code First
Create a database about music with the Entity Framework using the Code First aproach


&nbsp;
## 00 Start project

* New Console App (.NET Framework).

*Program.cs*
```
namespace MusicDbCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello MusicDb!");

            var people = new List<Person> {
                new Person { Id = 1, Name = "Bon Scott" },
                new Person { Id = 2, Name = "Lemmy" }
            } ;

            var bands = new List<Band> {
                new Band { Id = 1, Name = "AC/DC" },
                new Band { Id = 2, Name = "Motörhead" }
            };
        }


        public class Person
        {
            public int Id { get; set; }

            public string Name { get; set; }           

        }

        public class Band
        {
            public int Id { get; set; }

            public string Name { get; set; }                        
        }     

    }
}
```


&nbsp;
## 01 Add Entity and configure ConnectionStrings

* Install EF.

```
PM> install-package EntityFramework
...
Successfully installed 'EntityFramework 6.2.0' to MusicDbCodeFirst
```

* Add a connection to the *MusicDb* database (already created with MSSMS).

*App.config*
```
  <connectionStrings>    
    <add name="MusicDbConnection"
    connectionString="Data Source=(LocalDb)\MSSQLLocalDB;
    Initial Catalog=MusicDb;Integrated Security=SSPI"
    providerName="System.Data.SqlClient" />
  </connectionStrings>
```



&nbsp;
## 02 Add dbContext and migrations

* Add the *db* context, which inherits from System.Data.Entity.DbContext. Setup the DbSets for the data classes and the constructor which calls the base constructor overload that points at *MusicDbConnection* .

```
    public class db : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Band> Bands { get; set; }

        public db() : base("name=MusicDbConnection") { }
    }
```

* Enable migrations.

```
PM> enable-migrations
Checking if the context targets an existing database...
Code First Migrations enabled for project MusicDbCodeFirst.
```

* Add a migration.

```
PM> add-migration Initial
Scaffolding migration 'Initial'.
...
```

```
PM> update-database
...
Running Seed method.
```


&nbsp;
## 03 Relate bands and people

* Move classes to their own files and add relationships.

*Person.cs*
```
using System.Collections.Generic;

namespace MusicDbCodeFirst
{
    partial class Program
    {
        public class Band
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public List<Person> BandPeople { get; set; }
        }
    }
}
```

*Band.cs*
```
namespace MusicDbCodeFirst
{
    partial class Program
    {
        public class Band
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public List<Person> BandPeople { get; set; }
        }
    }
}
```

* Add another migration.

```
PM> add-migration BandPeopleManyToMany
```
```
PM> update-database
```



&nbsp;
## 04 non-persistent data

* Test the classes with demo non-persistent data

*Program.cs*
```
namespace MusicDbCodeFirst
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello MusicDb!");

            var people = new List<Person> {
                new Person { Id = 1, Name = "Bon Scott", Bands = new List<Band>() },
                new Person { Id = 2, Name = "Angus Young", Bands = new List<Band>() },
                new Person { Id = 3, Name = "Lemmy", Bands = new List<Band>() },
                new Person { Id = 4, Name = "Ritchie Blackmore", Bands = new List<Band>() },
                new Person { Id = 5, Name = "Ronnie James Dio", Bands = new List<Band>() }
            };

            var bands = new List<Band> {
                new Band { Id = 1, Name = "AC/DC", BandPeople = new List<Person>() },
                new Band { Id = 2, Name = "Motörhead", BandPeople = new List<Person>() },
                new Band { Id = 3, Name = "Deep Purple", BandPeople = new List<Person>() },
                new Band { Id = 4, Name = "Rainbow", BandPeople = new List<Person>() }
            };

            people[0].Bands.Add(bands[0]);
            people[1].Bands.Add(bands[0]);
            people[2].Bands.Add(bands[1]);
            people[3].Bands.Add(bands[2]);
            people[3].Bands.Add(bands[3]);
            people[4].Bands.Add(bands[3]);
            bands[0].BandPeople.Add(people[0]);
            bands[0].BandPeople.Add(people[1]);
            bands[1].BandPeople.Add(people[2]);
            bands[2].BandPeople.Add(people[3]);
            bands[3].BandPeople.Add(people[3]);
            bands[3].BandPeople.Add(people[4]);

            foreach (var person in people)
            {
                foreach (var band in person.Bands)
                { Console.WriteLine($"{person.Name} is in {band.Name}"); }
            }
            foreach (var band in bands)
            {
                foreach (var person in band.BandPeople)
                { Console.WriteLine($"{band.Name} has {person.Name}"); }
            }                        
        }
    }
}
```




&nbsp;
## 05 Populate People and Bands with migrations


* Create an empty migration.

```
PM> add-migration PopulatePeople
Scaffolding migration 'PopulatePeople'.
```
```
namespace MusicDbCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class PopulatePeople : DbMigration
    {
        public override void Up()
        {
        }

        public override void Down()
        {
        }
    }
}
```

* Then call the *Sql* method and type in SQL statements.

```
public override void Up()
{
  Sql("INSERT INTO People (Name) VALUES ('Bon Scott')");
  Sql("INSERT INTO People (Name) VALUES ('Angus Young')");
  Sql("INSERT INTO People (Name) VALUES ('Lemmy')");
  Sql("INSERT INTO People (Name) VALUES ('Ritchie Blackmore')");
  Sql("INSERT INTO People (Name) VALUES ('Ronnie James Dio')");
}
```

* By updating, we can seed the People data to the database.

```
PM> update-database
```



* Create another empty migration, now for the bands.

```
PM> add-migration PopulateBands
Scaffolding migration 'PopulateBands'.
```
```
namespace MusicDbCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class PopulateBands : DbMigration
    {
        public override void Up()
        {
        }

        public override void Down()
        {
        }
    }
}
```

* Then call the *Sql* method and type in SQL statements.

```
public override void Up()
{
  Sql("INSERT INTO Bands (Name) VALUES ('AC/DC')");
  Sql("INSERT INTO Bands (Name) VALUES ('Motörhead')");
  Sql("INSERT INTO Bands (Name) VALUES ('Deep Purple')");
  Sql("INSERT INTO Bands (Name) VALUES ('Rainbow')");
}
```

* By updating, we can seed the Bands data to the database.

```
PM> update-database
```



&nbsp;
## 06 Access persistent data from the database

* Access the *db* context by creating the *database* instance and read people and bands data.

```
var database = new db();

var people = database.People.ToList();
var bands = database.Bands.ToList();

foreach (var person in people)
{
    Console.WriteLine($"In People there is {person.Name}.");
}
foreach (var band in bands)
{
    Console.WriteLine($"In Bands there is {band.Name}.");
}
```
