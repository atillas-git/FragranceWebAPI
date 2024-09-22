using Application.Interfaces;
using Application.Mappings;
using Application.Services;
using Domain.Interfaces;
using Infastructure.Context;
using Infastructure.Repositories;
using Infastructure.Repositories.Infrastructure.Repositories;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<FragranceDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IFragranceRepository, FragranceRepository>();
builder.Services.AddScoped<ICreatorRepository, CreatorRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IFragranceNoteRepository, FragranceNoteRepository>();
builder.Services.AddScoped<IRatingRepository, RatingRepository>();

// Register Services
builder.Services.AddScoped<IFragranceService, FragranceService>();
builder.Services.AddScoped<ICreatorService, CreatorService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IFragranceNoteService, FragranceNoteService>();
builder.Services.AddScoped<IRatingService, RatingService>();
builder.Services.AddScoped<IAuthService,AuthService>();


//JWT Authentication Added
builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });


//Cors

var AllowFrontEnd = "_allowFrontend";

var allowedOrigins = builder.Configuration["AllowedOrigins"].Split(';').ToList();

// Configure CORS with options based on environment
builder.Services.AddCors(options =>
{
    options.AddPolicy(AllowFrontEnd, policy =>
    {
        if (builder.Environment.IsProduction())
        {
            // Use production origins from configuration
            policy.WithOrigins(allowedOrigins.ToArray());
        }
        else
        {
            // Use default origin for development
            policy.WithOrigins("http://localhost:3000");
        }

        policy.AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddAutoMapper(typeof(FragranceMappingProfile), typeof(CreatorMappingProfile), typeof(FragranceNoteMappingProfile), typeof(RatingMappingProfile), typeof(CommentMappingProfile), typeof(UserMappingProfile));
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    options.AddPolicy("UserOnly", policy => policy.RequireRole("User"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(AllowFrontEnd);

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
