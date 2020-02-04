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
            // reset interval
            schedulerInterval = MainWindow._localSettings.WallpaperSource.interval;

            // set timer for next scheduler run
            MainWindow._bindings.LastUpdated = $"Last updated {DateTime.Now}";
            StartTimers(false);

            // download image, return its path, set as wallpaper and delete
            try
            {
                var imagePath = await _downloadHelper.DownloadAndSaveImage(MainWindow._localSettings.WallpaperSource.url.full);
                // process downloaded image
                if (!imagePath.Any())
                {
                    MainWindow._bindings.ProgramStatus = "Download failed. Retrying shortly...";
                    StartTimers(true);
                }
                else
                {
                    _wallpaperHelper.SetWallpaper(imagePath);

                    if (MainWindow._localSettings.KeepImages)
                        _wallpaperHelper.MoveImage(imagePath);
                    else
                        _wallpaperHelper.DeleteImage(imagePath);
                }
            }
            catch(Exception ex)
            {
                // @TODO add a backoff or counter so this doesn't just retry indefinitly 
                MainWindow._bindings.ProgramStatus = "Network issue. Retrying shortly...";
                StartTimers(true);
            }
        }

        public void PauseScheduler()
        {
            MainWindow._bindings.ProgramStatus = "Paused.";
            schedulerTimer.Stop();
        }

        public void ResumeScheduler()
        {
            MainWindow._bindings.ProgramStatus = "";
            schedulerTimer.Start();
        }

        private void StartTimers(bool fastRetry)
        {
            schedulerTimer.Stop();

            // retry in 10s (in case of download failure) or the source's defined interval
            schedulerTimer.Interval = (fastRetry ? 10 : schedulerInterval) * 1000;
            schedulerTimer.Start();
        }

        private async void OnScheduleTimerElapsed(object sender, ElapsedEventArgs e)
        {
            await RunScheduler();
        }
    }
}
