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

            /// <summary>
            /// This method gets a person from the database
            /// </summary>
            /// <param name="id"></param>
            /// <returns>
            /// The person with the given id
            /// </returns>
            public Person? Get(int id)
            {
                return _context.Persons.Find(id);
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
            
            /// <summary>
            /// This method deletes a person from the database
            /// </summary>
            /// <param name="id"></param>
            /// <returns>
            /// The person that was deleted or null if the person was not found
            /// </returns>
            public Person? Delete(int id)
            {
                Person? person = _context.Persons.Find(id);
                if (person != null)
                {
                    _context.Persons.Remove(person);
                    _context.SaveChanges();
                }
                return person;
            }

            /// <summary>
            /// This method updates a person in the database
            /// </summary>
            /// <param name="id"></param>
            /// <param name="person"></param>
            /// <returns>
            /// This method returns the updated person
            /// </returns>
            public Person update(int id, Person person)
            {
                Person? p = _context.Persons.Find(id);
                if (p != null)
                {
                    p.Name = person.Name;
                    p.Age = person.Age;
                    p.Bpm = person.Bpm;
                    _context.SaveChanges();
                }

                return person;
            }
        }
    
}
