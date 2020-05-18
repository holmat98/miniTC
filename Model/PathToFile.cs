using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace miniTC.Model
{
    public class PathToFile
    {
        private string _currentPath;
        private short _code;
        public string CurrentPath
        {
            get => _currentPath;
            set
            {
                _currentPath = value;
            }
        }

        public PathToFile() { }

        public PathToFile(string currentPath, short code)
        {
            _currentPath = currentPath;
            _code = code;
        }

        public override string ToString()
        {
            if (_code == 0)
                return "<D>" + _currentPath.Substring(_currentPath.LastIndexOf(@"\") + 1);
            else
                return "...";
        }
    }
}
