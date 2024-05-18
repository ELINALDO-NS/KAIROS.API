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
        string AlteraPessoa_URL = "https://www.dimepkairos.com.br/RestServiceApi/People/ChangePerson";
        string ListaHorario_URL = "https://www.dimepkairos.com.br/RestServiceApi/Schedules/GetSchedulesSummary";
        string DeslihaPessoa_URL = "https://www.dimepkairos.com.br/RestServiceApi/Dismiss/MarkDismiss ";
        private readonly IExcelRepositorio _excel;

        public APIRepositorio(IExcelRepositorio excel)
        {
            _excel = excel;
        }


        public async Task InsereCargosAPI(string Key, string CNPJ, string caminho)
        {
            var cargos = await _excel.ListaCargosNovo(caminho);
            foreach( var cargo in cargos ) 
            { 
     
                using (var client = new RestClient(SalvaCargo_URL))
                {
                    var request = new RestRequest("", Method.Post);
                    request.AddHeader("Content-Type", "application/json");
                    request.AddHeader("key", Key);
                    request.AddHeader("identifier", CNPJ);

                    var carg = JsonConvert.SerializeObject(cargo);
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
                            Log.GravaLog("Salva Cargos - " + R + " : " + cargo.Codigo + " - " + cargo.Descricao);
                        }
                        else
                        {
                            Log.GravaLog("Salva Cargos - " + cargo.Descricao + " - " + Resposta.Mensagem);
                        }

                    }

                }

            };
        }

        public async Task InsereEstruturasAPI(string Key, string CNPJ, string Caminho)
        {
            var estruturas = await _excel.ListaEstruturasNovo(Caminho);
            foreach( var estrutura in estruturas)
            {
                using (var client = new RestClient(SalvaEstrutura_URL))
                {

                    var request = new RestRequest("", Method.Post);
                    request.AddHeader("Content-Type", "application/json");
                    request.AddHeader("key", Key);
                    request.AddHeader("identifier", CNPJ);
                    var estr = JsonConvert.SerializeObject(estrutura);
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
                            Log.GravaLog(R + " : " + estrutura.Codigo + " - " + estrutura.Descricao + " - " + CNPJ);
                        }
                        else
                        {
                            Log.GravaLog("Salva Estrutura - " + " : " + estrutura.Codigo + " - " + estrutura.Descricao + " - " + CNPJ + Resposta.Mensagem);
                        }

                    }


                }

            };
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
        public int status;
        public async Task InserePessoaAPI(string Key, string CNPJ, string caminho, string CPFResponsavel, List<Pessoa> pessoas)
        {

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

                });
            }
            catch (Exception ex)
            {
                string a = ex.Message;
            }
        }

        public async Task InserePessoaAPINOVO(string Key, string CNPJ, Pessoa pessoa)
        {

            var client = new RestClient(SalvaPessoa_URL);
            var request = new RestRequest("", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("key", Key);
            request.AddHeader("identifier", CNPJ);
            var JPessoa = JsonConvert.SerializeObject(pessoa);
            request.AddJsonBody(JPessoa);
            request.AddParameter("application/json; charset=utf-8", JPessoa, ParameterType.RequestBody);
            var response =  client.Execute(request);
            if (response.ContentType.Equals("application/json"))
            {
                var Resposta = JsonConvert.DeserializeObject<Resposta>(response.Content);
                if (!Resposta.Sucesso)
                {
                    Log.GravaLog("Salva Pessoa - " + Resposta.Mensagem + " - Matricula : " + pessoa.Matricula + " - " + pessoa.Nome);
                }

            }
            else
            {
                Log.GravaLog("Salva Pessoa - " + response.Content + " - Matricula : " + pessoa.Matricula + " - " + pessoa.Nome);
            }



        }

        public async Task<List<Pessoa>> ListaPessoasAPI(string Key, string CNPJ)
        {
            List <Pessoa> pessoa = new List<Pessoa>();
            await Task.Run(() =>
            {
                var client = new RestClient(ListaPessoas_URL);
                var request = new RestRequest("", Method.Post);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("key", Key);
                request.AddHeader("identifier", CNPJ);
                var body = "{}";
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                var response = client.Execute(request);
                Resposta Resposta = JsonConvert.DeserializeObject<Resposta>(response.Content);
                pessoa.AddRange(JsonConvert.DeserializeObject<List<Pessoa>>(Resposta.Obj.ToString()));
            });
            return pessoa;
        }

       public async Task AtualizaPessoasAPI(string Key, string CNPJ, AtualizaPessoa pessoa)
       {
            var client = new RestClient(AlteraPessoa_URL);
            var request = new RestRequest("", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("key", Key);
            request.AddHeader("identifier", CNPJ);
            var JPessoa = JsonConvert.SerializeObject(pessoa);
            request.AddJsonBody(JPessoa);
            request.AddParameter("application/json; charset=utf-8", JPessoa, ParameterType.RequestBody);
            var response = client.Execute(request);
            if (response.ContentType.Equals("application/json"))
            {
                var Resposta = JsonConvert.DeserializeObject<Resposta>(response.Content);
                if (!Resposta.Sucesso)
                {
                    Log.GravaLog("Salva Pessoa - " + Resposta.Mensagem + " - Matricula : " + pessoa.Matricula + " - " + pessoa.Nome);
                }

            }
            else
            {
                Log.GravaLog("Salva Pessoa - " + response.Content + " - Matricula : " + pessoa.Matricula + " - " + pessoa.Nome);
            }
        }
        public async Task DesligaPessoa(string Key, string CNPJ, Desligamento pessoa)
        {

            var client = new RestClient(DeslihaPessoa_URL);
            var request = new RestRequest("", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("key", Key);
            request.AddHeader("identifier", CNPJ);
            var JPessoa = JsonConvert.SerializeObject(pessoa);
            request.AddJsonBody(JPessoa);
            request.AddParameter("application/json; charset=utf-8", JPessoa, ParameterType.RequestBody);
            var response = client.Execute(request);
            if (response.ContentType.Equals("application/json"))
            {
                var Resposta = JsonConvert.DeserializeObject<Resposta>(response.Content);
                if (!Resposta.Sucesso)
                {
                    Log.GravaLog("Desliga Pessoa - " + Resposta.Mensagem + " - Matricula : " + pessoa.Matricula + " - " + pessoa);
                }

            }
            else
            {
                Log.GravaLog("Desliga Pessoa - " + response.Content + " - Matricula : " + pessoa.Matricula);
            }

        }


    }
}
