﻿using AnimalModel.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalModel
{
    internal class Model : IModel
    {
        public AnimalFactory AnimalFactory { get; set; }

        public IAnimal Animal { get; set; }

        public ObservableCollection<IAnimal> Animals { get; set; }

        Context context;

        public Model()
        {
            AnimalFactory = new AnimalFactory();
            context = new Context();
            Animals = new ObservableCollection<IAnimal>(context.Animals.ToList());
        }

        public IAnimal GetAnimal(string nameing)
        {
            return context.Animals.Single(a => a.Nameing == nameing);
        }

        public void RemoveAnimal(string nameing)
        {
            context.Animals.Remove(context.Animals.Single(a => a.Nameing == nameing));
            context.SaveChanges();
        }

        public void ChangeAnimal(string nameing, int legs, int nutrition, double avgLength, double avgWeigth)
        {
            var animal = context.Animals.Single(a => a.Nameing == nameing);
            animal.Legs = legs;
            animal.AvgLenght = avgLength;
            animal.AvgWeigth = avgWeigth;
            animal.Nutrition = (IAnimal.EnumNutrition)nutrition;

            context.Animals.Update(animal);
            context.SaveChanges();
        }

        public List<IAnimal> GetAnimals()
        {
            return [.. context.Animals];
        }
    }
}
