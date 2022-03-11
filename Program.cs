using DevJobs.API.Persistence;
using DevJobs.API.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Sinks.MSSqlServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DevJobsCs2");

builder.Services.AddDbContext<DevJobsContext>(options =>
    options.UseSqlServer(connectionString));
//options.UseInMemoryDatabase("DevJobs")); Use in memory

builder.Services.AddScoped<IJobVacancyRepository, JobVacancyRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "DevJobs.Api",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Ricardo Spernega",
            Email = "ricardo_srd@hotmail.com",
            Url = new Uri("https://github.com/RicardoSpernega")
        }
    });

    var xml = "DevJobs.Api.xml";

    var xmlPath = Path.Combine(AppContext.BaseDirectory, xml);

    c.IncludeXmlComments(xmlPath);

});


builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    Serilog.Log.Logger = new LoggerConfiguration()
        .Enrich.FromLogContext()
        .WriteTo.MSSqlServer(connectionString,
            sinkOptions: new MSSqlServerSinkOptions()
            {
                AutoCreateSqlTable = true,
                TableName = "Logs"
            })

            .WriteTo.Console()
            .CreateLogger();

}).UseSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
