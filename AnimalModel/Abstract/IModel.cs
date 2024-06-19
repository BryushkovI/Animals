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

        Dictionary<int, string> Nutritions
        {
            get
            {
                return new Dictionary<int, string>()
                {
                    {0, "herbaceous" },
                    {1, "carnivore" },
                    {2, "omnivorous" }
                };
            }
        }

        Dictionary<int, string> Types
        {
            get
            {
                return new Dictionary<int, string>()
                {
                    {0, "mammal" },
                    {1, "amphibia" },
                    {2, "bird" }
                };
            }
        }

        public void RemoveAnimal(string nameing);

        public void ChangeAnimal(string nameing, int legs, int nutrition, double avgLength, double avgWeigth, int type = -1);

        public void AddAnimal(string nameing, int legs, int nutrition, double avgLength, double avgWeigth);

        public List<IAnimal> GetAnimals();
    }
}
