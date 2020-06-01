using DVG.Models;
using DVG.Services.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVG.Services.StandaloneProject
{
    public class ProjectItem
    { 
        public string Name { get { return Path.GetFileNameWithoutExtension(ReplativePath); } }
        public string ReplativePath { get; set; }

        public ProjectItem(string path)
        {
            ReplativePath = path;
        }
    }

    public class ProjectFolder : ProjectItem
    {
        public List<ProjectFolder> Folders { get; set; }
        public List<ProjectFile> Files { get; set; }

        public ProjectFolder(string path)
            : base(path)
        {
            Files = new List<ProjectFile>();
            Folders = new List<ProjectFolder>();
        }
    }

    public class ProjectFile : ProjectItem
    {
        public ProjectFile(string path)
            :base(path)
        { 
        }
    }
}
