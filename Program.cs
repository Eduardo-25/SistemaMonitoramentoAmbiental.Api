using Microsoft.EntityFrameworkCore;
using SistemaMonitoramentoAmbiental.Infrastructure.Data;
using SistemaMonitoramentoAmbiental.Infrastructure.Repositories;
using SistemaMonitoramentoAmbiental.Interfaces;
using SistemaMonitoramentoAmbiental.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAnalisadorAmbiental, AnalisadorAmbiental>();
builder.Services.AddScoped<IAlertaRepository, AlertaRepository>();
builder.Services.AddScoped<ProcessamentoAmbientalService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();
app.MapControllers();

app.Run();