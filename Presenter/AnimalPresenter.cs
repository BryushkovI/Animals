using AnimalModel.Abstract;
using SaverModel.Abstract;
using SaverModel.Writers;
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
using System.Reflection;

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
            this.view.FileSaved += View_FileSaved;
        }

        private void View_FileSaved(object? sender, View.EventsArgs.SaverEventArgs e)
        {
            IWriter writer = new NullWriter();
            switch (e.FileType)
            {
                case "docx":
                    writer = new DocWriter(GetAnimalsAsTable(model.GetAnimals()));
                    break;
                case "xlsx":
                    writer = new XlsxWriter(GetAnimalsAsTable(model.GetAnimals()));
                    break;
                case "pdf":
                    writer = new PdfWriter(GetAnimalsAsTable(model.GetAnimals()));
                    break;
                default:
                    break;
            }
            writer.Write(e.FileName);
        }

        private void View_AnimalCreated(object? sender, View.EventsArgs.AnimalEventArgs e)
        {
            model.ChangeAnimal(e.Nameing,
                               e.Legs,
                               model.Nutritions.Single(n => n.Value == e.Nutrition).Key,
                               e.AvgLenght,
                               e.AvgWeigth,
                               e.Type);
            view.SetAnimals(GetAnimalsList());
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

        

        private string[,] GetAnimalsAsTable(List<IAnimal> animals)
        {
            string[,] result = new string[animals.Count, typeof(IAnimal).GetProperties().Length];

            PropertyInfo[] properties = typeof(IAnimal).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            for (int i = 0; i < animals.Count; i++)
            {
                int j = 0;
                for ( j = 0; j < properties.Length; j++)
                {
                    result[i, j] = properties[j].GetValue(animals[i]).ToString();
                }
                
            }
            return result;
        }
    }
}
