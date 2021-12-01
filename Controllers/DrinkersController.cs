using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BreathNDrinkAPI.Managers;
using BreathNDrinkAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BreathNDrinkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinkersController : ControllerBase
    {

        private readonly DrinkersManager _manager = new DrinkersManager();
        // GET: api/<DrinkersController>
        [HttpGet]
        public List<Drinkers> Get()
        {
            return _manager.getDrinkers();
        }

        // GET api/<DrinkersController>/5
        [HttpGet("id=" + "{id}")]
        public Drinkers GetById(int id)
        {
            return _manager.getDrinkerById(id);
        }

        [HttpGet("name=" + "{name}")]
        public Drinkers GetByName(string name)
        {
            return _manager.getDrinkerByName(name);
        }

        // POST api/<DrinkersController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] double maxPro)
        {
            _manager.updateDrinker(id, maxPro);
        }

    }
}
