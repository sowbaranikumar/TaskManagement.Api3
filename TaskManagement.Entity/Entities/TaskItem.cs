using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Entity.Entities;

public class TaskItem
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime DueDate { get; set; }
    public int Priority { get; set; }
    public bool IsCompleted { get; set; }

    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public int? ProjectId { get; set; }
    public Project? Project { get; set; }
}

