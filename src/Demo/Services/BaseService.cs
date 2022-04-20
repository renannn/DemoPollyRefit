using Demo.Configurations;
using Microsoft.Extensions.Options;
using Polly;
using Polly.Retry;
using Refit;
using System.Net;
using System.Threading.Tasks;

namespace Demo.Services
{
    public class BaseService
    {
        private readonly AppSettings _options;

        public BaseService(IOptionsSnapshot<AppSettings> options)
        {
            _options = options.Value;
        }

        public AsyncRetryPolicy GetTimeoutPolicy()
        {
            return Policy
                      .Handle<ApiException>(ex => ex.StatusCode == HttpStatusCode.RequestTimeout)
                      .RetryAsync(_options.NumberOfRetries, async (exception, retryCount) =>
                          await Task.Delay(500).ConfigureAwait(false));
        }
    }
}
