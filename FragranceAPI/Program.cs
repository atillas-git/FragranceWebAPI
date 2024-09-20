using Application.Interfaces;
using Application.Mappings;
using Application.Services;
using Domain.Interfaces;
using Infastructure.Context;
using Infastructure.Repositories;
using Infastructure.Repositories.Infrastructure.Repositories;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

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

builder.Services.AddAutoMapper(typeof(FragranceMappingProfile), typeof(CreatorMappingProfile), typeof(FragranceNoteMappingProfile), typeof(RatingMappingProfile), typeof(CommentMappingProfile), typeof(UserMappingProfile));
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
