using AnimalModel.Abstract;

namespace AnimalModel
{
    public enum AnimalType
    {
        mammal,
        amphibia,
        bird
    }

    public class Mammal(string nameing, int legs, IAnimal.EnumNutrition nutrition, double length, double weigth) : BaseAnimal(nameing, legs, nutrition, length, weigth)
    {
    }

    public class Amphibia(string nameing, int legs, IAnimal.EnumNutrition nutrition, double length, double weigth) : BaseAnimal(nameing, legs, nutrition, length, weigth)
    {
    }

    internal class Bird(string nameing, int legs, IAnimal.EnumNutrition nutrition, double length, double weigth) : BaseAnimal(nameing, legs, nutrition, length, weigth)
    {
    }

    public class NullAnimal(string nameing, int legs, IAnimal.EnumNutrition nutrition, double length, double weigth) : BaseAnimal(nameing, legs, nutrition, length, weigth)
    {
        public override string Nameing { get => "Ошибка природы"; set => base.Nameing = "Ошибка природы"; }
        public override int Legs { get => 0; set => base.Legs = 0; }

        public IAnimal.EnumNutrition Nutrition { get { return 0; } }

        public override double AvgLenght { get => 0; set => base.AvgLenght = 0; }

        public override double AvgWeigth { get => 0; set => base.AvgWeigth = 0; }
    }

    public class BaseAnimal : IAnimal
    {
        public BaseAnimal()
        {
            
        }
        public BaseAnimal(string nameing, int legs, IAnimal.EnumNutrition nutrition, double length, double weigth)
        {
            Nameing = nameing;
            Legs = legs;
            Nutrition = nutrition;
            AvgLenght = length;
            AvgWeigth = weigth;
        }
        public virtual string Nameing { get; set; }

        public virtual int Legs { get; set; }

        public IAnimal.EnumNutrition Nutrition { get; set; }

        public virtual double AvgLenght { get; set; }

        public virtual double AvgWeigth { get; set; }
    }
}
