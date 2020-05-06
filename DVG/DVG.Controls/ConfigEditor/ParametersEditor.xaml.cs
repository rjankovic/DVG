using DVG.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace DVG.Controls.ConfigEditor
{
    /// <summary>
    /// Interaction logic for ParametersEditor.xaml
    /// </summary>
    public partial class ParametersEditor : UserControl, INotifyPropertyChanged
    {
        private ObservableCollection<DvgConfigParameter> _parameters = new ObservableCollection<DvgConfigParameter>();
        
        private bool _enableEditing;
        public List<DvgConfigParameter> Parameters { 
            get 
            { 
                return _parameters.ToList(); 
            }
            set
            {
                _parameters.Clear();
                foreach (var item in value)
                {
                    _parameters.Add(item);
                }
            }
        }
        public bool EnableEditing { get { 
                return _enableEditing; 
            } set
            {
                _enableEditing = value;
                NotifyPropertyChanged("EnableEditing");
            } }
        public ObservableCollection<DvgConfigParameter> ParametersObservable { get => _parameters; set { _parameters = value; } }
        public string BindingTest { get => _bindingTest; set => _bindingTest = value; }

        public ParametersEditor()
        {
            InitializeComponent();
        }


        private string _bindingTest = "AAAA";

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
