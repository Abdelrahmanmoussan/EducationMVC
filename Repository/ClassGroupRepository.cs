using IdentityText.Repository;
using IdentityText.Repository.IRepository;
using IdentityText.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityText.Data;

namespace IdentityText.Repository
{
    public class ClassGroupRepository : Repository<ClassGroup> , IClassGroupRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ClassGroupRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        {
            dbContext = appDbContext;
        }
    }
}
