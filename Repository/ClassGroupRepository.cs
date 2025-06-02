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
using Microsoft.AspNetCore.Mvc.Rendering;

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

       

        public async Task<IEnumerable<SelectListItem>> SelectListClassGroupAsync()
        {
            return await dbSet.OrderBy(a => a.Title)
                             .Select(a => new SelectListItem
                             {
                                 Value = a.ClassGroupId.ToString(),
                                 Text = a.Title
                             }).ToListAsync();
        }
    }

}
