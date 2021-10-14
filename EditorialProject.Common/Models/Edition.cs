namespace EditorialProject.Common.Models
{
    using Newtonsoft.Json;
    public class Edition
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("novels")]
        public object Novels { get; set; }
    }
}