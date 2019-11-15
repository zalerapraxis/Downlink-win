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

        public void ToggleKeepImages(bool shouldKeepImages)
        {
            Properties.Settings.Default.KeepImages = shouldKeepImages;
            MainWindow._localSettings.KeepImages = shouldKeepImages;
        }

        public void LoadSettings()
        {
            // load wallpapersource settings, if they exist
            if (Properties.Settings.Default.WallpaperSource.Any())
            {
                // find saved source from sources list
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

                // set source in local settings & use
                MainWindow._localSettings.WallpaperSource = selectedSource;
                SelectSource(selectedSource);
            }

            // load keepimages settings, if they exist
            if (Properties.Settings.Default.KeepImages)
                MainWindow._localSettings.KeepImages = Properties.Settings.Default.KeepImages;
            
        }

        public void SaveSettings()
        {
            Properties.Settings.Default.Save();
        }
    }
}
