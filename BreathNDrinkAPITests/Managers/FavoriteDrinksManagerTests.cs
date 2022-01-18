using Microsoft.VisualStudio.TestTools.UnitTesting;
using BreathNDrinkAPI.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreathNDrinkAPI.Models;

namespace BreathNDrinkAPI.Managers.Tests
{
    [TestClass()]
    public class FavoriteDrinksManagerTests
    {
        private static BreathndrinkContext _dbContext = new BreathndrinkContext();

        [TestMethod()]
        public void AddFavoriteTest()
        {
            FavoriteDrinks newDrink = new FavoriteDrinks();
            newDrink.DrinkId = 111111;
            newDrink.DrinkerId = 3;

            int favorites = _dbContext.FavoriteDrinks.Count();
            FavoriteDrinksManager.AddFavorite(newDrink.DrinkId, newDrink.DrinkerId);
            int newFavorites = _dbContext.FavoriteDrinks.Count();
            Assert.AreEqual(favorites + 1, newFavorites);

            FavoriteDrinksManager.DeleteFavorite(newDrink.DrinkId, newDrink.DrinkerId);
        }

        [TestMethod()]
        public void DeleteFavoriteTest()
        {
            FavoriteDrinks newDrink = new FavoriteDrinks();
            newDrink.DrinkId = 111111;
            newDrink.DrinkerId = 3;
            FavoriteDrinksManager.AddFavorite(newDrink.DrinkId, newDrink.DrinkerId);

            List<FavoriteDrinks> list = _dbContext.FavoriteDrinks.ToList();
            int favorites = list.Count();
            FavoriteDrinks lastDrink = list.Last();
            FavoriteDrinksManager.DeleteFavorite(lastDrink.DrinkId, lastDrink.DrinkerId);
            int newFavorites = _dbContext.FavoriteDrinks.Count();
            Assert.AreEqual(favorites - 1, newFavorites);
        }
    }
}