using Microsoft.VisualStudio.TestTools.UnitTesting;
using BreathNDrinkAPI.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreathNDrinkAPITests.Managers
{
    [TestClass()]
    public class PromilleManagerTests
    {
        [TestMethod()]
        public void GetPromillleTest()
        {
            PromilleManager _manager = new PromilleManager();
            var result = _manager.GetPromillle();
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void GetPromilleByDrinker()
        {
            PromilleManager _manager = new PromilleManager();
            var result = _manager.GetPromillleByDrinker(1, 1);
            Assert.IsNotNull(result);
        }
    }
}