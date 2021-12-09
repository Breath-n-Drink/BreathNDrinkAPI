using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BreathNDrinkAPI.Managers;
using BreathNDrinkClassLibrary;
using BreathNDrinkAPI.Models;
using Microsoft.AspNetCore.Cors;

namespace BreathNDrinkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinksController : ControllerBase
    {
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost]
        [EnableCors("allowAll")]
        public ActionResult AddRating([FromQuery] int id, int drinkerId, int rating)
        {
            if (id < 0 || drinkerId < 0 || rating < 0 || rating > 5)
            {
                return BadRequest();
            }
            if (drinkerId == 0)
            {
                return NotFound(drinkerId);
            }
            else
            {
                DrinksManager.AddRating(id, drinkerId, rating);
                return Ok();
            }

        }

        //[HttpDelete]
        //public void Delete([FromBody] string value)
        //{
        //    DrinksManager.RemoveDrink(value);
        //}
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public ActionResult<List<Drink>> Get([FromQuery] string id, [FromQuery] string name, [FromQuery] double bodyWeight, [FromQuery] double bloodAlcCon, [FromQuery] double maxBacRequest, [FromQuery] int gender, [FromQuery] string[] ingredients, [FromQuery] string[] notFilter, [FromQuery] double minAlcPer, [FromQuery] double maxAlcPer = 100, [FromQuery] int sortByRating = 0)
        {
            return Ok(DrinksManager.Get(id, name, bodyWeight, bloodAlcCon, maxBacRequest, gender, ingredients, notFilter, minAlcPer, maxAlcPer, sortByRating));
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        [Route("Favorites")]
        public ActionResult<List<Drink>> GetFavorites([FromQuery] int drinkerId)
        {
            return Ok(DrinksManager.GetFavorites(drinkerId));
        }
    }
}
