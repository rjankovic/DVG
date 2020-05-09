using DVG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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

namespace DVG.Controls.ConfigEditor
{
    /// <summary>
    /// Interaction logic for ConfigEditor.xaml
    /// </summary>
    public partial class ConfigEditor : UserControl
    {
        //private DvgConfig _config;
        //public DvgConfig Config { 
        //    get 
        //    { 
        //        return _config; 
        //    } 
        //    set 
        //    { 
        //        _config = value; 
        //    } 
        //}

        public DvgConfig Config
        {
            get
            {
                return (DvgConfig)GetValue(ConfigProperty);
            }
            set
            {
                SetValue(ConfigProperty, value);
            }
        }

        public static DependencyProperty ConfigProperty =
       DependencyProperty.Register("Config", typeof(DvgConfig), typeof(ConfigEditor));


        public IFileProvider FileProvider
        {
            get { 
                return (IFileProvider)GetValue(FileProviderProperty); 
            }
            set { 
                SetValue(FileProviderProperty, value); 
            }
        }

        public static DependencyProperty FileProviderProperty =
       DependencyProperty.Register("FileProvider", typeof(IFileProvider), typeof(ConfigEditor));

        public ConfigEditor()
        {
            InitializeComponent();
        }

        private void VsSolutionPathBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
