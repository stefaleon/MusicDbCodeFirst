using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
