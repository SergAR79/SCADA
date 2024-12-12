using ScadaBLL.Interfaces;
using ScadaBLL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ScadaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SensorController : ControllerBase
    {
        private readonly ISensorService _service;
        private readonly IHubContext<SensorHub> _hubContext;

        public SensorController(ISensorService service, IHubContext<SensorHub> hubContext)
        {
            _service = service;
            _hubContext = hubContext;
        }

        [HttpGet]
        public async Task<ActionResult> GetSensors()
        {
            var sensors = await _service.GetSensors();

            return Ok(sensors);
        }

        [HttpPost]
        public async Task<ActionResult> CreateSensor(SensorModel model)
        {
            var id = await _service.CreateSensor(model);

            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> SensorUpdate(Guid id, SensorModel model)
        {
            await _service.SensorUpdate(id, model);
            await _hubContext.Clients.All.SendAsync("ReceiveSensorModel",
                model.Id,
                model.Name,
                model.Description,
                model.Engaged,
                model.OnLevel, model.OffLevel,
                model.X, model.Y,
                model.Unit
                );

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSensor(Guid id)
        {
            await _service.DeleteSensor(id);

            return NoContent();
        }
    }
}
