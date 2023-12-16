using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KAIROS.API.Model
{
    public class Cargo
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string? Descricao { get; set; }
        [JsonIgnore]
        public string? CNPJ { get; set; }
    }
}
