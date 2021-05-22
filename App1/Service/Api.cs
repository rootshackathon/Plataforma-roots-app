using Newtonsoft.Json;
using RestSharp;

namespace App1.Service
{
    public static class Api
    {
        public static bool GetLogin(string email, string senha)
        {
            var client = new RestClient("http://222.222.3.236:9090/api/login");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", "{\r\n    \"email\": \"" + email + "\",\r\n    \"password\": \"" + senha + "\"\r\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var login = JsonConvert.DeserializeObject<Models.RootLogin>(response.Content.Replace("\"body\"", "\"RootLogin\""));
                return login.status;
            }

            return false;
        }
    }
}
