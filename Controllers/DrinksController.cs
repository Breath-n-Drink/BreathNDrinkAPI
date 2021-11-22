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

namespace BreathNDrinkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinksController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Drink> Get()
        {
            return DrinksManager.GetAllDrinks();
        }

        [HttpPost]
        public void Post([FromBody] Drink value)
        { 
            DrinksManager.AddDrink(value);
        }

        [HttpDelete]
        public void Delete([FromBody] string value)
        {
            DrinksManager.RemoveDrink(value);
        }

        [HttpGet]
        public Drink FindById(string id)
        {
            return DrinksManager.FindById(id);
        }
    }
}
