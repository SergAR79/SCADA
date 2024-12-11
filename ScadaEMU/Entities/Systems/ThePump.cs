using ScadaBLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaEMU.Entities.Pumps
{
    public class ThePump : PumpModel
    {
        public bool IsOn{ get; private set; }
        public int Id { get; set; }

        public void TurnOn()
        {
            if (!IsOn)
            {
                Form1.tank1.echo($"The {Id} pump is running");
                IsOn = true;
            }
        }

        public void TurnOff()
        {
            if (IsOn)
            {
                Form1.tank1.echo($"The {Id} pump is stopped");
                IsOn = false;
            }
        }
    }
}
