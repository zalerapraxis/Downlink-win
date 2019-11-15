using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Application = System.Windows.Application;

namespace Downlink_win
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private System.Windows.Forms.NotifyIcon _notifyIcon;
        private bool _isExit;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow = new MainWindow();
            MainWindow.Closing += MainWindow_Closing;

            Downlink_win.MainWindow._settingsHelper.LoadSettings();

            _notifyIcon = new System.Windows.Forms.NotifyIcon();
            _notifyIcon.DoubleClick += (s, args) => ShowMainWindow();
            _notifyIcon.Icon = Downlink_win.Properties.Resources.AppIcon;
            _notifyIcon.Visible = true;

            CreateContextMenu();
        }

        private void CreateContextMenu()
        {
            _notifyIcon.ContextMenuStrip =
                new System.Windows.Forms.ContextMenuStrip();

            _notifyIcon.ContextMenuStrip.Items.Add($"{Downlink_win.Properties.Settings.Default.WallpaperSource}").Enabled = false;
            _notifyIcon.ContextMenuStrip.Items.Add("Select source").Click += (s, e) => ShowMainWindow();
            _notifyIcon.ContextMenuStrip.Items.Add("Keep images").Click += (s, e) => ContextMenuKeepImagesToggle();

            _notifyIcon.ContextMenuStrip.Items.Add(new ToolStripSeparator());

            _notifyIcon.ContextMenuStrip.Items.Add("Refresh now").Click += async (s, e) => await Downlink_win.MainWindow._scheduler.RunScheduler();
            _notifyIcon.ContextMenuStrip.Items.Add("Pause").Click += (s, e) => ContextMenuPauseScheduler();

            _notifyIcon.ContextMenuStrip.Items.Add(new ToolStripSeparator());

            _notifyIcon.ContextMenuStrip.Items.Add("Exit").Click += (s, e) => ExitApplication();


            // set keep images checkbox depending on loaded settings
            var itemIndex = FindContextMenuItemByText("Keep images");
            if (itemIndex == null)
                return;
            if (Downlink_win.Properties.Settings.Default.KeepImages)
                (_notifyIcon.ContextMenuStrip.Items[itemIndex.Value] as ToolStripMenuItem).Checked = true;
        }

        private void ExitApplication()
        {
            _isExit = true;
            MainWindow.Close();
            _notifyIcon.Dispose();
            _notifyIcon = null;

            Downlink_win.MainWindow._settingsHelper.SaveSettings();
        }

        private void ShowMainWindow()
        {
            if (MainWindow.IsVisible)
            {
                if (MainWindow.WindowState == WindowState.Minimized)
                {
                    MainWindow.WindowState = WindowState.Normal;
                }
                MainWindow.Activate();
            }
            else
            {
                MainWindow.Show();
            }
        }

        private void ContextMenuPauseScheduler()
        {
            var itemIndex = FindContextMenuItemByText("Pause");
            if (itemIndex == null)
                return;

            _notifyIcon.ContextMenuStrip.Items[itemIndex.Value].Text = "Resume";
            _notifyIcon.ContextMenuStrip.Items[itemIndex.Value].Click += (s, e) => ContextMenuResumeScheduler();
            Downlink_win.MainWindow._scheduler.PauseScheduler();
        }

        private void ContextMenuResumeScheduler()
        {
            var itemIndex = FindContextMenuItemByText("Resume");
            if (itemIndex == null)
                return;

            _notifyIcon.ContextMenuStrip.Items[itemIndex.Value].Text = "Pause";
            _notifyIcon.ContextMenuStrip.Items[itemIndex.Value].Click += (s, e) => ContextMenuPauseScheduler();
            Downlink_win.MainWindow._scheduler.ResumeScheduler();
        }

        private void ContextMenuKeepImagesToggle()
        {
            var itemIndex = FindContextMenuItemByText("Keep images");
            if (itemIndex == null)
                return;

            var contextMenuItem = (_notifyIcon.ContextMenuStrip.Items[itemIndex.Value] as ToolStripMenuItem);
            bool shouldKeepImages = Downlink_win.MainWindow._localSettings.KeepImages ? false : true;
            
            contextMenuItem.Checked = shouldKeepImages;
            Downlink_win.MainWindow._settingsHelper.ToggleKeepImages(shouldKeepImages);
        }

        private int? FindContextMenuItemByText(string searchText)
        {
            var i = 0;
            foreach (ToolStripItem item in _notifyIcon.ContextMenuStrip.Items)
            {
                if (item.Text == searchText)
                    return i;

                i++;
            }

            // if item wasn't found
            return null;
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            if (!_isExit)
            {
                e.Cancel = true;
                MainWindow.Hide(); // A hidden window can be shown again, a closed one not
            }
        }
    }
}
