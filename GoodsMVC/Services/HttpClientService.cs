using GoodsMVC.Config;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.Formatters;
using GoodsCore.Models;
using Goods.Models;

namespace GoodsMVC.Services
{
    public class HttpClientService
    {
        private IOptions<ApiConfig> _apiConfig;

        public HttpClientService(IOptions<ApiConfig> apiConfig)
        {
            _apiConfig = apiConfig;
        }

        public async Task<Tout?> Post<TIn, Tout>(string uri, TIn postData)
        {
            using HttpClient client = new HttpClient();

            var response = await client.PostAsJsonAsync(_apiConfig.Value.Host + uri, postData);

            var statusCode = response.StatusCode;
            var model = await response.Content.ReadFromJsonAsync<Tout>();

            return model;
        }

        public async Task Post<TIn>(string uri, TIn postData)
        {
            using HttpClient client = new HttpClient();

            var response = await client.PostAsJsonAsync(_apiConfig.Value.Host + uri, postData);
            //var model = await response.Content.ReadFromJsonAsync<Tout>();

            return;
        }

        public async Task Delete(string uri)
        {
            using HttpClient client = new HttpClient();

            var response = await client.DeleteAsync(_apiConfig.Value.Host + uri);
            //var model = await response.Content.ReadFromJsonAsync<Tout>();

            //return;
        }

        public async Task Put<TIn>(string uri, TIn putData)
        {
            using HttpClient client = new HttpClient();

            var response = await client.PutAsJsonAsync(_apiConfig.Value.Host + uri, putData);
            //var model = await response.Content.ReadFromJsonAsync<Tout>();

            //return;
        }

        public async Task<TOut> Get<TOut>(string uri)
        {
            using HttpClient client = new HttpClient();

            var model = await client.GetFromJsonAsync<TOut>(_apiConfig.Value.Host + uri);
            //var model = await response.Content.ReadFromJsonAsync<Tout>();

            return model;
        }
    }
}

