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
using System.Windows;

namespace miniTC.ViewModel
{
    class MainViewModel : ViewModelBase
    {
        #region Left Panel

        private PanelTC _leftPanel = new PanelTC();

        public string FromPath
        {
            get => _leftPanel.CurrentPath;
            set
            {
                _leftPanel.CurrentPath = value;
                onPropertyChanged(nameof(FromPath));
            }
        }

        public string[] LeftDrivesList
        {
            get => _leftPanel.DrivesList;
            set
            {
                _leftPanel.DrivesList = value;
                onPropertyChanged(nameof(LeftDrivesList));
            }
        }

        public ObservableCollection<PathToFile> LeftFilesList
        {
            get => _leftPanel.FilesList;
            set
            {
                _leftPanel.FilesList = value;
                onPropertyChanged(nameof(LeftFilesList));
            }
        }

        #endregion

        #region Right Panel

        private PanelTC _rightPanel = new PanelTC();

        public string ToPath
        {
            get => _rightPanel.CurrentPath;
            set
            {
                _rightPanel.CurrentPath = value;
                onPropertyChanged(nameof(ToPath));
            }
        }

        public string[] RightDrivesList
        {
            get => _rightPanel.DrivesList;
            set
            {
                _rightPanel.DrivesList = value;
                onPropertyChanged(nameof(RightDrivesList));
            }
        }

        public ObservableCollection<PathToFile> RightFilesList
        {
            get => _rightPanel.FilesList;
            set
            {
                _rightPanel.FilesList = value;
                onPropertyChanged(nameof(RightFilesList));
            }
        }

        #endregion

        private string _pathFromLCBox;
        public string PathFromLCBox
        {
            get => _pathFromLCBox;
            set
            {
                _pathFromLCBox = value;
                onPropertyChanged(nameof(PathFromLCBox));
            }
        }

        private string _pathFromRCBox;
        public string PathFromRCBox
        {
            get => _pathFromRCBox;
            set
            {
                _pathFromRCBox = value;
                onPropertyChanged(nameof(PathFromRCBox));
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
                            LeftDrivesList = Environment.GetLogicalDrives();
                        },
                        arg => true
                        );
                }
                return _getLeftDrivesList;
            }
        }

        private ICommand _leftSelectionChanged = null;
        public ICommand LeftSelectionChanged
        {
            get
            {
                if(_leftSelectionChanged == null)
                {
                    _leftSelectionChanged = new RelayCommand(
                        arg =>
                        {
                            FromPath = PathFromLCBox;
                            LeftFilesList.Clear();
                            for (int i=0; i< Directory.GetFiles(_leftPanel.CurrentPath).Length; i++)
                                LeftFilesList.Add(new PathToFile(Directory.GetFiles(FromPath)[i], 0));
                            for (int i = 0; i < Directory.GetDirectories(FromPath, "*", SearchOption.TopDirectoryOnly).Length; i++)
                                LeftFilesList.Add(new PathToFile(Directory.GetDirectories(FromPath, "*", SearchOption.TopDirectoryOnly)[i], 0));
                        },
                        arg => PathFromLCBox != null
                        );
                }

                return _leftSelectionChanged;
            }
        }

        private ICommand _rightSelectionChanged = null;
        public ICommand RightSelectionChanged
        {
            get
            {
                if(_rightSelectionChanged == null)
                {
                    _rightSelectionChanged = new RelayCommand(
                        arg => {
                            ToPath = PathFromRCBox;
                            RightFilesList.Clear();
                            for (int i = 0; i < Directory.GetFiles(ToPath).Length; i++)
                                RightFilesList.Add(new PathToFile(Directory.GetFiles(ToPath)[i], 0));
                                
                            for (int i = 0; i < Directory.GetDirectories(ToPath, "*", SearchOption.TopDirectoryOnly).Length; i++)
                                RightFilesList.Add(new PathToFile(Directory.GetDirectories(ToPath, "*", SearchOption.TopDirectoryOnly)[i], 0));
                        },
                        arg => PathFromRCBox != null
                        );
                }

                return _rightSelectionChanged;
            }
        }

        private PathToFile _selectedValueLList;
        public PathToFile SelectedValueLList
        {
            get => _selectedValueLList;
            set
            {
                _selectedValueLList = value;
                onPropertyChanged(nameof(SelectedValueLList));
            }
        }

        private PathToFile _selectedValueRList;
        public PathToFile SelectedValueRList
        {
            get => _selectedValueRList;
            set
            {
                _selectedValueRList = value;
                onPropertyChanged(nameof(SelectedValueRList));
            }
        }

        private ICommand _lNewDirectory = null;
        public ICommand LNewDirectory
        {
            get
            {
                if(_lNewDirectory == null)
                {
                    _lNewDirectory = new RelayCommand(
                        arg => {
                            if(Directory.Exists(SelectedValueLList.CurrentPath))
                            {
                                FromPath = SelectedValueLList.CurrentPath;
                                LeftFilesList.Clear();
                                if (Directory.GetParent(FromPath) != null)
                                    LeftFilesList.Add(new PathToFile(Directory.GetParent(FromPath).ToString(), 1));
                                _leftPanel.GoToNewPath(FromPath);
                            }
                        },
                        arg => SelectedValueLList != null
                        );
                }

                return _lNewDirectory;
            }
        }

        private ICommand _rNewDirectory = null;
        public ICommand RNewDirectory
        {
            get
            {
                if (_rNewDirectory == null)
                {
                    _rNewDirectory = new RelayCommand(
                        arg => {
                            if (Directory.Exists(SelectedValueRList.CurrentPath))
                            {
                                ToPath = SelectedValueRList.CurrentPath;
                                RightFilesList.Clear();
                                if (Directory.GetParent(ToPath) != null)
                                    RightFilesList.Add(new PathToFile(Directory.GetParent(ToPath).ToString(), 1));
                                _rightPanel.GoToNewPath(ToPath);
                            }
                        },
                        arg => SelectedValueRList != null
                        );
                }

                return _rNewDirectory;
            }
        }


        private ICommand _copyFile = null;
        public ICommand CopyFile
        {
            get
            {
                if(_copyFile == null)
                {
                    _copyFile = new RelayCommand(
                        arg => {
                            string destPath = Path.Combine(ToPath, SelectedValueLList.CurrentPath.Substring(SelectedValueLList.CurrentPath.LastIndexOf(@"\")+1));
                            MessageBox.Show(destPath);
                            if (Directory.GetDirectories(SelectedValueLList.CurrentPath, "*", SearchOption.TopDirectoryOnly) == null)
                            {
                                try
                                {
                                    File.Copy(SelectedValueLList.CurrentPath, destPath, true);
                                }
                                catch (Exception) { }
                            }
                            else
                            {
                                DirectoryCopy(SelectedValueLList.CurrentPath, ToPath, true);
                            }
                            RightFilesList.Clear();
                            if (Directory.GetParent(ToPath) != null)
                                RightFilesList.Add(new PathToFile(Directory.GetParent(ToPath).ToString(), 1));
                            _rightPanel.GoToNewPath(ToPath);

                        },
                        arg => SelectedValueLList != null && ToPath != null && ToPath != ""
                        );
                }

                return _copyFile;
            }
        }

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            if(!dir.Exists)
            {
                throw new DirectoryNotFoundException("Nie znaleziono ścieżki" + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            string tmp = Path.Combine(destDirName, sourceDirName.Substring(sourceDirName.LastIndexOf(@"\") + 1));
            if (!Directory.Exists(tmp))
                Directory.CreateDirectory(Path.Combine(tmp));

            FileInfo[] files = dir.GetFiles();
            foreach(FileInfo file in files)
            {
                string tempPath = Path.Combine(tmp, file.Name);
                file.CopyTo(tempPath, false);
            }

            if(copySubDirs)
            {
                foreach(DirectoryInfo directory in dirs)
                {
                    string tempPath = Path.Combine(tmp, directory.Name);
                    DirectoryCopy(directory.FullName, tempPath, copySubDirs);
                }
            }
        }

    }
}
