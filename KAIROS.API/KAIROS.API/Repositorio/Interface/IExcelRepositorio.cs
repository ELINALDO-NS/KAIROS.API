using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAIROS.API.Repositorio.Interface
{
    public interface IExcelRepositorio
    {
        Task ListaHorario(string caminho);
    }
}
