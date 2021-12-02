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

namespace BreathNDrinkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinksController : ControllerBase
    {
        [HttpPost]
        public void AddRating([FromQuery]int id, int rating)
        {
            DrinksManager.AddRating(id, rating);
        }

        //[HttpDelete]
        //public void Delete([FromBody] string value)
        //{
        //    DrinksManager.RemoveDrink(value);
        //}

        [HttpGet]
        public List<Drink> Get([FromQuery] string id, [FromQuery] string name, [FromQuery] double bodyWeight, [FromQuery] double bloodAlcCon, [FromQuery] double maxBacRequest, [FromQuery] int gender, [FromQuery] string[] ingredients, [FromQuery] string[] notFilter, [FromQuery] double minAlcPer, [FromQuery] double maxAlcPer = 100)
        {
            return DrinksManager.Get(id, name, bodyWeight, bloodAlcCon, maxBacRequest, gender, ingredients, notFilter, minAlcPer, maxAlcPer);
        }
    }
}
