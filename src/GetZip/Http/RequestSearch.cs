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
        #region Public methods
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
            catch (ArgumentException ex)
            {
                throw new ArgumentException(ex.Message);
            }
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException(ex.Message);
            }
            catch (AggregateException ex)
            {
                throw new AggregateException(ex.Message);
            }
            catch (ResponseException ex)
            {
                throw new ResponseException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Private methods
        private static async Task<string> GetMethod(string url, string data)
        {
            var client = new HttpClient { BaseAddress = new Uri(url) };
            var result = await client.GetAsync(data);
            if (result.StatusCode != HttpStatusCode.OK)
            {
                throw new InvalidZipCodeException();
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
                throw new ResponseException();
            }
            var received = result.Content;
            return await received.ReadAsStringAsync();
        }
        #endregion
    }
}
