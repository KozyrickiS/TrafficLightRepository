using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLight.Lib.Enums;

namespace TrafficLight.Lib
{
    public interface IBattery
    {
        void SwitchOn();
        void SwitchOff();
        Power GetPowerState();
        void SetPowerState(Power power);
    }
}
