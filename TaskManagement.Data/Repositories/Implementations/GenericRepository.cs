﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Data.Db;
using TaskManagement.Data.Repositories.Interfaces;
using TaskManagement.Entity.Interfaces;
namespace TaskManagement.Data.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        //public async Task<T> UpdateAsync(T entity)
        //{
        //    _dbSet.Update(entity);
        //    await _context.SaveChangesAsync();
        //    return entity;
        //}
       

    public async Task<T> UpdateAsync(T entity)
    {
        if (entity is IEntityStatus status)
        {
            if (status.IsDeleted) 
            {
                status.IsActive = false;
                status.DeletedAt ??= DateTimeOffset.UtcNow;
            }
            else 
            {
                if (status.DeletedAt != null)
                {
                    status.DeletedAt = null;
                }
                status.IsActive = true;
            }
        }

        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null) return;

            if (entity is IEntityStatus status)
            {
                status.IsDeleted = true;
            }
            await UpdateAsync(entity);
        }
     }
}
