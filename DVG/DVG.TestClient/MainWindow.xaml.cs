using DVG.Controls.Windows;
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

        private IFileProvider _fileProvider;

        private DvgConfig _config = new DvgConfig() { DbProjectName = "QWERTY" };

        public MainWindow()
        {
            FileProvider = new StandaloneFileProvider(_project);
            //ConfigEditor.FileProvider = _fileProvider;
            //ConfigEditor.Config = _config;
            InitializeComponent();
        }

        public IFileProvider FileProvider { get => _fileProvider; set => _fileProvider = value; }
        public DvgConfig Config { get => _config; set => _config = value; }

        private void OpenProjectMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CreateProjectMenu_Click(object sender, RoutedEventArgs e)
        {
            CreateProjectWindow dialog = new CreateProjectWindow();
            var result = dialog.ShowDialog().Value;
            if (!result)
            {
                return;
            }

            var projectPath = System.IO.Path.Combine(dialog.ProjectFolderPath, dialog.ProjectName + Project.EXTENSION_PROJECT);
            Project project = new Project() { ProjectPath = projectPath };
            project.Save();
            _project = project;
        }

        private void EditConfigMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditExtractsMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ProcessMenu_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
