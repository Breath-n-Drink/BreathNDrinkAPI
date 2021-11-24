using Microsoft.VisualStudio.TestTools.UnitTesting;
using BreathNDrinkAPI.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreathNDrinkAPI.Managers.Tests
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
    }
}