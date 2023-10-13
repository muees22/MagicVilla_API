

using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Looging;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Below code is used to add custoomised serilized logs in application and also instal two packages (Serilog.Sinks.File and  srilog)
//Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.File("log/villalogs.txt", rollingInterval:RollingInterval.Day).CreateLogger(); 
//builder.Host.UseSerilog();
builder.Services.AddDbContext<ApplicationDbContext>(options => { options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection")); });

builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;
}).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddSingleton<ILogging, LoggingV2>();

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
