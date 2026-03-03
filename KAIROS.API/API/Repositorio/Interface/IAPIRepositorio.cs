using API.Model;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Repositorio.Interface
{
    public interface IAPIRepositorio
    {
        Task InsereCargosAPI(string Key, string CNPJ, string CaminhoExcel);
        Task<List<Cargo>> ListaCargosAPI(string Key, string CNPJ);
        Task InsereEstruturasAPI(string Key, string CNPJ, string CaminhoExcel);
        Task<List<Estrutura>> ListaEstruturasAPI(string Key, string CNPJ);
        Task<List<Horarios>> ListaHorariosAPI(string Key, string CNPJ);
        Task InserePessoaAPI(string Key, string CNPJ, Pessoa Pessoa);
        Task<bool> AtualizaPessoasAPI(string Key, string CNPJ, AtualizaPessoa pessoa);
        Task<bool> InsereSaldo(ChromeDriver bot, string Historico, string CaminhoExcel);
        Task<bool> ValidaSaldo(string CaminhoExcel);
        Task DesligaPessoa(string Key, string CNPJ, List<Desligamento> pessoa);
        Task DesligaPessoaTxt(string Key, string CNPJ, List<Desligamento> desligamento, string localDeGravacao);
        Task<Pessoa> ListaPessoaPorMatriculaAPI(string Key, string CNPJ, int Matricula);
        Task<List<Pessoa>> ListaPessoasAPI(string Key, string CNPJ);
    }
}
