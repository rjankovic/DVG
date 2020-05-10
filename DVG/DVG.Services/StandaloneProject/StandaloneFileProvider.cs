using DVG.Models;
using DVG.Services.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IO = System.IO;

namespace DVG.Services.StandaloneProject
{
    public class StandaloneFileProvider : IFileProvider
    {
        private string _rootFolder;
        private FileSystemWatcher _fsw;
        private Project _project;

        public string ProjectName => _project.ProjectName;

        public string ProjectPath => _project.ProjectPath;

        private List<string> _folders = new List<string>();
        private List<string> _files = new List<string>();

        public event FileEventHandler FileChanged;

        public StandaloneFileProvider(Project project)
        {
            _project = project;
            _rootFolder = Path.GetDirectoryName(project.ProjectPath);
            _fsw = new FileSystemWatcher(_rootFolder);
            _fsw.Changed += OnFileSystemItemChanged;
            
            _folders = GetDirectoryTree(_rootFolder);
            _files = Directory.GetFiles(_rootFolder).Union(_folders.SelectMany(fld => Directory.GetFiles(fld))).ToList();
        }

        List<string> GetDirectoryTree(string path)
        {
            var folders = Directory.GetDirectories(path);
            return folders.Union(folders.SelectMany(f => GetDirectoryTree(f))).ToList();
        }

        private void OnFileSystemItemChanged(object sender, FileSystemEventArgs e)
        {
            var path = e.FullPath;
            bool isDirectory = Path.GetExtension(path) == "";
            
            FileEventArgs eventArgs = new FileEventArgs()
            {
                FullPath = e.FullPath, 
                ItemType = isDirectory ? FileEventItemType.Folder : FileEventItemType.File
            };
            
            switch (e.ChangeType)
            {
                case WatcherChangeTypes.Changed:
                    eventArgs.Operation = FileEventOperation.Changed;
                    break;
                case WatcherChangeTypes.Created:
                    eventArgs.Operation = FileEventOperation.Created;
                    if (isDirectory)
                    {
                        _folders.Add(path);
                    }
                    else
                    {
                        _files.Add(path);
                    }
                    break;
                case WatcherChangeTypes.Deleted:
                    eventArgs.Operation = FileEventOperation.Deleted;
                    if (isDirectory)
                    {
                        _folders.Remove(path);
                    }
                    else
                    {
                        _files.Remove(path);
                    }
                    break;
                case WatcherChangeTypes.Renamed:
                    eventArgs.Operation = FileEventOperation.Renamed;
                    var args = (RenamedEventArgs)e;
                    if (isDirectory)
                    {
                        _folders.Remove(args.OldFullPath);
                        _folders.Add(path);
                    }
                    else
                    {
                        _files.Remove(args.OldFullPath);
                        _files.Add(path);
                    }
                    break;
            }

            FileChanged?.Invoke(this, eventArgs);
        }

        public DvgConfig GetConfig()
        {
            CheckConfigExists();
            var configFile = _files.First(x => Path.GetExtension(x) == Models.File.EXTENSION_CONFIG);
            var deser = Serializer.Deserialize<DvgConfig>(IO.File.ReadAllText(configFile, Encoding.UTF8));
            return deser;
        }

        public List<string> ListFiles()
        {
            return _files;
        }

        public List<string> ListFolders()
        {
            return _folders;
        }

        public void SaveConfig(DvgConfig config)
        {
            CheckConfigExists();
            var configFile = _files.First(x => Path.GetExtension(x) == Models.File.EXTENSION_CONFIG);
            var ser = Serializer.Serialize(config);
            IO.File.WriteAllText(configFile, ser, Encoding.UTF8);
        }

        private void CheckConfigExists()
        {
            var configFile = _files.FirstOrDefault(x => Path.GetExtension(x) == Models.File.EXTENSION_CONFIG);
            if (configFile != null)
            {
                return;
            }
            var configPath = Path.Combine(_rootFolder, "config" + Models.File.EXTENSION_CONFIG);
            _files.Add(configPath);
            var ser = Serializer.Serialize(new DvgConfig());
            IO.File.WriteAllText(configPath, ser, Encoding.UTF8);
        }

        Models.File IFileProvider.ReadFile(string relativePath)
        {
            var fullPath = Path.Combine(_project.ProjectPath, relativePath);
            var content = IO.File.ReadAllText(fullPath, Encoding.UTF8);
            var deser = Serializer.Deserialize<Models.File>(content);
            return deser;
        }

        public void SaveFile(Models.File file)
        {
            var fullPath = Path.Combine(_project.ProjectPath, file.RelativePath);
            var ser = Serializer.Serialize(file);
            throw new NotImplementedException();
        }
    }
}
