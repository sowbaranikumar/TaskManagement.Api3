using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Entity.Interfaces
{
    public interface IEntityStatus
    {
        bool IsActive { get; set; }
        bool IsDeleted { get; set; }
        DateTimeOffset? DeletedAt { get; set; }
    }
}

