using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public interface ISensor
    {
        bool AlarmOn { get; }
        double PopNextPressurePsiValue();
        double ReadPressureSample();
    }
}
