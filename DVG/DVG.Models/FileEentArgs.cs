using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVG.Models
{
    public enum FileEventOperation { Created, Deleted, Renamed, Changed }
    public enum FileEventItemType { File, Folder }
    
    public class FileEventArgs : EventArgs
    {
        public FileEventItemType ItemType { get; set; }
        public FileEventOperation Operation { get; set; }
        public string FullPath { get; set; }
    }

    public class FileRenameEventArgs : FileEventArgs
    { 
        public string OldFullPath { get; set; }
    }

    public delegate void FileEventHandler(object sender, FileEventArgs args);
}
