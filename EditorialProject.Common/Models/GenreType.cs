namespace EditorialProject.Common.Models
{
    using Newtonsoft.Json;
    public class GenreType
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("genres")]
        public object Genres { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name}";
        }
    }
}