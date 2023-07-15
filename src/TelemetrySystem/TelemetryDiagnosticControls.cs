
using System;

namespace TDDMicroExercises.TelemetrySystem
{
    public class TelemetryDiagnosticControls
    {
        private const string DiagnosticChannelConnectionString = "*111#";

        //private readonly TelemetryClient _telemetryClient;
        private readonly ITelemetryClient _ItelemetryClient;
        private string _diagnosticInfo = string.Empty;

        public TelemetryDiagnosticControls()
        {
            _ItelemetryClient = new TelemetryClient();
        }

        public string DiagnosticInfo
        {
            get { return _diagnosticInfo; }
            set { _diagnosticInfo = value; }
        }

        public bool OnlineStatus => throw new NotImplementedException();

        public void CheckTransmission()
        {
            _diagnosticInfo = string.Empty;

            _ItelemetryClient.Disconnect();

            int retryLeft = 3;
            while (_ItelemetryClient.OnlineStatus == false && retryLeft > 0)
            {
                _ItelemetryClient.Connect(DiagnosticChannelConnectionString);
                retryLeft -= 1;
            }
             
            if(_ItelemetryClient.OnlineStatus == false)
            {
                throw new Exception("Unable to connect.");
            }

            _ItelemetryClient.Send(TelemetryClient.DiagnosticMessage);
            _diagnosticInfo = _ItelemetryClient.Receive();
        }
    }
}
