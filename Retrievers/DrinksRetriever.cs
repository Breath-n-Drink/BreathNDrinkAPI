using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BreathNDrinkAPI.Retrievers
{
    public class DrinksRetriever
    {
        private static HttpClient client = new HttpClient();
        private static string path = "http://www.thecocktaildb.com/api/json/v1/1/search.php";

        public static async Task<string> GetDrinkByNameAsync(string name)
        {
            HttpResponseMessage response = await client.GetAsync(path + $"?s={name}");
            string jsonDrink = "";
            if (response.IsSuccessStatusCode)
            {
                jsonDrink = await response.Content.ReadAsStringAsync();
            }
            return jsonDrink;
        }

        public static async Task<string> GetDrinkByIdAsync(string id)
        {
            HttpResponseMessage response = await client.GetAsync(path + $"i={id}");
            string jsonDrink = "";
            if (response.IsSuccessStatusCode)
            {
                jsonDrink = await response.Content.ReadAsStringAsync();
            }
            return jsonDrink;
        }
    }
}
