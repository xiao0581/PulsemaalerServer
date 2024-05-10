namespace PulsemaalerRestApi.Model
{
    public class Person
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }

        public double Bpm { get; set; }

        /// <summary>
        /// This method validates the name of the person
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void validateName()
        {
            if (Name is null)
            {
                throw new ArgumentNullException("name is null");
            }
            if (Name.Length <= 1)
            {
                throw new ArgumentException("name has to be at least one character ");
            }

        }

        /// <summary>
        /// This method validates the age of the person
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void validateBirthYear()
        {
            if (Age <= 0)
            {
                throw new ArgumentOutOfRangeException("Age out of boundary");
            }

        }
    }
}
