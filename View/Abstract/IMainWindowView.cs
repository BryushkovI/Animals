using Animals.View.EventsArgs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals.View.Abstract
{
    interface IMainWindowView : IView
    {
        void SetAnimalDetails(string nameing, int legs, string nutrition, double avgLength, double avgWeigth);

        void SetAnimals(ObservableCollection<string> animals);

        event EventHandler<AnimalEventArgs> AnimalSelected;

        event EventHandler<AnimalEventArgs> AnimalUpdated;

        event EventHandler<AnimalEventArgs> AnimalRemoved;

        event EventHandler<AnimalEventArgs> AnimalCreated;

        event EventHandler<SaverEventArgs> FileSaved;

        Dictionary<int, string> Nutritions { get; set; }

        Dictionary<int, string> Types { get; set; }
    }
}
