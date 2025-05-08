
using IdentityText.Data;
using IdentityText.Models;
using IdentityText.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
