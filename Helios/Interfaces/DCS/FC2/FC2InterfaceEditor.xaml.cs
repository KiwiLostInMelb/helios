﻿//  Copyright 2014 Craig Courtney
//    
//  Helios is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  Helios is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

namespace GadrocsWorkshop.Helios.Interfaces.DCS.FC2
{
    using GadrocsWorkshop.Helios.Interfaces.DCS.Common;
    using GadrocsWorkshop.Helios.UDPInterface;
    using GadrocsWorkshop.Helios.Windows.Controls;
    using Microsoft.Win32;
    using System;
    using System.Windows;
    using System.Windows.Input;


    /// <summary>
    /// Interaction logic for DCSA10InterfaceEditor.xaml
    /// </summary>
    public partial class FC2InterfaceEditor : HeliosInterfaceEditor
    {
        private string _fc2Path;

        static FC2InterfaceEditor()
        {
            Type ownerType = typeof(FC2InterfaceEditor);

            CommandManager.RegisterClassCommandBinding(ownerType, new CommandBinding(DCSConfigurator.AddDoFile, AddDoFile_Executed));
            CommandManager.RegisterClassCommandBinding(ownerType, new CommandBinding(DCSConfigurator.RemoveDoFile, RemoveDoFile_Executed));
        }

        private static void AddDoFile_Executed(object target, ExecutedRoutedEventArgs e)
        {
            FC2InterfaceEditor editor = target as FC2InterfaceEditor;
            string file = e.Parameter as string;
            if (editor != null && !string.IsNullOrWhiteSpace(file) && !editor.Configuration.DoFiles.Contains(file))
            {
                editor.Configuration.DoFiles.Add((string)e.Parameter);
                editor.NewDoFile.Text = "";
            }
        }

        private static void RemoveDoFile_Executed(object target, ExecutedRoutedEventArgs e)
        {
            FC2InterfaceEditor editor = target as FC2InterfaceEditor;
            string file = e.Parameter as string;
            if (editor != null && !string.IsNullOrWhiteSpace(file) && editor.Configuration.DoFiles.Contains(file))
            {
                editor.Configuration.DoFiles.Remove(file);
            }
        }

        public FC2InterfaceEditor()
        {
            InitializeComponent();
            Configuration = new DCSConfigurator("FC2", "pack://application:,,,/Helios;component/Interfaces/DCS/FC2/Export.lua", FC2Path, true);
            Configuration.ExportConfigPath = "Config\\Export";
            Configuration.ExportFunctionsPath = "pack://application:,,,/Helios;component/Interfaces/DCS/FC2/ExportFunctions.lua";
        }

        #region Properties

        public DCSConfigurator Configuration
        {
            get { return (DCSConfigurator)GetValue(ConfigurationProperty); }
            set { SetValue(ConfigurationProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Configuration.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ConfigurationProperty =
            DependencyProperty.Register("Configuration", typeof(DCSConfigurator), typeof(FC2InterfaceEditor), new PropertyMetadata(null));

        public string FC2Path
        {
            get
            {
                if (_fc2Path == null)
                {
                    RegistryKey pathKey = Registry.CurrentUser.OpenSubKey(@"Software\Eagle Dynamics\LockOn Flaming Cliffs 2\Path");
                    if (pathKey != null)
                    {
                        _fc2Path = (string)pathKey.GetValue("Path");
                    }
                    else
                    {
                        _fc2Path = "";
                    }
                }
                return _fc2Path;
            }
        }

        #endregion

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            if (e.Property == InterfaceProperty)
            {
                Configuration.UDPInterface = Interface as BaseUDPInterface;
            }

            base.OnPropertyChanged(e);
        }

        private void Configure_Click(object sender, RoutedEventArgs e)
        {
            if (Configuration.UpdateExportConfig())
            {
                MessageBox.Show(Window.GetWindow(this), "Lockon Falming Cliffs 2 has been configured.");
            }
            else
            {
                MessageBox.Show(Window.GetWindow(this), "Error updating Lockon Falming Cliffs 2 configuration.  Please do one of the following and try again:\n\nOption 1) Run Helios as Administrator\nOption 2) Install Lockon outside the Program Files Directory\nOption 3) Disable UAC.");
            }
        }

        private void ResetPath(object sender, RoutedEventArgs e)
        {
            Configuration.AppPath = FC2Path;
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            Configuration.RestoreConfig();
        }
    }
}
