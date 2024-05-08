namespace PulsemaalerRestApi.Model
{
   
        public class PersonRepository
        {
            private readonly PersonDbContext _context;
            public PersonRepository(PersonDbContext context)
            {
                _context = context;
            }
            public IEnumerable<Person> GetAll()
            {
                IQueryable<Person> queryable = _context.Persons.AsQueryable();
                return queryable.ToList();
            }
            public Person? Get(int id)
            {
                return _context.Persons.Find(id);
            }
            public Person Add(Person person)
            {
                _context.Persons.Add(person);
                _context.SaveChanges();
                return person;


            }
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
