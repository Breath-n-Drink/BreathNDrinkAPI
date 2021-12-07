using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BreathNDrinkAPI.Managers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BreathNDrinkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteDrinksController : ControllerBase
    {
        // POST api/<FavoriteDrinksController>
        [HttpPost]
        public void Post([FromQuery] int drinkId, int drinkerId)
        {
            FavoriteDrinksManager.AddFavorite(drinkId, drinkerId);
        }

        // DELETE api/<FavoriteDrinksController>/5
        [HttpDelete]
        public void Delete([FromQuery] int drinkId, int drinkerId)
        {
            FavoriteDrinksManager.DeleteFavorite(drinkId, drinkerId);
        }
    }
}
