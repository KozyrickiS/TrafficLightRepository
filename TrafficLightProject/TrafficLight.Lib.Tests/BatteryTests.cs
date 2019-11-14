using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using TrafficLight.Lib.Enums;

namespace TrafficLight.Lib.Tests
{
    [TestFixture]
    public class BatteryTests
    {
        Battery battery = new Battery();

        [Test]
        public void Test_Positive_SwitchOn()
        {            
            battery.SwitchOn();
            battery.GetPowerState().Should().Be(Power.On);
        }

        [Test]
        public void Test_Positive_SwitchOff()
        {
            battery.SwitchOff();
            battery.GetPowerState().Should().Be(Power.Off);
        }

        [Test]
        public void Test_Positive_Set_PowerState()
        {
            battery.SwitchOff();
            battery.SetPowerState(Power.On);
            battery.GetPowerState().Should().Be(Power.On);
        }
    }
}
