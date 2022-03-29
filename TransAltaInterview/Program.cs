using Microsoft.EntityFrameworkCore;
using TransAltaInterview.Services;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<TransAltaInterview.DbContexts.TransAltaDbContext>(cfg => cfg.UseSqlServer("Server=tcp:interviewdbserver2022.database.windows.net,1433;Initial Catalog=InterviewDb;Persist Security Info=False;User ID=interviewadmin;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
builder.Services.AddScoped<TransAltaInterview.Interfaces.IWeatherForecastService, TransAltaInterview.Services.WeatherForecastService>();
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutoMapperProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddHttpClient();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
