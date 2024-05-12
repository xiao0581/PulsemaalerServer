using Microsoft.EntityFrameworkCore;

namespace PulsemaalerRestApi.Model
{
    public class PersonDbContext : DbContext
    {
        
        /// <summary>
        /// This method creates a new instance of the PersonDbContext
        /// </summary>
        /// <param name="options"></param>
        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options) { }
      
        /// <summary>
        /// This method creates a new table in the database
        /// </summary>
        public DbSet<Person> Persons { get; set; }



    }
}
