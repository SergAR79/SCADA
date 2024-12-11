using ScadaBLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaEMU.Entities.Systems
{
    public class TheValve : ValveModel
    {
        public bool IsOn { get; private set; }
        public int Id { get; set; }

        public void TurnOn()
        {
            if (!IsOn)
            {
                Form1.tank1.echo($"The valve{Id} is opened");
                IsOn = true;
            }
        }

        public void TurnOff()
        {
            if (IsOn)
            {
                Form1.tank1.echo($"The valve{Id} is closed");
                IsOn = false;
            }
        }
    }
}
