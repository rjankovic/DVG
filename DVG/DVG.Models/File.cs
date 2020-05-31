using DVG.Models.FilePropertyAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVG.Models
{
    public class File : EditableItem
    {
        public File(string relativePath, DvgConfig config)
        {
            _relativePath = relativePath;
            _fileName = Path.GetFileName(_relativePath);
            _config = config;
        }

        protected string _fileName;
        [ExcludeFromEditor]
        public string FileName { get => _fileName; set => _fileName = value; }
        [ExcludeFromEditor]
        public string RelativePath { get => _relativePath; set => _relativePath = value; }
        [ExcludeFromEditor]
        public string FileExtension { get { return Path.GetExtension(_fileName); } }

        protected string _relativePath;

        public const string EXTENSION_CONFIG = ".dvgcfg";
        public const string EXTENSION_EXTRACT = ".dvge";
    }

}
