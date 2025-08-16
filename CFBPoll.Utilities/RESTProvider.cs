using System.Net;
using System.Text;

namespace CFBPoll.Utilities
{
    public static class RESTProvider
    {
        private static Dictionary<string, string> JsonHeaders => new Dictionary<string, string>()
        {
            { "Content-Type", "application/json" },
            { "Accept", "application/json" }
        };

        /// <summary>
        /// Performs a GET request to the provided endpoint using the provided request headers.
        /// </summary>
        /// <param name="endPoint">The full endpoint URL which includes all the parameters of the request.</param>
        /// <param name="headers">Any information needed to pass in the headers.</param>
        /// <returns>A string representation of the response body.</returns>
        public static string GetStringReturn(string endPoint, IDictionary<string, string> headers)
        {
            //If there were no supplied headers then use default headers
            if (headers == null || !headers.Any())
                headers = JsonHeaders;

            var webClient = new WebClient();

            //Add the headers to the request
            if (headers?.Any() ?? false)
                foreach (var header in headers)
                    webClient.Headers.Add(header.Key, header.Value);

            //Perform the GET request and return the string response
            webClient.Headers["Content-type"] = "application/json";
            webClient.Encoding = Encoding.UTF8;
            return webClient.DownloadString(new Uri(endPoint));
        }
    }
}
