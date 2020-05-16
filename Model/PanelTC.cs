using miniTC.ViewModel.BaseClass;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace miniTC.Model
{
    class PanelTC : ViewModelBase
    {
        private string _currentPath = "";
        private ObservableCollection<string> _filesList = new ObservableCollection<string>();
        private string[] _drivesList;

        public string CurrentPath
        {
            get => _currentPath;
            set
            {
                _currentPath = value;
                onPropertyChanged(nameof(CurrentPath));
            }
        }

        public ObservableCollection<string> FilesList
        {
            get => _filesList;
            set
            {
                _filesList = value;
                onPropertyChanged(nameof(FilesList));
            }
        }

        public string[] DrivesList
        {
            get => _drivesList;
            set
            {
                _drivesList = value;
                onPropertyChanged(nameof(DrivesList));
            }
        }
    }
}
