using API_LAB_1.Model;
using API_LAB_1.Validation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Reflection;

namespace API_LAB_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {

        private readonly ILogger<CarsController> logger;
        public CarsController (ILogger<CarsController> _logger)
        {
          logger = _logger;
        }
        private static List<Cars> cars = new List<Cars>{

            new Cars {Id=1 ,Name="mrecedes" },
            new Cars {Id=2 ,Name="MG"},
            new Cars {Id=3 ,Name="BWM"}
           
       
        };
   

        [HttpGet]
        public ActionResult<List<Cars>> GetALL()
        {

            return cars ;
        }


        [HttpGet]
        [Route("{id:int:min(1):max(100)}")]
       public ActionResult <Cars> getByID(int id)
        {
            var car = (from i in cars where i.Id == id select i).FirstOrDefault();

            if (!ModelState.IsValid)
            {

                logger.LogDebug("iam Debugging");
                logger.LogError(ModelState.ErrorCount.ToString());
                return BadRequest("the Car id is not availble");
            }
            if (car == null)
            {

                return NotFound("the Car id is not availble");
            }

            return car;
            

        }

        [HttpPost]

        public ActionResult Add( Cars car)
        {

            var carex = (from i in cars where i.Id==car.Id select i).FirstOrDefault();
            if(carex == null)
            {
                
                cars.Add(car);
                return CreatedAtAction(
                "getByID",
               new { id = car.Id },
               new { Message = "The car has been added" });
            }
            else
            {
                return BadRequest("The Car already exists");
            }

        }

        [HttpPost]
        [CarTypeValidation]
        [Route("V2")]
        public ActionResult AddV2(Cars car)
        {

            var carex = (from i in cars where i.Id == car.Id select i).FirstOrDefault();
            if (carex == null)
            {

                cars.Add(car);
                return CreatedAtAction(
                "getByID",
               new { id = car.Id },
               new { Message = "The car has been added" });
            }
            else
            {
                return BadRequest("The Car already exists");
            }

        }

        [HttpPut]
        [Route("{id:int:min(1):max(100)}")]
        public ActionResult Edit (Cars car,int id)
        {



            if (car.Id != id)
            {
                return BadRequest();
            }
            var carex = (from i in cars where i.Id == car.Id select i).FirstOrDefault();
            if (carex == null)
            {

                return NotFound("the Car id is not availble");
            }
            carex.Name=car.Name;
            return NoContent();
        }

        [HttpDelete]
        [Route("{id:int:min(1):max(100)}")]

        public ActionResult Delete(int id )
        {
            var car = (from i in cars where i.Id == id select i).FirstOrDefault();
            if (car == null)
            {

                return NotFound("the Car doesn't exist");
            }
            cars.Remove(car);
            return NoContent();
        }

    }
}
