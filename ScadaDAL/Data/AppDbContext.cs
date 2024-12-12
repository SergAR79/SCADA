using Microsoft.EntityFrameworkCore;
using System.Linq;
using ScadaCore.Entities;

namespace ScadaDAL.Data
{
    public class ScadaDbContext : DbContext
    {
        public DbSet<User>? Users { get; set; }
        public DbSet<Valve>? Valves { get; set; }
        public DbSet<Pump>? Pumps { get; set; }
        public DbSet<Sensor>? Sensors { get; set; }
        public DbSet<Tank>? Tanks { get; set; }
        public DbSet<Event>? Events { get; set; }
        public DbSet<BackgroundImage> BackgroundImages { get; set; }


        public ScadaDbContext(DbContextOptions<ScadaDbContext> options)
           : base(options)
        {
        }

        public static Guid Tank_Id = Guid.NewGuid();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<User>()
                .HasMany(e => e.Events)
                .WithOne(u => u.User)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Tank>()
                .HasMany(e => e.Events)
                .WithOne(t => t.Tank)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Valve>()
                .HasMany(e => e.Tanks)
                .WithOne(v => v.Valve)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Pump>()
                .HasMany(e => e.Tanks)
                .WithOne(p => p.Pump)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Sensor>()
                .HasMany(e => e.TanksS)
                .WithOne(s => s.ThresholdSensor)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Sensor>()
                .HasMany(e => e.TanksH)
                .WithOne(h => h.HighLevelSensor)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Sensor>()
                .HasMany(e => e.TanksA)
                .WithOne(a => a.AlarmSensor)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BackgroundImage>()
                .HasData(
                new BackgroundImage
                {
                    Id = 1,
                    Bytes = File.ReadAllBytes("Resources/back.jpg")
                });

            var V_Id = Guid.NewGuid();
            modelBuilder.Entity<Valve>()
                .HasData(
                new Valve
                {
                    Id = V_Id,
                    Name = "Inlet valve",
                    Description = "This valve shutts off the incoming flow",
                    Enabled = false,
                    FillingSpeed = 3.13
                });

            var P_Id = Guid.NewGuid();
            modelBuilder.Entity<Pump>()
                .HasData(
                new Pump
                {
                    Id = P_Id,
                    Name = "Drain pump",
                    Description = "Running When the high waste level is reached",
                    Enabled = false,
                    PumpingSpeed = 11.87
                });

            var A_Id = Guid.NewGuid();
            var H_Id = Guid.NewGuid();
            var T_Id = Guid.NewGuid();
            modelBuilder.Entity<Sensor>()
                .HasData(
                new Sensor
                {
                    Id = A_Id,
                    Name = "AlarmLevel",
                    Description = "Engaged When the waste level is above critical",
                    Engaged = false,
                    OnLevel = 244,
                    OffLevel = 222,
                    X = 11,
                    Y = 222,
                    Unit = "liters"
                },
                new Sensor
                {
                    Id = H_Id,
                    Name = "HighLevel",
                    Description = "Engaged When the waste level is too high",
                    Engaged = false,
                    OnLevel = 211,
                    OffLevel = 191,
                    X = 11,
                    Y = 191,
                    Unit = "liters"
                },
                new Sensor
                {
                    Id = T_Id,
                    Name = "ThresholdLevel",
                    Description = "Engaged When the waste level is no longer too low",
                    Engaged = false,
                    OnLevel = 22,
                    OffLevel = 11,
                    X = 11,
                    Y = 11,
                    Unit = "liters"
                });

            //var Tank_Id = Guid.NewGuid();
            modelBuilder.Entity<Tank>()
                .HasData(
                new Tank
                {
                    Id = Tank_Id,
                    Name = "Waste container 1",
                    Description = "Plastic waste container",
                    ThresholdSensorId = T_Id,
                    HighLevelSensorId = H_Id,
                    AlarmSensorId = A_Id,
                    PumpId = P_Id,
                    ValveId = V_Id,
                    WasteLevel = 0.01,
                    Capacity = 250
                });

            var User_Id = Guid.NewGuid();
            modelBuilder.Entity<User>()
                .HasData(
                new User
                {
                    Id = User_Id,
                    Name = "Admin",
                    Email = "admin@scada.net",
                    Password = "*****",
                    Rank = 0xF0
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Supervisor",
                    Email = "supervisor@scada.net",
                    Password = "*****",
                    Rank = 0b01111000
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Adjuster",
                    Email = "adjuster@scada.net",
                    Password = "*****",
                    Rank = 0b00111100
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Technician",
                    Email = "technician@scada.net",
                    Password = "*****",
                    Rank = 0b00011110
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Worker",
                    Email = "worker@scada.net",
                    Password = "*****",
                    Rank = 0x0F
                });

            modelBuilder.Entity<Event>()
                .HasData(
                new Event
                {
                    Id = Guid.NewGuid(),
                    CreationDate = DateTime.Now,
                    Description = DateTime.Now + ":  Logging started",
                    UserId = User_Id,
                    TankId = Tank_Id,
                    WasteLevel = 0.01
                });
        }
    }
}
