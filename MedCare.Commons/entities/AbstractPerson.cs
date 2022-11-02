namespace MedCare.Commons.Entities
{
    public abstract class AbstractPerson
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int PhoneNumber { get; set; }
        public string Cpf { get; set; }
    }
}
