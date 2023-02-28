using System.Text;
using System.Text.Json.Serialization;
using LifesaverHub.Data;
using LifesaverHub.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DatabaseContext>(option =>
{
    option.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 5;
    options.Password.RequireLowercase = true;
}).AddEntityFrameworkStores<DatabaseContext>().AddDefaultTokenProviders();

builder.Services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(option =>
{
    option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = configuration["AuthSettings:Audience"],
        ValidIssuer = configuration["AuthSettings:Issuer"],
        RequireExpirationTime = true,
        IssuerSigningKey =
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["AuthSettings:Key"])),
        ValidateIssuerSigningKey = true
    };
});
builder.Services.AddScoped<IUserService, UserService>();


builder.Services.AddAuthorization(); //TODO

// builder.Services.AddCors();

// builder.Services.AddCors(options =>
// {
//     options.AddPolicy("CorsPolicy", policy =>
//     {
//         policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials();
//     });
// });

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy",
        builder => builder.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod().AllowCredentials());

});
// builder.Services.AddCors(cors=>{ cors.AddPolicy(name:MyAllowSpecificOrigins, policy =>
// {
//     policy.WithOrigins("http://localhost:3000/").AllowCredentials().AllowAnyHeader().AllowAnyMethod();
// });});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseCors("MyPolicy");
// app.UseCors(opt =>
// {
//     opt.WithOrigins("http://localhost:3000/")
//         
//         .AllowAnyHeader()
//         .AllowAnyMethod()
//         .AllowCredentials();
// });

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();




