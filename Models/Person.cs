namespace PersonAPI.Models;

public class Person(
    string? firstName,
    string? lastName,
    Gender gender,
    DateTime dateOfBirth,
    string? phoneNumber,
    string? birthPlace,
    bool isGraduated)
{
    public string? FirstName { get; } = firstName;
    public string? LastName { get; } = lastName;
    public string FullName => $"{FirstName} {LastName}";
    public Gender Gender { get; private set; } = gender;
    public DateTime DateOfBirth { get; private set; } = dateOfBirth;
    public string? PhoneNumber { get; private set; } = phoneNumber;
    public string? BirthPlace { get; private set; } = birthPlace;
    public string IsGraduated { get; private set; } = isGraduated ? "Yes" : "No";
}

public enum Gender
{
    Male,
    Female,
    Other,
}