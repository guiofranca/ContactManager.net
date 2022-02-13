using ContactManager.Api.DTOs;
using FluentValidation;

namespace ContactManager.Api.Validators;

class ContactValidator : AbstractValidator<ContactDTO> 
{
    public ContactValidator()
    {
        RuleFor(c => c.Name)
            .Length(3, 255);

        RuleFor(c => c.Nickname)
            .Length(3, 255);

        RuleFor(c => c.DateOfBirth)
            .Must(BeAValidDate)
            .WithMessage("The Date of Birth should be a valid date.");
    }

    private bool BeAValidDate(string? arg)
    {
        if(arg == null || arg.Equals(String.Empty)) return true;
        try {
            DateOnly.Parse(arg);
            return true;
        } catch {
            return false;
        }
    }
}