using Golf.Global.Implementations;
using Golf.RESTService.Client.Interfaces;
using Golf.ServiceLayer.Dto.Implementations;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Golf.RESTService.Client.Implementations.Generic
{
    public class UpdateEntity<T> : IUpdateEntity<T>, IDisposable
        where T: BaseDto
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public UpdateEntity(HttpClient httpClient, string baseUrl)
        {
            if (httpClient == null)
            {
                throw new ArgumentNullException(nameof(httpClient));
            }
            if (string.IsNullOrWhiteSpace(baseUrl))
            {
                throw new ArgumentNullException(nameof(baseUrl));
            }

            _httpClient = httpClient;
            _baseUrl = baseUrl;
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }

        public async Task<T> UpdateEntityAsync(int id, T entity)
        {
            var url = new UrlEncoder(_baseUrl)
               .AddPath(id);

            var jsonString = JsonConvert.SerializeObject(entity);

            var response = await _httpClient.Clear().PutAsync(
                url.ToString(), new StringContent(jsonString, Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<T>(json);
            }

            return default(T);
        }
    }
}
