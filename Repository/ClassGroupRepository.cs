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
    public class ClassGroupRepository : Repository<ClassGroup>, IClassGroupRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ClassGroupRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        {
            dbContext = appDbContext;
        }
        public async Task<int> CountAsync()
        {
            return await dbContext.ClassGroups.CountAsync();
        }

        public IEnumerable<ClassGroup> GetWithFullIncludes(
             Expression<Func<ClassGroup, bool>>? filter = null,
             Expression<Func<ClassGroup, object>>[]? includes = null,
             bool tracked = true)
            {
                IQueryable<ClassGroup> query = dbContext.ClassGroups
                    .Include(cg => cg.Teacher)
                        .ThenInclude(t => t.ApplicationUser)
                    .Include(cg => cg.Subject)
                    .Include(s=>s.AcademicYear);

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                if (!tracked)
                {
                    query = query.AsNoTracking();
                }

                return query.ToList();
            }

        public string? GetWithFullIncludes()
        {
            throw new NotImplementedException();
        }
    }

}
