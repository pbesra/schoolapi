using FluentValidation;
using schoolapi.Controllers.Models.Request;

namespace schoolapi.Controllers.Models.ModelValidators.Student
{
    public class CreateStudentRequestValidator : AbstractValidator<CreateStudentRequest>
    {
        public CreateStudentRequestValidator()
        {
            RuleFor(o => o.Gender)
                .NotEmpty()
                .WithMessage("Gender is a required field.");

            RuleFor(o => o.FirstName)
                .NotEmpty()
                .WithMessage("FirstName is a required field.")
                .MinimumLength(3)
                .WithMessage("FirstName: Minimum three characters are needed.");

            RuleFor(o => o.LastName)
                .NotEmpty()
                .WithMessage("LastName is a required field.")
                .MinimumLength(3)
                .WithMessage("LastName: Minimum three characters are needed.");

            RuleFor(o => o.DateOfBirth)
                .NotEmpty()
                .WithMessage("DateOfBirth is a required field.")
                .Must(x => DateTime.TryParse(x, out _))
                .WithMessage("DateOfBirth is not a valid field.")
                .Must(x =>
                {
                    DateTime twoYearsAfterDateOfBirth;

                    var isValidDate=DateTime.TryParse(x, out twoYearsAfterDateOfBirth);
                    if (isValidDate && twoYearsAfterDateOfBirth.AddYears(2) > DateTime.Now)
                    {
                        return false;
                    }
                    return true;
                })
                .WithMessage("Minimum 2 years required");

            RuleFor(o => o.Parents)
                .NotEmpty()
                .WithMessage("Parents is a required field.");

            RuleFor(o => o)
                .Must(o =>
                {
                    if (o.Parents?.FatherName?.Trim()?.Length <= 0)
                    {
                        return false;
                    }
                    return true;
                })
                .WithName("FatherName")
                .WithMessage("FatherName is a required field");
            RuleFor(o => o)
                .Must(o =>
                {
                    if (o.Parents?.MotherName?.Trim()?.Length <= 0)
                    {
                        return false;
                    }
                    return true;
                }).WithName("MotherName").WithMessage("MotherName is a required field");
            RuleFor(o => o)
                .Must(o =>
                {
                    if (o.Parents?.Contacts?.Count() <= 0)
                    {
                        return false;
                    }
                    if (!o.Parents.Contacts.Any(x => x.Name == "main"))
                    {
                        return false;
                    }
                    return true;
                })
                .WithName("Contact")
                .WithMessage("Contact is a required field");
            RuleFor(o => o.Addresses)
                .NotEmpty()
                .WithMessage("Address is a required field.");

            RuleFor(o => o)
                .Must(o =>
                {
                    if (o.Addresses?.Count() <= 0)
                    {
                        return false;
                    }
                    return true;
                })
                .WithName("Address")
                .WithMessage("At least one Address is mandatory.");

            RuleFor(o => o)
                .Must(o =>
                {
                    if (o.HasGuardian && o.Guardian == null)
                    {
                        return false;
                    }
                    return true;
                })
                .WithName("Guardian")
                .WithMessage("If You have a guardian, then guardian is a required field.");

            RuleFor(o => o)
                .Must(o =>
                {
                    if (o.HasGuardian && o.Guardian?.FirstName?.Trim()?.Length <= 0)
                    {
                        return false;
                    }
                    return true;
                })
                .WithName("Guardian.FirstName")
                .WithMessage("Guardian FirstName is required field.");
            RuleFor(o => o)
                .Must(o =>
                {
                    if (o.HasGuardian && o.Guardian?.FirstName?.Trim()?.Length <= 2
                    && o.Guardian?.FirstName?.Trim()?.Length > 0)
                    {
                        return false;
                    }
                    return true;
                })
                .WithName("Guardian.FirstName")
                .WithMessage("Guardian FirstName needs at least three characters.");

            RuleFor(o => o)
                .Must(o =>
                {
                    if (o.HasGuardian && o.Guardian?.FirstName?.Trim()?.Length <= 0)
                    {
                        return false;
                    }
                    return true;
                })
                .WithName("Guardian.FirstName")
                .WithMessage("Guardian FirstName is required field.");
            RuleFor(o => o)
                .Must(o =>
                {
                    if (o.HasGuardian && o.Guardian?.LastName?.Length <= 2
                    && o.Guardian?.LastName?.Trim()?.Length > 0)
                    {
                        return false;
                    }
                    return true;
                })
                .WithName("Guardian.LastName")
                .WithMessage("Guardian LastName needs at least three characters.");

            RuleFor(o => o)
                .Must(o =>
                {
                    if (o.HasGuardian && o.Guardian?.Contact?.Trim()?.Length <= 0)
                    {
                        return false;
                    }
                    return true;
                })
                .WithName("Guardian.Contact")
                .WithMessage("Guardian Contact is a required field.");

            RuleFor(o => o)
                .Must(o =>
                {
                    DateTime twoYearsAfterDateOfBirth;
                    var isValidDate = DateTime.TryParse(o.Guardian?.DateOfBirth, out twoYearsAfterDateOfBirth);
                    if (o.HasGuardian && isValidDate && twoYearsAfterDateOfBirth.AddYears(2) > DateTime.Now)
                    {
                        return false;
                    }
                    return true;
                })
                .WithName("Guardian.DateOfBirth")
                .WithMessage("Minimum age is 21 years old.");
        }
    }
}