using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLight.Lib.Enums;

namespace TrafficLight.Lib
{
    public interface ITrafficLight
    {
        Traffic_Color ChangeColor(Traffic_Color color);
        void BlickColor(Traffic_Color color, int time_To_Blink, int delay_Time);
        void BatteryOn();
        void SwitchingColors(Traffic_Color _traffic_Color);
        bool GetStatus { get; }
    }
}
