using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAIROS.API.Repositorio.Interface
{
    public interface IValidaDadosRepositorio
    {
        Task<bool> ValidaCPF(string Caminho);
        Task<bool> ValidaCPFDuplicado(string Caminho);
        Task<bool> ValidaPIS(string Caminho);
        Task<bool> ValidaPISDuplicado(string Caminho);
        Task<bool> ValidaMatriculaDuplicada(string Caminho);
        Task<bool> ValidaPessoaSemMatricula(string Caminho);
        Task<bool> ValidaEmailDuplicado(string Caminho);
        Task<bool> ValidaDescricaoHorario(string Caminho);
        Task<bool> ValidaDatas(string Caminho);
        Task<bool> ValidaPessoaSemCNPJ(string Caminho);

    }
}
