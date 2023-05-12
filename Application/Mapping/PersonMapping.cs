using Application.Dto;
using DataAccess.Models;


namespace Application.Mapping;

public static class PersonMapping
{
    public static PersonDto toDto(this Person person, int Age)
        => new PersonDto(person.PersonId, person.FullName, person.BirthDate, person.Sex, Age);

    public static Person toPerson(this PersonModel personModel)
        => new Person(personModel.PersonId, personModel.FullName, personModel.BirthDate, personModel.Sex);
}