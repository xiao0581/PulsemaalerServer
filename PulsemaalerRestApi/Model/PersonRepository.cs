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

        public Person? PatchUpdate(string name, Person updateData)
        {
            Person? existingPerson = _context.Persons.FirstOrDefault(p => p.Name == name);
            if (existingPerson != null)
            {
                // 只更新非null和非默认值的字段（这里假设0是默认值）
                if (!string.IsNullOrEmpty(updateData.Name))
                    existingPerson.Name = updateData.Name;
                if (updateData.Age > 0) // 假设年龄0是非法的，只有当大于0时才更新
                    existingPerson.Age = updateData.Age;
                if (updateData.HvilePuls > 0)
                    existingPerson.HvilePuls = updateData.HvilePuls;
                if (updateData.AktivPuls > 0)
                    existingPerson.AktivPuls = updateData.AktivPuls;
                if (updateData.Stresspuls > 0)
                    existingPerson.Stresspuls = updateData.Stresspuls;
                if (updateData.AfterTrainingPuls > 0)
                    existingPerson.AfterTrainingPuls = updateData.AfterTrainingPuls;

                _context.SaveChanges();
            }

            return existingPerson;
        }
    }


}
    

