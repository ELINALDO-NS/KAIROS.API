using KAIROS.API.Model;
using KAIROS.API.Repositorio.Interface;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.LinkLabel;

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
        string ListaPessoaPorId_URL = "https://www.dimepkairos.com.br/RestServiceApi/People/SearchPerson ";
        private readonly IExcelRepositorio _excel;

        public APIRepositorio(IExcelRepositorio excel)
        {
            _excel = excel;
        }


        public async Task InsereCargosAPI(string Key, string CNPJ, string caminho)
        {
            var cargos = await _excel.ListaCargosNovo(caminho);
            foreach (var cargo in cargos)
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
            foreach (var estrutura in estruturas)
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
        public async Task<Pessoa> ListaPessoaPorMatriculaAPI(string Key, string CNPJ, int Matricula)
        {

            try
            {
                List<Pessoa> pess = new();

                var client = new RestClient(ListaPessoaPorId_URL);
                var request = new RestRequest("", Method.Post);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("key", Key);
                request.AddHeader("identifier", CNPJ);
                var body = @"
                            " + "\n" +
                            @"{
                            " + "\n" +
                            $@"  ""Matricula"" :{Matricula}
                            " + "\n" +
                            @"}
                            " + "\n" +
                        @"";
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                var response = await client.ExecuteAsync(request);
                if (response != null)
                {
                    Resposta? Resposta = JsonConvert.DeserializeObject<Resposta>(response.Content);
                    if (Resposta.Sucesso)
                    {
                        pess = JsonConvert.DeserializeObject<List<Pessoa>>(Resposta.Obj.ToString());
                    }
                    else
                    {
                        return null;
                    }

                }
                return pess[0];
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }



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
            int TotalPagina = 1;
            await Task.Run(() =>
            {
                for (int pagina = 1; pagina <= TotalPagina; pagina++)
                {
                    var client = new RestClient(ListaHorario_URL);
                    var request = new RestRequest("", Method.Post);
                    request.AddHeader("Content-Type", "application/json");
                    request.AddHeader("key", Key);
                    request.AddHeader("identifier", CNPJ);
                    var body  = $@"
                            " + "\n" +
                                   @"{
                            " + "\n" +
                                   $@"  ""pagina"" : {pagina}
                            " + "\n" +
                                   @"}
                            " + "\n" +
                               @"";
                    request.AddParameter("application/json", body, ParameterType.RequestBody);
                    var response = client.Execute(request);
                    Resposta? Resposta = JsonConvert.DeserializeObject<Resposta>(response.Content);
                    TotalPagina = Resposta.TotalPagina;
                    horario.AddRange(JsonConvert.DeserializeObject<List<Horarios>>(Resposta.Obj.ToString()));
                }
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

        public async Task<List<Pessoa>> ListaTodasPaginasPessoasAPI(string Key, string CNPJ, int totalPage)
        {
            List<Pessoa> pessoas = new List<Pessoa>();

            for (int pagina = 1; pagina <= totalPage; pagina++)
            {
                var client = new RestClient(ListaPessoas_URL);
                var request = new RestRequest("", Method.Post);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("key", Key);
                request.AddHeader("identifier", CNPJ);
                var body = @"
                            " + "\n" +
                                   @"{
                            " + "\n" +
                                   $@"  ""pagina"" : {pagina}
                            " + "\n" +
                                   @"}
                            " + "\n" +
                               @"";
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                var response1 =  client.Execute(request);
                Resposta? Resposta = JsonConvert.DeserializeObject<Resposta>(response1.Content);
                if (Resposta.Sucesso)
                {
                    pessoas.AddRange(JsonConvert.DeserializeObject<List<Pessoa>>(Resposta.Obj.ToString()));
                }
                else
                {
                    Log.GravaLog(Resposta.Mensagem.ToString() + $" - Pagina requisitada: {pagina}");
                }
            }
            return pessoas;
        }

        public async Task<List<Pessoa>> ListaPessoasAPI(string Key, string CNPJ, int pagina = 1)
        {
            List<Pessoa> pessoa = new List<Pessoa>();
            await Task.Run(async () =>
            {
                var client = new RestClient(ListaPessoas_URL);
                var request = new RestRequest("", Method.Post);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("key", Key);
                request.AddHeader("identifier", CNPJ);
                var body = @"
                            " + "\n" +
                                   @"{
                            " + "\n" +
                                   $@"  ""pagina"" : {pagina}
                            " + "\n" +
                                   @"}
                            " + "\n" +
                               @"";
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                var response1 = client.Execute(request);
                Resposta? Resposta = JsonConvert.DeserializeObject<Resposta>(response1.Content);
                if (Resposta.Sucesso)
                {
                    if (Resposta.TotalPagina > 1)
                    {
                        pessoa = await ListaTodasPaginasPessoasAPI(Key,CNPJ, Resposta.TotalPagina);
                    }
                    else
                    {
                        pessoa.AddRange(JsonConvert.DeserializeObject<List<Pessoa>>(Resposta.Obj.ToString()));

                    }
                }
                else
                {
                    Log.GravaLog(Resposta.Mensagem.ToString() + $" - Pagina requisitada: {pagina}");
                }

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
        public async Task DesligaPessoa(string Key, string CNPJ, List<Desligamento> desligamento)
        {

            var client = new RestClient(DeslihaPessoa_URL);
            var request = new RestRequest("", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("key", Key);
            request.AddHeader("identifier", CNPJ);
            string diretorio = @"C:\Users\SUPORTE\Desktop\Desligamento.txt";
            StreamWriter writer = new StreamWriter(diretorio, true);
            int i = 0;
            foreach (var item in desligamento)
            {
                var IdPessoa = await ListaPessoaPorMatriculaAPI(Key, CNPJ, item.Matricula);

                if (IdPessoa != null)
                {
                    writer.WriteLine("902" + IdPessoa.CodigoPis.ToString().PadLeft(12, '0') +
                   IdPessoa.Matricula.ToString().PadLeft(9, '0') + item.DATA.Date);
                }
                Console.WriteLine(i);
                i++;


                //var JPessoa = JsonConvert.SerializeObject(item);
                //request.AddJsonBody(JPessoa);
                //request.AddParameter("application/json; charset=utf-8", JPessoa, ParameterType.RequestBody);
                //var response = client.Execute(request);
                //if (response.ContentType.Equals("application/json"))
                //{
                //    var Resposta = JsonConvert.DeserializeObject<Resposta>(response.Content);
                //    if (!Resposta.Sucesso)
                //    {
                //        Log.GravaLog("Desliga Pessoa - " + Resposta.Mensagem + " - Matricula : " + item.Matricula);
                //    }

                //}
                //else
                //{
                //    Log.GravaLog("Desliga Pessoa - " + response.Content + " - Matricula : " + item.Matricula);
                //}

            }
            writer.Flush();
            writer.Close();

        }
        public async Task DesligaPessoaTxt(string Key, string CNPJ, List<Desligamento> desligamento, string localDeGravacao)
        {

            var client = new RestClient(DeslihaPessoa_URL);
            var request = new RestRequest("", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("key", Key);
            request.AddHeader("identifier", CNPJ);
            string diretorio = @$"{localDeGravacao}\Desligamento.txt";

            int i = 0;
            using (StreamWriter writer = new StreamWriter(diretorio, true))
            {

                foreach (var item in desligamento)
                {
                    var IdPessoa = await ListaPessoaPorMatriculaAPI(Key, CNPJ, item.Matricula);

                    if (IdPessoa != null)
                    {
                        writer.WriteLine("902" + IdPessoa.CodigoPis.ToString().PadLeft(12, '0') +
                       IdPessoa.Matricula.ToString().PadLeft(9, '0') + item.DATA.Date);
                    }
                    Console.WriteLine(i);
                    i++;

                }
            }
           

        }

        private bool PessoaExiste(ChromeDriver chromeDriver)
        {

            bool existe = chromeDriver.FindElements(By.ClassName("funcionarioName")).Count() > 0;
            return existe;
        }
        public async Task<bool> ValidaSaldo(string caminho)
        {
            int Linha = 5;
            Excel excel = new Excel(caminho);
            bool ValidaSaldo = true;
            string Planilha = "Lanç. Saldo de Banco Residual";
            while (true)
            {
                string Matricula = excel.LeExcel(Planilha, Linha, 1);

                if (!string.IsNullOrEmpty(Matricula))
                {
                    if (!string.IsNullOrEmpty(excel.LeExcel(Planilha, Linha, 2)))
                    {
                        string[] Saldo1 = excel.LeExcel("Lanç. Saldo de Banco Residual", Linha, 2).Split(":");

                        string Saldo = $"{Saldo1[0].PadLeft(4, '0')}:{Saldo1[1]}";

                        if (Convert.ToInt32(Saldo1[1]) > 59)
                        {
                            ValidaSaldo = false;
                            Log.GravaLog($"Saldo invalido - matricula: {Matricula}");
                        }


                    }
                }
                else
                {
                    break;

                }
                Linha++;
            }
            return ValidaSaldo;
        }

        private string ErroLancamento(ChromeDriver chromeDriver)
        {
            string existe = string.Empty;
            if (chromeDriver.FindElements(By.ClassName("field-validation-error-Popups")).Count() > 0)
            {
                existe = chromeDriver.FindElement(By.ClassName("field-validation-error-Popups")).Text;
                return existe;
            }
            else
            {
                return existe;
            }
        }
        private async Task<bool> InsereSaldoBot(ChromeDriver bot, string Matricula, string Historico, string Data, bool Posito_Negativo, string Saldo)
        {
            Thread.Sleep(2000);
            bot.FindElement(By.Id("filterResumeMessagesButton")).Click();
            bot.FindElement(By.Id("userAutocomplete")).SendKeys($"{Matricula}");
            bot.FindElement(By.Id("SearchButtonPessoa")).Click();
            bot.FindElement(By.XPath("//*/text()[normalize-space(.)='Lançamento de Banco de Horas']/parent::*")).Click();
            if (PessoaExiste(bot))
            {

                bot.FindElement(By.ClassName("checkboxCustom")).Click();
                bot.FindElement(By.Id("LancarBancoHoras")).Click();
                Thread.Sleep(1000);
                if (Posito_Negativo)
                {
                    Thread.Sleep(1000);
                    bot.ExecuteScript($"document.getElementById('credito').value = '{Saldo}'");
                }
                else
                {
                    Thread.Sleep(1000);
                    bot.ExecuteScript($"document.getElementById('debito').value = '{Saldo}'");
                }
                bot.FindElement(By.Id("dataLancarBancoHoras")).Clear();
                // bot.FindElement(By.Id("dataLancarBancoHoras")).SendKeys($"{saldo.Data}");

                bot.ExecuteScript($"document.getElementById('dataLancarBancoHoras').value = '{Data?.Replace("00:00:00", "")}'");
                bot.FindElement(By.Id("historico")).SendKeys(Historico);
                bot.FindElement(By.Id("SaveLancarBancoHoras")).Click();
                Thread.Sleep(1000);
                if (!string.IsNullOrWhiteSpace(ErroLancamento(bot)))
                {
                    Log.GravaLog($"Funcionario de Matricula: {Matricula} - " + ErroLancamento(bot));
                    Thread.Sleep(1000);
                    bot.FindElement(By.XPath("//button/span")).Click();
                    return true;
                    // bot.FindElement(By.ClassName("ui-button-icon-primary")).Click();
                }

            }
            else
            {
                Log.GravaLog($"Funcionario de Matricula: {Matricula} não encontrado no KAIROS !");
                return true;
            }
            return false;
        }

        public async Task<bool> InsereSaldo(ChromeDriver bot, string Historico, string caminho)
        {
            using (bot)
            {
                int Linha = 5;
                Excel excel = new Excel(caminho);
                string Planilha = "Lanç. Saldo de Banco Residual";
                bool erro = false;
                await Task.Run(async () =>
                {
                    TimeSpan t = new TimeSpan(10);
                    WebDriverWait wait = new WebDriverWait(bot, t);
                    // WebElement element = wait.Until(ExpectedConditions.elementToBeClickable(By.id("someid")));
                    MessageBox.Show("Selecione a Empresa !", "Lança Saldo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bot.FindElement(By.Id("Tab6")).Click();
                    bot.FindElement(By.Id("userAutocomplete")).SendKeys("teste");
                    bot.FindElement(By.Id("SearchButtonPessoa")).Click();

                    while (true)
                    {
                        string Matricula = excel.LeExcel(Planilha, Linha, 1);

                        if (!string.IsNullOrEmpty(Matricula))
                        {

                            if (!string.IsNullOrEmpty(excel.LeExcel(Planilha, Linha, 2)))
                            {
                                bool Pos_Neg = false;

                                if (excel.LeExcel(Planilha, Linha, 3) == "POSITIVO")
                                {
                                    Pos_Neg = true;
                                }

                                string[] Saldo1 = excel.LeExcel("Lanç. Saldo de Banco Residual", Linha, 2).Split(":");
                                DateTime Data = Convert.ToDateTime(excel.LeExcel("Lanç. Saldo de Banco Residual", Linha, 4));
                                string Saldo = $"{Saldo1[0].PadLeft(4, '0')}:{Saldo1[1]}";
                                if (!(excel.LeExcel(Planilha, Linha, 5) == "OK".ToUpper()) || !(Saldo == "0000:00"))
                                {
                                    erro = await InsereSaldoBot(bot, Matricula, Historico, Data.ToString(), Pos_Neg, Saldo);
                                    if (erro)
                                    {
                                        excel.EscreveExcel(Planilha, Linha, 5, "NOK");
                                    }
                                    else
                                    {
                                        excel.EscreveExcel(Planilha, Linha, 5, "OK");
                                    }
                                }


                            }


                            Linha++;
                        }
                        else
                        {
                            break;
                        }
                    }
                });
                if (erro)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

        }



    }
}
