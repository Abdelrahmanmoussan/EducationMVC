using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace IdentityText.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {

        Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default);

        void Create(IEnumerable<T> entities);

        public void Edit(T entity);
        Task<bool> CommitAsync();

        public void Delete(T entity);

        public void Delete(IEnumerable<T> entities);

        public IEnumerable<T> Get(Expression<Func<T, bool>>? filter = null, Expression<Func<T, object>>[]? includes = null, bool tracked = true);

        public T? GetOne(Expression<Func<T, bool>>? filter = null, Expression<Func<T, object>>[]? includes = null, bool tracked = true);
    }
}
