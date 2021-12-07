using System.Collections.Generic;
using BreathNDrinkAPI.Managers;
using BreathNDrinkAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BreathNDrinkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromilleController : ControllerBase
    {
        private readonly PromilleManager _manager = new PromilleManager();
        // GET: api/<PromilleController>
        [HttpGet]
        public double Get()
        {
            return _manager.GetPromillle();
        }
        [HttpGet("id=" + "{id}")]
        public List<Promille> GetByDrinker(int id)
        {
            return _manager.GetPromillleByDrinker(id);
        }

        //Hej
    }
}
