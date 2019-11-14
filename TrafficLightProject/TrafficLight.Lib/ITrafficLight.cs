using System;
using System.Collections.Generic;
using System.Text;
using TrafficLight.Lib.Enums;

namespace TrafficLight.Lib
{
    interface ITrafficLight
    {
        Traffic_Color ChangeColor(Traffic_Color color);
        void BlickColor(Traffic_Color color, int time_To_Blink, int delay_Time);
        void BatteryOn();
        void SwitchingColors(Traffic_Color _traffic_Color);
        bool GetStatus { get; }
    }
}
