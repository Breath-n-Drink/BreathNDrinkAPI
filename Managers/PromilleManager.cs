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
    }
}
