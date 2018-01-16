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
