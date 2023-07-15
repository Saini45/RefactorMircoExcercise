using Moq;
using NUnit.Framework;
using TDDMicroExercises.TelemetrySystem;

namespace TestProjectForTDDMicroExcercises
{
    public class TelemetrySystemTests
    {
        [Test]
        public void CheckTransmission_ValidResponse_NoExceptionThrown()
        {
            var mockTelemetryClient = new Mock<ITelemetryClient>();
            mockTelemetryClient.Setup(c => c.Connect("TelemetryServerConnectionString"));
            mockTelemetryClient.Setup(c => c.Send("DiagnosticRequest"));
            mockTelemetryClient.Setup(c => c.Receive()).Returns("DiagnosticResponse:12345");

            var controls = new TelemetryDiagnosticControls();
            controls.Equals(mockTelemetryClient.Object);
            Assert.DoesNotThrow(() => controls.CheckTransmission());
        }

        [Test]
        public void CheckTransmission_InvalidResponse_ExceptionThrown()
        {
            var mockTelemetryClient = new Mock<ITelemetryClient>();
            mockTelemetryClient.Setup(c => c.Connect("TelemetryServerConnectionString"));
            mockTelemetryClient.Setup(c => c.Send("DiagnosticRequest"));
            mockTelemetryClient.Setup(c => c.Receive()).Returns("InvalidResponse");

            var controls = new TelemetryDiagnosticControls();
            controls.Equals(mockTelemetryClient.Object);
            Assert.Throws<Exception>(() => controls.CheckTransmission());
        }
    }
}
