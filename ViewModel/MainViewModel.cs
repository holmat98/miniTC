using miniTC.ViewModel.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Input;

namespace miniTC.ViewModel
{
    class MainViewModel : ViewModelBase
    {
        private string[] _drivesList;

        public string[] DriveList
        {
            get => _drivesList;
            set
            {
                _drivesList = value;
                onPropertyChanged(nameof(DriveList));
            }
        }



        private ICommand _getDrivesList = null;
        public ICommand GetDrivesList
        {
            get
            {
                if(_getDrivesList == null)
                {
                    _getDrivesList = new RelayCommand(
                        arg => { DriveList = Environment.GetLogicalDrives(); },
                        arg => true
                        );
                }
                return _getDrivesList;
            }
        }

    }
}
