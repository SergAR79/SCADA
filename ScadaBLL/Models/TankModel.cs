using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaBLL.Models
{
    public class TankModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ThresholdSensor { get; set; }
        public Guid HighLevelSensor { get; set; }
        public Guid AlarmSensor { get; set; }
        public Guid PumpId { get; set; }
        public Guid ValveId { get; set; }
        public double WasteLevel { get; set; } = 0;
        public double Capacity { get; set; }
    }
}
