using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaCore.Entities
{
    public class Sensor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Engaged { get; set; } = false;
        public double OnLevel { get; set; }
        public double OffLevel { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string Unit { get; set; } = "Liters";

        //public List<SensorValue> SensorValues { get; set; } = new List<SensorValue>();

        public virtual List<Tank> TanksS { get; set; } = new List<Tank>();
        public virtual List<Tank> TanksH { get; set; } = new List<Tank>();
        public virtual List<Tank> TanksA { get; set; } = new List<Tank>();
    }
}
