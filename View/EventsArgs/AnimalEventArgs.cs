  using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AnimalModel.Abstract.IAnimal;

namespace Animals.View.EventsArgs
{
    public class AnimalEventArgs : EventArgs
    {
        public string Nameing { get; }
        public int Legs { get; }
        public int Nutrition { get; }

        public double AvgLenght { get; }

        public double AvgWeigth { get; }
        public AnimalEventArgs(string nameing)
        {
            Nameing= nameing;
        }
        public AnimalEventArgs(string nameing, int legs, int nutrition, double avgLength, double avgWeigth)
        {
            Nameing = nameing;
            Legs= legs;
            Nutrition= nutrition;
            AvgLenght= avgLength;
            AvgWeigth= avgWeigth;
        }
    }
}
