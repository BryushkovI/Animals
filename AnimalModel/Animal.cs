using AnimalModel.Abstract;
namespace AnimalModel
{
    public enum AnimalType
    {
        mammal,
        amphibia,
        bird
    }
    

    public class Mammal(string nameing, int legs, IAnimal.EnumNutrition nutrition, double length, double weigth) : IAnimal
    {
        public string Nameing { get; } = nameing;
        public int Legs { get; } = legs;

        public IAnimal.EnumNutrition Nutrition { get; } = nutrition;

        public double AvgLenght { get; } = length;

        public double AvgWeigth { get; } = weigth;
    }

    public class Amphibia(string nameing, int legs, IAnimal.EnumNutrition nutrition, double length, double weigth) : IAnimal
    {
        public string Nameing { get; } = nameing;
        public int Legs { get; } = legs;

        public IAnimal.EnumNutrition Nutrition { get; } = nutrition;

        public double AvgLenght { get; } = length;

        public double AvgWeigth { get; } = weigth;
    }

    internal class Bird(string nameing, int legs, IAnimal.EnumNutrition nutrition, double length, double weigth) : IAnimal
    {
        public string Nameing { get; } = nameing;
        public int Legs { get; } = legs;

        public IAnimal.EnumNutrition Nutrition { get; } = nutrition;

        public double AvgLenght { get; } = length;

        public double AvgWeigth { get; } = weigth;
    }

    public class NullAnimal : IAnimal
    {
        public string Nameing { get; } = "Ошибка природы";
        public int Legs { get { return 0; } }

        public IAnimal.EnumNutrition Nutrition { get { return 0; } }

        public double AvgLenght { get { return 0; } }

        public double AvgWeigth { get { return 0; } }
    }

    public class BaseAnimal : IAnimal
    {
        public string Nameing { get; set; }

        public int Legs { get; set; }

        public IAnimal.EnumNutrition Nutrition { get; set; }

        public double AvgLenght { get; set; }

        public double AvgWeigth { get; set; }
    }
}
