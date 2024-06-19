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
            this.view.Nutritions = this.model.Nutritions;
            this.view.Types = this.model.Types;
            this.view.SetAnimals(GetAnimalsList());
            this.view.AnimalSelected += View_AnimalSelected;
            this.view.AnimalUpdated += View_AnimalUpdated;
            this.view.AnimalRemoved += View_AnimalRemoved;
            this.view.AnimalCreated += View_AnimalCreated;
        }

        private void View_AnimalCreated(object? sender, View.EventsArgs.AnimalEventArgs e)
        {
            model.ChangeAnimal(e.Nameing,
                               e.Legs,
                               model.Nutritions.Single(n => n.Value == e.Nutrition).Key,
                               e.AvgLenght,
                               e.AvgWeigth,
                               e.Type);
        }

        private void View_AnimalRemoved(object? sender, View.EventsArgs.AnimalEventArgs e)
        {
            model.RemoveAnimal(e.Nameing);
            view.SetAnimals(GetAnimalsList());
        }

        private void View_AnimalUpdated(object? sender, View.EventsArgs.AnimalEventArgs e)
        {

            model.ChangeAnimal(e.Nameing,
                               e.Legs, 
                               model.Nutritions.Single(n => n.Value == e.Nutrition).Key, 
                               e.AvgLenght, 
                               e.AvgWeigth);
        }

        private void View_AnimalSelected(object? sender, View.EventsArgs.AnimalEventArgs e)
        {
            model.Animal = model.GetAnimal(e.Nameing);
            view.SetAnimalDetails(model.Animal.Nameing,
                                  model.Animal.Legs,
                                  model.Nutritions.Single(n => n.Key == (int)model.Animal.Nutrition).Value,
                                  model.Animal.AvgLenght,
                                  model.Animal.AvgWeigth);
        }

        private ObservableCollection<string> GetAnimalsList()
        {
            ObservableCollection<string> animals = [];
            foreach (var item in model.GetAnimals())
            {
                animals.Add(item.Nameing);
            }
            return animals;
        }
    }
}
