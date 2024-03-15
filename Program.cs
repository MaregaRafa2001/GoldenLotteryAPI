using GoldenLotteryAPI.Controllers.Core;
using GoldenLotteryAPI.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    //options.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    // Configurar a autenticação para o Swagger UI
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "JWT Authorization header using the Bearer scheme",
        Type = SecuritySchemeType.ApiKey,
        In = ParameterLocation.Header,
        Scheme = "Bearer",
    };

    options.AddSecurityDefinition("Bearer", securityScheme);

    var securityRequirement = new OpenApiSecurityRequirement
    {
        { securityScheme, new[] { "Bearer" } },
    };

    options.AddSecurityRequirement(securityRequirement);
});

builder.Services.AddDbContext<DbContext>(options =>
{
    var configuration = builder.Configuration.GetConnectionString(builder.Environment.IsDevelopment() ? "GoldenLottery_Development" : "GoldenLottery_Production");
    options.UseMySQL(configuration);
});

builder.Services.AddScoped<DbContext>();

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new GlobalExceptionFilterController());
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "GoldenLotteryAuth";
    options.DefaultChallengeScheme = "GoldenLotteryAuth";
}).AddScheme<CustomAuthenticationOptions, CustomAuthenticationHandler>("GoldenLotteryAuth", options =>
{
});

builder.Services.AddAuthorizationBuilder()
    .AddPolicy(Enums.EUserPolicies.Administrator.ToString(), policy => policy.RequireRole(Enums.EUserPolicies.Administrator.ToString()))
    .AddPolicy(Enums.EUserPolicies.Customer.ToString(), policy => policy.RequireRole(Enums.EUserPolicies.Customer.ToString()))
    .AddPolicy(Enums.EUserPolicies.Any.ToString(), policy => policy.RequireRole(Enums.EUserPolicies.Administrator.ToString(), Enums.EUserPolicies.Customer.ToString()));

builder.Services.AddHttpContextAccessor();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});


var serviceProvider = builder.Services.BuildServiceProvider();
var httpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
GlobalSettings.Initialize(httpContextAccessor);


var app = builder.Build();

app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "apiagenda v1"));
}

app.UseAuthentication();
app.UseAuthorization();

app.UseDeveloperExceptionPage();

app.MapControllers();

string uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
if (!Directory.Exists(uploadsPath))
    Directory.CreateDirectory(uploadsPath);

app.UseStaticFiles();

app.UseCors("AllowAnyOrigin");

app.Run();
