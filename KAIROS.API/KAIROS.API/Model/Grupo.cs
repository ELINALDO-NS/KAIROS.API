using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAIROS.API.Model
{
    public class Grupo
    {
        public int id { get; set; }
        public int codigo { get; set; }
        public string Descricao { get; set; }
        public string CNPJ { get; set; }
    }
}
