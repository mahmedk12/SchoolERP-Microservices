using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staff.Application.Features.Staff.Commands.CreateStaff
{
    public class CreateStaffCommandValidator : AbstractValidator<CreateStaffCommand>
    {
        public CreateStaffCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{Name} is required.");
            
            RuleFor(p => p.email)
               .NotEmpty().WithMessage("{EmailAddress} is required.");

            RuleFor(p => p.Nic)
               .NotEmpty().WithMessage("CNIC Number is required.")
               .Length(13).WithMessage("CNIC Numbers must be 13 digits.");

            RuleFor(p => p.mobileNumber)
               .NotEmpty().WithMessage("Mobile number is required")
               .Length(11).WithMessage("Mobile number must be exactly 11 digits");
        }
    }
}
