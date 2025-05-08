
using IdentityText.Repository.IRepository;
using IdentityText.Models;
using IdentityText.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityText.Repository
{
    public class PrivateLessonRepository : Repository<PrivateLesson> , IPrivateLessonRepository
    {
        private readonly ApplicationDbContext dbContext;

        public PrivateLessonRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        {
            dbContext = appDbContext;
        }
    }
}
