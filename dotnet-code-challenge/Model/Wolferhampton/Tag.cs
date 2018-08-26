using Newtonsoft.Json;

namespace dotnet_code_challenge.Model.Wolferhampton
{
    public class Tag
    {
        [JsonProperty("participant")]
        public int Participant { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
