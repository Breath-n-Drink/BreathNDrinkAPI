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
        private static HttpClient client = new HttpClient();
        private static string path = "http://www.thecocktaildb.com/api/json/v1/1/";

        public static async Task<Drink> GetDrinkByNameAsync(string name)
        {
            HttpResponseMessage response = await client.GetAsync(path + $"search.php?s={name}");
            Drink receivedDrink = new Drink();
            if (response.IsSuccessStatusCode)
            {
                receivedDrink = await response.Content.ReadFromJsonAsync<Drink>();
            }
            return receivedDrink;
        }

        public static async Task<Drink> GetDrinkByIdAsync(string id)
        {
            HttpResponseMessage response = await client.GetAsync(path + $"lookup.php?i={id}");
            TempDrinkList tempDrinkList = null;
            TempDrink tempDrink = new();
            if (response.IsSuccessStatusCode)
            {
                //tempDrinkList = JsonSerializer.Deserialize<TempDrinkList>(response.Content.ReadAsStringAsync().Result);
                tempDrinkList = await response.Content.ReadFromJsonAsync<TempDrinkList>();
            }

            tempDrink = tempDrinkList.Drinks.First();

            Drink drink = new Drink();
            if (tempDrink.StrAlcoholic == "Alcoholic")
                drink.Alcoholic = true;
            else
                drink.Alcoholic = false;

            drink.DrinkId = tempDrink.IdDrink;
            drink.Name = tempDrink.StrDrink;
            drink.ImgThumbUrl = tempDrink.StrDrinkThumb;
            drink.Instructions = tempDrink.StrInstructions;

            if (tempDrink.StrIngredient1 != null)
            {
                drink.AddIngredientAndMeasurement(tempDrink.StrIngredient1, tempDrink.StrMeasure1);
                if (tempDrink.StrIngredient2 != null)
                {
                    drink.AddIngredientAndMeasurement(tempDrink.StrIngredient2, tempDrink.StrMeasure2);
                    if (tempDrink.StrIngredient3 != null)
                    {
                        drink.AddIngredientAndMeasurement(tempDrink.StrIngredient3, tempDrink.StrMeasure3);
                        if (tempDrink.StrIngredient4 != null)
                        {
                            drink.AddIngredientAndMeasurement(tempDrink.StrIngredient4, tempDrink.StrMeasure4);
                            if (tempDrink.StrIngredient5 != null)
                            {
                                drink.AddIngredientAndMeasurement(tempDrink.StrIngredient5, tempDrink.StrMeasure5);
                                if (tempDrink.StrIngredient6 != null)
                                {
                                    drink.AddIngredientAndMeasurement(tempDrink.StrIngredient6, tempDrink.StrMeasure6);
                                    if (tempDrink.StrIngredient7 != null)
                                    {
                                        drink.AddIngredientAndMeasurement(tempDrink.StrIngredient7,
                                            tempDrink.StrMeasure7);
                                        if (tempDrink.StrIngredient8 != null)
                                        {
                                            drink.AddIngredientAndMeasurement(tempDrink.StrIngredient8,
                                                tempDrink.StrMeasure8);
                                            if (tempDrink.StrIngredient9 != null)
                                            {
                                                drink.AddIngredientAndMeasurement(tempDrink.StrIngredient9,
                                                    tempDrink.StrMeasure9);
                                                if (tempDrink.StrIngredient10 != null)
                                                {
                                                    drink.AddIngredientAndMeasurement(tempDrink.StrIngredient10,
                                                        tempDrink.StrMeasure10);
                                                    if (tempDrink.StrIngredient11 != null)
                                                    {
                                                        drink.AddIngredientAndMeasurement(tempDrink.StrIngredient11,
                                                            tempDrink.StrMeasure11);
                                                        if (tempDrink.StrIngredient12 != null)
                                                        {
                                                            drink.AddIngredientAndMeasurement(tempDrink.StrIngredient12,
                                                                tempDrink.StrMeasure12);
                                                            if (tempDrink.StrIngredient13 != null)
                                                            {
                                                                drink.AddIngredientAndMeasurement(
                                                                    tempDrink.StrIngredient13,
                                                                    tempDrink.StrMeasure13);
                                                                if (tempDrink.StrIngredient14 != null)
                                                                {
                                                                    drink.AddIngredientAndMeasurement(
                                                                        tempDrink.StrIngredient14,
                                                                        tempDrink.StrMeasure14);
                                                                    if (tempDrink.StrIngredient15 != null)
                                                                    {
                                                                        drink.AddIngredientAndMeasurement(
                                                                            tempDrink.StrIngredient15,
                                                                            tempDrink.StrMeasure15);
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return drink;
        }
    }
}
