using KAIROS.API.Model;
using KAIROS.API.Repositorio.Interface;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
        private readonly IExcelRepositorio _excel;

        public APIRepositorio(IExcelRepositorio excel)
        {
            _excel = excel;
        }


        public async Task InsereCargosAPI(string Key, string CNPJ, string caminho)
        {
            var cargos = await _excel.ListaCargosNovo(caminho);
            foreach (var item in cargos)
            {
                using (var client = new RestClient(SalvaCargo_URL))
                {
                    var request = new RestRequest("", Method.Post);
                    request.AddHeader("Content-Type", "application/json");
                    request.AddHeader("key", Key);
                    request.AddHeader("identifier", CNPJ);

                    var carg = JsonConvert.SerializeObject(item);
                    request.AddParameter("application/json", carg, ParameterType.RequestBody);
                    var response = client.Execute(request).Content;
                    Resposta Resposta = JsonConvert.DeserializeObject<Resposta>(response);

                    if (!Resposta.Sucesso)
                    {
                        string R = "";
                        if (Resposta.Mensagem.Contains("Could not complete the action because there is a job " +
                            "position with the same code"))
                        {
                            R = "Não foi possível concluir a ação porque existe um cargo com o mesmo código.";
                            Log.GravaLog("Salva Cargos - " + R + " : " + item.Codigo + " - " + item.Descricao);
                        }
                        else
                        {
                            Log.GravaLog("Salva Cargos - " + item.Descricao + " - " + Resposta.Mensagem);
                        }

                    }

                }

            }
        }

        public async Task InsereEstruturasAPI(string Key, string CNPJ, string Caminho)
        {
            var estruturas = await _excel.ListaEstruturasNovo(Caminho);
            foreach (var item in estruturas)
            {
                using (var client = new RestClient(SalvaEstrutura_URL))
                {

                    var request = new RestRequest("", Method.Post);
                    request.AddHeader("Content-Type", "application/json");
                    request.AddHeader("key", Key);
                    request.AddHeader("identifier", CNPJ);
                    var estr = JsonConvert.SerializeObject(item);
                    request.AddParameter("application/json", estr, ParameterType.RequestBody);
                    var response = client.Execute(request).Content;
                    Resposta Resposta = JsonConvert.DeserializeObject<Resposta>(response);
                    if (!Resposta.Sucesso)
                    {
                        string R = "";
                        if (Resposta.Mensagem.Contains("Could not complete the action because there" +
                            " is a structure with the same description."))
                        {
                            R = " Não foi possível concluir a ação porque existe uma estrutura com o mesmo codigo/descrição.";
                            Log.GravaLog(R + " : " + item.Codigo + " - " + item.Descricao + " - " + CNPJ);
                        }
                        else
                        {
                            Log.GravaLog("Salva Estrutura - " + " : " + item.Codigo + " - " + item.Descricao + " - " + CNPJ + Resposta.Mensagem);
                        }

                    }


                }

            }
        }

        public async Task<List<Cargo>> ListaCargosAPI(string Key, string CNPJ)
        {
            var cargos = new List<Cargo>();
            await Task.Run(() =>
                  {
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
                      cargos.AddRange(JsonConvert.DeserializeObject<List<Cargo>>(Resposta.Obj.ToString()));
                  });
            return cargos;
        }

        public async Task<List<Estrutura>> ListaEstruturasAPI(string Key, string CNPJ)
        {
            var estruturas = new List<Estrutura>();
            await Task.Run(() =>
            {
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
                estruturas.AddRange(JsonConvert.DeserializeObject<List<Estrutura>>(Resposta.Obj.ToString()));
            });
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

        public async Task InserePessoaAPI(string Key, string CNPJ, string caminho, string CPFResponsavel, List<Pessoa> pessoas)
        {
            int status = 0;
            Form1.StatusPessoas = $"{status}/{pessoas.Count}";
            try
            {

                Parallel.ForEach(pessoas, Pessoa =>
                {
                    var client = new RestClient(SalvaPessoa_URL);
                    var request = new RestRequest("", Method.Post);
                    request.AddHeader("Content-Type", "application/json");
                    request.AddHeader("key", Key);
                    request.AddHeader("identifier", CNPJ);
                    var JPessoa = JsonConvert.SerializeObject(Pessoa);
                    request.AddJsonBody(JPessoa);
                    request.AddParameter("application/json; charset=utf-8", JPessoa, ParameterType.RequestBody);
                    var response = client.Execute(request);
                    if (response.ContentType.Equals("application/json"))
                    {
                        var Resposta = JsonConvert.DeserializeObject<Resposta>(response.Content);
                        if (!Resposta.Sucesso)
                        {
                            Log.GravaLog("Salva Pessoa - " + Resposta.Mensagem + " - Matricula : " + Pessoa.Matricula + " - " + Pessoa.Nome);
                        }

                    }
                    else
                    {
                        Log.GravaLog("Salva Pessoa - " + response.Content + " - Matricula : " + Pessoa.Matricula + " - " + Pessoa.Nome);
                    }
                    Form1.StatusPessoas = $"{status}/{pessoas.Count}";
                });
            }
            catch (Exception ex)
            {

                string a = ex.Message;
            }
        }
    }
}
