﻿
using IdentityText.Data;
using IdentityText.Models;
using IdentityText.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IdentityText.Repository
{
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        private readonly ApplicationDbContext dbContext;

        public TeacherRepository(ApplicationDbContext appDbContext) : base(appDbContext) 
        {
            dbContext = appDbContext;
        }
        public async Task<int> CountAsync()
        {
            return await dbContext.Teachers.CountAsync();
        }

        public async Task<Teacher?> GetByIdWithIncludesAsync(int id)
        {
            return await dbContext.Teachers
                .Include(t => t.ApplicationUser)
                .Include(t => t.Subject)
                .FirstOrDefaultAsync(t => t.TeacherId == id);
        }
        public async Task<IEnumerable<SelectListItem>> SelectListTeacherAsync()
        {
            return await dbSet.OrderBy(a => a.TeacherId)
                              .Select(a => new SelectListItem
                              {
                                  Value = a.TeacherId.ToString(),
                                  Text = a.ApplicationUser.FirstName.ToString() + " " + a.ApplicationUser.LastName.ToString()
                              }).ToListAsync();
        }


    }
}
