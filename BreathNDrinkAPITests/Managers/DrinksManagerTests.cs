using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BreathNDrinkAPI.Managers;
using BreathNDrinkAPI.Models;
using BreathNDrinkClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BreathNDrinkAPITests.Managers
{
    [TestClass]
    public class DrinksManagerTests
    {
        private static BreathndrinkContext _dbContext = new BreathndrinkContext();

        [TestMethod]
        public void GetByValidIdTest()
        {
            Drink margarita = DrinksManager.Get(id:"11007").First();

            Assert.AreEqual("Margarita", margarita.Name);
        }

        [TestMethod]
        public void GetByInvalidIdTest()
        {
            List<Drink> drinks = DrinksManager.Get(id: "kdjfkdjfk3434");

            Assert.AreEqual(0, drinks.Count);
        }

        [TestMethod]
        public void OverMaxBACTest()
        {
            List<Drink> drinks = DrinksManager.Get(bloodAlcCon: 2.0, bodyWeight: 80);
            
            Assert.AreEqual(0, drinks.FindAll(d => d.Alcoholic).Count);
        }

        [TestMethod]
        public void WayUnderMaxBACTest()
        {
            List<Drink> drinksBefore = DrinksManager.Get();

            List<Drink> drinksAfter = DrinksManager.Get(bloodAlcCon: 0.01, bodyWeight: 80, maxBacRequest: 100.0);

            Assert.AreEqual(drinksBefore.Count, drinksAfter.Count);
        }

        [TestMethod]
        public void IngredientFilterFind1Test()
        {
            string[] ingredients = new[] {"Gin", "Light rum", "Tequila", "Triple sec", "Vodka", "Coca-Cola", "Sweet and sour", "Bitters", "Lemon"};

            List<Drink> drinks = DrinksManager.Get(ingredients: ingredients);

            Assert.AreEqual(1, drinks.Count);
        }

        [TestMethod]
        public void IngredientFilterFindManyTest()
        {
            string[] ingredients = { "Gin" };

            List<Drink> drinks = DrinksManager.Get(ingredients: ingredients);
            
            Assert.IsTrue(drinks.Count > 0);
        }

        [TestMethod]
        public void IngredientFilterFindNoneTest()
        {
            string[] ingredients = { "dlkfjlkdjlfkjdlfjlu83748738479879432" };

            List<Drink> drinks = DrinksManager.Get(ingredients: ingredients);

            Assert.IsTrue(drinks.Count == 0);
        }

        [TestMethod]
        public void AlcoholPctInvalidIntervalTest()
        {
            List<Drink> drinks = DrinksManager.Get(minAlcPer: 80, maxAlcPer: 70);

            Assert.IsTrue(drinks.Count == 0);
        }

        [TestMethod]
        public void AlcoholPctValidIntervalTest()
        {
            List<Drink> drinks = DrinksManager.Get(minAlcPer: 20, maxAlcPer: 40);

            List<Drink> drinksFiltered = drinks.FindAll(d => d.AlcoholPercentage >= 0.2 && d.AlcoholPercentage <= 0.4);

            Assert.AreEqual(drinks.Count, drinksFiltered.Count);
        }
        [TestMethod]
        public void SortDrinksByRatingAscendingTest()
        {
            List<Drink> drinks = DrinksManager.Get(sortByRating: 1);
            double highestRating = drinks.Max(d => d.Rating);
            Assert.AreEqual(drinks[^1].Rating, highestRating);
        }
        [TestMethod]
        public void SortDrinksByRatingDescendingTest()
        {
            List<Drink> drinks = DrinksManager.Get(sortByRating: 2);
            double highestRating = drinks.Max(d => d.Rating);
            Assert.AreEqual(drinks[0].Rating, highestRating);
        }

        [TestMethod]
        public void GetFavoritesTest()
        {
            int drinkList = DrinksManager.GetFavorites(3).Count();
            int realList = _dbContext.FavoriteDrinks.Where(d => d.DrinkerId == 3).Count();
            Assert.AreEqual(drinkList, realList);
        }
    }
}
