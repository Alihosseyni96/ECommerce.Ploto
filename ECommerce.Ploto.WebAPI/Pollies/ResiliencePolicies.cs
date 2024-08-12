using ECommerce.Ploto.Application.Queries.User.GetAllUserQuery;
using ECommerce.Ploto.Domain.Exceptions;
using Polly;

namespace ECommerce.Ploto.WebAPI.Pollies
{
    public static class ResiliencePolicies
    {
        public static IAsyncPolicy CreateConnectionPoolingPolicy()
        {
            return Policy
           .Handle<InvalidOperationException>(ex => ex.Message.Contains("Connection pool")) // i have to filter on message , beacuse connection pool base type error is a general one "InvalidOperaionException" and i have to filter by name but this is not best way , its better to give retry pattern in databse configurations by connection string
           .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(2))
           .WrapAsync(
               Policy
                   .Handle<InvalidOperationException>()
                   .CircuitBreakerAsync(2, TimeSpan.FromSeconds(5))
           );
           
        }

        public static IAsyncPolicy CreateTimeoutPolicy()
        {
            return Policy
           .Handle<HandledTestPollyException>()
           .WaitAndRetryAsync(10, retryAttempt => TimeSpan.FromSeconds(2))
           .WrapAsync(
               Policy
                   .Handle<HandledTestPollyException>()
                   .CircuitBreakerAsync(2, TimeSpan.FromSeconds(10))
           );
           



        }
    }

}
