using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaBLL.Models
{
    public class EventModel
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public Guid TankId { get; set; }
        public double WasteLevel { get; set; }
    }
}
