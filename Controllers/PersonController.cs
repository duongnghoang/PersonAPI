using Microsoft.AspNetCore.Mvc;
using PersonAPI.Models;
using PersonAPI.Services;

namespace PersonAPI.Controllers;

[ApiController]
[Route("NashTech/[controller]")]
public class PersonController(IPersonService personService) : ControllerBase
{
    [HttpGet("GetMale")]
    public IEnumerable<Person> GetMale()
    {
        return personService.GetPersonsMale();
    }

    [HttpGet("GetOldestAge")]
    public Person? GetOldestPerson()
    {
        return personService.GetPersonOldestAge();
    }

    [HttpGet("GetFullName")]
    public IEnumerable<string> GetFullNames()
    {
        return personService.GetPersonsFullName();
    }

    [HttpGet("GetBirthYearWithAction")]
    public IActionResult GetPersonsByBirthYearAction([FromQuery] string action)
    {
        if (string.IsNullOrEmpty(action))
        {
            return BadRequest("Action is required");
        }

        var normalizedAction = action.ToLowerInvariant();

        return normalizedAction switch
        {
            "getbirthyearlower" => RedirectToAction("GetBirthYearLower"),
            "getbirthyeargreater" => RedirectToAction("GetBirthYearGreater"),
            "getbirthyearequal" => RedirectToAction("GetBirthYearEqual"),
            _ => NotFound("Action not found"),
        };
    }

    [HttpGet("GetBirthYearLower")]
    public IEnumerable<Person> GetBirthYearLower()
    {
        return personService.GetPersonsByBirthYearWithAction("lower");
    }

    [HttpGet("GetBirthYearGreater")]
    public IEnumerable<Person> GetBirthYearGreater()
    {
        return personService.GetPersonsByBirthYearWithAction("greater");
    }

    [HttpGet("GetBirthYearEqual")]
    public IEnumerable<Person> GetBirthYearEqual()
    {
        return personService.GetPersonsByBirthYearWithAction("equal");
    }

    [HttpPost("ExportToExcel")]
    public IActionResult ExportToExcel()
    {
        var fileResponse = personService.ExportToExcel();

        return File(fileResponse.FileContent, fileResponse.ContentType, fileResponse.FileName);
    }
}
