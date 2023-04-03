using Newtonsoft.Json;

namespace DadJokeCodingExercise.Model
{
    public class RandomJoke
    {
        [JsonProperty(PropertyName = "success")]
        public bool? Success { get; set; }
        [JsonProperty(PropertyName = "body")]
        public Body[]? Body { get; set; }
    }

    public class Body
    {
        [JsonProperty(PropertyName = "_id")]
        public string? _Id { get; set; }
        [JsonProperty(PropertyName = "type")]
        public string? Type { get; set; }
        [JsonProperty(PropertyName = "setup")]
        public string? Setup { get; set; }
        [JsonProperty(PropertyName = "punchline")]
        public string? PunchLine { get; set;}
    }
}
