using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BL
{
    public interface IDoctorManager
    {

        List<DoctorReadDTO> GetAllDoctors();
        DoctorReadDTO? GetDoctor(Guid id);

        DoctorReadDTO AddDoctor(DoctorWriteDTO dctr);

        Boolean EditDoctor (DoctorWriteDTO dctr);

        void DeleteDoctor(Guid id);

    }
}
