using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            HttpLogin();
        }

        private static void WriteY()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.Write("y");
                Thread.Sleep(100);
            }
        }

        private static void WriteX()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.Write("X");
                Thread.Sleep(200);
            }
        }

        private static void HttpLogin()
        {
            HttpClient _client = new HttpClient();
            _client.MaxResponseContentBufferSize = 256000;
            _client.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppletWebKit/537.36(KHTML, like Gecko) Chrome/36.0.1985.143 Safari/537.36");
            string url = "http://localhost";
            HttpResponseMessage response = _client.GetAsync(new Uri(url)).Result;
            Console.Write(response.Content);
            _client.Dispose();
        }

    }
}
