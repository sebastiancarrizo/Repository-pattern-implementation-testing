using Microsoft.EntityFrameworkCore;
using Test.Data.Context;
using Test.DataAccess.Interfaces;

namespace Test.DataAccess.Services
{
    public class RepositoryAsync<T> : IRepositoryAsync<T> where T : class
    {
        private readonly PermissionContext context;
        private bool disposed = false;
        public RepositoryAsync(PermissionContext context)
        {
                this.context = context;
        }

        protected DbSet<T> EntitySet
        {
            get
            {
                return context.Set<T>();
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await EntitySet.ToListAsync();
        }


        public async Task<T> GetById(int id)
        {
            return await EntitySet.FindAsync(id);
        }
        public async Task<T> Insert(T entity)
        {
            EntitySet.Add(entity);
            await Save();
            return entity;
        }
        public async Task<bool> Delete(int id)
        {
            T entity = await EntitySet.FindAsync(id);
            if(entity == null)
            {
                return false;
            }

            EntitySet.Remove(entity);
            int result = await context.SaveChangesAsync();
            return result == 1;
        }
        public async Task<bool> Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;            
            int result = await context.SaveChangesAsync();
            return result == 1;
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    context.Dispose();
                }
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
