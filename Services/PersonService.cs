using PersonAPI.Data;
using PersonAPI.Helpers;
using PersonAPI.Models;
using PersonAPI.Responses;

namespace PersonAPI.Services;

public class PersonService : IPersonService
{
    private readonly PersonData _personData = new();

    public IEnumerable<Person> GetPersonsMale()
    {
        var malePersons = _personData.Persons.Where(mp => mp.Gender == Gender.Male);

        return malePersons;
    }

    public Person GetPersonOldestAge()
    {
        var oldestPerson = _personData.Persons.OrderByDescending(p => p.DateOfBirth).First();

        return oldestPerson;
    }

    public IEnumerable<string> GetPersonsFullName()
    {
        var fullNames = _personData.Persons.Select(p => p.FullName);

        return fullNames;
    }

    public IEnumerable<Person> GetPersonsByBirthYearWithAction(string action)
    {
        return action.ToUpper() switch
        {
            "GREATER" => _personData.Persons.Where(p => p.DateOfBirth.Year < 2000),
            "LOWER" => _personData.Persons.Where(p => p.DateOfBirth.Year > 2000),
            _ => _personData.Persons.Where(p => p.DateOfBirth.Year == 2000),
        };
    }

    public FileResponse ExportToExcel()
    {
        var personToExcel = _personData.Persons.ToList();
        var fileContent = FileHelper<Person>.GenerateExcelFile(personToExcel);
        var fileName = $"Persons_{DateTime.Now:yyyyMMddHHmmss}.xlsx";

        return new FileResponse(fileContent, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
    }
}