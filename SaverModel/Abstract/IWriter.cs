using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaverModel.Abstract
{
    public interface IWriter
    {
        public string Extension { get; }

        public string FileName { get; set; }

        string[,] Table { get; set; }

        public void Write(string name);
    }

}
