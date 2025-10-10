using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Entity.Interfaces;
namespace TaskManagement.Entity.Entities;

public class TaskItem:IEntityStatus
{
   public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime DueDate { get; set; }
    public int Priority { get; set; }
    public bool IsCompleted { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsDeleted { get; set; } = false;
    public DateTimeOffset? DeletedAt { get; set; }

    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public int? ProjectId { get; set; }
    public Project? Project { get; set; }
}

