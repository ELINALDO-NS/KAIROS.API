using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAIROS.API.Model
{

    public class AtualizaPessoa
    {
        public int Id { get; set; }
        public int Matricula { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string DataNascimento { get; set; }
        public string DataAdmissao { get; set; }
        public string BaseHoras { get; set; }
        public string Email { get; set; }
        public Tiposalario TipoSalario { get; set; }
        public Estrutura Estrutura { get; set; }
        public Cargo Cargo { get; set; }
        public int FlagGerarNumeroPISAutomatico { get; set; }
        public string CodigoPis { get; set; }
        public bool Atualiza { get; set; } = false;
        public int Sexo { get; set; }
        public string CpfResponsavel { get; set; }
        public Ambientetrabalhopessoa[] AmbienteTrabalhoPessoa { get; set; }
    }


}
