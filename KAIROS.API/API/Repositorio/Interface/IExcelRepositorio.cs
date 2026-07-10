using API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Repositorio.Interface
{
    public interface IExcelRepositorio
    {
        Task<List<Cargo>> ListaCargos(string CaminhoExcel, bool comunicacao = false);
        Task<List<Estrutura>> ListaEstruturas(string CaminhoExcel, bool comunicacao = false);
        Task<List<Horarios>> ListaHorariosAssociados(string CaminhoExcel, bool comunicacao);
        Task<List<Horarios>> ListaHorariosNaoAssociados(string CaminhoExcel, bool comunicacao);
        Task<List<Pessoa>> ListaPessoas(string CaminhoExcel, string CPFResponsavel, List<Cargo> Cargos, List<Estrutura> Estruturas, List<Horarios> Horarios, bool AtualizaPessoa = false);
        Task SalvaHorarios(string caminhoLeitura, string SalvarEm,bool comunicacao);
        Task SalvaBKPExcel(List<Pessoa> pessoas, string CNPJ, string SalvarEm = "");
        Task<List<Desligamento>> ListaDesligamento(string caminho);
        Task<List<Pessoa>> ListaPessoasComunica(string CaminhoExcel, string CPFResponsavel, List<Cargo> Cargos, List<Estrutura> Estruturas, List<Horarios> Horarois, bool AtualizaPessoa);
    }
}
