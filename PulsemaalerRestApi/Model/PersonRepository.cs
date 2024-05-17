using Microsoft.EntityFrameworkCore;

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
       
        /// <summary>
        /// This method deletes a person from the database      
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
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
       /// <summary>
       ///  This method updates a person in the database
       /// </summary>
       /// <param name="name"></param>
       /// <param name="person"></param>
       /// <returns></returns>
            public Person update(String name, Person person)
            {
            Person? p = _context.Persons.FirstOrDefault(p => p.Name == name);
            if (p != null)
                {
                    p.Name = person.Name;
                    p.Age = person.Age;
                  
                    _context.SaveChanges();
                }

                return person;
            }

        /// <summary>
        /// This method can update only one or more of several properties
        /// </summary>
        /// <param name="name"></param>
        /// <param name="updateData"></param>
        /// <returns></returns>
        public Person? PatchUpdate(string name, Person updateData)
        {
            Person? existingPerson = _context.Persons.FirstOrDefault(p => p.Name == name);
            if (existingPerson != null)
            {
               
                if (!string.IsNullOrEmpty(updateData.Name))
                    existingPerson.Name = updateData.Name;
                if (updateData.Age > 0) 
                    existingPerson.Age = updateData.Age;
              

                _context.SaveChanges();
            }

            return existingPerson;
        }
        public Person? GetPersonWithHistories(string name)
        {
            return _context.Persons
                .Include(p => p.PulsHistories)
                .FirstOrDefault(p => p.Name == name);
        }
    }


}
    

