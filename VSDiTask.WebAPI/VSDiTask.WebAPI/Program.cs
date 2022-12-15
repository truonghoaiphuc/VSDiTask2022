using VSDiTask.Core;
using VSDiTask.Services;
using VSDiTask.WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var env = builder.Environment.EnvironmentName;
var isDevelopment = builder.Environment.IsDevelopment();

builder.Configuration
    .AddJsonFile("appsettings.json")
    .AddJsonFile($"appsettings.{env}.json", optional: true);

var connectionString = builder.Configuration.GetConnectionString("VSDiTaskConnection");

builder.Services
    .AddCoreServices(connectionString, isDevelopment, isDevelopment)
    .AddInternalServices(builder.Configuration)
    .AddUserServices()
    .AddCompanyServices()
    .AddCors(p => p.AddPolicy("corspolicy", build =>
    {
        build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
    }))
    .AddControllers();

builder.Services.AddJwtAuthentication(builder.Configuration);

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
app.UseCors("corspolicy");
app.UseHttpsRedirection();
app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
