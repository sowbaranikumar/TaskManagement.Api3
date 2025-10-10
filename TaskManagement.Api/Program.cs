using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Serilog;
using TaskManagement.Api.Filters;
using TaskManagement.Api.Middlewares;
using TaskManagement.Business.Automapper;
using TaskManagement.Business.DTOs;
using TaskManagement.Business.Interfaces;
using TaskManagement.Business.Services;
using TaskManagement.Business.Validations;
using TaskManagement.Data.Db;
using TaskManagement.Data.Repositories.Implementations;
using TaskManagement.Data.Repositories.Interfaces;


var builder=WebApplication.CreateBuilder(args);
//builder.Services.AddControllers(options =>
//{
//    options.Filters.Add<ApiResponseWrapperFilter>();
//});
builder.Services.AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();


builder.Services.AddScoped<ApiResponseWrapperFilter>();
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Host.UseSerilog();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddValidatorsFromAssemblyContaining<TaskItemValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<ProjectValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UserValidator>();

builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
builder.Services.AddScoped<IProjectsRepository, ProjectsRepository>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<ITasksRepository, TasksRepository>();


builder.Services.AddScoped<IProjectsServices, ProjectsServices>();
builder.Services.AddScoped<IUsersServices, UsersServices>();
builder.Services.AddScoped<ITasksServices, TasksServices>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseMiddleware<ErrorHandlingMiddleware>();
//app.UseGlobalErrorHandling();

app.UseSerilogRequestLogging();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
Log.Information("This is a test info log.");
Log.Warning("This is a test warning.");
app.Run();

