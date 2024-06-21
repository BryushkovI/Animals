using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals.View.EventsArgs
{
    public class SaverEventArgs : EventArgs
    {
        public string FileName { get; set; }
        public string FileType { get; set; }
        public SaverEventArgs(string fileName, string fileType)
        {
            FileName = fileName;
            FileType = fileType;
        }
    }
}
