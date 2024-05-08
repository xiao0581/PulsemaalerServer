namespace PulsemaalerRestApi.Model
{
    public class Person
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }

        public double Bpm { get; set; }


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
        public void validateBirthYear()
        {
            if (Age <= 0)
            {
                throw new ArgumentOutOfRangeException("Age out of boundary");
            }

        }
    }
}
