using Application.Dto;
using DataAccess.Models;

namespace Application.Services;

public interface IPersonService
{
    void CreatePerson(string fullName, DateOnly birthDate, string sex);

    List<PersonDto> GetAllWithSort();

    void CreatePersons(List<PersonModel> personsToAdd);

    public List<Person> GetPersonsWithLetterF();
    
    public List<PersonDto> GetAll();
}