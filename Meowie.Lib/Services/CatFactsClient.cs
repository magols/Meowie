using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Meowie.Lib.Data;

namespace Meowie.Lib.Services
{
    public class CatFactsClient
    {
        private HttpClient _client;

        public CatFactsClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<CatFact> GetFactAsync()
        {
            var result = await _client.GetFromJsonAsync<CatFact>("/fact?max_length=500");
            return result;
        }

        public async Task<IEnumerable<Breed>> GetBreedsAsync()
        {
            var result = await _client.GetFromJsonAsync<BreedsResponse>("/breeds?limit=100");
            return result.Data;

            
        }
    }







    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class Breed
    {
        [JsonPropertyName("breed")]
        public string Name { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("origin")]
        public string Origin { get; set; }

        [JsonPropertyName("coat")]
        public string Coat { get; set; }

        [JsonPropertyName("pattern")]
        public string Pattern { get; set; }
    }

    public class Link
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("active")]
        public bool Active { get; set; }
    }

    public class BreedsResponse
    {
        [JsonPropertyName("current_page")]
        public int CurrentPage { get; set; }

        [JsonPropertyName("data")]
        public List<Breed> Data { get; set; }

        [JsonPropertyName("first_page_url")]
        public string FirstPageUrl { get; set; }

        [JsonPropertyName("from")]
        public int From { get; set; }

        [JsonPropertyName("last_page")]
        public int LastPage { get; set; }

        [JsonPropertyName("last_page_url")]
        public string LastPageUrl { get; set; }

        [JsonPropertyName("links")]
        public List<Link> Links { get; set; }

        [JsonPropertyName("next_page_url")]
        public object NextPageUrl { get; set; }

        [JsonPropertyName("path")]
        public string Path { get; set; }

        [JsonPropertyName("per_page")]
        public string PerPage { get; set; }

        [JsonPropertyName("prev_page_url")]
        public object PrevPageUrl { get; set; }

        [JsonPropertyName("to")]
        public int To { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }
    }


}
