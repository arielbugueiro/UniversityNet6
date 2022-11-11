

using Microsoft.EntityFrameworkCore;
using UniversityAPiBackEnd.DataAccess;

var builder = WebApplication.CreateBuilder(args);

#region: Conección con la BD

// Connections with SQL Server Express
var connectionString = builder.Configuration.GetConnectionString("ConnectionDB");

//Add Context
builder.Services.AddDbContext<UniversityDbContext>(options => options.UseSqlServer(connectionString));


#endregion

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
