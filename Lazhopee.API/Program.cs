using Lazhopee.API.Middleware;
using Lazhopee.Contracts.Repositories;
using Lazhopee.Contracts.Services;
using Lazhopee.Infrastracture;
using Lazhopee.Infrastracture.Repositories;
using Lazhopee.Models;
using Lazhopee.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;

// Add services to the container.
#region DB Configurations

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("LocalSQLServer")));

#endregion

#region Repositories

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

// Unit of work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

#endregion

#region Services

builder.Services.AddScoped<IProductService, ProductService>();

#endregion

#region AutoMapper

builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);

#endregion

#region Middleware

builder.Services.AddTransient<ExceptionHandlingMiddleware>();

#endregion

#region ASP.NET Core

builder.Services.AddControllers();

#endregion

#region OpenAPI

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = assemblyName });

    var xmlFilename = $"{assemblyName}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", assemblyName);
        options.RoutePrefix = string.Empty;
    });
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

PrepDb.PrepPopulation(app);

app.Run();
