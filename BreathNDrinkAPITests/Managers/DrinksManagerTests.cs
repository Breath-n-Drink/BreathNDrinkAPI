using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BreathNDrinkAPI.Managers;
using BreathNDrinkClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BreathNDrinkAPITests.Managers
{
    [TestClass]
    public class DrinksManagerTests
    {
        [TestMethod]
        public void GetByIdTest()
        {
            Drink margarita = DrinksManager.Get(id:"11007").First();

            Assert.AreEqual("Margarita", margarita.Name);
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
        public void IngredientFilterTest()
        {
            string[] ingredients = new[] {"Gin", "Light rum", "Tequila", "Triple sec", "Vodka", "Coca-Cola", "Sweet and sour", "Bitters", "Lemon"};

            List<Drink> drinks = DrinksManager.Get(ingredients: ingredients);

            Assert.AreEqual(1, drinks.Count);
        }
    }
}
