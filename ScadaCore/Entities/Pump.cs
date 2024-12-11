using ScadaCore.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaCore.Entities
{
    public class Pump
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }
        public double PumpingSpeed { get; set; } = OptionsConstants.PumpingSpeed;

        public List<Tank> Tanks { get; set; } = new List<Tank>();
    }
}
