using AnimalModel.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalModel
{
    public class AnimalFactory
    {
        public static IAnimal CreateAnimal(string nameing, AnimalType type, int legs, IAnimal.EnumNutrition nutrition, double length, double weigth)
        {
            return type switch
            {
                AnimalType.mammal => new Mammal(nameing, legs, nutrition, length, weigth),
                AnimalType.amphibia => new Amphibia(nameing, legs, nutrition, length, weigth),
                AnimalType.bird => new Bird(nameing, legs, nutrition, length, weigth),
                _ => new NullAnimal(nameing, legs, nutrition, length, weigth),
            };
        }


    }
}
