using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaBLL.Models
{
    public class SensorUpdateModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [DefaultValue(false)]
        public bool Engaged { get; set; } = false;
        public double OnLevel { get; set; }
        public double OffLevel { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        [DefaultValue("Liters")]
        public string Unit { get; set; }
    }
}