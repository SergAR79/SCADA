using Microsoft.AspNet.SignalR;
using Microsoft.EntityFrameworkCore;
using ScadaBLL.Interfaces;
using ScadaBLL.Models;
using ScadaCore.Entities;
using ScadaDAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaBLL.Services
{
    public class TankService : ITankService
    {
        private readonly IHubContext _hubcontext;

        public TankService(IHubContext hubcontext)
        {
            _hubcontext = hubcontext;
        }

        public async Task SendTankModelAsync(Guid TankId, double wasteLevel)
        {
            await _hubcontext.Clients.All.SendAsync("ReceiveTankModel", TankId, wasteLevel);
        }
    }
}