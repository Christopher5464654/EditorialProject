namespace EditorialProject.Common.Models
{
    using Newtonsoft.Json;
    public class Status
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("suscriptions")]
        public object Suscriptions { get; set; }

        [JsonProperty("validations")]
        public object Validations { get; set; }

        [JsonProperty("moderators")]
        public object Moderators { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name}";
        }
    }
}