using AnimalModel.Abstract;
using Animals.View.Abstract;
using Animals.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals.Presenter
{
    internal class AnimalPresenter
    {
        private IAnimal animal;
        private IMainWindowView view;
        public AnimalPresenter(IAnimal animal, IMainWindowView view)
        {
            this.animal = animal;
            this.view = view;
        }

    }
}
