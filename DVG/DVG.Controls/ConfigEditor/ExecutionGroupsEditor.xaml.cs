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
    /// Interaction logic for ExecutionGroupsEditor.xaml
    /// </summary>
    public partial class ExecutionGroupsEditor : UserControl, INotifyPropertyChanged
    {
        private ObservableCollection<DvgConfigExecutionGroup> _executionGroups = new ObservableCollection<DvgConfigExecutionGroup>();

        private bool _enableEditing;

        public ExecutionGroupsEditor()
        {
            InitializeComponent();
        }

        public bool EnableEditing
        {
            get
            {
                return _enableEditing;
            }
            set
            {
                _enableEditing = value;
                NotifyPropertyChanged("EnableEditing");
            }
        }
        public ObservableCollection<DvgConfigExecutionGroup> ExecutionGroups { get => _executionGroups; set { _executionGroups = value; } }

        public static DependencyProperty ExecutionGroupsProperty =
       DependencyProperty.Register("ExecutionGroups", typeof(ObservableCollection<DvgConfigExecutionGroup>), typeof(ExecutionGroupsEditor));

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            DataGrid.UnselectAll();
            var parameterNo = 1;
            while (_executionGroups.Any(x => x.ExecutionGroupName == "ExecGroup" + parameterNo.ToString()))
            {
                parameterNo++;
            }
            _executionGroups.Add(new DvgConfigExecutionGroup() { ExecutionGroupName = "ExecGroup" + parameterNo.ToString(), SchemaName = "" });
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            var item = DataGrid.SelectedItem as DvgConfigExecutionGroup;
            if (item is null)
            {
                return;
            }

            _executionGroups.Remove(item);
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
