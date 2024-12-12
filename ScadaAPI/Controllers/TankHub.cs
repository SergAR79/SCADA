using ScadaBLL.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace ScadaAPI.Controllers
{
    public class TankHub : Hub
    {
        private readonly ITankService tankService;

        public TankHub(ITankService service)
        {
            tankService = service;
        }

        public async Task SendTankModelAsync(Guid tankId, double wasteLevel)
        {
            await Clients.All.SendAsync("ReceiveTankModel", tankId, wasteLevel);
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
