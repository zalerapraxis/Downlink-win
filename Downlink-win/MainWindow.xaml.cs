using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Downlink_win.Helpers;
using Downlink_win.Models;
using Application = System.Windows.Application;
using ListViewItem = System.Windows.Controls.ListViewItem;

namespace Downlink_win
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Bindings _bindings = new Bindings();
        public static LocalSettings _localSettings = new LocalSettings();
        public static SettingsHelper _settingsHelper = new SettingsHelper();
        public static Scheduler _scheduler = new Scheduler();

        public Sources _imageSources = new Sources();

        public static NotifyIcon notifyIcon;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = _bindings;

            _settingsHelper.LoadSettings();

            // populate listbox with source images & titles
            var listSources = new ObservableCollection<SourceDisplay>();
            foreach (var source in _imageSources.sources)
            {
                listSources.Add(new SourceDisplay()
                {
                    name = $"{source.name}",
                    image = new BitmapImage(new Uri(source.url.tiny))
                });
            }
            lstSources.ItemsSource = listSources;
        }


        private async void lstSourcesItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedItem = ((ListViewItem) sender).Content as SourceDisplay;
            Source selectedSource = _imageSources.sources.FirstOrDefault(x => x.name.Equals(selectedItem.name));

            _settingsHelper.SelectSource(selectedSource);
        }

        
    }
}
