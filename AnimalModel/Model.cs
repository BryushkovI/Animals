using AnimalModel.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalModel
{
    internal class Model : IModel
    {
        public AnimalFactory AnimalFactory { get; set; }

        public IAnimal Animal { get; set; }

        Context context;

        public Model()
        {
            AnimalFactory = new AnimalFactory();
            context = new Context();
        }
    }
}
