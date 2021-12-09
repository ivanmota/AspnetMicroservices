using System.Text.Json;

namespace Shopping.Aggregator.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<T?> ReadContentAsAsync<T>(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Something went wrong calling the API: {response.ReasonPhrase}");
            }

            var jsonString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            var serializerOptions = new JsonSerializerOptions {
                PropertyNameCaseInsensitive = true,
            };

            var result = JsonSerializer.Deserialize<T>(jsonString, serializerOptions);

            return result;
        }
    }
}
