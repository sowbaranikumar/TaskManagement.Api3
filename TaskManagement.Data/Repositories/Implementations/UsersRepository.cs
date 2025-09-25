using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Data.Db;
using TaskManagement.Data.Repositories.Interfaces;
using TaskManagement.Entity.Entities;

//namespace TaskManagement.Data.Repositories.Implementations
//{
//    public class UsersRepository : IUsersRepository
//    {
//        private readonly AppDbContext _context;

//        public UsersRepository(AppDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<List<User>> GetAllAsync()
//        {
//            return await _context.Users.ToListAsync();
//        }

//        public async Task<User?> GetByIdAsync(int id)
//        {
//            return await _context.Users.FindAsync(id);
//        }
//    }
//}
namespace TaskManagement.Data.Repositories.Implementations
{
    public class UsersRepository : GenericRepository<User>, IUsersRepository
    {
        public UsersRepository(AppDbContext context) : base(context) { }
    }
}