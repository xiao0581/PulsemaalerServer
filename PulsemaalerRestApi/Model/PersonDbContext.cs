using Microsoft.EntityFrameworkCore;

namespace PulsemaalerRestApi.Model
{
    public class PersonDbContext : DbContext
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options) { }
        public DbSet<Person> Persons { get; set; }



    }
}
