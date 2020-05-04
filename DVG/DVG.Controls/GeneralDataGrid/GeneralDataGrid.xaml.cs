using DVG.Models;
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

namespace DVG.Controls.GeneralDataGrid
{
    public class GeneralDataGridItemEventArgs : EventArgs
    {
        public EditableItem Item { get; }
    }

    /// <summary>
    /// Interaction logic for GeneralDataGrid.xaml
    /// </summary>
    public partial class GeneralDataGrid : UserControl
    {
        private ObservableCollection<EditableItem> _items;
        private List<Type> _availableTypes;

        public GeneralDataGrid()
        {
            InitializeComponent();
        }

        public IEnumerable<EditableItem> Items
        {
            get => _items;
        }

        public List<Type> AvailableTypes
        {
            get => _availableTypes;
            set
            {
                if (value.Any(x => !typeof(EditableItem).IsAssignableFrom(x)))
                {
                    throw new Exception("All the available types must be IEditableItems.");
                }
                _availableTypes = value;
                RefreshColumns();
            }
        }

        private void RefreshColumns()
        { 
        
        }
    }
}
