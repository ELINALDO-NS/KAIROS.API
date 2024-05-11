using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAIROS.API.Model
{
    public class Desligamento
    {
        public int Matricula { get; set; }
        public int PessoaId { get; set; }
        public string Motivo { get; set; } = "11-Rescisão sem justa causa por iniciativa do empregador";
    }
}
