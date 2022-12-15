

using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using UniversityAPiBackEnd;
using UniversityAPiBackEnd.DataAccess;

var builder = WebApplication.CreateBuilder(args);

#region: Conección con la BD

// Connections with SQL Server Express
var connectionString = builder.Configuration.GetConnectionString("ConnectionDB");

//Add Context
builder.Services.AddDbContext<UniversityDbContext>(options => options.UseSqlServer(connectionString));

//Add Services of JWT Authorization
builder.Services.AddJwtTokenServices(builder.Configuration);

//Add Authorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("UserOnlyPolicy", policy => policy.RequireClaim("UserOnly", "User1"));
});

#endregion

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Config Swagger to take care of Authorization of JWT 
builder.Services.AddSwaggerGen(options =>
    {
        //We define the Security for authorization
        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JWT authorization header using bearer scheme"
        });

        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer",
                    }
                },
                new string[]{ }
            }
        });
    }
);

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
