using server.Data;
using server.Middlewares;
using server.Repositories;
using server.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularDev",
        builder =>
        {
            builder.WithOrigins("*") 
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

// DbContext
builder.Services.AddDbContext<AppDbContext>(
    options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserService>();

builder.Services.AddScoped<IScheduleRepository, ScheduleRepository>();
builder.Services.AddScoped<ScheduleService>();

builder.Services.AddScoped<ILogRepository, LogRepository>();
builder.Services.AddScoped<LogService>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseMiddleware<GlobalExceptionHandler>();
app.UseHttpsRedirection();
app.UseCors("AllowAngularDev"); 
app.MapControllers();

app.Run();
