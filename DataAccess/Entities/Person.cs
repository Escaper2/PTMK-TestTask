namespace DataAccess.Models;

public class Person
{
    public Person(Guid personId, string fullName, DateOnly birthDate, string sex)
    {
        PersonId = personId;
        FullName = fullName;
        BirthDate = birthDate;
        Sex = sex;
    }

    public Guid PersonId { get; set; }
    public string FullName { get; set; }
    public DateOnly BirthDate { get; set; }
    public string Sex { get; set; }
}