using IdentityText.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IdentityText.Repository.IRepository
{
    public interface IClassGroupRepository : IRepository<ClassGroup>
    {
      
        Task<int> CountAsync();
         IEnumerable<ClassGroup> GetWithFullIncludes(
             Expression<Func<ClassGroup, bool>>? filter = null,
             Expression<Func<ClassGroup, object>>[]? includes = null,
             bool tracked = true);
        
    }
}
