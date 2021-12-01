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
        //public static Drink AddDrink(Drink drink)
        //{
        //    _drinksList.Add(drink);
        //    return drink;
        //}

        //public static Drink RemoveDrink(string drinkId)
        //{
        //    Drink d = _drinksList.Find(D => D.DrinkId == drinkId);
        //    _drinksList.Remove(_drinksList.Find(d => d.DrinkId == drinkId));
        //    return d;
        //}
        
        public static List<Drink> Get(string id = null, string name = null, double bodyWeight = 0.0, double bloodAlcCon = 0.0, double maxBacRequest = 1.5, int gender = 0, string[] ingredients = null, string[] notFilter = null, double minAlcPer = 0, double maxAlcPer = 100)
        {
            List<Drink> drinksList = new();

            if (id != null)
            {
                Drink newDrink = DrinksRetriever.GetDrinkByIdAsync(id).Result;
                if (newDrink != null)
                    drinksList.Add(newDrink);
                drinksList = drinksList.FindAll(d => d.TotalVolume > 0.0 && d.AlcoholPercentage >= 0.0);
                return drinksList;
            }

            drinksList = DrinksRetriever.GetDrinksByNameAsync(name).Result;
            drinksList = drinksList.FindAll(d => d.TotalVolume > 0.0 && d.AlcoholPercentage >= 0.0);

            if (bodyWeight > 0.0 && bloodAlcCon >= 0.0 && maxBacRequest >= 0.0)
            {
                double bwRatio;
                switch (gender)
                {
                    case 1:
                        bwRatio = 0.68;
                        break;
                    case 2:
                        bwRatio = 0.55;
                        break;
                    default:
                        bwRatio = 0.6;
                        break;
                }

                drinksList = drinksList.FindAll(d => ((d.TotalAlcVolume * 0.78945) <= (maxBacRequest-bloodAlcCon) * (bwRatio * bodyWeight)) || !d.Alcoholic);
            }

            if (ingredients != null)
            {
                foreach (var item in ingredients)
                {
                    drinksList = drinksList.FindAll(d => (d.IngredientList.Any(i => (i.ToLower().IndexOf(item.ToLower()) > 0) || i.ToLower().Contains(item.ToLower()))));
                }
            }

            if (notFilter != null)
            {
                foreach (var item in notFilter)
                {

                    drinksList = drinksList.FindAll(d => !d.IngredientList.Any((i => (i.ToLower().IndexOf(item.ToLower()) > 0) || i.ToLower().Contains(item.ToLower()))));
                }
            }

            drinksList = drinksList.FindAll(d => ((d.AlcoholPercentage * 100) > minAlcPer) && ((d.AlcoholPercentage * 100) < maxAlcPer));

            return drinksList;
        }
    }
}
