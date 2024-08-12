using Polly;

namespace ECommerce.Ploto.WebAPI.Pollies
{
    public static class CombinedResiliencePolicy
    {
        public static IAsyncPolicy CreateCombinedPolicy()
        {
            var connectionPollingPolicy = ResiliencePolicies.CreateConnectionPoolingPolicy();
            var timeoutPolicy = ResiliencePolicies.CreateTimeoutPolicy();

            return Policy.WrapAsync(connectionPollingPolicy, timeoutPolicy);
        }
    }
}
