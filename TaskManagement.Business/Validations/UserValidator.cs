using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Entity.Entities;
using TaskManagement.Business.DTOs;
namespace TaskManagement.Business.Validations
{
    public class UserValidator:AbstractValidator<User>
    {
       public UserValidator()
       {
        RuleFor(u => u.Name)
            .NotEmpty().WithMessage("Username is required.")
            .MaximumLength(50).WithMessage("Username must not exceed 50 characters.");
        RuleFor(u => u.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("A valid email is required.")
            .MaximumLength(100).WithMessage("Email must not exceed 100 characters.");

        }
    }
}
