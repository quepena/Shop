using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
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

        public async Task<int> CountAsync(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).CountAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await this.context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetEntityWithSpecification(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync(); 
        }

        public async Task<IReadOnlyList<T>> List()
        {
            return await this.context.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).ToListAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> specification)
        {
            return SpecificationEvaluator<T>.GetQuery(this.context.Set<T>().AsQueryable(), specification);
        }
    }
}