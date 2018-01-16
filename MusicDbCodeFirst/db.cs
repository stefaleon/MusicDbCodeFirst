using System.Data.Entity;

namespace MusicDbCodeFirst
{
    partial class Program
    {
        public class db : DbContext
        {
            public DbSet<Person> People { get; set; }
            public DbSet<Band> Bands { get; set; }

            public db() : base("name=MusicDbConnection") { }
        }


    }
}
