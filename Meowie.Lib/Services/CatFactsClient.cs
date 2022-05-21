using System.Net.Http.Json;
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
    }
}
