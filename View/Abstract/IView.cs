using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Animals.View.Abstract
{
    internal interface IView
    {
        void Close();
    }
}
