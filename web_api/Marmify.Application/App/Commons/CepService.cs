using Marmify.Application.Interfaces.Commons;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System.Text.RegularExpressions;

namespace Marmify.Application.App.Commons
{
	public class CepService : ICepService
    {
        private readonly IRestClient _restClient;

        public CepService()
        {
            _restClient = new RestClient("https://viacep.com.br/ws")
            {
                Proxy = null
            };
        }

        public CepDTO GetAddressByCep(string cep)
        {
            if (ValidateFormatCEP(cep))
            {
                cep = cep + "/json";
                var request = new RestRequest(cep, Method.GET)
                {
                    Timeout = TimeoutConsulting
                };

                int attempts = 3;
                int attempt = 0;
                do
                {
                    IRestResponse restResponse = _restClient.Execute(request);
                    if (restResponse.ResponseStatus == ResponseStatus.TimedOut)
                    {
                        if (restResponse.IsSuccessful || restResponse.StatusCode == HttpStatusCode.OK)
                            break;
                        else
                            attempt++;
                    }
                    else
                        return JsonConvert.DeserializeObject<CepDTO>(restResponse.Content);

                } while (attempt < attempts);
            }
            return null;
        }

        public int TimeoutConsulting
        {
            get
            {
                int timeout = 0;

                try
                {
                    int.TryParse("10", out timeout);
                }
                catch
                {
                    timeout = 10;
                }
                return timeout * 1000;
            }
        }

        public bool ValidateFormatCEP(string cep)
        {
            string pattern = @"\d{5}[-]?\d{3}";
            Regex Rgx = new Regex(pattern);

            if (!Rgx.IsMatch(cep))
                return false;
            else
                return true;
        }
    }

    public class CepDTO
    {
        [JsonProperty(PropertyName = @"cep", Required = Required.Always)]
        public string Cep { get; set; }

        [JsonProperty(PropertyName = @"logradouro", Required = Required.Always)]
        public string PublicPlace { get; set; }

        [JsonProperty(PropertyName = @"complemento", Required = Required.Always)]
        public string Complement { get; set; }

        [JsonProperty(PropertyName = @"bairro", Required = Required.Always)]
        public string Neighborhood { get; set; }

        [JsonProperty(PropertyName = @"localidade", Required = Required.Always)]
        public string Locality { get; set; }

        [JsonProperty(PropertyName = @"uf", Required = Required.Always)]
        public string Uf { get; set; }

        [JsonProperty(PropertyName = @"ibge", Required = Required.Always)]
        public string Ibge { get; set; }

        [JsonProperty(PropertyName = @"gia", Required = Required.Always)]
        public string Gia { get; set; }

        [JsonProperty(PropertyName = @"ddd", Required = Required.Always)]
        public string DDD { get; set; }
    }
}
