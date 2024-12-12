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
    public class SensorService : ISensorService
    {
        private readonly ScadaDbContext context;

        public SensorService(ScadaDbContext context)
        {
            this.context = context;
        }

        public async Task<Guid> CreateSensor(SensorModel model)
        {
            var sensor = new Sensor()
            {
                Name = model.Name,
                Description = model.Description,
                Engaged = model.Engaged,
                OnLevel = model.OnLevel,
                OffLevel = model.OffLevel,
                X = model.X,
                Y = model.Y,
                Unit = model.Unit
            };

            context.Add(sensor);
            await context.SaveChangesAsync();

            return sensor.Id;
        }

        public async Task DeleteSensor(Guid id)
        {
            var sensor = await context.Sensors.FirstOrDefaultAsync(x => x.Id == id);

            if (sensor is null)
            {
                return;
            }

            context.Remove(sensor);

            await context.SaveChangesAsync();
        }

        public async Task<List<SensorModel>> GetSensors()
        {
            return await context.Sensors
                .Select(s => new SensorModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    Engaged = s.Engaged,
                    OnLevel = s.OnLevel,
                    OffLevel = s.OffLevel,
                    X = s.X,
                    Y = s.Y,
                    Unit = s.Unit
                })
                .ToListAsync();
        }

        public async Task SensorUpdate(Guid id, SensorModel model)
        {
            var sensor = await context.Sensors.FindAsync(id);
            if (sensor == null)
            {
                return;
            }

            if (model.Name != null) sensor.Name = model.Name;
            if (model.Description != null) sensor.Description = model.Description;
            if (model.Engaged != null) sensor.Engaged = model.Engaged;
            if (model.OnLevel != null) sensor.OnLevel = model.OnLevel;
            if (model.OffLevel != null) sensor.OffLevel = model.OffLevel;
            if (model.X != null) sensor.X = model.X;
            if (model.Y != null) sensor.Y = model.Y;
            if (model.Unit != null) sensor.Unit = model.Unit;

            context.Sensors.Update(sensor);
            await context.SaveChangesAsync();

            //return true;
        }
    }
}