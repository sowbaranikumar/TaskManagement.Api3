using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using TaskManagement.Entity.Entities;
using TaskManagement.Business.DTOs;

namespace TaskManagement.Business.Validations
{
    public class ProjectValidator:AbstractValidator<Project>
    {
        public ProjectValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Project name is required.")
                .MaximumLength(100).WithMessage("Project name must not exceed 100 characters.");
        }
    }
}
