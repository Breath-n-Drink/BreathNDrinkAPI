using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BreathNDrinkAPI.Retrievers;
using BreathNDrinkClassLibrary;

namespace BreathNDrinkAPI.Managers
{
    public static class DrinksManager
    {
        private static List<Drink> _drinksList = new();

        public static Drink AddDrink(Drink drink)
        {
            _drinksList.Add(drink);
            return drink;
        }

        public static Drink RemoveDrink(string drinkId)
        {
            Drink d = _drinksList.Find(D => D.DrinkId == drinkId);
            _drinksList.Remove(_drinksList.Find(d => d.DrinkId == drinkId));
            return d;
        }

        public static List<Drink> GetAllDrinks()
        {
            return new List<Drink>(_drinksList);
        }

        public static List<Drink> Get(string id = null, string name = null)
        {
            List<Drink> drinksList = new();

            if (id != null)
            {
                drinksList.Add(DrinksRetriever.GetDrinkByIdAsync(id).Result);
                return drinksList;
            }

            if (name != null)
                drinksList = DrinksRetriever.GetDrinksByNameAsync(name).Result;

            return drinksList;
        }
    }
}
