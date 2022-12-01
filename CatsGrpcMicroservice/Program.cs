using CatsGrpcMicroservice.Models;
using CatsGrpcMicroservice.Repositories;
using CatsGrpcMicroservice.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddDbContext<CatsDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                        providerOptions => { providerOptions.EnableRetryOnFailure(); });
    options.LogTo(Console.WriteLine);
    options.EnableDetailedErrors();
    options.EnableSensitiveDataLogging();
});
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
builder.Services.AddScoped<ICatsGrpcRepository, CatsGrpcRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<CatsService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
