using System.Text.RegularExpressions;

namespace FluentValidation.Validators;

public class StuffValidator : AbstractValidator<Stuff>
{
    public StuffValidator()
    {
        RuleFor(x => x.Name).NotEmpty()
            .WithMessage("You have to enter name")
            .Length(10, 250).WithMessage("Name must be 10-250");

        RuleFor(x => x.EmailAddress).NotEmpty()
            .WithMessage("You have to enter email dear")
            .EmailAddress().WithMessage("Please enter a valid email address");

        RuleFor(x => x.HourlySalary).NotEmpty()
            .WithMessage("Hourly salary cannot be empty")
            .InclusiveBetween(30, 400).WithMessage("Range should be between 30-400. What is your expectation?");

        RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("You have to enter phone number")
            .Must(IsPhoneNumber).WithMessage("Please enter a valid phone number");
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
}

