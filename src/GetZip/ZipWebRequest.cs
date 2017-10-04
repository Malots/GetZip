using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GetZip
{
    internal static class ZipWebRequest
    {
        #region methods
        public static async Task<string> GetResponse(string URL, string postData)
        {
            try
            {
                string received = null;
                var request = WebRequest.Create(new Uri(URL)) as HttpWebRequest;
                request.UserAgent = "Malots";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Method = "POST";
                byte[] data = Encoding.UTF8.GetBytes(postData);
                request.ContentLength = data.Length;
                using (var requestStream = await Task<Stream>.Factory.FromAsync(request.BeginGetRequestStream, request.EndGetRequestStream, request))
                {
                    await requestStream.WriteAsync(data, 0, data.Length);
                }
                using (var responseObject = await Task<WebResponse>.Factory.FromAsync(request.BeginGetResponse, request.EndGetResponse, request))
                {
                    var responseStream = responseObject.GetResponseStream();
                    using (var reader = new StreamReader(responseStream))
                    {
                        received = await reader.ReadToEndAsync();
                    }
                }
                return received;
            }
            catch
            {
                return null;
            }
        }
        #endregion
    }
}
