using Application.Dto;
using Application.Mapping;
using DataAccess;
using DataAccess.Models;

namespace Application.Services.Implementations;

public class PersonService : IPersonService
{
    private readonly DatabaseContext _context;

    public PersonService(DatabaseContext context)
    {
        _context = context;
    }

    private static int CalculateAge(DateOnly birthDate) => DateOnly.FromDateTime(DateTime.Now).Year- birthDate.Year;
    public void CreatePerson(string fullName, DateOnly birthDate, string sex)
    {
        var person = new Person(Guid.NewGuid(), fullName, birthDate, sex);

        _context.Persons.Add(person);

       _context.SaveChanges();

        person.toDto(CalculateAge(birthDate));
    }

    public List<PersonDto> GetAllWithSort()
    {
        var uniqPersons = _context.Persons
            .GroupBy(x => new { x.FullName, x.BirthDate })
            .Select(x => x.First())
            .ToList();

        var personsDtos = uniqPersons.OrderBy(x => x.FullName)
            .Select(x => x.toDto(CalculateAge(x.BirthDate)))
            .ToList();

        return personsDtos;
    }
    
    public void CreatePersons(List<PersonModel> personsToAdd)
    {

        var persons = personsToAdd.Select(x => x.toPerson());

        _context.Persons.AddRange(persons);

        _context.SaveChanges();
    }

    public List<PersonDto> GetAll()
    {
        var b = _context.Persons
            .Select(x => x.toDto(CalculateAge(x.BirthDate)))
            .ToList();

        return b;
    }

    public List<Person> GetPersonsWithLetterF()
    {
        return _context.Persons.Where(x => x.FullName.StartsWith("f") && x.Sex == "Male").ToList();
    }

}