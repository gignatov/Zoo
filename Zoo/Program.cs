using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public class Program
    {
        public static int GetNumberOfAnimals(List<Animal> list)
        {
            return list.Count();
        }
        public static List<Animal> GetLowestHealthAnimals(List<Animal> list)
        {
            List<Animal> result = new List<Animal>();
            list.Sort((x, y) => x.health.GetHealth().CompareTo(y.health.GetHealth()));
            foreach (Animal an in list)
            {
                if (an is Monkey && !result.OfType<Monkey>().Any())
                    result.Add(an);
                if (an is Giraffe && !result.OfType<Giraffe>().Any())
                    result.Add(an);
                if (an is Elephant && !result.OfType<Elephant>().Any())
                    result.Add(an);
                if (result.Count() == 3)
                    return result;
            }
            return result;
        }
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            for (int i = 0; i < 5; i++)
            {
                animals.Add(new Monkey());
                animals.Add(new Giraffe());
                animals.Add(new Elephant());
            }
            animals.Sort((x, y) => string.Compare(x.GetType().Name, y.GetType().Name));

            //Following code shows all the methods in use.

            Console.WriteLine("Animals with starting health:");
            Console.WriteLine();
            foreach (Animal an in animals)
            {
                Console.WriteLine(an.GetType().Name + " - " + an.health.GetHealth() + " HP");
            }
            Console.WriteLine();
            Console.WriteLine("-------------------------");
            Console.WriteLine();
            Console.WriteLine("Animals after getting hungry:");
            Console.WriteLine();
            Animal.AnimalIsHungry(animals);
            foreach (Animal an in animals)
            {
                Console.WriteLine(an.GetType().Name + " - " + an.health.GetHealth() + " HP");
            }
            Console.WriteLine();
            Console.WriteLine("-------------------------");
            Console.WriteLine();
            Console.WriteLine("Animals after being fed:");
            Console.WriteLine();
            Animal.FeedAnimal(animals);
            foreach (Animal an in animals)
            {
                Console.WriteLine(an.GetType().Name + " - " + an.health.GetHealth() + " HP");
            }
            Console.WriteLine();
            Console.WriteLine("-------------------------");
            Console.WriteLine();
            Console.WriteLine("Number of animals: " + GetNumberOfAnimals(animals));
            Console.WriteLine();
            Console.WriteLine("-------------------------");
            Console.WriteLine();
            Console.WriteLine("Lowest health animal of each species: ");
            Console.WriteLine();
            List<Animal> lowestHealth = GetLowestHealthAnimals(animals);
            foreach (Animal an in lowestHealth)
            {
                Console.WriteLine(an.GetType().Name + " - " + an.health.GetHealth() + " HP");
            }
            Console.WriteLine();
            Console.WriteLine("-------------------------");
        }
    }
}
