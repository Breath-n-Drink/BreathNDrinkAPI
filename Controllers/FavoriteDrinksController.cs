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
    public class FavoriteDrinksController : ControllerBase
    {
         BreathndrinkContext _context = new BreathndrinkContext();
        // POST api/<FavoriteDrinksController>
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost]
        public ActionResult Post([FromQuery] int drinkId, int drinkerId)
        {
            if (drinkId < 0 || drinkerId < 0)
            {
                return BadRequest();
            }
            FavoriteDrinksManager.AddFavorite(drinkId, drinkerId);
            return Ok();
        }

        // DELETE api/<FavoriteDrinksController>/5
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete]
        public ActionResult Delete([FromQuery] int drinkId, int drinkerId)
        {
            if (_context.FavoriteDrinks.Count(d => d.DrinkerId == drinkerId && d.DrinkId == drinkId) == 0)
            {
                return NotFound();
            }
            FavoriteDrinksManager.DeleteFavorite(drinkId, drinkerId);
            return NoContent();
        }
    }
}
