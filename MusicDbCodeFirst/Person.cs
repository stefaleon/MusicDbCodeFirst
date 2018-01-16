using System.Collections.Generic;

namespace MusicDbCodeFirst
{
    partial class Program
    {
        public class Person
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public List<Band> Bands { get; set; }

        }


    }
}
