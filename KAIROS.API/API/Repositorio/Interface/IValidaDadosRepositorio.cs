using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Repositorio.Interface
{
    public interface IValidaDadosRepositorio
    {
        Task<bool> ValidaCPF(string Caminho, bool Comunicacao);
        Task<bool> ValidaCPFDuplicado(string Caminho, bool Comunicacao);
        Task<bool> ValidaPIS(string Caminho, bool Comunicacao);
        Task<bool> ValidaPISDuplicado(string Caminho, bool Comunicacao);
        Task<bool> ValidaMatriculaDuplicada(string Caminho, bool Comunicacao);
        Task<bool> ValidaPessoaSemMatricula(string Caminho, bool Comunicacao);
        Task<bool> ValidaEmailDuplicado(string Caminho, bool Comunicacao);
        Task<bool> ValidaDescricaoHorario(string Caminho, bool Comunicacao);
        Task<bool> ValidaDatas(string Caminho, bool Comunicacao);
        Task<bool> ValidaPessoaSemCNPJ(string Caminho, bool Comunicacao);
        Task<bool> ValidaBaseDeHoras(string CaminhoExcel, bool Comunicacao);
        Task<bool> ValidaColunas(string CaminhoExcel, bool Comunicacao);
    }
}
