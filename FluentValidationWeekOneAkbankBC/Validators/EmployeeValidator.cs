using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace FluentValidation.Validators;

public class EmployeeValidator : AbstractValidator<Employee>
{
    public EmployeeValidator()
    {
        RuleFor(x => x.Name).NotEmpty()
            .WithMessage("You have to enter name")
            .Length(10, 250).WithMessage("Name must be 10-250");
        
        RuleFor(s=>s.DateOfBirth)
            .Must(BeAValidDate)
            .WithMessage("Invalid date/time")
            .Must(RetireNow)
            .WithMessage("It's time to love the grandchildren")
            .Must(YouAreTooYoungForWork)
            .WithMessage("What work? let's play a game");
        
        RuleFor(x => x.Email).NotEmpty()
            .WithMessage("You have to enter email dear")
            .EmailAddress().WithMessage("Please enter a valid email address");
        
        RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("You have to enter phone number")
            .Must(IsPhoneNumber).WithMessage("Please enter a valid phone number");

        RuleFor(x => x.HourlySalary).NotEmpty().WithMessage("You have to enter Hourly salary")
            .InclusiveBetween(50, 400).WithMessage("Range should be between 50-400");

        RuleFor(x => x.DateOfBirth).LessThan(DateTime.Today.AddYears(-30))
            .When(x => x.HourlySalary < 50).WithMessage("Junior staff should receive more salary");
        
        RuleFor(x => x.DateOfBirth).GreaterThan(DateTime.Today.AddYears(-30))
            .When(x => x.HourlySalary < 200).WithMessage("Senior staff should receive more salary");
    }
    
    private bool IsPhoneNumber(string arg)
    {
        if (arg[0] == '0')
        {
            arg = arg[1..];
        }
            
        Regex regex = new Regex(@"^[0-9]{10}$");
        return regex.IsMatch(arg);
    }
    
    private bool BeAValidDate(DateTime date)
    {
        return !date.Equals(default(DateTime));
    }
    
    private bool RetireNow(DateTime date)
    {
        var minAllowedBirthDate = DateTime.Today.AddYears(-65);
        return !(minAllowedBirthDate >= date);
    }
    
    private bool YouAreTooYoungForWork(DateTime date)
    {
        var minAllowedBirthDate = DateTime.Today.AddYears(-18);
        return !(minAllowedBirthDate <= date);
    }
}