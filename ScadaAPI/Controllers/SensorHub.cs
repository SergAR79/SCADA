using ScadaBLL.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace ScadaAPI.Controllers
{
    public class SensorHub : Hub
    {
        private readonly ISensorService sensorService;

        public SensorHub(ISensorService service)
        {
            sensorService = service;
        }

        //public async Task SendValue(string id, string value)
        //{
        //    await sensorService.UpdateSensorValue(new()
        //    {
        //        Id = Guid.Parse(id),
        //        Value = value
        //    });

        //    await this.Clients.Others.SendAsync("receive", id, value);
        //}
    }
}
