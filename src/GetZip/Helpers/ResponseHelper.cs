using GetZip.Enums;
using GetZip.Http;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GetZip.Helpers
{
    /// <summary>
    /// Static helper class
    /// </summary>
    public static class ResponseHelper
    {
        #region Public static methods
        /// <summary>
        /// Async method to check if domain of service is online
        /// </summary>
        /// <param name="domain">Url of domain</param>
        /// <returns>Request status code</returns>
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

        /// <summary>
        /// Async method to get result of request
        /// </summary>
        /// <param name="url">Url os webservice</param>
        /// <param name="data">Content(Xml or Url)</param>
        /// <param name="node">Node to get return of the xml</param>
        /// <param name="option">Webservice method</param>
        /// <returns>XElement</returns>
        public static async Task<XElement> ResultRequest(string url, string data, string node, MethodOption option)
        {
            string errorMessage = "";
            try
            {
                string result = await RequestSearch.GetResponse(url, data, option);
                return CheckContentRequest(result,node);
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
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            return new XElement("error", errorMessage);
        }
        #endregion

        #region Private static methods
        private static XElement CheckContentRequest(string content, string node)
        {
            if (content is null || content == "")
                throw new ArgumentException("ZipCode or key is invalid");
            var doc = XDocument.Parse(content);
            var element = doc.Descendants(node).FirstOrDefault();
            if (element is null || element.IsEmpty)
                throw new HttpRequestException("Zip code is not found or invalid");
            return element;
        }
        #endregion
    }
}
