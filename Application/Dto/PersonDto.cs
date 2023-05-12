namespace Application.Dto;

public record PersonDto(Guid PersonId, string FullName, DateOnly BirthDate, string Sex, int Age);