using AutoMapper;
using Hospital.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.BL
{
    public class PatientManager : IPatientManager
    {
        private readonly IPatientRepo patientRepo;
        private readonly IMapper mapper;
        public PatientManager(IPatientRepo _patientRepo,IMapper _mapper)
        {
            patientRepo= _patientRepo;
            mapper= _mapper;
        }
        public List<PatientReadDTO> GetAllPatients()
        {
            var patList= patientRepo.GetPatientsWithIssues().ToList();

            return mapper.Map<List<PatientReadDTO>>(patList) ;
        }
    }
}
