using System.Text.Json.Serialization;

namespace asp_dotnet_getstarted.Models
{
    public class Product
    {
        public string id { get; set; }
        public string Maker { get; set; }

        [JsonPropertyName("img")]
        public string Image { get; set; }

        public string Url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
