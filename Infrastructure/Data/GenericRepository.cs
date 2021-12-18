using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DataContext context;

        public GenericRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<T> GetById(int id)
        {
            return await this.context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> List()
        {
            return await this.context.Set<T>().ToListAsync();
        }
    }
}