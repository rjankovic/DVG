using DVG.Models.FileProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Navigation;

namespace DVG.Controls.GeneralDataGrid.Fields
{
    public class ExpressionField : FieldBase, IField
    {
        private string _value;

        public string StringValue {
            get => _value; set => _value = value; 
        }

        public IValueConverter GetConverter()
        {
            return new ExpressionFieldConverter();
        }

        public UserControl GetUserControl()
        {
            var editor = new ExpressionFieldEditor();
            editor.Field = this;
            return editor;
        }
    }

    [ValueConversion(typeof(ExpressionField), typeof(string))]
    public class ExpressionFieldConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }
            ExpressionField field = (ExpressionField)value;
            return field.StringValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }
            var field = new ExpressionField();
            field.StringValue = (string)value;
            return field;
        }
    }
}
