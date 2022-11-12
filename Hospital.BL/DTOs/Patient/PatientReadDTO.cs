using Hospital.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BL
{
    public class PatientReadDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";

        public ICollection<IssueChildReadDTO> Issues { get; set; } = new HashSet<IssueChildReadDTO>();
    }
}
