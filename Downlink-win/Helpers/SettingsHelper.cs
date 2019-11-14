using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Downlink_win.Helpers
{
    public class SettingsHelper
    {
        public Sources _imageSources = new Sources();

        public async void SelectSource(Source source)
        {
            // this func is called when user selects a source, and when settings are loaded
            // so cover both cases here
            Properties.Settings.Default.WallpaperSource = source.name;
            MainWindow._localSettings.WallpaperSource = source;

            await MainWindow._scheduler.RunScheduler();
        }

        public void LoadSettings()
        {
            // don't try any of this if no settings were found
            if (Properties.Settings.Default.WallpaperSource.Any() == false)
                return;
            
            var savedSourceName = Properties.Settings.Default.WallpaperSource;
            Source selectedSource = _imageSources.sources.FirstOrDefault(x => x.name.Equals(savedSourceName));

            // should only be null if settings were externally modified or corrupted
            // overwrite failure settings and cancel out
            if (selectedSource == null)
            {
                Properties.Settings.Default.WallpaperSource = null;
                SaveSettings();
                return;
            }
                
            MainWindow._localSettings.WallpaperSource = selectedSource;
            SelectSource(selectedSource);
        }

        public void SaveSettings()
        {
            Properties.Settings.Default.Save();
        }
    }
}
