using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaCore.Entities
{
    public class Event
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public Guid TankId { get; set; }
        public double WasteLevel { get; set; }

        public User User   { get; set; }
        public Tank Tank { get; set; }
    }
}
