using FluentValidation;
using schoolapi.Controllers.Models.Request;

namespace schoolapi.Utility.Validators
{
    public class UserEntityValidator : AbstractValidator<CreateStudentRequest>
    {
        public UserEntityValidator()
        {
            /*RuleFor(o => o.Gender)
                .NotEmpty()
                .WithMessage("Gender is a required field");
            RuleFor(o => o.FirstName)
                .NotEmpty()
                .WithMessage("FirstName can not be empty");
            RuleFor(o => o.LastName)
                .NotEmpty()
                .WithMessage("LastName can not be empty");
            RuleFor(o => o.Type)
                .NotEmpty()
                .WithMessage("Type can not be empty.");
            RuleFor(o => o)
                .Must(o =>
                {
                    var isValidDate = IsValidDate(o.DateOfBrith);
                    if (o.Type == "student" && !isValidDate)
                    {
                        return false;
                    }
                    return true;
                })
                .WithName("DateOfBirth")
                .WithMessage("DateTime is required.");
            *//*RuleFor(o => o)
                .Must(o =>
                {
                    if (o.Type == "student" && o.UserParents.ContactNumber?.Length <= 0)
                    {
                        return false;
                    }
                    return true;
                })
                .WithName("ParentContactNumber")
                .WithMessage("ParentContactNumber is required.");*/
            /* RuleFor(o => o)
                 .Must(o =>
                 {
                     if (o.Type == "student" && o.UserParents.FatherName?.Length <= 0)
                     {
                         return false;
                     }
                     return true;
                 })
                 .WithName("FatherName")
                 .WithMessage("FatherName is required.");*/
            /*RuleFor(o => o)
                .Must(o =>
                {
                    if (o.Type == "student" && o.UserParents.MotherName?.Length <= 0)
                    {
                        return false;
                    }
                    return true;
                })
                .WithName("MotherNumber")
                .WithMessage("MotherNumber is required.");*/
            /*RuleFor(o => o)
                .Must(o =>
                {
                    if (
                        o.Type == "student"
                        && o.UserAddressList.Find(x => x.Type.ToLower() == "permanent") == null
                    )
                    {
                        return false;
                    }
                    return true;
                })
                .WithName("MotherNumber")
                .WithMessage("Permanent address is required.");*/
        }

        private bool IsValidDate(string date)
        {
            DateTime outDate;
            var isValid = DateTime.TryParse(date, out outDate);
            return isValid;
        }
    }
}