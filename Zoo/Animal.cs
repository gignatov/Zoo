using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public abstract class Animal
    {
        public Health health = new Health();
        private bool canWalk = true;
        public static void FeedAnimal(List<Animal> list)
        {
            Random rd = new Random();
            list.Sort((x, y) => x.health.GetHealth().CompareTo(y.health.GetHealth()));            
            int count = list.Count();
            int numberToFeed = (int)Math.Floor((float)count * 85 / 100);
            for (int i = 0; i < numberToFeed; i++)
            {
                list[i].health.Feed(rd.Next(5,25));
                if (list[i] is Elephant && list[i].health.GetHealth() >= 70)
                    list[i].canWalk = true;
            }
        }
        public static void AnimalIsHungry(List<Animal> list)
        {
            Random rd = new Random();
            int monkeyDecrease = rd.Next(0, 20);
            int giraffeDecrease = rd.Next(0, 20);
            int elephantDecrease = rd.Next(0, 20);
            foreach (Animal an in list)
            {
                if (an is Monkey)
                    an.health.IsHungry(monkeyDecrease);
                if (an is Giraffe)
                    an.health.IsHungry(giraffeDecrease);
                if (an is Elephant)
                    an.health.IsHungry(elephantDecrease);          
            }
            CheckIfAnimalDies(list);
        }
        private static void CheckIfAnimalDies(List<Animal> list)
        {
            foreach (Animal an in list.Reverse<Animal>())
            {
                if (an is Monkey && an.health.GetHealth() < 30)
                    list.Remove(an);
                if (an is Giraffe && an.health.GetHealth() < 50)
                    list.Remove(an);
                if (an is Elephant && !an.canWalk)
                    list.Remove(an);
                if (an is Elephant && an.health.GetHealth() < 70)
                    an.canWalk = false;
            }
        }
    }
}
