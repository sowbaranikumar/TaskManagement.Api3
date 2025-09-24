using TaskManagement.Entity.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace TaskManagement.Data.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        Task<List<User>> GetAllAsync();   
        Task<User?> GetByIdAsync(int id);
    }
}

