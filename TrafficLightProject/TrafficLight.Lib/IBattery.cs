using System;
using System.Collections.Generic;
using System.Text;
using TrafficLight.Lib.Enums;

namespace TrafficLight.Lib
{
    interface IBattery
    {
        void SwitchOn();
        void SwitchOff();
        Power GetPowerState();
        void SetPowerState(Power power);
    }
}
