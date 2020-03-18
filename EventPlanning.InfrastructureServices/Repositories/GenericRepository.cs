using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using EventPlanning.Infrastructure.Interfaces;
using EventPlanning.InfrastructureServices.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EventPlanning.InfrastructureServices.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T: class 
    {
        private readonly MyContext _context;

        public GenericRepository(MyContext context)
        {
            _context = context;
        }

        public async Task<T> Create(T t)
        {
            _context.Set<T>().Add(t);
            await _context.SaveChangesAsync();
            return t;
        }

        public async Task Delete(T t)
        {
            _context.Set<T>().Remove(t);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T t)
        {
            _context.Set<T>().Update(t);
            await _context.SaveChangesAsync();
        }

        public async Task<T> Get(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IList<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }
    }
}
