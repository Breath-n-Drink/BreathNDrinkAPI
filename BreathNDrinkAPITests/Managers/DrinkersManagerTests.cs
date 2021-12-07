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
    public class DrinkersManagerTests
    {
        DrinkersManager drinkersManager = new DrinkersManager();
        private static BreathndrinkContext _dbContext = new BreathndrinkContext();

        [TestMethod()]
        public void getDrinkersTest()
        {
            int expectedDrinkers = drinkersManager.getDrinkers().Count();
            int realDrinkers = _dbContext.Drinkers.Count();
            Assert.AreEqual(expectedDrinkers, realDrinkers);

        }

        [TestMethod()]
        public void getDrinkerByIdTest()
        {
            Drinkers drinker = drinkersManager.getDrinkerById(1);
            Assert.AreEqual("Mads", drinker.Name);
        }

        [TestMethod()]
        public void getDrinkerByNameTest()
        {
            Drinkers drinker = drinkersManager.getDrinkerByName("Mads");
            Assert.AreEqual(1, drinker.Id);
        }

        [TestMethod()]
        public void updateDrinkerTest()
        {
            Drinkers drinker = drinkersManager.getDrinkerById(4);
            double? promille = drinker.MaxPromille;

            drinkersManager.updateDrinker(4, 4);

            Assert.AreNotEqual(promille, drinkersManager.getDrinkerById(4));

            drinkersManager.updateDrinker(4, 10);
        }

        [TestMethod()]
        public void addDrinkerTest()
        {
            int drinkers = _dbContext.Drinkers.Count();
            drinkersManager.addDrinker("Poul");
            int newDrinkers = _dbContext.Drinkers.Count();
            Assert.AreEqual(drinkers + 1, newDrinkers);

            Drinkers deleteDrinker = _dbContext.Drinkers.First(d => d.Name == "Poul");
            _dbContext.Remove(deleteDrinker);
            _dbContext.SaveChanges();
        }
    }
}