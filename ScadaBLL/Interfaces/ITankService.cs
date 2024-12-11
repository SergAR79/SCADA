using ScadaBLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ScadaBLL.Interfaces
{
    public interface ITankService
    {
        Task SendTankModelAsync(Guid id, double wasteLevel);
    }
}