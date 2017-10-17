using GetZip.Enums;
using GetZip.Exceptions;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace GetZip.Http
{
    public static class RequestSearch
    {
        #region Public static methods
        /// <summary>
        /// Get or Post request
        /// </summary>
        /// <param name="url">Url of webservice</param>
        /// <param name="data">Content to send(Xml or Url)</param>
        /// <param name="method">Method option(GET or POST)</param>
        /// <returns>String result</returns>
        public static async Task<string> GetResponse(string url, string data, MethodOption method)
        {
            switch (method)
            {
                case MethodOption.POST: return await PostMethod(url, data);
                default: return await GetMethod(url, data);
            }
        }
        #endregion

        #region Private static methods
        private static async Task<string> GetMethod(string url, string data)
        {
            var client = new HttpClient { BaseAddress = new Uri(url) };
            var result = await client.GetAsync(data);
            if (result.StatusCode != HttpStatusCode.OK)
            {
                throw new BadRequestException();
            }
            return await result.Content.ReadAsStringAsync();
        }

        private static async Task<string> PostMethod(string url, string data)
        {
            var client = new HttpClient { BaseAddress = new Uri(url) };
            var result = await client.PostAsync(client.BaseAddress, new StringContent(data));
            var statusCode = result.EnsureSuccessStatusCode();
            if (!statusCode.IsSuccessStatusCode)
            {
                throw new BadRequestException();
            }
            var received = result.Content;
            return await received.ReadAsStringAsync();
        }
        #endregion
    }
}
