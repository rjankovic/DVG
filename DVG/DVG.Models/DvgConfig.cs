using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVG.Models
{
    public class DvgConfig
    {
        private List<DvgConfigParameter> _parameters;
        public List<DvgConfigParameter> Parameters { get => _parameters; set => _parameters = value; }
        
        private List<DvgConfigExecutionGroup> _executionGroups; 
        public List<DvgConfigExecutionGroup> ExecutionGroups { get => _executionGroups; set => _executionGroups = value; }
        
        private string _dbProjectName;
        public string DbProjectName { get => _dbProjectName; set => _dbProjectName = value; }
        
        private string _ssisProjectName;
        public string SsisProjectName { get => _ssisProjectName; set => _ssisProjectName = value; }
    }

    public enum ConfigParameterType { Boolean, Integer, String }

    public class DvgConfigParameter
    { 
        public string ParameterName { get; set; }

        public string DefaultValue { get; set; }

        public ConfigParameterType ParameterType { get; set; }
    }

    public class DvgConfigExecutionGroup
    { 
        public string ExecutionGroupName { get; set; }

        public string SchemaName { get; set; }
    }
}
