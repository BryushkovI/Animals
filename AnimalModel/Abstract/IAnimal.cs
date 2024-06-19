using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalModel.Abstract
{
    public interface IAnimal
    {
        string Nameing { get; set; }
        int Legs { get; set; }

        enum EnumNutrition
        {
            herbaceous,
            carnivore,
            omnivorous
        }

        EnumNutrition Nutrition { get; set; }

        double AvgLenght { get; set; }

        double AvgWeigth { get; set; }
    }
}
