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
    class Scheduler
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
            schedulerInterval = MainWindow._bindings.WallpaperSource.interval;

            MainWindow._bindings.LastUpdated = $"Last updated {DateTime.Now}";

            // download image, return its path, set as wallpaper and delete
            var imagePath = await _downloadHelper.DownloadAndSaveImage(MainWindow._bindings.WallpaperSource.url.full);
            _wallpaperHelper.SetWallpaper(imagePath);
            _wallpaperHelper.DeleteImage(imagePath);

            StartTimers();
        }

        private void StartTimers()
        {
            schedulerTimer.Stop();

            schedulerTimer.Interval = schedulerInterval * 1000;
            schedulerTimer.Start();
        }

        private async void OnScheduleTimerElapsed(object sender, ElapsedEventArgs e)
        {
            await RunScheduler();
        }
    }
}
