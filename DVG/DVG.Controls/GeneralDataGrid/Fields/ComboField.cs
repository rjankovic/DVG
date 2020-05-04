using DVG.Models.FileProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace DVG.Controls.GeneralDataGrid.Fields
{
    public abstract class ComboField : FieldBase, IField
    {
        public ComboField()
        {
            _options = new List<string>();
        }
        protected List<string> _options;
        public List<string> Options { get { return _options; } }

        public string StringValue { get => _value; set => _value = value; }

        protected string _value;

        public UserControl GetUserControl()
        {
            return null;
        }

        public IValueConverter GetConverter()
        {
            return new ComboFieldConverter();
        }
    }

    [ValueConversion(typeof(ComboField), typeof(string))]
    public class ComboFieldConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }
            ComboField field = (ComboField)value;
            return field.StringValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }
            var constructor = targetType.GetConstructor(new Type[0] { });
            var field = (ComboField)constructor.Invoke(new object[0] { });
            field.StringValue = value.ToString();
            return field;
        }
    }
}
