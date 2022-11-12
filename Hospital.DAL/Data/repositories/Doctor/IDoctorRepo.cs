using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL
{
    public interface IDoctorRepo :IGenericRepo<Doctor>
    {
        List<Doctor> GetDoctorsbyPerfomance (int performnaceRate);   
    }
}
