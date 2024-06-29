using AutoMapper;
using ECommerce.Ploto.Application.Queries.User.GetAllUserQuery;
using ECommerce.Ploto.Domain.UnitOfWork;
using ECommerce.Ploto.Infrastructure.Context;
using ECommerce.Ploto.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ECommerce.Ploto.Common.CacheAbstraction.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg =>
     cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddAutoMapper(typeof(ECommerce.Ploto.Application.Queries.User.GetAllUserQuery.Mapper).Assembly);
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(typeof(GetAllUserQueryHandler).Assembly);
});
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();    

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    //options.UseNpgsql("Host=localhost;Database=ploto-database;Username=beepdb_devu;Password=6720bd679a7c46d2a109;Port=25060");
    options.UseSqlServer("Data Source=.;Initial Catalog=ploto-database;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;");
});

builder.Services.AddCacheAbstraction(config =>
{
    config.UseRedisCache(options =>
    {
        options.ConnectionString = builder.Configuration["Redis:ConnectionString"]!;
    });
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
