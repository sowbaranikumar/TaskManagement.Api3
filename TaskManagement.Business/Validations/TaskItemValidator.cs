using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Business.DTOs;
using TaskManagement.Entity.Entities;
namespace TaskManagement.Business.Validations
{
      public class TaskItemValidator:AbstractValidator<TaskItemDto>
    {
        public TaskItemValidator() { 
            RuleFor(t => t.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(5).WithMessage("Title cannot exceed 5 characters.");
            RuleFor(t => t.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");
            RuleFor(t => t.DueDate)
                .GreaterThan(DateTime.Now).WithMessage("Due date must be in the future.");
            RuleFor(x => x.Priority)
                .InclusiveBetween(1,3).WithMessage("Priority must be between 1 and 3.");
            RuleFor(t=>t.IsCompleted)
                .NotNull().WithMessage("IsCompleted must be specified.");
            RuleFor(t => t.UserId)
                .InclusiveBetween(1,3).WithMessage("UserId must be 1 or 2 or 3.");
            RuleFor(t => t.ProjectId)
                .InclusiveBetween(1, 2).WithMessage("ProjectId must be 1 or 2.");
        }
    }
}
