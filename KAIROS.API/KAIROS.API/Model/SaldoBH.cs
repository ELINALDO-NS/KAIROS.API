using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAIROS.API.Model
{
    public class SaldoBH
    {
        public int ID { get; set; }
        public string? Matricula { get; set; }
        public string? Saldo { get; set; }
        public Boolean Posito_Negativo { get; set; }
        public DateTime? Data { get; set; }
        public string? OK { get; set; } = string.Empty;


    }
}
