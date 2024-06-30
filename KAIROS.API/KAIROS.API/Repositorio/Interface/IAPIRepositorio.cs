using KAIROS.API.Model;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAIROS.API.Repositorio.Interface
{
    interface IAPIRepositorio
    {
        Task InsereCargosAPI(string Key, string CNPJ, string caminho);
        Task<List<Cargo>> ListaCargosAPI(string Key, string CNPJ);
        Task InsereEstruturasAPI(string Key, string CNPJ, string caminho);
        Task<List<Estrutura>> ListaEstruturasAPI(string Key, string CNPJ);
        Task<List<Horarios>> ListaHorariosAPI(string Key, string CNPJ);
        Task InserePessoaAPI(string Key, string CNPJ, string caminho, string CPFResponsavel, List<Pessoa> pessoas);
        Task InserePessoaAPINOVO(string Key, string CNPJ, Pessoa pessoa);
        Task<List<Pessoa>> ListaPessoasAPI(string Key, string CNPJ,int pagina =1);
        Task AtualizaPessoasAPI(string Key, string CNPJ,AtualizaPessoa pessoa);
        Task<bool> InsereSaldo(ChromeDriver bot, string Historico,string caminho);


    }
}
