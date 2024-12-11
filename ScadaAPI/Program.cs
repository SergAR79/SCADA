using ScadaAPI.Controllers;
using ScadaBLL.Interfaces;
using ScadaBLL.Services;
using ScadaCore.Constants;
using ScadaCore.Options;
using ScadaCore.Entities;
using ScadaDAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ScadaDAL.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSignalR();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAll",
                      policy =>
                      {
                          policy.WithOrigins("http://127.0.0.1:5500");
                          policy.AllowAnyHeader();
                          policy.AllowAnyMethod();
                          policy.AllowCredentials();
                      });

});

builder.Services.Configure<DbOptions>(
    builder.Configuration.GetSection(
        OptionsConstants.DbOptionsKey));

builder.Services.AddDbContext<ScadaDbContext>((provider, ctx) =>
{
    var options = provider.GetRequiredService<IOptions<DbOptions>>().Value;
    ctx.UseSqlServer(options.ConnectionString);
    Console.WriteLine(options.ConnectionString); 
});

builder.Services.AddScoped<ISensorService, SensorService>();
builder.Services.AddScoped<IBackgroundImageService, BackgroundImageService>();
//builder.Services.AddScoped<ITankService, TankService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapHub<SensorHub>("/sensor");
app.MapHub<TankHub>("/tank");

app.MapControllers();

app.Run();