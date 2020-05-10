using DVG.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
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
        public DvgConfig Config
        {
            get
            {
                return (DvgConfig)GetValue(ConfigProperty);
            }
            set
            {
                SetValue(ConfigProperty, value);
                //OnPropertyChanged();
            }
        }

        public static DependencyProperty ConfigProperty =
       DependencyProperty.Register("Config", typeof(DvgConfig), typeof(ConfigEditor), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender, OnConfigChangedCallBack));


        private static void OnConfigChangedCallBack(
        DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var editor = (ConfigEditor)sender;
            var val = e.NewValue as DvgConfig;
            if (val == null)
            {
                val = new DvgConfig();
            }
            editor.VsSolutionPathTb.Text = val.VsSolutionPath;
            editor.DbProjectNameTb.Text = val.DbProjectName;
            editor.SsisProjectNameTb.Text = val.SsisProjectName;
            editor.ParametersEditor.Parameters.Clear();
            if (val.Parameters != null)
            {
                foreach (var param in val.Parameters)
                {
                    editor.ParametersEditor.Parameters.Add(param);
                }
            }
            editor.ExecutionGroupsEditor.ExecutionGroups.Clear();
            if (val.ExecutionGroups != null)
            {
                foreach (var eg in val.ExecutionGroups)
                {
                    editor.ExecutionGroupsEditor.ExecutionGroups.Add(eg);
                }
            }
        }

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
       DependencyProperty.Register("FileProvider", typeof(IFileProvider), typeof(ConfigEditor), new FrameworkPropertyMetadata(OnFileEditorChangedCallBack));

        private static void OnFileEditorChangedCallBack(
        DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var provider = e.NewValue as IFileProvider;
            if (provider == null)
            {
                return;
            }
            var editor = (ConfigEditor)sender;
            if (editor.Config == null)
            {
                editor.Config = provider.GetConfig();
            }
        }

        public ConfigEditor()
        {
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            FileProvider.SaveConfig(Config);
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Config = FileProvider.GetConfig();
            
        }

    }
}
