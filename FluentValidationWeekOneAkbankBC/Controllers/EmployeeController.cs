using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidation;

public class Employee
{
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public double HourlySalary { get; set; }
}

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    public EmployeeController()
    {
    }
    
    // POST: api/Test
    [HttpPost]
    public Employee Post([FromBody] Employee value)
    {
        return value;
    }
}