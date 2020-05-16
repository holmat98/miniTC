using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniTC.Model
{
    class PathToFile
    {
        private string _currentPath;
        public string CurrentPath
        {
            get => _currentPath;
            set
            {
                _currentPath = value;
            }
        }

        public PathToFile() { }

        public PathToFile(string currentPath)
        {
            _currentPath = currentPath;
        }

        public override string ToString()
        {
            return String.Format("<D>"+_currentPath.Substring(_currentPath.LastIndexOf(@"\")+1));
        }
    }
}
