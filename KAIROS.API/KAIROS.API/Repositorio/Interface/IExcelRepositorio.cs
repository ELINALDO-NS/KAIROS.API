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
        Task< List<Cargo>> LerCargos(string Caminho);
        Task LerEstrutura(string Caminho);
        Task LerHoarios(string Caminho);
        Task LerPessoas(string Caminho);
        Task ListaHorarios(string caminho);

    }
}
