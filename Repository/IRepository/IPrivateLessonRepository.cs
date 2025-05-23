using IdentityText.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IdentityText.Repository.IRepository
{
    public interface IPrivateLessonRepository : IRepository<PrivateLesson>
    {
        IEnumerable<PrivateLesson> GetWithFullIncludes(
                 Expression<Func<PrivateLesson, bool>>? filter = null,
                 Func<IQueryable<PrivateLesson>, IQueryable<PrivateLesson>>? include = null,
                 bool tracked = true);
    }
}
