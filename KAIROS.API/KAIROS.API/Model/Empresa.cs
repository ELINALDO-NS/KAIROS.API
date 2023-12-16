using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAIROS.API.Model
{
    public class Empresa
    {
        public string Codigo { get; set; }
        public string Razao { get; set; }
        public string CNPJ { get; set; }
        public string ID { get; set; }
        public bool Filial { get; set; }
    }
}

