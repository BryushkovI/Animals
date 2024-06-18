using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalModel.Abstract
{
    internal interface IModel
    {
        AnimalFactory AnimalFactory { get; }

        IAnimal Animal { get; set; }

        ObservableCollection<IAnimal> Animals { get; set; }

        public IAnimal GetAnimal(string nameing);

        public void RemoveAnimal(string nameing);

        public void ChangeAnimal(string nameing, int legs, int nutrition, double avgLength, double avgWeigth);

        public List<IAnimal> GetAnimals();
    }
}
