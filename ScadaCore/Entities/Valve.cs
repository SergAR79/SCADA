using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScadaCore.Constants;

namespace ScadaCore.Entities
{
    public class Valve
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }
        public double FillingSpeed { get; set; } = OptionsConstants.FillingSpeed;

        public List<Tank> Tanks { get; set; } = new List<Tank>();
    }
}
