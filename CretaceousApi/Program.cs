using CretaceousApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(); //add controllers as a service. No views are being added
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<CretaceousApiContext>(
                  dbContextOptions => dbContextOptions
                    .UseMySql(
                      builder.Configuration["ConnectionStrings:DefaultConnection"], 
                      ServerVersion.AutoDetect(builder.Configuration["ConnectionStrings:DefaultConnection"]
                    )
                  )
                );

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();//enables swagger to do its job. Exposes APIs endpoints

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) //configure their api to use swashbuckle. Swagger auto documents endpoints of the application. 
{
    app.UseSwagger(); //swagger is the user interface for our documentation. Only used in development mode, so as to not expose sensitive data.
    app.UseSwaggerUI();
}
else
{
    app.UseHttpsRedirection(); //handles redirection to https if we are not in development
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); //config app to rely on attributes and controllers for our api

app.Run();
