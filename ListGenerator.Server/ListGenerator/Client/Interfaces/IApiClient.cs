using ListGenerator.Client.Models;
using ListGenerator.Shared.Responses;
using System.Threading.Tasks;

namespace ListGenerator.Client.Interfaces
{
    public interface IApiClient
    {
        Task<T> GetAsync<T>(string requestUri);

        Task<BaseResponse> PostAsync(string requestUri, string jsonContent);

        Task<BaseResponse> PutAsync(string requestUri, string jsonContent);

        Task<BaseResponse> DeleteAsync(string requestUri);
    }
}
