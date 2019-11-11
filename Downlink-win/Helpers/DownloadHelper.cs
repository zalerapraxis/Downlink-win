using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Downlink_win
{
    class DownloadHelper
    {
        public async Task<string> DownloadAndSaveImage(string url)
        {
            // get filename & make a path
            var uri = new Uri(url);
            var fileName = Path.GetFileName(uri.LocalPath);
            var filePath = Path.Combine(Environment.CurrentDirectory, fileName);

            using (WebClient client = new WebClient())
            {
                client.DownloadProgressChanged += Client_DownloadProgressChanged1;
                client.DownloadFileCompleted += Client_DownloadFileCompleted;
                await client.DownloadFileTaskAsync(url, fileName);
            }

            return filePath;
        }

        private void Client_DownloadProgressChanged1(object sender, DownloadProgressChangedEventArgs e)
        {
            MainWindow._bindings.ProgramStatus =
                $"{e.ProgressPercentage}% ({e.BytesReceived} / {e.TotalBytesToReceive})";
        }

        private void Client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            MainWindow._bindings.ProgramStatus = "";
        }
    }
}
