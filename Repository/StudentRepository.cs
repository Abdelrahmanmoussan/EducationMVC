
using IdentityText.Data;
using IdentityText.Models;
using IdentityText.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityText.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        readonly ApplicationDbContext appDbContext;
        public StudentRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        {
            this.appDbContext = appDbContext;
        }
    }
}
