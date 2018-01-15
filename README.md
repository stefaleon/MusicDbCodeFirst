# MusicDb
## Music Database Code First



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
