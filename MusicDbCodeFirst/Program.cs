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
                new Person { Id = 1, Name = "Bon Scott" },
                new Person { Id = 2, Name = "Lemmy" }
            };

            var bands = new List<Band> {
                new Band { Id = 1, Name = "AC/DC" },
                new Band { Id = 2, Name = "Motörhead" }
            };

            foreach (var person in people) { Console.WriteLine(person.Name); }
            foreach (var band in bands) { Console.WriteLine(band.Name); }
        }


    }
}
