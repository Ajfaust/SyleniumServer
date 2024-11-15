using System.Reflection;
using AllostaServer.DbContexts;
using Microsoft.EntityFrameworkCore;
using Serilog;
using SwaggerThemes;

var builder = WebApplication.CreateBuilder(args);
var myPolicy = "MyPolicy";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myPolicy,
                      policy =>
                      {
                          policy.AllowAnyOrigin();
                          policy.AllowAnyMethod();
                          policy.AllowAnyHeader();
                      });
});

builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<BudgetContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("BudgetDb")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerThemes(Theme.Gruvbox);
    app.UseSwaggerUI();
}

app.UseCors(myPolicy);

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();