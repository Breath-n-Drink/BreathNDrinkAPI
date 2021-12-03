using BreathNDrinkAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreathNDrinkAPI.Managers
{

    public class DrinkersManager
    {

        private BreathndrinkContext _dbContext = new BreathndrinkContext();

        public List<Drinkers> getDrinkers()
        {
            List<Drinkers> drinkers = _dbContext.Drinkers.ToList();
            return drinkers;
        }

        public Drinkers getDrinkerById(int id)
        {
            Drinkers drinker = getDrinkers().FirstOrDefault(d => d.Id == id);
            return drinker;
        }

        public Drinkers getDrinkerByName(string name)
        {
            Drinkers drinker = getDrinkers().FirstOrDefault(d => d.Name == name);
            return drinker;
        }

        public void updateDrinker(int id, double maxPro)
        {
            Drinkers drinker = getDrinkerById(id);
            drinker.MaxPromille = maxPro;
            _dbContext.Drinkers.Update(drinker);
            _dbContext.SaveChanges();
        }

        public void addDrinker(string name)
        {
            var result = _dbContext.Drinkers.FirstOrDefault(r => r.Name== name);
            if (result == null)
            {
                Drinkers newDrinker = new Drinkers();
                newDrinker.Name = name;
                newDrinker.MaxPromille = 2;
                _dbContext.Drinkers.Add(newDrinker);
                _dbContext.SaveChanges();
            }
            
        }
    }

}
