using Avalonia;
using Avalonia.Controls;
using Muse_Dash_Mod_Downloader.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reactive;
using System.Runtime.InteropServices;
using System.Text;

namespace Muse_Dash_Mod_Downloader.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ReactiveCommand<string, Unit> Run_OpenURL { get; }
        public MainWindowViewModel()
        {
            Run_OpenURL = ReactiveCommand.Create<string>(OpenURL);
        }


        public void OpenURL(string linkToOpen)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? linkToOpen : "open",
                Arguments = RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? $"-e {linkToOpen}" : "",
                CreateNoWindow = true,
                UseShellExecute = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
            });
        }

        public void Button_FilterAll()
        {
            MainWindow._Instance.Selected_ModFilter = 0;
            MainWindow._Instance.UpdateFilters();
        }

        public void Button_FilterInstalled()
        {
            MainWindow._Instance.Selected_ModFilter = 1;
            MainWindow._Instance.UpdateFilters();
        }

        public void Button_FilterEnabled()
        {
            MainWindow._Instance.Selected_ModFilter = 2;
            MainWindow._Instance.UpdateFilters();
        }

        public void Button_FilterOutdated()
        {
            MainWindow._Instance.Selected_ModFilter = 3;
            MainWindow._Instance.UpdateFilters();
        }
    }
}
