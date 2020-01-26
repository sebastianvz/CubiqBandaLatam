using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;


namespace wpfCubiqBanda.UI.Helper
{
    public class Utilities
    {
        public static string DoRequest()
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com/posts");

            var response = client.Execute(new RestRequest());

            return response.Content;
        }
    }
}
