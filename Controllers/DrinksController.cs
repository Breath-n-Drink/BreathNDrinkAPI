﻿using Microsoft.AspNetCore.Http;
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
        public List<Drink> Get([FromQuery] string id, [FromQuery] string name)
        {
            return DrinksManager.Get(id, name);
        }
    }
}
