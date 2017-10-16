using GetZip.Enums;
using GetZip.Exceptions;
using GetZip.Http;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GetZip.Helpers
{
    public static class ResponseHelper
    {
        public static async Task<HttpStatusCode> ResultStatusCode(string domain)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(domain);
                    return response.StatusCode;
                }
            }
            catch
            {
                return HttpStatusCode.BadRequest;
            }
        }

        public static async Task<XElement> ResultRequest(string url, string data, string node, MethodOption option)
        {
            string errorMessage = "";
            try
            {
                string result = await RequestSearch.GetResponse(url, data, option);
                var doc = XDocument.Parse(result);
                return doc.Descendants(node).FirstOrDefault();
            }
            catch (ArgumentException ex)
            {
                errorMessage = ex.Message;
            }
            catch (HttpRequestException ex)
            {
                errorMessage = ex.Message;
            }
            catch (AggregateException ex)
            {
                errorMessage = ex.Message;
            }
            catch (ResponseException ex)
            {
                errorMessage = ex.Message;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            return new XElement("error", errorMessage);
        }
    }
}
