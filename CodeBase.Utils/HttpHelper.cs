using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CodeBase.Utils
{
    public class HttpHelper
    {
        private readonly HttpClient _client;

        public HttpClient Client => _client;

        public HttpHelper(Uri baseAddress)
        {
            _client = new HttpClient(new HttpClientHandler() { UseDefaultCredentials = true }) { BaseAddress = baseAddress };

            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public TModel Get<TModel>(string endpoint)
        {
            return GetResult<TModel>(Client.GetAsync(endpoint).Result);
        }

        public void Get(string endpoint)
        {
            Client.GetAsync(endpoint);
        }

        public List<TModel> GetList<TModel>(string endpoint)
        {
            var result = Client.GetAsync(endpoint).Result.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<List<TModel>>(Client.GetAsync(endpoint).Result.Content.ReadAsStringAsync().Result);
        }

        public void Post<TModel>(string endpoint, TModel model)
        {
            Client.PostAsync(endpoint, new StringContent(JsonConvert.SerializeObject(model),
                Encoding.UTF8,
                "application/json"));
        }

        private static TResult GetResult<TResult>(HttpResponseMessage response)
        {
            return JsonConvert.DeserializeObject<TResult>(response.Content.ReadAsStringAsync().Result);
        }
    }
}
