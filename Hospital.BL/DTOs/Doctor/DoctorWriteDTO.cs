using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BL
{
    public class DoctorWriteDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";

        public string Specialization { get; set; } = "";

        public double Salary { get; set; }

    }
}
