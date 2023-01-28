using Avalonia.Controls;
using Avalonia.Interactivity;
using ReactiveUI;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Reactive;
using System.Text;
using static System.Net.WebRequestMethods;
using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using System.Configuration;

namespace Muse_Dash_Mod_Downloader.Views
{
    public partial class MainWindow : Window
    {
        public static MainWindow _Instance { get; private protected set; } = null;
        public int Selected_ModFilter { get; set; } = 0;
        public Version GameVersion { get; private set; } = null;

        public List<WebModInfo> WebModsList { get; private set; }

        private const string ModLinks = "https://raw.githubusercontent.com/MDModsDev/ModLinks/dev/ModLinks.json";
        public MainWindow()
        {
            InitializeComponent();
            _Instance = this;
#pragma warning disable SYSLIB0014 // Type or member is obsolete
            var webClient = new WebClient
            {
                Encoding = Encoding.UTF8
            };
#pragma warning restore SYSLIB0014 // Type or member is obsolete
            string data = Encoding.Default.GetString(webClient.DownloadData(ModLinks));
            webClient.Dispose();
            WebModsList = JsonSerializer.Deserialize<List<WebModInfo>>(data);


        }

        public void UpdateFilters()
        {

        }
    }

    public class WebModInfo
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public string Author { get; set; }
        public string DownloadLink { get; set; }
        public string HomePage { get; set; }
        public string[] GameVersion { get; set; }
        public string Description { get; set; }
        public string[] DependentMods { get; set; }
        public string[] DependentLibs { get; set; }
        public string[] IncompatibleMods { get; set; }
        public string SHA256 { get; set; }
    }

    public class LocalModInfo
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public string SHA256 { get; set; }
    }
}
