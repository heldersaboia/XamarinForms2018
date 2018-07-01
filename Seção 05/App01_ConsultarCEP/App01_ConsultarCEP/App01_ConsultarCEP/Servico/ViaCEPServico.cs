using App01_ConsultarCEP.Servico.Modelo;
using System.Net;
using Newtonsoft.Json;


namespace App01_ConsultarCEP.Servico
{
    public class ViaCEPServico
    {
        private static readonly string enderecoURL = "http://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            string novoEnderecoURL = string.Format(enderecoURL, cep);

            var webClient = new WebClient();
            string conteudo = webClient.DownloadString(novoEnderecoURL);

            var endereco = JsonConvert.DeserializeObject<Endereco>(conteudo);

            if (endereco.cep == null)
            {
                return null;
            }

            return endereco;
        }

    }
}
