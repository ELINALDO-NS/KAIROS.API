using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAIROS.API.Model
{
    public class Resposta
    {
        public bool Sucesso { get; set; }
        public object? Obj { get; set; }
        public string? Mensagem { get; set; }
    }
}
