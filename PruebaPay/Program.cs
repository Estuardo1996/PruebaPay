using Core.Interfas;
using Infraestructura.Context;
using Infraestructura.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Data>(options =>
                options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
new MySqlServerVersion(new Version(8, 0, 21))));

builder.Services.AddScoped<IPersona, PersonaRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirOrigenReact",
        policy => policy
            .WithOrigins("http://localhost:3000") // Dirección de tu frontend en React
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("PermitirOrigenReact");

app.UseAuthorization();

app.MapControllers();

app.Run();
