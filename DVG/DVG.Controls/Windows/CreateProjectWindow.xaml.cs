using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Resources;
using System.Windows.Shapes;

namespace DVG.Controls.Windows
{
    /// <summary>
    /// Interaction logic for CreateProjectWindow.xaml
    /// </summary>
    public partial class CreateProjectWindow : Window
    {
        public CreateProjectWindow()
        {
            InitializeComponent();

            ErrorMessage = string.Empty;
        }

        public string ProjectFolderPath
        {
            get
            {
                return (string)GetValue(ProjectFolderPathProperty);
            }
            set
            {
                SetValue(ProjectFolderPathProperty, value);
            }
        }

        public static DependencyProperty ProjectFolderPathProperty =
       DependencyProperty.Register("ProjectFolderPath", typeof(string), typeof(CreateProjectWindow));


        public string ProjectName
        {
            get
            {
                return (string)GetValue(ProjectNameProperty);
            }
            set
            {
                SetValue(ProjectNameProperty, value);
            }
        }

        public static DependencyProperty ProjectNameProperty =
       DependencyProperty.Register("ProjectName", typeof(string), typeof(CreateProjectWindow));


        public string ErrorMessage
        {
            get
            {
                return (string)GetValue(ErrorMessageProperty);
            }
            set
            {
                SetValue(ErrorMessageProperty, value);
            }
        }

        public static DependencyProperty ErrorMessageProperty =
       DependencyProperty.Register("ErrorMessage", typeof(string), typeof(CreateProjectWindow));



        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            ErrorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(ProjectFolderPath))
            {
                ErrorMessage = "The project folder path is required";
                return;
            }
            if (string.IsNullOrWhiteSpace(ProjectName))
            {
                ErrorMessage = "The project name is required";
                return;
            }

            this.DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            Close();
        }

        private void SelectFolderButton_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                if (result != System.Windows.Forms.DialogResult.OK)
                {
                    return;
                }

                ProjectFolderPath = dialog.SelectedPath;
            }
        }
    }
}
