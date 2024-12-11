using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ScadaCore.Options
{
    public class DbOptions  
    {
        public string ConnectionString { get; set; } =
        "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog = ScadaDB; Integrated Security = True;" +
            " Connect Timeout = 30; Encrypt=False;Trust Server Certificate=False;" +
            "Application Intent = ReadWrite; Multi Subnet Failover=False";
    }
}
