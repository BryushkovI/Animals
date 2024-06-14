﻿using System;
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
    }
}
