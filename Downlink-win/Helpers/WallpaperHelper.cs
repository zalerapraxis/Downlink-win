using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Downlink_win.Helpers;

namespace Downlink_win
{
    class WallpaperHelper
    {
        WallpaperApi _wallpaperApi = new WallpaperApi();

        public void SetWallpaper(string path)
        {
            _wallpaperApi.EnableTransitions();
            _wallpaperApi.SetWallpaper(path);
        }

        public void DeleteImage(string path)
        {
            File.Delete(path);
        }

        public void MoveImage(string path)
        {
            var dirName = "Saved images";
            var fileExtension = Path.GetExtension(path);
            if (!Directory.Exists(dirName))
            {
                Directory.CreateDirectory(dirName);
            }
            File.Move(path, Path.Combine(dirName, $"{MainWindow._localSettings.WallpaperSource.name} - {DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss")}{fileExtension}"));
        }
    }
}
