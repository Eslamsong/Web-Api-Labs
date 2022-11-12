using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL;

public class DoctorRepo : GenericRepo<Doctor>, IDoctorRepo
{
    private readonly HospitalDb _context;
    public DoctorRepo(HospitalDb context) : base(context)
    {
        _context = context;
    }

    public List<Doctor> GetDoctorsbyPerfomance(int performnaceRate)
    {
        //var doc = (from i in _context.Doctors where i.PerformanceRate > performnaceRate select i).ToList();
        //return doc

        return _context.Set<Doctor>().Where(d=>d.PerformanceRate>performnaceRate).ToList();
    }
}
