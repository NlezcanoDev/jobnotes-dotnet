using Job.Notes.Application.Interfaces;
using Job.Notes.Persistence.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddDbContext<DatabaseService>(opt => 
        opt.UseSqlServer(builder.Configuration["SQLConnectionString"]));

builder.Services.AddScoped<IDatabaseService, DatabaseService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.Run();