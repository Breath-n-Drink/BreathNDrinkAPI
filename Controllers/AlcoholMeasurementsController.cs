using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BreathNDrinkAPI.Managers;
using BreathNDrinkClassLibrary;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BreathNDrinkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlcoholMeasurementsController : ControllerBase
    {
        // GET: api/<AlcoholMeasurementsController>
        [HttpGet]
        public IEnumerable<AlcoholMeasurement> Get([FromQuery] string userId)
        {
            return AlcoholMeasurementsManager.GetMeasurements(userId);
        }

        // POST api/<AlcoholMeasurementsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AlcoholMeasurementsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AlcoholMeasurementsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
