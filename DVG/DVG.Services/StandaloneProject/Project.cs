using DVG.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVG.Services.StandaloneProject
{
    public class Project
    {
        private string _projectPath;

        public Project()
        {
            _projectPath = string.Empty;
        }
        
        public string ProjectPath {
            get { return _projectPath; }
            set { _projectPath = value; }
        }

        public string ProjectName { get => Path.GetFileNameWithoutExtension(_projectPath); }

        public void AddFolder(string folderPath)
        {
            Directory.CreateDirectory(folderPath);
        }

        public void DeleteFolder(string folderPath)
        {
            Directory.Delete(folderPath, true);
        }

        public void RenameFolder(string folderPath, string newFolderName)
        {
            var newPath = Path.Combine(Path.GetDirectoryName(folderPath), newFolderName);
            Directory.Move(folderPath, newPath);
        }

        public IFileProvider GetFileProvider()
        {
            return new StandaloneFileProvider(this);
        }
    }
}
