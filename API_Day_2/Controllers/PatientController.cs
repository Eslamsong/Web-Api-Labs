using Hospital.BL;
using Hospital.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Day_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly HospitalDb context;
        private readonly IPatientManager patientManager;

        public PatientController(HospitalDb _context,IPatientManager _patientManager)
        {
            context = _context;
            patientManager = _patientManager;
        }
        [HttpGet]
        public ActionResult<List<PatientReadDTO>> GetAll()
        {
            var patientList = patientManager.GetAllPatients().ToList();
            return Ok(patientList);
        }

        [HttpGet]
        [Route("{with Doctors}")]

        public ActionResult<List<Patient>> getAllwithDoctors()
        {

            var list = context.Patients.ToList();
            return list;
        }
    }
}
