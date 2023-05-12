namespace DataAccess.Models;

public record PersonModel(Guid PersonId, string FullName, DateOnly BirthDate, string Sex);