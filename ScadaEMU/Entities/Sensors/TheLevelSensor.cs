using ScadaBLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaEMU.Entities.Sensors
{
    public class TheLevelSensor : SensorModel
    {
        public TheLevelSensor(string name, string description, double onlevel, double offlevel) { }

        public void CheckLevel(double Value)
        {
            if (Value >= OnLevel && !Engaged)
            {
                Engaged = true;
            }
            else if (Value < OffLevel && Engaged)
            {
                Engaged = false;
            }
            Form1.tank1.echo($"{Name} engaged: {Engaged}");
        }
    }
}
