using DVG.Models;
using DVG.Services.StandaloneProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DVG.TestClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Project _project = new Project() { ProjectPath = "C:\\TEMP\\DVG_1\\test.dvgproj" };

        private StandaloneFileProvider _fileProvider;

        private DvgConfig _config = new DvgConfig();

        public MainWindow()
        {
            FileProvider = new StandaloneFileProvider(_project);
            //ConfigEditor.FileProvider = _fileProvider;
            //ConfigEditor.Config = _config;
            InitializeComponent();
        }

        public StandaloneFileProvider FileProvider { get => _fileProvider; set => _fileProvider = value; }
        public DvgConfig Config { get => _config; set => _config = value; }
    }
}
