using Microsoft.EntityFrameworkCore;
using AppCourses.Core.Db;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using AppCourses.Core.Options;
using AppCourses.Core.Abstractions;
using AppCourses.BL.Operations;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
builder.Services.AddDbContext<AppDbContext>(d => d.UseSqlServer(builder.Configuration.GetConnectionString("default")));
var authOptions = builder.Configuration.GetSection("Auth").Get<AuthOptions>();
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = authOptions.Issuer,
        ValidAudience = authOptions.Audience,
        IssuerSigningKey = authOptions.GetSymmetricSecurityKey(),
    };
});
builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserBL, UserBL>();
builder.Services.AddScoped<IGroupBL, GroupBL>();
builder.Services.AddScoped<ICourseBL, CourseBL>();
var app = builder.Build();

// Configure the HTTP request pipeline.


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
