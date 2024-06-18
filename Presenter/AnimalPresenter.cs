using AnimalModel.Abstract;
using Animals.View.Abstract;
using Animals.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Runtime.CompilerServices;
using Microsoft.IdentityModel.Abstractions;
using System.Collections.ObjectModel;

namespace Animals.Presenter
{
    internal class AnimalPresenter
    {
        private IModel model ;
        private IMainWindowView view;
        public AnimalPresenter(IModel model, IMainWindowView view)
        {
            this.model = model;
            this.view = view;
            ObservableCollection<string> animals = new ObservableCollection<string>();
            foreach (var item in model.Animals)
            {
                animals.Add(item.Nameing);
            }
            this.view.SetAnimals(animals);
            this.view.AnimalSelected += View_AnimalSelected;
            this.view.AnimalUpdated += View_AnimalUpdated;
            this.view.AnimalRemoved += View_AnimalRemoved;
        }

        private void View_AnimalRemoved(object? sender, View.EventsArgs.AnimalEventArgs e)
        {
            model.RemoveAnimal(e.Nameing);
        }

        private void View_AnimalUpdated(object? sender, View.EventsArgs.AnimalEventArgs e)
        {
            model.ChangeAnimal(e.Nameing, e.Legs, e.Nutrition, e.AvgLenght, e.AvgWeigth);
        }

        private void View_AnimalSelected(object? sender, View.EventsArgs.AnimalEventArgs e)
        {
            model.Animal = model.GetAnimal(e.Nameing);
            view.SetAnimalDetails(model.Animal.Nameing,
                                  model.Animal.Legs,
                                  (int)model.Animal.Nutrition,
                                  model.Animal.AvgLenght,
                                  model.Animal.AvgWeigth);
        }
    }
}
