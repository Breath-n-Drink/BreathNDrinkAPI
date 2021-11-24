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

        public static async Task<List<Drink>> GetDrinksByNameAsync(string name)
        {
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
            HttpResponseMessage response = await client.GetAsync(path + $"lookup.php?i={id}");
            TempDrinkList tempDrinkList = null;
            TempDrink tempDrink = new();
            if (response.IsSuccessStatusCode)
            {
                tempDrinkList = await response.Content.ReadFromJsonAsync<TempDrinkList>();
            }

            if (tempDrinkList.Drinks != null)
            {
                tempDrink = tempDrinkList.Drinks.First();
                return ConvertDrink(tempDrink);
            }

            return null;
        }

        public static Drink ConvertDrink(TempDrink tD)
        {
            Drink drink = new Drink();

            if (tD.StrAlcoholic == "Alcoholic")
                drink.Alcoholic = true;
            else
                drink.Alcoholic = false;

            drink.DrinkId = tD.IdDrink;
            drink.Name = tD.StrDrink;
            drink.ImgThumbUrl = tD.StrDrinkThumb;
            drink.Instructions = tD.StrInstructions;

            if (tD.StrIngredient1 == null) return drink;
            drink.AddIngredientAndMeasurement(tD.StrIngredient1, tD.StrMeasure1);
            if (tD.StrIngredient2 == null) return drink;
            drink.AddIngredientAndMeasurement(tD.StrIngredient2, tD.StrMeasure2);
            if (tD.StrIngredient3 == null) return drink;
            drink.AddIngredientAndMeasurement(tD.StrIngredient3, tD.StrMeasure3);
            if (tD.StrIngredient4 == null) return drink;
            drink.AddIngredientAndMeasurement(tD.StrIngredient4, tD.StrMeasure4);
            if (tD.StrIngredient5 == null) return drink;
            drink.AddIngredientAndMeasurement(tD.StrIngredient5, tD.StrMeasure5);
            if (tD.StrIngredient6 == null) return drink;
            drink.AddIngredientAndMeasurement(tD.StrIngredient6, tD.StrMeasure6);
            if (tD.StrIngredient7 == null) return drink;
            drink.AddIngredientAndMeasurement(tD.StrIngredient7, tD.StrMeasure7);
            if (tD.StrIngredient8 == null) return drink;
            drink.AddIngredientAndMeasurement(tD.StrIngredient8, tD.StrMeasure8);
            if (tD.StrIngredient9 == null) return drink;
            drink.AddIngredientAndMeasurement(tD.StrIngredient9, tD.StrMeasure9);
            if (tD.StrIngredient10 == null) return drink;
            drink.AddIngredientAndMeasurement(tD.StrIngredient10, tD.StrMeasure10);
            if (tD.StrIngredient11 == null) return drink;
            drink.AddIngredientAndMeasurement(tD.StrIngredient11, tD.StrMeasure11);
            if (tD.StrIngredient12 == null) return drink;
            drink.AddIngredientAndMeasurement(tD.StrIngredient12, tD.StrMeasure12);
            if (tD.StrIngredient13 == null) return drink;
            drink.AddIngredientAndMeasurement(tD.StrIngredient13, tD.StrMeasure13);
            if (tD.StrIngredient14 == null) return drink;
            drink.AddIngredientAndMeasurement(tD.StrIngredient14, tD.StrMeasure14);
            if (tD.StrIngredient15 == null) return drink;
            drink.AddIngredientAndMeasurement(tD.StrIngredient15, tD.StrMeasure15);

            return drink;
        }
    }
}
