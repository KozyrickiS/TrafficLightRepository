using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLight.Lib.Enums;

namespace TrafficLight.Lib
{
    public class Battery : IBattery
    {
        public Power powerState { get; private set; }
        public void SwitchOn()
        {
            powerState = Power.On;
        }

        public void SwitchOff()
        {
            powerState = Power.Off;
        }
        public Power GetPowerState()
        {
            return powerState;
        }
        public void SetPowerState(Power power)
        {
            this.powerState = power;
        }
    }
}
