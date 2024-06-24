using KAIROS.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAIROS.API.Repositorio.Interface
{
    public interface IExcelRepositorio
    {
        Task<List<Cargo>> ListaCargos(string Caminho);
        Task<List<Cargo>> ListaCargosNovo(string Caminho);        
        Task<List<Estrutura>> ListaEstruturas(string Caminho);
        Task<List<Estrutura>> ListaEstruturasNovo(string caminho);
        Task<List<Horarios>> ListaHorarios(string Caminho);
        Task<List<Horarios>> ListaHorariosNovo(string caminho);
        Task<List<Pessoa>> ListaPessoas(string caminho, string CPFResponsavel, List<Cargo> Cargos, List<Estrutura> Estruturas, List<Horarios> Horarois,bool AtualizaPessoa =false);
        Task SalvaHorarios(string caminhoLeitura, string SalvarEm);
        Task SalvaBKPExcel(List<Pessoa> pessoas, string CNPJ);

    }
}
