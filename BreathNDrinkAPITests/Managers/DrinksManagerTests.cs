using System;
using System.Collections.Generic;
using System.Linq;
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
            Drink Margarita = DrinksManager.Get(id:"11007").First();

            Assert.AreEqual("Margarita", Margarita.Name);
        }

        [TestMethod]
        public void OverMaxPromilleTest()
        {
            int DrinksCount = DrinksManager.Get(bloodAlcCon:2.0, bodyWeight:80).Count;

            Assert.AreEqual(0, DrinksCount);
        }
    }
}
