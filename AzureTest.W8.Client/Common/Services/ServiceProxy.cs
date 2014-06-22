using System;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AzureTest.Support.Services;
using Newtonsoft.Json;

namespace AzureTest.W8.Client.Common.Services
{
    public class ServiceProxy<T> : IServiceProxy<T> where T : IService
    {
        public void Invoke(Expression<Action<T>> method)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:10398/");
                client.DefaultRequestHeaders.Accept.Clear();
                var response = client.GetAsync(new Uri("api/team/get"));
                response.Result.EnsureSuccessStatusCode();

                if (!response.Result.IsSuccessStatusCode)
                {
                }
            }
        }

        public async Task<TResult> Invoke<TResult>(Expression<Func<T, TResult>> method)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:10398/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync("api/team");
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return await JsonConvert.DeserializeObjectAsync<TResult>(result);
                }
            }
            return default(TResult);
        }
    }
}
