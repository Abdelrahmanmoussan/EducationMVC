
using IdentityText.Repository.IRepository;
using IdentityText.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IdentityText.Repository.IRepository
{
    public interface ITeacherRepository : IRepository<Teacher>
    {
        Task<int> CountAsync();

        Task<IEnumerable<Teacher>> GetAllWithIncludesAsync();
        Task<Teacher?> GetByIdWithIncludesAsync(int id);
        Task<IEnumerable<SelectListItem>> SelectListTeacherAsync();

    }
}
