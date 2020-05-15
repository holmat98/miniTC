using miniTC.ViewModel.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Input;
using System.Collections.ObjectModel;
using miniTC.Model;

namespace miniTC.ViewModel
{
    class MainViewModel : ViewModelBase
    {
        private string[] _leftdrivesList;

        public string[] LeftDrivesList
        {
            get => _leftdrivesList;
            set
            {
                _leftdrivesList = value;
                onPropertyChanged(nameof(LeftDrivesList));
            }
        }

        private string[] _rightdrivesList;

        public string[] RightDrivesList
        {
            get => _rightdrivesList;
            set
            {
                _rightdrivesList = value;
                onPropertyChanged(nameof(RightDrivesList));
            }
        }

        private string _pathFromLList;
        public string PathFromLList
        {
            get => _pathFromLList;
            set
            {
                _pathFromLList = value;
                onPropertyChanged(nameof(PathFromLList));
            }
        }

        private string _currentPath;
        public string CurrentPath
        {
            get => _currentPath;
            set
            {
                _currentPath = value;
                onPropertyChanged(nameof(CurrentPath));
            }
        }

        private List<string> _leftPathList;
        public List<string> LeftPathList
        {
            get => _leftPathList;
            set
            {
                _leftPathList = value;
                onPropertyChanged(nameof(LeftPathList));
            }
        }


        private ICommand _getRightDrivesList = null;
        public ICommand GetRightDrivesList
        {
            get
            {
                if (_getRightDrivesList == null)
                {
                    _getRightDrivesList = new RelayCommand(
                        arg => {
                            RightDrivesList = new string[Environment.GetLogicalDrives().Length];
                            RightDrivesList = Environment.GetLogicalDrives(); },
                        arg => true
                        );
                }
                return _getRightDrivesList;
            }
        }

        private ICommand _getLeftDrivesList = null;
        public ICommand GetLeftDrivesList
        {
            get
            {
                if (_getLeftDrivesList == null)
                {
                    _getLeftDrivesList = new RelayCommand(
                        arg => {
                            LeftDrivesList = new string[Environment.GetLogicalDrives().Length];
                            LeftDrivesList = Environment.GetLogicalDrives(); },
                        arg => true
                        );
                }
                return _getLeftDrivesList;
            }
        }

        private ICommand _selectionChanged = null;
        public ICommand SelectionChanged
        {
            get
            {
                if(_selectionChanged == null)
                {
                    _selectionChanged = new RelayCommand(
                        arg => { 
                            CurrentPath = PathFromLList;
                            LeftPathList = Directory.GetFiles(PathFromLList).ToList<string>();
                            LeftPathList.AddRange(Directory.GetDirectories(PathFromLList).ToList<string>());
                        },
                        arg => PathFromLList != null
                        );
                }

                return _selectionChanged;
            }
        }

    }
}
