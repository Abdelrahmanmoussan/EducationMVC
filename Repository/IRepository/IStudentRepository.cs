
using IdentityText.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityText.Repository.IRepository
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<int> CountAsync();


        Task<IEnumerable<Student>> GetAllWithIncludesAsync();
        Task<Student?> GetByIdWithIncludesAsync(int id);


        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student?> GetByIdAsync(int id);
        Task AddAsync(Student student);
        Task UpdateAsync(Student student);
        Task DeleteAsync(int id);

    }
}
