using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace DVG.Controls.GeneralDataGrid.Fields
{
    public class ExtractMethodField : ComboField
    {
        public ExtractMethodField()
            :base()
        {
            _options = new List<string>()
            { 
                "OLEDB", "CSV", "Excel"
            };
        }
    }
}
