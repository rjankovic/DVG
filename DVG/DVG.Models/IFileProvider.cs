using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVG.Models
{
    public interface IFileProvider
    {
        File ReadFile(string relativePath);

        void SaveFile(File file);

        List<string> ListFiles();

        List<string> ListFolders();

        void SaveConfig(DvgConfig config);

        DvgConfig GetConfig();

        string ProjectName { get; }

        string ProjectPath { get; }

        event FileEventHandler FileChanged;
    }
}
