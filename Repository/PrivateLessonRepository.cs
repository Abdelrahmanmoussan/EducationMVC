using IdentityText.Repository;
using IdentityText.Repository.IRepository;
using IdentityText.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityText.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace IdentityText.Repository
{
    public class PrivateLessonRepository : Repository<PrivateLesson> , IPrivateLessonRepository
    {
        private readonly ApplicationDbContext dbContext;

        public PrivateLessonRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        {
            dbContext = appDbContext;
        }
        public IEnumerable<PrivateLesson> GetWithFullIncludes(
                 Expression<Func<PrivateLesson, bool>>? filter = null,
                 Func<IQueryable<PrivateLesson>, IQueryable<PrivateLesson>>? include = null,
                 bool tracked = true)
        {
            IQueryable<PrivateLesson> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (include != null)
            {
                query = include(query);
            }

            if (!tracked)
            {
                query = query.AsNoTracking();
            }

            return query.ToList();
        }
    }
}
