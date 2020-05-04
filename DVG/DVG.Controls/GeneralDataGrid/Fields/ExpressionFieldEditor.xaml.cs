using System;
using System.Collections.Generic;
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

namespace DVG.Controls.GeneralDataGrid.Fields
{
    /// <summary>
    /// Interaction logic for ExpressionFieldEditor.xaml
    /// </summary>
    public partial class ExpressionFieldEditor : UserControl
    {
        public ExpressionFieldEditor()
        {
            InitializeComponent();
        }

        private ExpressionField _field;

        internal ExpressionField Field { get => _field; set => _field = value; }
    }
}
