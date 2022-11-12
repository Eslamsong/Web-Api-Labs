using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL
{
    public class PatientRepo : GenericRepo<Patient>, IPatientRepo
    {
        private readonly HospitalDb _context;
        public PatientRepo(HospitalDb context) :base (context)
        {
            _context=context;   
        }

        public List<Patient> GetPatientsWithIssues()
        {
            return _context.Patients.Include(P => P.Issues).ToList();
        }
    }
}
