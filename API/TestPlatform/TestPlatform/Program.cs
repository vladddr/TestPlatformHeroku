using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TestPlatform.API.Services;
using TestPlatform.DAL.Context;
using TestPlatform.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
.AddJsonOptions(options =>
{
    options.JsonSerializerOptions.WriteIndented = true;
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IGenericService<, , ,>), typeof(GenericService<, , ,>));

builder.Services.AddScoped<ITestRepository, TestRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITestService, TestService>();
builder.Services.AddScoped<ITestQuestionService, TestQuestionService>();

builder.Services.AddDbContext<TestPlatformContext>(options =>
{
    options.EnableSensitiveDataLogging();
    options.UseSqlServer(
       builder.Configuration.GetConnectionString("SmartNetConnection"),
 
       sqlServerOptionsAction: sqlOptions =>
       {
           sqlOptions.EnableRetryOnFailure(
               maxRetryCount: 10,
               maxRetryDelay: TimeSpan.FromSeconds(5),
               errorNumbersToAdd: null)
           .MigrationsAssembly(typeof(TestPlatformContext).Assembly.FullName);
       });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

var service = (IServiceScopeFactory)app.Services.GetService(typeof(IServiceScopeFactory));

using(var database = service.CreateScope().ServiceProvider.GetService<TestPlatformContext>())
{
    await database.Database.MigrateAsync();
}

app.MapControllers();

app.Run();
