using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVG.Models.FilePropertyAttributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    public class DisplayPriority : Attribute
    {
        public DisplayPriority(int priority)
        {
            Priority = priority;
        }

        public int Priority { get; }
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    public class DisplayName : Attribute
    {
        public DisplayName(string displayName)
        {
            Name = displayName;
        }

        public string Name { get; }
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    public class ExcludeFromEditor : Attribute
    {
    }
}
