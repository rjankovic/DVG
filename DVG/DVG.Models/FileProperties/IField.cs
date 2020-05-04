using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace DVG.Models.FileProperties
{
    public interface IField
    {
        string StringValue { get; set; }

        UserControl GetUserControl();

        IValueConverter GetConverter();

        DvgConfig DvgConfig { get; set; }
    }
}
