using System.Text;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DauxChallenge.Services
{
    public class EncryptService : IEncryptService
    {
        private readonly HttpClient _httpClient;

        public EncryptService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> EncryptApiAsync(string nombre, string apellido)
        {
            try
            {
                var content = PrepareRequestContent(nombre, apellido);

                ConfigureRequestHeaders(nombre, apellido);

                var response = await SendPostRequestAsync("https://daux.com.ar/api/test-encrypt", content);

                return await ProcessResponseAsync(response);
            }
            catch (HttpRequestException ex)
            {
                throw new ApplicationException("Error calling the API. Please try again later.", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An unexpected error occurred. Please try again later.", ex);
            }
        }

        private StringContent PrepareRequestContent(string nombre, string apellido)
        {
            var requestData = new
            {
                nombre,
                apellido
            };

            var json = JsonSerializer.Serialize(requestData);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        private void ConfigureRequestHeaders(string nombre, string apellido)
        {
            var authValue = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{nombre}{apellido}"));
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", authValue);
        }

        private async Task<HttpResponseMessage> SendPostRequestAsync(string url, HttpContent content)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = content
            };

            return await _httpClient.SendAsync(request);
        }

        private async Task<string> ProcessResponseAsync(HttpResponseMessage response)
        {
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

    }
}