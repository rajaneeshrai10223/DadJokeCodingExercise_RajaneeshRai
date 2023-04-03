using DadJokeCodingExercise.Config;
using DadJokeCodingExercise.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Text.Json;

namespace DadJokeCodingExercise.Controllers
{
    /// <summary>
    /// Rajaneesh Rai
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class DadJokesController : ControllerBase
    {

        private readonly ILogger<DadJokesController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public DadJokesController(ILogger<DadJokesController> logger,
            IHttpClientFactory httpClientFactory,
            IConfiguration configuration)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }


        [HttpGet("joke_count")]
        public async Task<IActionResult> GetJokeCount()
        {
            try
            {
                string? JokeUrl = _configuration.GetValue<string>("JokeCount");

                var httpRequestMessage = new HttpRequestMessage(
                          HttpMethod.Get,
                            JokeUrl)
                {
                    Headers =
                    {
                        { "X-RapidAPI-Key", "798712199dmsh2f63521f1c4d1f1p1a2bffjsn01241cbbc1e0" },
                        { "X-RapidAPI-Host", "dad-jokes.p.rapidapi.com" },
                    },
                };

                var httpClient = _httpClientFactory.CreateClient();
                using (var response = await httpClient.SendAsync(httpRequestMessage))
                {
                    response.EnsureSuccessStatusCode();
                    string stream = await response.Content.ReadAsStringAsync();
                    JokeCount? jokecount = JsonSerializer.Deserialize<JokeCount>(stream, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    return Ok(jokecount);
                }
          
            }

            catch (Exception ex)
            {
                _logger.LogError($"Exception in Get Random Jokemethod", ex.Message);
                return Ok(ex.Message);
            }


;        }

        [HttpGet("random_jokes")]
        public async Task<IActionResult> GetRandomJoke()
        {
            try
            {
                string? JokeUrl = _configuration.GetValue<string>("JokeURL");

                var httpRequestMessage = new HttpRequestMessage(
                          HttpMethod.Get,
                            JokeUrl)
                {
                    Headers =
                    {
                        { "X-RapidAPI-Key", "798712199dmsh2f63521f1c4d1f1p1a2bffjsn01241cbbc1e0" },
                        { "X-RapidAPI-Host", "dad-jokes.p.rapidapi.com" },
                    },
                };

                var httpClient = _httpClientFactory.CreateClient();
                using (var response = await httpClient.SendAsync(httpRequestMessage))
                {
                    response.EnsureSuccessStatusCode();
                    string stream = await response.Content.ReadAsStringAsync();
                    RandomJoke? randomJoke = JsonSerializer.Deserialize<RandomJoke>(stream, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    return Ok(randomJoke);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception in Get Random Get Random Joke", ex.Message);
                return Ok(ex.Message);
            }
        }
    }
}