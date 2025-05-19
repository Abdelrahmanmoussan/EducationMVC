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
    public class AssessmentRepository : Repository<Assessment> , IAssessmentRepository 
    {
        private readonly ApplicationDbContext _dbContext;
        public AssessmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<SelectListItem>> SelectListAssessmentAsync()
        {
            return await dbSet.OrderBy(a => a.Title)
                             .Select(a => new SelectListItem
                             {
                                 Value = a.AssessmentId.ToString(),
                                 Text = a.Title
                             }).ToListAsync();
        }

        
    }
}
