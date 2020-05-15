using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace miniTC.Model
{
    class PanelTC
    {
        private string _currentPath;
        private string[] _drivesList;
        private string[] _pathList;

        public string CurrentPath
        {
            get => _currentPath;
            set
            {
                _currentPath = value;
            }
        }

        public string[] DriveList
        {
            get => _drivesList;
            set
            {
                _drivesList = value;
            }
        }

        public string[] PathList
        {
            get => _pathList;
            set
            {
                _pathList = value;
            }
        }
    }
}
