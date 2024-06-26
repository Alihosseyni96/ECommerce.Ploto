using AutoMapper;
using ECommerce.Ploto.Domain.UnitOfWork;
using ECommerce.Ploto.Infrastructure.Context;
using ECommerce.Ploto.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg =>
     cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddAutoMapper(typeof(ECommerce.Ploto.Application.Queries.User.GetAllUserQuery.Mapper).Assembly);
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();    

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql("Host=localhost;Database=ploto-database;Username=beepdb_devu;Password=6720bd679a7c46d2a109;Port=25060");
});

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
