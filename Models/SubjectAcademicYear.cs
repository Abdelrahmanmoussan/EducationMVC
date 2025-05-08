using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityText.Models
{
    public class SubjectAcademicYear
    {
        public int SubjectId { get; set; }
        public required Subject Subject { get; set; }

        public int AcademicYearId { get; set; }
        public required AcademicYear AcademicYear { get; set; }
    }

}
