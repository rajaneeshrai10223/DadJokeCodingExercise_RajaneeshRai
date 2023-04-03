using Newtonsoft.Json;

namespace DadJokeCodingExercise.Model
{
    public class JokeCount
    {
        [JsonProperty(PropertyName = "success")]
        public bool? Success { get; set; }
        [JsonProperty(PropertyName = "body")]
        public int Body { get; set; }
    }
}
