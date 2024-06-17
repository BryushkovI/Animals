using AnimalModel.Abstract;
using Animals.View.Abstract;
using Animals.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
        }

    }
}
