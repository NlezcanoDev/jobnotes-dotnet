using Job.Notes.Api;
using Job.Notes.Api.Middlewares;
using Job.Notes.Application;
using Job.Notes.Common;
using Job.Notes.External;
using Job.Notes.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddWebApi()
    .AddCommon()
    .AddApplication()
    .AddExternal(builder.Configuration)
    .AddPersistence(builder.Configuration)
    .AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
                policyBuilder => policyBuilder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });

builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();
app.UseCors("CorsPolicy");
app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.Run();