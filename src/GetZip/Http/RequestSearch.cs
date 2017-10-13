using GetZip.Enums;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GetZip.Http
{
    public static class RequestSearch
    {
        #region methods
        public static async Task<string> GetResponse(string url, string data, MethodOption method)
        {
            try
            {
                switch(method)
                {
                    case MethodOption.POST: return await PostMethod(url, data);
                    default: return await GetMethod(url, data);
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private static async Task<string> GetMethod(string url, string data)
        {
            var client = new HttpClient { BaseAddress = new Uri(url) };
            var result = client.GetAsync(data);
            var received = result.Result;
            return await received.Content.ReadAsStringAsync();
        }

        private static async Task<string> PostMethod(string url, string data)
        {
            var client = new HttpClient { BaseAddress = new Uri(url) };
            var result = await client.PostAsync(client.BaseAddress, new StringContent(data));
            result.EnsureSuccessStatusCode();
            var received = result.Content;
            return await received.ReadAsStringAsync();
        }
        #endregion
    }
}
