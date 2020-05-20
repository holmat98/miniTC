using miniTC.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace miniTC.Controls
{
    /// <summary>
    /// Logika interakcji dla klasy TCPanel.xaml
    /// </summary>
    public partial class TCPanel : UserControl
    {
        public TCPanel()
        {
            InitializeComponent();
        }

        public string CurrentPath
        {
            get => (string)GetValue(CurrentPathProperty);
            set
            {
                SetValue(CurrentPathProperty, value);
            }
        }

        public static readonly DependencyProperty CurrentPathProperty = DependencyProperty.Register("CurrentPath", typeof(string), typeof(TCPanel), new PropertyMetadata(""));

        public string[] CBBoxItemSource
        {
            get => (string[])GetValue(CBBoxItemSourceProperty);
            set
            {
                SetValue(CBBoxItemSourceProperty, value);
            }
        }

        public static readonly DependencyProperty CBBoxItemSourceProperty = DependencyProperty.Register("CBBoxItemSource", typeof(string[]), typeof(TCPanel), new PropertyMetadata(null));

        //public string[] CBBoxItemSource { get; set; }

        public string CBBoxSelectedItem
        {
            get => (string)GetValue(CBBoxSelectedItemProperty);
            set
            {
                SetValue(CBBoxSelectedItemProperty, value);
            }
        }

        public static readonly DependencyProperty CBBoxSelectedItemProperty = DependencyProperty.Register("CBBoxSelectedItem", typeof(string), typeof(TCPanel), new PropertyMetadata(""));

        public ICommand CBBoxGotFocus
        {
            get => (ICommand)GetValue(CBBoxGotFocusProperty);
            set
            {
                SetValue(CBBoxGotFocusProperty, value);
            }
        }
        public static readonly DependencyProperty CBBoxGotFocusProperty = DependencyProperty.Register("CBBoxGotFocus", typeof(ICommand), typeof(TCPanel), new PropertyMetadata(null));
        
        public ICommand CBBoxSelChng
        {
            get => (ICommand)GetValue(CBBoxSelChngProperty);
            set
            {
                SetValue(CBBoxSelChngProperty, value);
            }
        }

        public static readonly DependencyProperty CBBoxSelChngProperty = DependencyProperty.Register("CBBoxSelChng", typeof(ICommand), typeof(TCPanel), new PropertyMetadata(null));

        public ObservableCollection<PathToFile> CurrentPathContents
        {
            get => (ObservableCollection<PathToFile>)GetValue(CurrentPathContentsProperty);
            set
            {
                SetValue(CurrentPathContentsProperty, value);
            }
        }
        public static readonly DependencyProperty CurrentPathContentsProperty = DependencyProperty.Register("CurrentPathContents", typeof(ObservableCollection<PathToFile>), typeof(TCPanel), new PropertyMetadata(null));

        public PathToFile SelectedEntry
        {
            get => (PathToFile)GetValue(SelectedEntryProperty);
            set
            {
                SetValue(SelectedEntryProperty, value);
            }
        }

        public static readonly DependencyProperty SelectedEntryProperty = DependencyProperty.Register("SelectedEntry", typeof(PathToFile), typeof(TCPanel), new PropertyMetadata(null));

        public ICommand MDClick
        {
            get => (ICommand)GetValue(MDClickProperty);
            set
            {
                SetValue(MDClickProperty, value);
            }
        }
        public static readonly DependencyProperty MDClickProperty = DependencyProperty.Register("MDClick", typeof(ICommand), typeof(TCPanel), new PropertyMetadata(null));


    }
}
