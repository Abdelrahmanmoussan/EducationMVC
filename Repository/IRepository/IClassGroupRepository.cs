using IdentityText.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IdentityText.Repository.IRepository
{
    public interface IClassGroupRepository : IRepository<ClassGroup>
    {

        Task<IEnumerable<SelectListItem>> SelectListClassGroupAsync();
        Task<int> CountAsync();

        Task<List<ClassGroup>> GetLatestCoursesAsync(int count = 5);

        Task<int> CountByMonthAsync(int month, int year);

    }



}
