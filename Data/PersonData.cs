using PersonAPI.Models;

namespace PersonAPI.Data;

public class PersonData
{
    public List<Person> Persons { get; } =
    [
        new("John", "Doe", Gender.Male, new DateTime(1990, 1, 1), "123-456-7890", "New York", true),
        new("Jane", "Doe", Gender.Female, new DateTime(2000, 2, 2), "234-567-8901", "Los Angeles", false),
        new("Jim", "Beam", Gender.Male, new DateTime(1985, 3, 3), "345-678-9012", "Chicago", true),
        new("Jack", "Daniels", Gender.Male, new DateTime(2000, 4, 4), "456-789-0123", "Houston", true),
        new("Jill", "Valentine", Gender.Female, new DateTime(1995, 5, 5), "567-890-1234", "Phoenix", false),
        new("Chris", "Redfield", Gender.Other, new DateTime(2022, 6, 6), "678-901-2345", "Philadelphia", true),
        new("Claire", "Redfield", Gender.Female, new DateTime(1991, 7, 7), "789-012-3456", "San Antonio", true),
        new("Leon", "Kennedy", Gender.Male, new DateTime(2021, 8, 8), "890-123-4567", "San Diego", false)
    ];
}