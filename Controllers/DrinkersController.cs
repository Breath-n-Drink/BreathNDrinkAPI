using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BreathNDrinkAPI.Managers;
using BreathNDrinkAPI.Models;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BreathNDrinkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinkersController : ControllerBase
    {

        private readonly DrinkersManager _manager = new DrinkersManager();
        private readonly BreathndrinkContext _context = new BreathndrinkContext();
        // GET: api/<DrinkersController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public ActionResult<List<Drinkers>> Get()
        {
            return Ok(_manager.getDrinkers());
        }

        // GET api/<DrinkersController>/5
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("id=" + "{id}")]
        public ActionResult<Drinkers> GetById(int id)
        {
            if (_context.Drinkers.Find(id) == null)
            {
                return NotFound();
            }
            return Ok(_manager.getDrinkerById(id));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("name=" + "{name}")]
        public ActionResult<Drinkers> GetByName(string name)
        {
            return Ok(_manager.getDrinkerByName(name));
        }

        // POST api/<DrinkersController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] double maxPro)
        {
            _manager.updateDrinker(id, maxPro);
            return Ok();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost]
        public ActionResult Post([FromQuery] string name)
        {
            _manager.addDrinker(name);
            return Ok();
        }

    }
}
