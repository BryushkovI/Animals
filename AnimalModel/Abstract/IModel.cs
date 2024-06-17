using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalModel.Abstract
{
    internal interface IModel
    {
        AnimalFactory AnimalFactory { get; }

        IAnimal Animal { get; }
    }
}
