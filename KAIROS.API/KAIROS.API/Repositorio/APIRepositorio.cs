using KAIROS.API.Model;
using KAIROS.API.Repositorio.Interface;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KAIROS.API.Repositorio
{
    public class APIRepositorio : IAPIRepositorio
    {
        string ListarCargos_URL = "https://www.dimepkairos.com.br/RestServiceApi/JobPosition/SearchJobPosition";
        string ListarEstrutura_URL = "https://www.dimepkairos.com.br/RestServiceApi/OrganizationalStructure/SearchOrganizationalStructure";
        string SalvaEstrutura_URL = "https://www.dimepkairos.com.br/RestServiceApi/OrganizationalStructure/SaveOrganizationalStructure";
        string SalvaCargo_URL = "https://www.dimepkairos.com.br/RestServiceApi/JobPosition/SaveJobPosition";
        string ListaPessoas_URL = "https://www.dimepkairos.com.br/RestServiceApi/People/SearchPeople";
        string SalvaPessoa_URL = "https://www.dimepkairos.com.br/RestServiceApi/People/SavePerson";
        string ListaHorario_URL = "https://www.dimepkairos.com.br/RestServiceApi/Schedules/GetSchedulesSummary";


        public Task InsereCargosAPI(string Key, string CNPJ, Cargo cargo)
        {
            throw new NotImplementedException();
        }

        public Task InsereEstruturasAPI(string Key, string CNPJ, Estrutura estrutura)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Cargo>> ListaCargosAPI(string Key, string CNPJ)
        {
            var cargos = new List<Cargo>();
            var client = new RestClient(ListarCargos_URL);
            var request = new RestRequest("", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("key", Key);
            request.AddHeader("identifier", CNPJ);
            var body = @"
                            " + "\n" +
                        @"{
                            " + "\n" +
                        @"  ""Codigo"" : 0
                            " + "\n" +
                        @"}
                            " + "\n" +
                    @"";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            var response = client.Execute(request);
            Resposta Resposta = JsonConvert.DeserializeObject<Resposta>(response.Content);
            cargos.AddRange(JsonConvert.DeserializeObject<List<Cargo>>(Resposta.Obj.ToString()).OrderBy(x => x.Descricao).ToList());

            return cargos;
        }

        public async Task<List<Estrutura>> ListaEstruturasAPI(string Key, string CNPJ)
        {
            var estruturas = new List<Estrutura>();
            var client = new RestClient(ListarEstrutura_URL);
            var request = new RestRequest("", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("key", Key);
            request.AddHeader("identifier", CNPJ);
            var body = @"
                         " + "\n" +
                     @"{
                         " + "\n" +
                     @"  ""Codigo"" : 0
                         " + "\n" +
                     @"}
                         " + "\n" +
                     @"";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            var response = client.Execute(request);
            Resposta Resposta = JsonConvert.DeserializeObject<Resposta>(response.Content);
            estruturas.AddRange(JsonConvert.DeserializeObject<List<Estrutura>>(Resposta.Obj.ToString()).OrderBy(x => x.Descricao));
            return estruturas;
        }

        public async Task<List<Horarios>> ListaHorariosAPI(string Key, string CNPJ)
        {
            var horario = new List<Horarios>();
            await Task.Run(() =>
            {
                var client = new RestClient(ListaHorario_URL);
                var request = new RestRequest("", Method.Post);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("key", Key);
                request.AddHeader("identifier", CNPJ);
                var body = "{}";
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                var response = client.Execute(request);
                Resposta Resposta = JsonConvert.DeserializeObject<Resposta>(response.Content);
                horario.AddRange(JsonConvert.DeserializeObject<List<Horarios>>(Resposta.Obj.ToString()));
            });
            return horario;
        }
    }
}
