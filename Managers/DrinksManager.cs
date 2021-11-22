using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BreathNDrinkClassLibrary;

namespace BreathNDrinkAPI.Managers
{
    public static class DrinksManager
    {
        private static List<Drink> _drinksList = new();

        public static void AddDrink(Drink drink)
        {
            _drinksList.Add(drink);
        }

        public static void RemoveDrink(string drinkId)
        {
            _drinksList.Remove(_drinksList.Find(d => d.DrinkId.Equals(drinkId)));
        }

        public static List<Drink> GetAllDrinks()
        {
            return new List<Drink>(_drinksList);
        }

        public static Drink FindById(string id)
        {
            return _drinksList.Find(drink => drink.DrinkId == id);
        }

        
    }
}
