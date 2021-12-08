using AutoMapper;
using ListGenerator.Client.Builders;
using ListGenerator.Client.Interfaces;
using ListGenerator.Shared.Interfaces;
using ListGenerator.Shared.Responses;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ListGenerator.Client.Models
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly IJsonHelper _jsonHelper;

        public ApiClient(HttpClient httpClient, IJsonHelper jsonHelper)
        {
            _httpClient = httpClient;
            _jsonHelper = jsonHelper;
        }

        public async Task<T> GetAsync<T>(string requestUri)
        {
            var httpResponse = await _httpClient.GetAsync(requestUri);

            var content = await httpResponse.Content.ReadAsStringAsync();

            var deserializedItems = _jsonHelper.Deserialize<T>(content);

            return deserializedItems;
        }

        public async Task<BaseResponse> PostAsync(string requestUri, string jsonContent)
        {
            var stringContent =
              new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var httpResponse = await _httpClient.PostAsync(requestUri, stringContent);

            var content = await httpResponse.Content.ReadAsStringAsync();

            var response = _jsonHelper.Deserialize<BaseResponse>(content);
                
            return response;
        }

        public async Task<BaseResponse> PutAsync(string requestUri, string jsonContent)
        {
            var stringContent =
              new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var httpResponse = await _httpClient.PutAsync(requestUri, stringContent);

            var content = await httpResponse.Content.ReadAsStringAsync();

            var response = _jsonHelper.Deserialize<BaseResponse>(content);

            return response;
        }

        public async Task<BaseResponse> DeleteAsync(string requestUri)
        {
            var httpResponse = await _httpClient.DeleteAsync(requestUri);

            var content = await httpResponse.Content.ReadAsStringAsync();

            var response = _jsonHelper.Deserialize<BaseResponse>(content);

            return response;
        }
    }
}
