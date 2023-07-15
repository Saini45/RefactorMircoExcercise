using System;
using TDDMicroExercises.TirePressureMonitoringSystem;
using NUnit.Framework;
using Moq;
using TDDMicroExercises.TelemetrySystem;

namespace TestProjectForTDDMicroExcercises
{
    public class TirePressureMonitoringSystemTests
    {
        [Test]
        public void Check_LowPressure_AlarmOn()
        {
            var mockSensor = new Mock<ISensor>();
            mockSensor.Setup(s => s.PopNextPressurePsiValue()).Returns(16);
            var alarm = new Alarm();
            alarm.Equals(mockSensor.Object);
            alarm.Check();
            Assert.IsTrue(alarm.AlarmOn);
        }

        [Test]
        public void Check_NormalPressure_AlarmOff()
        {
            var mockSensor = new Mock<ISensor>();
            mockSensor.Setup(s => s.PopNextPressurePsiValue()).Returns(19);
            var alarm = new Alarm();
            alarm.Equals(mockSensor.Object);
            alarm.Check();
            Assert.IsFalse(alarm.AlarmOn);
        }

        [Test]
        public void Check_HighPressure_AlarmOn()
        {
            var mockSensor = new Mock<ISensor>();
            mockSensor.Setup(s => s.PopNextPressurePsiValue()).Returns(30);
            var alarm = new Alarm();
            alarm.Equals(mockSensor.Object);
            alarm.Check();
            Assert.IsTrue(alarm.AlarmOn);
        }
    }
}
