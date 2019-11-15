using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using TrafficLight.Lib.Enums;

namespace TrafficLight.Lib.Tests
{
    [TestFixture]
    public class TrafficLightTests
    {
        TrafficThreeLight trafficLight;
        Mock<IBattery> mock;
        [Test]
        public void Test_Change_Color_To_Red()
        {
            var currentColor = Traffic_Color.Yellow;
            mock = new Mock<IBattery>();
            mock.Setup((bat) => bat.SetPowerState(Power.On));
            IBattery battery = mock.Object;
            trafficLight = new TrafficThreeLight(battery);
            Traffic_Color newColor = trafficLight.ChangeColor(currentColor);
            newColor.Should().Be(Traffic_Color.Red);
        }

        [Test]
        public void Test_Change_Color_To_Yellow()
        {
            var currentColor = Traffic_Color.Green;
            mock = new Mock<IBattery>();
            mock.Setup((bat) => bat.SetPowerState(Power.On));
            IBattery battery = mock.Object;
            trafficLight = new TrafficThreeLight(battery);
            Traffic_Color newColor = trafficLight.ChangeColor(currentColor);
            newColor.Should().Be(Traffic_Color.Yellow);
        }

        [Test]
        public void Test_Change_Color_To_Green()
        {
            var currentColor = Traffic_Color.Red;
            mock = new Mock<IBattery>();
            mock.Setup((bat) => bat.SetPowerState(Power.On));
            IBattery battery = mock.Object;
            trafficLight = new TrafficThreeLight(battery);
            Traffic_Color newColor = trafficLight.ChangeColor(currentColor);
            newColor.Should().Be(Traffic_Color.Green);
        }

        [Test]
        public void CurrentColor_When4_ThrowArgumentException()
        {
            var currentColor = (Traffic_Color)4;
            mock = new Mock<IBattery>();
            mock.Setup((bat) => bat.SetPowerState(Power.On));
            IBattery battery = mock.Object;
            trafficLight = new TrafficThreeLight(battery);
            Assert.Throws<ArgumentOutOfRangeException>(() => trafficLight.ChangeColor(currentColor));
        }

        [Test]
        [TestCase(Traffic_Color.Green, 2)]
        [TestCase(Traffic_Color.Yellow, 2)]
        [TestCase(Traffic_Color.Red, 2)]
        public void Test_Blink_Color_By_Time(Traffic_Color color, int time_To_Blink)
        {
            int delay_Time = 1;
            mock = new Mock<IBattery>();
            mock.Setup((bat) => bat.SetPowerState(Power.On));
            IBattery battery = mock.Object;
            trafficLight = new TrafficThreeLight(battery);
            trafficLight.BlickColor(color, time_To_Blink, delay_Time);
        }

        [Test]
        public void Test_Negative_Blink_Black_Color_Exception()
        {
            var currentColor = Traffic_Color.Black;
            mock = new Mock<IBattery>();
            mock.Setup((bat) => bat.SetPowerState(Power.On));
            IBattery battery = mock.Object;
            trafficLight = new TrafficThreeLight(battery);
            Assert.Throws<ArgumentException>(() => trafficLight.BlickColor(currentColor, 10, 1));
        }

        [Test]
        public void Test_Positive_BatteryOn()
        {
            mock = new Mock<IBattery>();
            mock.Setup((bat) => bat.SetPowerState(Power.On));
            IBattery battery = mock.Object;
            trafficLight = new TrafficThreeLight(battery);
            trafficLight.BatteryOn();
            trafficLight.GetStatus.Should().BeTrue();
        }

        [Test]
        public void Test_Negative_BatteryOn()
        {
            mock = new Mock<IBattery>();
            mock.Setup((bat) => bat.SetPowerState(Power.Off));
            IBattery battery = mock.Object;
            trafficLight = new TrafficThreeLight(battery);
            trafficLight.BatteryOn();
            trafficLight.GetStatus.Should().BeTrue();
        }

    }
}
