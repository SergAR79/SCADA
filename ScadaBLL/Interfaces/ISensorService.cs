using ScadaBLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ScadaBLL.Interfaces
{
    public interface ISensorService
    {
        Task<Guid> CreateSensor(SensorModel model);
        Task<List<SensorModel>> GetSensors();
        Task DeleteSensor(Guid id);
        Task SensorUpdate(Guid id, SensorModel model);
    }
}