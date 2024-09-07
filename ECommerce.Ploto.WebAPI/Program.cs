using ECommerce.Ploto.Application.Queries.User.GetAllUserQuery;
using ECommerce.Ploto.Domain.UnitOfWork;
using ECommerce.Ploto.Infrastructure.Context;
using ECommerce.Ploto.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using ECommerce.Ploto.Common.CacheAbstraction.Configurations;
using ECommerce.Ploto.Common.AuthenticationAbstraction.Configuration;
using ECommerce.Ploto.WebAPI.Middlewares;
using System.Threading.RateLimiting;
using System.Reflection;
using ECommerce.Ploto.Common.JobAbstraction.Configurations;
using Prometheus;
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
builder.Services.AddScoped<IPlotoUnitOfWork, UnitOfWork>();

builder.Services.AddDbContext<PlotoDbContext>(options =>
{
    //options.UseNpgsql(builder.Configuration["ConnectionStrings:postgresql"]);
    options.UseSqlServer(builder.Configuration["ConnectionStrings:SqlServerAtAork"]);
});

#region Cache Abstraction

builder.Services.AddCacheAbstraction(config =>
{
    #region Redis
    config.UseRedisCache(options =>
    {
        options.Host = builder.Configuration["ConnectionStrings:Redis:Host"];
        options.Port = int.Parse(builder.Configuration["ConnectionStrings:Redis:Port"]);
        options.Password = builder.Configuration["ConnectionStrings:Redis:Password"];
        options.ProjectNamePrefix = Assembly.GetEntryAssembly().GetName().Name;
        options.EnvironmentPrefix = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
    });

    #endregion

    #region InMemory

    //config.UseInMemoryCache();

    #endregion

});

#endregion

#region Authentication 
builder.Services.AddAuthenticationAbstraction(config =>
{

    #region Cookie Base
    //config.UseCookieBaseAuthentication(options =>
    //{
    //    options.IsPersistent = true;
    //    options.ExpiresUtc = DateTimeOffset.UtcNow.AddDays(30);
    //    options.IssueDateUTC = DateTimeOffset.UtcNow;
    //    options.AllowRefresh = false;
    //});

    #endregion

    #region token Base
    config.UseTokenBaseAuthentication(options =>
    {
        options.Expires = DateTime.Now.AddDays(30);
        options.Issuer = builder.Configuration["JWT:Issuer"];
        options.Audience = builder.Configuration["JWT:Audience"];
        options.JwtKey = builder.Configuration["JWT:JwtKey"]!;
        options.AddingAuthenticationServicesToDI = true;
    });

    #endregion

});

#endregion

#region Rate Limit 

builder.Services.AddRateLimiter(options =>
{
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests; // StatusCode When Hit Limits

    options.AddPolicy("rate-limit-ip-policy", httpContext =>
           RateLimitPartition.GetFixedWindowLimiter(
               partitionKey: httpContext.Connection.LocalIpAddress?.ToString(), // every ip will be Limited if call One API more then 10 times in 10 seconeds
               factory: _ => new FixedWindowRateLimiterOptions
               {
                   PermitLimit = 100,
                   Window = TimeSpan.FromSeconds(60),
                   QueueProcessingOrder = QueueProcessingOrder.OldestFirst, // sort for queue and process 
                   QueueLimit = 10, // when hit limitation , excess reqesust will be queued and will go for process when windows will be open again
                   AutoReplenishment = true,
               }));

    //options.AddFixedWindowLimiter("fixed", o => // this is fixed type for limitation type- will be process 10 request in 10 seconds and windows start point is fixed 
    //{
    //    o.PermitLimit = 10;
    //    o.Window = TimeSpan.FromSeconds(10);
    //    o.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
    //    o.QueueLimit = 5;
    //    o.AutoReplenishment = true; // refresh window when window time is new and epmty if from before requests
    //});
    //options.AddSlidingWindowLimiter(); // in this case , windows start point will slide with first request and windows start point in not fixed

    //options.AddTokenBucketLimiter("tokenBucketPolicy", limiterOptions => // in this type there will be a token storage which every comes in Request will picked up one of those Token , and processing requests will keeps going untill token storage is not empty, and by time as you configure , token will be added to storage
    //{
    //    limiterOptions.TokenLimit = 10; // Bucket can hold 10 tokens
    //    limiterOptions.TokensPerPeriod = 1; // Add 1 token per second
    //    limiterOptions.ReplenishmentPeriod = TimeSpan.FromSeconds(1); // Refill rate
    //});


    //options.AddConcurrencyLimiter() // this is fot concurrent Request for Application.. you can say just proccess 5 cuncurrent request  in same time
});


#endregion

builder.Services.AddMiniProfiler(options =>
{
    options.RouteBasePath = "/profiler"; //endpint : /profiler/results-index

    // Optional settings for MiniProfiler
    options.ColorScheme = StackExchange.Profiling.ColorScheme.Dark;
    options.TrackConnectionOpenClose = true;

}).AddEntityFramework(); // This adds EF Core profiling support.
//builder.Services.AddScoped<HelloWordJob>();

builder.Services.AddJobAbstraction(options =>
{
    options.UseQuartz(options =>
    {
        options.Assembly = Assembly.GetExecutingAssembly();
    });
});



var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();

app.UseMetricServer();
// Enable Prometheus metrics collection.
app.UseHttpMetrics();

app.UseHttpsRedirection();

app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseMiddleware<ResilienceMiddleware>();
app.UseRateLimiter();

#region Authorization
app.AuthorizationAbstraction(options =>
{
    //options.UseAuthentication();
    //options.UseAuthorizatio();
});
#endregion
app.UseMiniProfiler();
app.UseEndpoints(endpoint =>
{
    endpoint.MapControllers();
    //endpoint.MapMetrics();
});

//app.MapControllers();

app.Run();


//app.UseَAuthentication(); => it  adds the authentication middleware to the request pipeline. This middleware is responsible for authenticating users and setting the HttpContext.User
// property with the user’s principal if authentication is successful. it can open token with properties which you gave in DI container into builder.services.AddAhtnetication();
//Typically, it should be called before app.UseAuthorization()


//app.UseAuthorization()=> when you add this , you can use [Authorize] to see request is allowd to access action , it checks with see  , HttoContext.user.Isauthenticated = true 
// and if you set Role like [Authorize(Role = "Admin")] it will go to HttpContext.User.Claims and search if there are any claim with Tyoe role = Admin , if exist , the requst is pass into action
// Notice : [Authorize] for use this attribute for role , you can just put one roleName in Role claim .. if You want to put Some more Role in one key , you have to create Customized attribute