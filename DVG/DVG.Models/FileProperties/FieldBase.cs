using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVG.Models.FileProperties
{
    public abstract class FieldBase
    {
        private DvgConfig dvgConfig;

        public DvgConfig DvgConfig { get => dvgConfig; set => dvgConfig = value; }
    }
}
