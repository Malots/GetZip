using GetZip.Enums;
using GetZip.Exceptions;
using System;
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
                throw new ArgumentException("Error", ex);
            }
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException("Error", ex);
            }
            catch (AggregateException ex)
            {
                throw new AggregateException("Error", ex);
            }
            catch (ResponseException ex)
            {
                throw new ResponseException("Error", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
        #endregion

        #region Private methods
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
