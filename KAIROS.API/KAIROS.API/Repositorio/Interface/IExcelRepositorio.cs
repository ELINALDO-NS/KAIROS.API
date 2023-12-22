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
        Task< List<Cargo>> ListaCargos(string Caminho);
        Task<List<Estrutura>> ListaEstruturas(string Caminho);
        Task<List<Horarios>> ListaHorarios(string Caminho);
        Task<List<Pessoa>> ListaPessoas(string caminho, List<Cargo> Cargos, List<Estrutura> Estruturas, List<Horarios> Horarois);
        Task SalvaHorarios(string caminhoLeitura, string SalvarEm);

    }
}
