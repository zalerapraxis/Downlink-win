using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace Downlink_win.Helpers
{
    public class Scheduler
    {
        DownloadHelper _downloadHelper = new DownloadHelper();
        WallpaperHelper _wallpaperHelper = new WallpaperHelper();

        private Timer schedulerTimer = new Timer();

        private int schedulerInterval;

        public Scheduler()
        {
            schedulerTimer.Elapsed += OnScheduleTimerElapsed;
        }

        public async Task RunScheduler()
        {
            schedulerInterval = MainWindow._localSettings.WallpaperSource.interval;

            // download image, return its path, set as wallpaper and delete
            var imagePath = await _downloadHelper.DownloadAndSaveImage(MainWindow._localSettings.WallpaperSource.url.full);

            if (!imagePath.Any())
            {
                MainWindow._bindings.ProgramStatus = "Download failed. Retrying shortly...";
                StartTimers(true);
            }
            else
            {
                _wallpaperHelper.SetWallpaper(imagePath);
                _wallpaperHelper.DeleteImage(imagePath);

                MainWindow._bindings.LastUpdated = $"Last updated {DateTime.Now}";

                StartTimers(false);
            }
            
        }

        private void StartTimers(bool fastRetry)
        {
            schedulerTimer.Stop();

            schedulerTimer.Interval = (fastRetry ? 10 : schedulerInterval) * 1000;
            schedulerTimer.Start();
        }

        private async void OnScheduleTimerElapsed(object sender, ElapsedEventArgs e)
        {
            await RunScheduler();
        }
    }
}
