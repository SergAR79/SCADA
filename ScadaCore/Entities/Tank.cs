using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaCore.Entities
{
    public class Tank
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ThresholdSensorId { get; set; }
        public Guid HighLevelSensorId { get; set; }
        public Guid AlarmSensorId { get; set; }
        public Guid PumpId { get; set; }
        public Guid ValveId { get; set; }
        public double WasteLevel { get; set; } = 0;
        public double Capacity { get; set; } = 0;

        public Sensor ThresholdSensor { get; set; }
        public Sensor HighLevelSensor { get; set; }
        public Sensor AlarmSensor { get; set; }
        public Pump Pump { get; set; }
        public Valve Valve { get; set; }

        public List<Event> Events { get; set; } = new List<Event>();
    }
}
