using RestSharp;
using RestSharp.Authenticators;

namespace Client
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var client = new RestClient("http://localhost:52382/token");
            RestRequest req = new RestRequest() { Method = Method.POST };
            req.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            client.Authenticator = new HttpBasicAuthenticator("client-app", "secret");
            //req.AddParameter("grant_type", "client_credentials");
            req.AddHeader("Accept", "application/json");
            var response = client.Execute(req);
        }
    }
}