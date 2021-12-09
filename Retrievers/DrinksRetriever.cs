using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using BreathNDrinkAPI.Models;
using BreathNDrinkClassLibrary;

namespace BreathNDrinkAPI.Retrievers
{
    public static class DrinksRetriever
    {
        private static HttpClient client = new ();
        private static string path = "http://www.thecocktaildb.com/api/json/v2/9973533/";
        private static BreathndrinkContext _context = new BreathndrinkContext();
        private static List<Ratings> _allRatings;

        static DrinksRetriever()
        {
            _allRatings = _context.Ratings.ToList();
        }

        public static async Task<List<Drink>> GetDrinksByNameAsync(string name)
        {
            _allRatings = _context.Ratings.ToList();

            HttpResponseMessage response = await client.GetAsync(path + $"search.php?s={name}");
            TempDrinkList tempDrinkList = null;
            if (response.IsSuccessStatusCode)
            {
                tempDrinkList = await response.Content.ReadFromJsonAsync<TempDrinkList>();
            }

            List<Drink> drinkList = new List<Drink>();
            foreach (TempDrink tD in tempDrinkList.Drinks)
            {
                drinkList.Add(ConvertDrink(tD));
            }

            return drinkList;
        }

        public static async Task<Drink> GetDrinkByIdAsync(string id)
        {
            _allRatings = _context.Ratings.ToList();

            HttpResponseMessage response = await client.GetAsync(path + $"lookup.php?i={id}");
            TempDrinkList tempDrinkList = null;
            TempDrink tempDrink = new();
            if (response.IsSuccessStatusCode)
            {
                try
                {
                    tempDrinkList = await response.Content.ReadFromJsonAsync<TempDrinkList>();
                }
                catch (JsonException)
                {
                    return null;
                }
            }

            if (tempDrinkList.Drinks != null)
            {
                tempDrink = tempDrinkList.Drinks.First();
                return ConvertDrink(tempDrink);
            }

            return null;
        }

        public static Drink ConvertDrink(TempDrink tempDrink)
        {
            Drink drink = new Drink(_allRatings.FindAll(r => r.DrinkId.Equals(int.Parse(tempDrink.IdDrink))));

            if (tempDrink.StrAlcoholic.ToLower().Equals("alcoholic") || tempDrink.StrAlcoholic.ToLower().Equals("optional alcohol"))
                drink.Alcoholic = true;
            else
                drink.Alcoholic = false;

            drink.DrinkId = tempDrink.IdDrink;
            drink.Name = tempDrink.StrDrink;
            drink.ImgThumbUrl = tempDrink.StrDrinkThumb;
            drink.Instructions = tempDrink.StrInstructions;

            if (tempDrink.StrIngredient1 == null) return drink;
            drink.AddIngredientAndMeasurement(tempDrink.StrIngredient1, tempDrink.StrMeasure1);
            if (tempDrink.StrIngredient2 == null) return drink;
            drink.AddIngredientAndMeasurement(tempDrink.StrIngredient2, tempDrink.StrMeasure2);
            if (tempDrink.StrIngredient3 == null) return drink;
            drink.AddIngredientAndMeasurement(tempDrink.StrIngredient3, tempDrink.StrMeasure3);
            if (tempDrink.StrIngredient4 == null) return drink;
            drink.AddIngredientAndMeasurement(tempDrink.StrIngredient4, tempDrink.StrMeasure4);
            if (tempDrink.StrIngredient5 == null) return drink;
            drink.AddIngredientAndMeasurement(tempDrink.StrIngredient5, tempDrink.StrMeasure5);
            if (tempDrink.StrIngredient6 == null) return drink;
            drink.AddIngredientAndMeasurement(tempDrink.StrIngredient6, tempDrink.StrMeasure6);
            if (tempDrink.StrIngredient7 == null) return drink;
            drink.AddIngredientAndMeasurement(tempDrink.StrIngredient7, tempDrink.StrMeasure7);
            if (tempDrink.StrIngredient8 == null) return drink;
            drink.AddIngredientAndMeasurement(tempDrink.StrIngredient8, tempDrink.StrMeasure8);
            if (tempDrink.StrIngredient9 == null) return drink;
            drink.AddIngredientAndMeasurement(tempDrink.StrIngredient9, tempDrink.StrMeasure9);
            if (tempDrink.StrIngredient10 == null) return drink;
            drink.AddIngredientAndMeasurement(tempDrink.StrIngredient10, tempDrink.StrMeasure10);
            if (tempDrink.StrIngredient11 == null) return drink;
            drink.AddIngredientAndMeasurement(tempDrink.StrIngredient11, tempDrink.StrMeasure11);
            if (tempDrink.StrIngredient12 == null) return drink;
            drink.AddIngredientAndMeasurement(tempDrink.StrIngredient12, tempDrink.StrMeasure12);
            if (tempDrink.StrIngredient13 == null) return drink;
            drink.AddIngredientAndMeasurement(tempDrink.StrIngredient13, tempDrink.StrMeasure13);
            if (tempDrink.StrIngredient14 == null) return drink;
            drink.AddIngredientAndMeasurement(tempDrink.StrIngredient14, tempDrink.StrMeasure14);
            if (tempDrink.StrIngredient15 == null) return drink;
            drink.AddIngredientAndMeasurement(tempDrink.StrIngredient15, tempDrink.StrMeasure15);

            return drink;
        }
    }
}
