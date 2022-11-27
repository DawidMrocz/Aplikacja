using InboxMicroservice;
using InboxMicroservice.Consumers;
using InboxMicroservice.Models;
//using InboxMicroservice.OrderGrpcService;
using InboxMicroservice.Repositories;
using InboxMicroservice.Settings;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
//using OrderMicroservice.Grpc.Protos;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var authenticationSettings = new AuthenticationSettings();
builder.Services.AddSingleton(authenticationSettings);
builder.Configuration.GetSection("Authentication").Bind(authenticationSettings);
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = "Bearer";
    option.DefaultScheme = "Bearer";
    option.DefaultChallengeScheme = "Bearer";
}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = authenticationSettings.JwtIssuer,
        ValidAudience = authenticationSettings.JwtIssuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey)),
    };
});

builder.Services.AddControllers();
builder.Services.AddDbContext<InboxDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                        providerOptions => { providerOptions.EnableRetryOnFailure(); });
    options.LogTo(Console.WriteLine);
    options.EnableDetailedErrors();
    options.EnableSensitiveDataLogging();
});

//builder.Services.AddGrpcClient<OrderProtoService.OrderProtoServiceClient>
//                        (o => o.Address = new Uri("http://ordermicroservice:80"));
//builder.Services.AddScoped<MyOrderGrpcService>();

var rabbitMqSettings = builder.Configuration.GetSection(nameof(RabbitMqSettings)).Get<RabbitMqSettings>();
builder.Services.AddMassTransit(busConfigurator =>
{
    busConfigurator.AddConsumer<CreateInboxItemConsumer>();
    busConfigurator.AddConsumer<CreateUserInboxConsumer>();
    busConfigurator.AddConsumer<DeleteInboxItemConsumer>();
    busConfigurator.AddConsumer<DeleteUserInboxConsumer>();
    busConfigurator.AddConsumer<UpdateInboxItemConsumer>();
    busConfigurator.AddConsumer<UpdateUserInboxConsumer>();
    busConfigurator.SetKebabCaseEndpointNameFormatter();
    busConfigurator.UsingRabbitMq((context, busFactoryConfiguration) =>
    {
        busFactoryConfiguration.Host(rabbitMqSettings.Uri);
        busFactoryConfiguration.ConfigureEndpoints(context);
    });
});
//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
//builder.Services.AddMediator(x =>
//{
//    x.AddConsumersFromNamespaceContaining<CreateUserInboxItemConsumer>();

//    x.AddRequestClient<CreateUserInboxItem>();
//});
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
builder.Services.AddScoped<IInboxRepository, InboxRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();