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
            public Person? GetbyName(String name)
            {
                return _context.Persons.FirstOrDefault(p => p.Name == name);
            }
            public Person Add(Person person)
            {
                _context.Persons.Add(person);
                _context.SaveChanges();
                return person;


            }
            public Person? Delete(String name)
            {
                Person? person = _context.Persons.FirstOrDefault(p => p.Name == name);
            if (person != null)
                {
                    _context.Persons.Remove(person);
                    _context.SaveChanges();
                }
                return person;
            }
            public Person update(String name, Person person)
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
