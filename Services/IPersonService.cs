using PersonAPI.Models;
using PersonAPI.Responses;

namespace PersonAPI.Services;

public interface IPersonService
{
    IEnumerable<Person> GetPersonsMale();
    Person GetPersonOldestAge();
    IEnumerable<string> GetPersonsFullName();
    IEnumerable<Person> GetPersonsByBirthYearWithAction(string action);
    FileResponse ExportToExcel();
}