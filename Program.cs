using DevJobs.API.Persistence;
using DevJobs.API.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DevJobsCs");

builder.Services.AddDbContext<DevJobsContext>(options =>
    options.UseSqlServer(connectionString));

//  builder.Services.AddDbContext<DevJobsContext>(options =>
// options.UseInMemoryDatabase("DevJobs"));   

builder.Services.AddScoped<IJobVacancyRepository, JobVacancyRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "DevJobs.API",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Gabriel Martins",
            Email = "gabrielmatheus209@gmail.com.br",
            Url = new Uri("https://github.com/omartins-zs/")
        }
    });

    var xmlFile = "DevJobs.API.xml";

    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
// Retirado "if (app.Environment.IsDevelopment())" | Se estiver apenas usa Swagger em ambiente de produçao
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
