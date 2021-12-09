using System.Collections.Generic;
using BreathNDrinkAPI.Managers;
using BreathNDrinkAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BreathNDrinkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromilleController : ControllerBase
    {
        private readonly PromilleManager _manager = new PromilleManager();
        private readonly BreathndrinkContext _context = new BreathndrinkContext();
        // GET: api/<PromilleController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public ActionResult<double> Get()
        {
            return Ok(_manager.GetPromillle());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("id=" + "{id}" + "page=" + "{page}")]
        public ActionResult<List<Promille>> GetByDrinker(int id, int page)
        {
            if (_context.Drinkers.Find(id) == null)
            {
                return NotFound();
            }

            
            return Ok(_manager.GetPromillleByDrinker(id, page));
        }
    }
}
