using System.Configuration;
using Microsoft.EntityFrameworkCore;
using WebApiTask.Data;


var builder = WebApplication.CreateBuilder(args);

// Register controllers
builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IEmployeeRepo, EmployeeRepoImpl>();
builder.Services.AddDbContext<EmployeeDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeConnection")));


var app = builder.Build();

// app.UseHttpsRedirection();

// Enable attribute routing
app.MapControllers();

app.Run();
