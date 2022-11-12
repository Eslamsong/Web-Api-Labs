using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {

        [HttpGet]
        [Route("secured-data")]
        [Authorize]

        public ActionResult GetSecuredData()
        {

            return Ok(new
            {
                Name ="Eslam Hussien"

            });
        }

        [HttpGet]
        [Route("Manager")]
        [Authorize(Policy ="ManagersOnly")]
        public ActionResult GetSecuredManagerData()
        {

            return Ok(new
            {
                Name = "Authorization Tutorial" 

            }); ;
        }
    }
}
