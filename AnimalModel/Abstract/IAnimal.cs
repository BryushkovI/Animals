using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalModel.Abstract
{
    public interface IAnimal
    {
        string Nameing { get; }
        int Legs { get; }

        enum EnumNutrition
        {
            herbaceous,
            carnivore,
            omnivorous
        }

        EnumNutrition Nutrition { get; }

        double AvgLenght { get; }

        double AvgWeigth { get; }
    }
}
