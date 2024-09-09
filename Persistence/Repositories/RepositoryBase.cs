using System.Linq.Expressions;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {

        protected RepositoryContext context;

        protected RepositoryBase(RepositoryContext repositoryContext)
        {
            context = repositoryContext;
        }

        public void Create(T entity) => context.Set<T>().Add(entity);

        public void Delete(T entity) => context.Set<T>().Remove(entity);

        public IQueryable<T> FinByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ?
            context.Set<T>()
                .Where(expression)
                .AsNoTracking():
            context.Set<T>()
                .Where(expression);

        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ?
            context.Set<T>().
                AsNoTracking() :
            context.Set<T>();


        public void Update(T entity) => context.Set<T>().Update(entity);
    }
}
