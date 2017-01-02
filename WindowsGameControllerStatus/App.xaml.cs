using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Hardcodet.Wpf.TaskbarNotification;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Input;

namespace WindowsGameControllerStatus
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private TaskbarIcon tbIcon;
        private static System.Timers.Timer refreshTimer;
        ControllerManager controller;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //initialize tbIcon
            tbIcon = (TaskbarIcon)FindResource("tbIcon");
            controller = new ControllerManager();

            // Find the "close application" menu item
            System.Windows.Controls.MenuItem closeAppMenuItem = 
                (
                    from System.Windows.Controls.MenuItem item in tbIcon.ContextMenu.Items
                        where item.Name.Equals("tbIconClose")
                        select item
                ).FirstOrDefault();

            closeAppMenuItem.Click += CloseApplication;

            refreshTimer = new System.Timers.Timer(10000);

            // Execute initial battery query
            setControllerStatusBar();

            // Query battery state every 10s
            refreshTimer.Elapsed += OnTimedEvent;

            refreshTimer.Enabled = true;
        }

        private void CloseApplication(object sender, RoutedEventArgs args)
        {
            Application.Current.Shutdown();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            tbIcon.Dispose();
            base.OnExit(e);
        }

        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e) {
            this.Dispatcher.Invoke(() =>
                {
                    setControllerStatusBar();
                });
        }

        private void setControllerStatusBar()
        {

            if (controller.IsConnected())
            {
                string tooltipText = "Controller Battery: ",
                       iconLocation = "";

                switch (controller.GetBatteryLevel())
                {
                    case SlimDX.XInput.BatteryLevel.Full:
                        tooltipText += "Full";
                        iconLocation += "full";
                        break;

                    case SlimDX.XInput.BatteryLevel.Medium:
                        tooltipText += "Medium";
                        iconLocation += "medium";
                        break;

                    case SlimDX.XInput.BatteryLevel.Low:
                        tooltipText += "Low";
                        iconLocation += "low";
                        break;

                    case SlimDX.XInput.BatteryLevel.Empty:
                        tooltipText += "Empty";
                        iconLocation += "empty";
                        break;
                }

                tbIcon.ToolTipText = tooltipText;
                tbIcon.IconSource = new BitmapImage(new Uri("pack://application:,,,/Resources/" + iconLocation + "-battery.ico"));
            }

            else
            {
                tbIcon.ToolTipText = "Xbox controller not connected as Player 1, or not at all.";
                tbIcon.IconSource = new BitmapImage(new Uri("pack://application:,,,/Resources/not-connected.ico"));
            }
        }

        
    }
}
