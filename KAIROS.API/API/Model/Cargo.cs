using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Model
{
    public class Cargo
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        

        private string _Descricao = string.Empty;

        public string Descricao
        {
            get { return _Descricao; }
            set { _Descricao = value.ToTitleCase(); }
        }

        [JsonIgnore]
        public string? CNPJ { get; set; }
    }
}
