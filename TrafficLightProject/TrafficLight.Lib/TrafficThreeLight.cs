using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLight.Lib.Enums;

namespace TrafficLight.Lib
{
    public class TrafficThreeLight : ITrafficLight
    {
        const int RED_TIME = 30;
        const int YELLOW_TIME = 4;
        const int GREEN_TIME = 25;
        const int BLINK_TIME = 5;
        const int DELAY_TIME = 1000;
        private IBattery _battery;
        private bool _status;
        public TrafficThreeLight(IBattery battery)
        {
            _battery = battery;
            _status = _battery.GetPowerState() == Power.On ? true : false;
        }
        public bool GetStatus => _status;

        public Traffic_Color ChangeColor(Traffic_Color currentColor)
        {
            if (!Enum.IsDefined(typeof(Traffic_Color), currentColor))
                throw new ArgumentOutOfRangeException(nameof(currentColor));
            switch (currentColor)
            {
                case Traffic_Color.Red:
                    return Traffic_Color.Green;
                case Traffic_Color.Yellow:
                    return Traffic_Color.Red;
                case Traffic_Color.Green:
                    return Traffic_Color.Yellow;
            }
            return currentColor;
        }

        public void BlickColor(Traffic_Color color, int time_To_Blink, int delay_Time)
        {
            if (color == Traffic_Color.Black)
                throw new ArgumentException(nameof(color));
            Traffic_Color display_Color;
            for (int i = 0; i < time_To_Blink; i++)
            {
                if (i % 2 == 0)
                {
                    display_Color = color;
                }
                else
                {
                    display_Color = Traffic_Color.Black;
                }
                System.Threading.Thread.Sleep(delay_Time);
            }
        }

        public void BatteryOn()
        {
            if (_status == false)
            {
                _battery.SetPowerState(Power.On);
            }
        }

        public void SwitchingColors(Traffic_Color _start_traffic_Color)
        {
            Traffic_Color traffic_Color = _start_traffic_Color;
            BatteryOn();
            switch (traffic_Color)
            {
                case Traffic_Color.Green:
                    System.Threading.Thread.Sleep(GREEN_TIME * 1000);
                    ChangeColor(traffic_Color);
                    break;
                case Traffic_Color.Red:
                    System.Threading.Thread.Sleep(RED_TIME * 1000);
                    ChangeColor(traffic_Color);
                    break;
                case Traffic_Color.Yellow:
                    System.Threading.Thread.Sleep(YELLOW_TIME * 1000);
                    ChangeColor(traffic_Color);
                    break;
            }
            if (_battery.GetPowerState() == Power.On)
            {
                SwitchingColors(traffic_Color);
            }
        }

        public void YellowBlicking(int blickingTime)
        {
            Traffic_Color color = Traffic_Color.Yellow;
            BlickColor(color, blickingTime, DELAY_TIME);
        }

    }
}
