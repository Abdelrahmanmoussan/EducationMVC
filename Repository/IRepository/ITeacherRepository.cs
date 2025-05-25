
using IdentityText.Repository.IRepository;
using IdentityText.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;

namespace IdentityText.Repository.IRepository
{
    public interface ITeacherRepository : IRepository<Teacher>
    {
        Task<int> CountAsync();

        //Task<IEnumerable<Teacher>> GetAllWithIncludesAsync();
        public IEnumerable<Teacher> GetAllWithIncludesAsync(
            Expression<Func<Teacher, bool>>? filter = null,
            Func<IQueryable<Teacher>, IQueryable<Teacher>>? include = null,
            bool tracked = true);
        Task<Teacher?> GetByIdWithIncludesAsync(int id);
        Task<IEnumerable<SelectListItem>> SelectListTeacherAsync();

    }
}
