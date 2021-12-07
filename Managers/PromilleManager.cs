using System.Collections.Generic;
using BreathNDrinkAPI.Models;
using System.Linq;

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
        public List<Promille> GetPromillleByDrinker(int drinkerId)
        {
            List<Promille> result = _dbContext.Promille.Where(p=> p.DrinkerId == drinkerId).ToList();
            return result;
        }
    }
}
