namespace PulsemaalerRestApi.Model
{
   
        public class PersonRepository
        {
            private readonly PersonDbContext _context;
            public PersonRepository(PersonDbContext context)
            {
                _context = context;
            }

            /// <summary>
            /// This method gets all the persons from the database
            /// </summary>
            /// <returns>
            /// Returns a list of all the persons in the database
            /// </returns>
            public IEnumerable<Person> GetAll()
            {
                IQueryable<Person> queryable = _context.Persons.AsQueryable();
                return queryable.ToList();
            }
            public Person? GetbyName(String name)
            {
                return _context.Persons.FirstOrDefault(p => p.Name == name);
            }

            /// <summary>
            /// This method adds a person to the database
            /// </summary>
            /// <param name="person"></param>
            /// <returns>
            /// Returns the person that was added
            /// </returns>
            public Person Add(Person person)
            {
                _context.Persons.Add(person);
                _context.SaveChanges();
                return person;


            }
            public Person? Delete(int id)
            {
                Person? person = _context.Persons.FirstOrDefault(p => p.Name == name);
            if (person != null)
                {
                    _context.Persons.Remove(person);
                    _context.SaveChanges();
                }
                return person;
            }
            public Person update(int id, Person person)
            {
            Person? p = _context.Persons.FirstOrDefault(p => p.Name == name);
            if (p != null)
                {
                    p.Name = person.Name;
                    p.Age = person.Age;
                    p.HvilePuls = person.HvilePuls;
                p.AktivPuls = person.AktivPuls;
                p.Stresspuls = person.Stresspuls;
                p.AfterTrainingPuls = person.AfterTrainingPuls;
                    _context.SaveChanges();
                }

                return person;
            }
        }
    
}
