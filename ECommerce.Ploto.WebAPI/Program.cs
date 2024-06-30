using AutoMapper;
using ECommerce.Ploto.Application.Queries.User.GetAllUserQuery;
using ECommerce.Ploto.Domain.UnitOfWork;
using ECommerce.Ploto.Infrastructure.Context;
using ECommerce.Ploto.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ECommerce.Ploto.Common.CacheAbstraction.Configurations;
using ECommerce.Ploto.Common.AuthenticationAbstraction.Configuration;
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

builder.Services.AddAuthenticationAbstraction(config =>
{
    config.UseCookieBaseAuthentication(options =>
    {
        options.IsPersistent = true;
        options.ExpiresUtc = DateTimeOffset.UtcNow.AddDays(30);
        options.IssueDateUTC = DateTimeOffset.UtcNow;
        options.AllowRefresh = false;
    });

    //config.UseTokenBaseAuthentication(options =>
    //{
    //    options.Expires =DateTime.Now.AddDays(30);
    //    options.Issuer = builder.Configuration["JWT:Issuer"];
    //    options.Audience = builder.Configuration["JWT:Audience"];
    //    options.JwtKey = builder.Configuration["JWT:JwtKey"];
    //    options.AddingAuthenticationServicesToDI = true;
    //});
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


//app.UseAuthorization(); => it  adds the authentication middleware to the request pipeline. This middleware is responsible for authenticating users and setting the HttpContext.User
// property with the user’s principal if authentication is successful. it can open token with properties which you gave in DI container into builder.services.AddAhtnetication();
//Typically, it should be called before app.UseAuthorization()


//app.UseAuthentication()=> when you add this , you can use [Authorize] to see request is allowd to access action , it checks with see  , HttoContext.user.Isauthenticated = true 
// and if you set Role like [Authorize(Role = "Admin")] it will go to HttpContext.User.Claims and search if there are any claim with Tyoe role = Admin , if exist , the requst is pass into action