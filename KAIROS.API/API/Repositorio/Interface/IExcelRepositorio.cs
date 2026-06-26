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
        Task<List<Cargo>> ListaCargos(string CaminhoExcel);
        Task<List<Estrutura>> ListaEstruturas(string CaminhoExcel);
        Task<List<Horarios>> ListaHorariosAssociados(string CaminhoExcel);
        Task<List<Horarios>> ListaHorariosNaoAssociados(string CaminhoExcel);
        Task<List<Pessoa>> ListaPessoas(string CaminhoExcel, string CPFResponsavel, List<Cargo> Cargos, List<Estrutura> Estruturas, List<Horarios> Horarios, bool AtualizaPessoa = false);
        Task SalvaHorarios(string caminhoLeitura, string SalvarEm);
        Task SalvaBKPExcel(List<Pessoa> pessoas, string CNPJ, string SalvarEm = "");
        Task<List<Desligamento>> ListaDesligamento(string caminho);
    }
}
