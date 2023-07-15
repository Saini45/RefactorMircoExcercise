namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class Alarm
    {
        private const double LowPressureThreshold = 17;
        private const double HighPressureThreshold = 21;

        //readonly Sensor _sensor = new Sensor();
        private readonly ISensor _sensor;
        bool _alarmOn = false;
        public Alarm(ISensor sensor)
        {
            //this._sensor = new Sensor();
            this._sensor = sensor;
            //_alarmOn = false;
        }
        public Alarm()
        {
        }
        public void Check()
        {
            double psiPressureValue = _sensor.PopNextPressurePsiValue();

            if (psiPressureValue < LowPressureThreshold || HighPressureThreshold < psiPressureValue)
            {
                _alarmOn = true;
            }
        }

        public bool AlarmOn
        {
            get { return _alarmOn; }
        }

    }
}
