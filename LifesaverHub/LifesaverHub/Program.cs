using System.Text.Json.Serialization;
using LifesaverHub.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DatabaseContext>(option =>
{
    option.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
});

// builder.Services.AddIdentity<IUserService, UserService>()
builder.Services.AddIdentity<IdentityUser, IdentityRole>(o =>
{
// o setup
}).AddRoles<IdentityRole>().AddEntityFrameworkStores<DatabaseContext>().AddDefaultTokenProviders();

builder.Services.AddAuthentication();  // To DO
builder.Services.AddAuthorization();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseCors();

app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();