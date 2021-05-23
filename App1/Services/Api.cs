using Newtonsoft.Json;
using RestSharp;

namespace App1.Services
{
    public static class Api
    {
        public static Models.Arvore GetArvore(string id)
        {
            var client = new RestClient($"http://18.229.206.130:8080/api/arvore/{id}");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
                return JsonConvert.DeserializeObject<Models.Arvore>(response.Content);

            return null;
        }

        public static Models.RootArvore GetArvore()
        {
            var client = new RestClient("http://18.229.206.130:8080/api/arvore");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
                return JsonConvert.DeserializeObject<Models.RootArvore>(response.Content.Replace("\"body\"", "\"RootArvore\""));

            return null;
        }

        public static bool PostArvore(Models.Arvore value)
        {
            var client = new RestClient("http://18.229.206.130:8080/api/arvore");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            string json = "{\r\n    \"descricao\": \"" + value.descricao + "\", \r\n    \"foto\": null, \r\n    \"latitude\": " + value.latitude.ToString().Replace(",", ".") + ", \r\n    \"longitude\": " + value.longitude.ToString().Replace(",", ".") + ", \r\n    \"ponto_referencia\": \"" + value.ponto_referencia + "\", \r\n    \"codigo_pessoa\": \"1\", \r\n    \"codigo_especie\": \"0\", \r\n    \"codigo_regiao\": \"1\"\r\n}";

            request.AddParameter("application/json", json, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
                return true;

            return false;
        }

        public static bool GetLogin(string email, string senha)
        {
            var client = new RestClient("http://18.229.206.130:8080/api/login");
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

        public static Models.RootEspecie GetEspecies()
        {
            var client = new RestClient("http://18.229.206.130:8080/api/especie");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
                return JsonConvert.DeserializeObject<Models.RootEspecie>(response.Content.Replace("\"body\"", "\"RootEspecie\""));

            return null;

        }

        public static Models.RootManutencao GetManutencao()
        {
            var client = new RestClient("http://18.229.206.130:8080/api/manutencao");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
                return JsonConvert.DeserializeObject<Models.RootManutencao>(response.Content.Replace("\"body\"", "\"RootManutencao\""));

            return null;

        }

        public static bool PostManutencao(Models.Manutencao value)
        {
            var client = new RestClient("http://18.229.206.130:8080/api/manutencao");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            var body = JsonConvert.SerializeObject(value);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
                return true;

            return false;
        }
    }
}
