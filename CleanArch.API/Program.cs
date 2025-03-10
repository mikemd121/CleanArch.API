using Autofac;
using Autofac.Extensions.DependencyInjection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new AutofacModule(builder.Configuration)); // Pass IConfiguration
});


// Register MediatR
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

// Add services to the container.
builder.Services.AddControllers();

// Enable CORS with a custom policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin()  // Allows all origins (you can restrict it later for security)
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CleanArch.API", Version = "v1" });
});


var app = builder.Build();
app.UseCors("AllowAllOrigins");  // Use the CORS policy

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate(); // Ensures the database is created and migrations are applied
    ApplicationDbContext.SeedSampleData(dbContext);
}

app.UseDeveloperExceptionPage();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CleanArch.API v1"));

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
