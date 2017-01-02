using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Hardcodet.Wpf.TaskbarNotification;

namespace WindowsGameControllerStatus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ControllerStatus : Window
    {
        public ControllerStatus()
        {
            InitializeComponent();

            

        }

        private void setControllerStatusBar(ControllerManager controller) {

            TaskbarIcon tbIcon = (TaskbarIcon)FindResource("tbIcon");

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

            MainWindow.AddChild(tbIcon);
        }
    }
}
