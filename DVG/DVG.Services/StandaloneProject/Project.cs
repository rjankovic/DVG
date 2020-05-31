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

        public const string EXTENSION_PROJECT = ".dvgproj";

        public void Save()
        {
            var folder = Path.GetDirectoryName(this.ProjectPath);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            var serilized = Serializer.Serialize(this);
            System.IO.File.WriteAllText(this.ProjectPath, serilized);
        }

        public static Project Load(string path)
        {
            var text = System.IO.File.ReadAllText(path);
            var deser = Serializer.Deserialize<Project>(text);
            return deser;
        }
    }
}
