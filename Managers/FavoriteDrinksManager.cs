using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BreathNDrinkAPI.Models;

namespace BreathNDrinkAPI.Managers
{
    public class FavoriteDrinksManager
    {
        private static BreathndrinkContext _dbContext = new BreathndrinkContext();

        public static void AddFavorite(int drinkId, int drinkerId)
        {
            if (_dbContext.FavoriteDrinks.Where(d => d.DrinkId == drinkId && d.DrinkerId == drinkerId).ToList().Count==0)
            {
                FavoriteDrinks newFavorite = new FavoriteDrinks();
                newFavorite.DrinkId = drinkId;
                newFavorite.DrinkerId = drinkerId;

                _dbContext.Add(newFavorite);
                _dbContext.SaveChanges();
            }
                
        }

        public static void DeleteFavorite(int drinkId, int drinkerId)
        {
            FavoriteDrinks drinkToDelete =
                _dbContext.FavoriteDrinks.Where(d => d.DrinkId == drinkId && d.DrinkerId == drinkerId).ToList()[0];
            _dbContext.FavoriteDrinks.Remove(drinkToDelete);
            _dbContext.SaveChanges();
        }
    }
}
