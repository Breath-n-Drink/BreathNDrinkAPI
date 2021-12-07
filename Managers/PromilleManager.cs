using System.Collections.Generic;
using BreathNDrinkAPI.Models;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

namespace BreathNDrinkAPI.Managers
{
    public class PromilleManager
    {
        private BreathndrinkContext _dbContext = new BreathndrinkContext();

        public double GetPromillle()
        {
            Promille result = _dbContext.Promille.ToList()[^1];
            return result.Promille1;
        }
        public List<Promille> GetPromillleByDrinker(int drinkerId, int page)
        {
            List<Promille> result = _dbContext.Promille.Where(p=> p.DrinkerId == drinkerId).ToList();
            result.Reverse();
            var startIndex = 0;
            var count = 10;
            if (page != 1)
            {
                startIndex = page * 10 - 10;
            }

            if ((result.Count - startIndex) < 10)
            {
                count = result.Count - startIndex;
            }
            

            return result.GetRange(startIndex, count);
        }
    }
}
