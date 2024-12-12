using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaCore.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } = string.Empty;
        public int Rank { get; set; } = 0x0F;

        public List<Event> Events { get; set; } = new List<Event>();
    }
}
