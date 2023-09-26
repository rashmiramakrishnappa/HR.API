using AutoMapper;
using HRWeb.API.Models;
using HRWeb.Data;
using HRWeb.Data.Entities;
using HRWeb.Services.Implementations;
using HRWeb.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<HRDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


// Add services to the container.
builder.Services.AddScoped<IHumanResourceService, HumanResourceService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();
app.UseRouting();
// Define minimal API endpoints
app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/api/resource/{id}", async (int id, HumanResourceService humanResourceService) =>
    {
        // Handle GET request for a resource
        var result = await humanResourceService.GetRecruiterById(id);
        if (result != null)
        {
            await context.Response.WriteAsJsonAsync(result);
        }
        else
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
        }
    });
    endpoints.MapGet("/api/resource/{firstName}/{lastName}", async (string firstName, string lastName, HumanResourceService humanResourceService) =>
    {
        // Handle GET request for a resource
        var result = await humanResourceService.GetRecruiterByName(firstName, lastName);
        if (result != null)
        {
            await context.Response.WriteAsJsonAsync(result);
        }
        else
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
        }
    });
    endpoints.MapPost("/api/resource", async (RecruiterInfo recruiter, HumanResourceService humanResourceService, Mapper mapper) =>
    {
        // Handle POST request to create a resource
        var createdRecruiter = await humanResourceService.UpsertRecruiter(mapper.Map<Recruiter>(recruiter));
        await context.Response.WriteAsJsonAsync(createdRecruiter);
    });
});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();

