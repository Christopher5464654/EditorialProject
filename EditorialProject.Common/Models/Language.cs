namespace EditorialProject.Common.Models
{
    using Newtonsoft.Json;
    public class Language
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("novels")]
        public object Novels { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name}";
        }
    }
}