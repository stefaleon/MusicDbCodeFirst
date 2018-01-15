using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            };

            var bands = new List<Band> {
                new Band { Id = 1, Name = "AC/DC" },
                new Band { Id = 2, Name = "Motörhead" }
            };
        }

        public class db : DbContext
        {
            public DbSet<Person> People { get; set; }
            public DbSet<Band> Bands { get; set; }

            public db() : base("name=MusicDbConnection") { }
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
