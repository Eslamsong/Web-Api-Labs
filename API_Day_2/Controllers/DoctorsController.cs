using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hospital.DAL;
using Hospital.BL;

namespace API_Day_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorManager doctorManager;

        public DoctorsController(IDoctorManager _doctorManager)
        {
            this.doctorManager = _doctorManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DoctorReadDTO>> GetDoctors()
        {
            var docs= doctorManager.GetAllDoctors();
            return docs;
        }

        
        [HttpGet]
        [Route("{id:Guid}")]
        public ActionResult<DoctorReadDTO?> GetDoctor(Guid id)
        {
            var doctor = doctorManager.GetDoctor(id);

            if (doctor == null)
            {
                return NotFound();
            }

            return doctor;
        }

        [HttpPut]
        public ActionResult PutDoctor( DoctorWriteDTO doctorDTO)
        {

            var result = doctorManager.EditDoctor(doctorDTO);
            if (result)
            {
                return NoContent();
            }
            return BadRequest();
        }



        [HttpPost]
        public ActionResult<DoctorReadDTO> PostDoctor(DoctorWriteDTO doctor)
        {
            var doctorReadDTO =doctorManager.AddDoctor(doctor);

            return CreatedAtAction("GetDoctor", new { id = doctorReadDTO.Id }, doctorReadDTO);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteDoctor(Guid id)
        {
            doctorManager.DeleteDoctor(id);
            return NoContent();
        }

     
    }
}
