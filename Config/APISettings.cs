using Microsoft.AspNetCore.Authentication;

namespace DadJokeCodingExercise.Config
{
    public class APISettings
    {
        public RandomJokeAPI? randomJokeAPI  { get; set; }
    }

    public class RandomJokeAPI
    {
        public string? JokeURL { get; set; }
        public string? JokeCount { get; set; }
    }
}
