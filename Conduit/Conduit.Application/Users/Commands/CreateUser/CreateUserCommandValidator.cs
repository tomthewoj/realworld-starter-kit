using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(user => user.Username).MinimumLength(3).WithMessage("Your username length must be at least 3").MaximumLength(40).WithMessage("Your username is too long");
            RuleFor(user => user.Password).NotEmpty().WithMessage("Your password cannot be empty")
                   .MinimumLength(8).WithMessage("Your password length must be at least 8.")
                   .MaximumLength(16).WithMessage("Your password length must not exceed 16.")
                   .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                   .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
                   .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.")
                   .Matches(@"[\!\?\*\.]+").WithMessage("Your password must contain at least one (!? *.).");
            RuleFor(user => user.Email).EmailAddress().WithMessage("Incorrect email format");
        }
    }
}
