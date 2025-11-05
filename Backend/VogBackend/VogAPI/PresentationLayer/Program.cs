using System.Text;
using BusinessLogicLayer.Configurations;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using DataAccessLayer;
using DataAccessLayer.Interface;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace PresentationLayer
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var builder = WebApplication.CreateBuilder(args);

      builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
      );

      var jwt = builder.Configuration.GetSection("Jwt");

      // JWT Middleware
      builder
        .Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
          options.TokenValidationParameters = new TokenValidationParameters
          {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwt["Issuer"],
            ValidAudience = jwt["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt["Key"]!))
          };
        });

      builder.Services.AddAuthorization();

      // Add services to the container.
      builder.Services.AddScoped<IUserService, UserService>();
      builder.Services.AddScoped<IUserRepository, UserRepository>();

      builder.Services.AddScoped<IBacklogService, BacklogService>();
      builder.Services.AddScoped<IBacklogRepository, BacklogRepository>();

      builder.Services.AddScoped<IGameService, GameService>();
      builder.Services.AddScoped<IGameRepository, GameRepository>();

      builder.Services.AddScoped<ICustomUserListService, CustomUserListService>();
      builder.Services.AddScoped<ICustomUserListRepository, CustomUserListRepository>();

      builder.Services.AddScoped<ICustomUserListGameService, CustomUserListGameService>();
      builder.Services.AddScoped<ICustomUserListGameRepository, CustomUserListGameRepository>();

      builder.Services.AddScoped<IUserReviewService, UserReviewService>();
      builder.Services.AddScoped<IUserReviewRepository, UserReviewRepository>();

      builder.Services.AddScoped<AuthService>();

      builder.Services.AddControllers();

      MappingConfigurations.ConfigureMappings();
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

      app.UseAuthentication();
      app.UseAuthorization();

      app.UseCors("AllowLocalhost4200");

      app.UseCors(builder =>
      {
        builder.WithOrigins(app.Configuration["AllowedOrigins"]).AllowAnyHeader().AllowAnyMethod();
      });

      app.MapControllers();

      app.Run();
    }
  }
}
