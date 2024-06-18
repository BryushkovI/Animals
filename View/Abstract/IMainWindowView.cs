﻿using Animals.View.EventsArgs;
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
        void SetAnimalDetails(string nameing, int legs, int nutrition, double avgLength, double avgWeigth);

        void SetAnimals(ObservableCollection<string> animals);

        event EventHandler<AnimalEventArgs> AnimalSelected;

        event EventHandler<AnimalEventArgs> AnimalUpdated;

        event EventHandler<AnimalEventArgs> AnimalRemoved;
    }
}
