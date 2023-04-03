using System.Net.Http;
using System.Net.Http;

namespace DadJokeCodingExercise.HttpClientFactory
{
    public class HttpClientFactoryService : IHttpClientServiceImplementation
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public HttpClientFactoryService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public HttpClient CreateClient()
        {
            return _httpClientFactory.CreateClient();
        }
    }
}
