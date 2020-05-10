using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVG.Models
{
    public class DvgConfig : INotifyPropertyChanged
    {
        private List<DvgConfigParameter> _parameters = new List<DvgConfigParameter>();
        public List<DvgConfigParameter> Parameters { get => _parameters; set => _parameters = value; }

        private List<DvgConfigExecutionGroup> _executionGroups = new List<DvgConfigExecutionGroup>();
        public List<DvgConfigExecutionGroup> ExecutionGroups { get => _executionGroups; set => _executionGroups = value; }

        private string _dbProjectName;
        public string DbProjectName
        {
            get => _dbProjectName; set
            {
                _dbProjectName = value;
                OnPropertyChanged();
            }
        }

        private string _ssisProjectName;
        public string SsisProjectName { get => _ssisProjectName; set => _ssisProjectName = value; }

        private string _vsSolutionPath;
        public string VsSolutionPath { get => _vsSolutionPath; set => _vsSolutionPath = value; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

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
