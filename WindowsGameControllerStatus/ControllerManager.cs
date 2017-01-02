using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlimDX.XInput;

namespace WindowsGameControllerStatus
{
    partial class ControllerManager
    {
        private Controller controller = new Controller(UserIndex.One);

        public ControllerManager() { }

        public BatteryLevel GetBatteryLevel() { return controller.GetBatteryInformation(BatteryDeviceType.Gamepad).Level; }
        public bool IsConnected() { return controller.IsConnected; }
    }
}
