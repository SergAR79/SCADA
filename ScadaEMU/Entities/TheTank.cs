using ScadaEMU.Entities.Pumps;
using ScadaEMU.Entities.Sensors;
using ScadaEMU.Entities.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaEMU.Entities
{
    public class TheTank
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Level { get; set; }
        public List<TheLevelSensor> Sensors { get; set; }
        public ThePump Pump { get; set; }
        public TheValve Valve { get; set;}

        public TheTank()
        {
            Sensors = new List<TheLevelSensor>();
            Pump = new ThePump();
            Valve = new TheValve();
        }

        public void Monitor() 
        {
            foreach (var sensor in Sensors)
            {
                sensor.CheckLevel(Level);
            }

            TheLevelSensor sThreshold = Sensors.FirstOrDefault(s => s.Name == "EmptyLevel");
            TheLevelSensor sHigh = Sensors.FirstOrDefault(s => s.Name == "HighLevel");
            TheLevelSensor sAlarm = Sensors.FirstOrDefault(s => s.Name == "AlarmLevel");

            if(sHigh.Engaged)
            {
                Pump.TurnOn();
            }

            if (Pump.IsOn)
            {
                if(sThreshold.Engaged) Level -= ScadaCore.Constants.OptionsConstants.PumpingSpeed;
                else
                    {
                        Pump.TurnOff();
                        Valve.TurnOn();
                    }
            }

            if (Valve.IsOn)
            {
                if(!sAlarm.Engaged) Level += ScadaCore.Constants.OptionsConstants.FillingSpeed;
                else
                { 
                    Valve.TurnOff();
                    Pump.TurnOn();
                }
            }

        }
    }
}
