using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidation;

public class Stuff 
{
    public string Name { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }
    public decimal HourlySalary { get; set; }
}

[Route("api/[controller]")]
[ApiController]
public class StuffController : ControllerBase
{
    public StuffController()
    {
    }
    
    // POST: api/Test
    [HttpPost]
    public Stuff Post([FromBody] Stuff value)
    {
        return value;
    }
}