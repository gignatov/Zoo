using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public class Health
    {
        private static int maxHealthPoints = 100;
        private static int minHealthPoints = 0;
        private int currentHealthPoints = maxHealthPoints;
        public int GetHealth()
        {
            return currentHealthPoints;
        }
        private void ValidateHealth()
        {
            if (currentHealthPoints > maxHealthPoints)
                currentHealthPoints = maxHealthPoints;
            if (currentHealthPoints < minHealthPoints)
                currentHealthPoints = minHealthPoints;
        }
        public void Feed(int food)
        {
            currentHealthPoints += food;
            ValidateHealth();
        }
        public void IsHungry(int hunger)
        {
            currentHealthPoints -= hunger;
            ValidateHealth();
        }
    }
}
