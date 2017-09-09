using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpLogin();
        }

        private static void HttpLogin()
        {

            HttpClient httpClient = new HttpClient();
            httpClient.MaxResponseContentBufferSize = 256000;
            httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/36.0.1985.143 Safari/537.36");
            String url = "http://localhost:8098";
            HttpResponseMessage response = httpClient.GetAsync(new Uri(url)).Result;
            String result = response.Content.ReadAsStringAsync().Result;

            string username = "admin";
            string password = "888888";



            Console.Write(result);
            Console.ReadKey();
        }

    }
}
