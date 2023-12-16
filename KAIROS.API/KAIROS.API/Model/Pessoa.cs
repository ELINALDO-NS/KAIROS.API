using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static KAIROS.API.Model.Pessoa;

namespace KAIROS.API.Model
{

        public class Pessoa
        {
            public int Id { get; set; }
            public int Matricula { get; set; }
            public int Cracha { get; set; }
            public string Nome { get; set; }
            public string DataNascimento { get; set; }
            public object Endereco { get; set; }
            public string DataAdmissao { get; set; }
            public string DataDemissao { get; set; }
            public string Rg { get; set; }
            public string Cpf { get; set; }
            public string CpfResponsavel { get; set; }
            public object Telefone { get; set; }
            public object TelefoneCelular { get; set; }
            public string Email { get; set; }
            public bool ControlaPonto { get; set; }
            public string DataControlaPonto { get; set; }
            public bool EhResponsavel { get; set; }
            public float BaseHoras { get; set; }
            public float ValorHora { get; set; }
            public int CodCrachaProv { get; set; }
            public string DataInicioCrachaProv { get; set; }
            public string DataFimCrachaProv { get; set; }
            public Estrutura Estrutura { get; set; }
            public Tipofuncionario TipoFuncionario { get; set; }
            public Tiposalario TipoSalario { get; set; }
            public object TipoSalarioExportacao { get; set; }
            public Horarios[] Horarios { get; set; }

            [JsonIgnore]
            public string? HorarioPessoa { get; set; }
            [JsonIgnore]
            public Regrascalculo[] RegrasCalculo { get; set; }
            public string CodigoPis { get; set; }
            public long CodigoPisNumerico { get; set; }
            public int Sexo { get; set; }
            public object Foto { get; set; }
            public object FotoUpload { get; set; }
            public object MiniFoto { get; set; }
            public int PessoaStatus { get; set; }
            public int IdStatusObjeto { get; set; }
            public Ambientetrabalhopessoa[] AmbienteTrabalhoPessoa { get; set; }
            //public object PessoaEmpresaTemporaria { get; set; }
            public object HorariosAlternativos { get; set; }
            public Grupo Grupo { get; set; }
            // public object LocalizacaoAlternativaGPS { get; set; }
            public Cargo Cargo { get; set; }

            [JsonIgnore]
            public string CNPJ { get; set; }
        }

        public class Estrutura
        {
            public int Id { get; set; }
            public int Codigo { get; set; }
            public object CentroCusto { get; set; }
            public string Descricao { get; set; }
            public object DescricaoEstruturaPai { get; set; }
            public string CNPJ { get; set; }
            public string EmpresaCNPJ { get; set; }
            public object Extra1 { get; set; }
            public object Extra2 { get; set; }
        }

        public class Tipofuncionario
        {
            public int IdTipoFuncionario { get; set; }
            public string CarteiraTrabalho { get; set; }
            public object InformacaoInstituicao { get; set; }
            public object CnpjEmpresa { get; set; }
            public object EnderecoEmpresa { get; set; }
        }

        public class Tiposalario
        {
            public int Id { get; set; }
            public object Nome { get; set; }
        }

        public class Horarios
        {
            public int Id { get; set; }
            [JsonIgnore]
            public int Codigo { get; set; }
            [JsonIgnore]
            public string Descricao { get; set; }
            public Horario? Horario { get; set; }
            public string Inicio { get; set; }
            public string Fim { get; set; }
            public string CNPJ { get; set; }
        }



        public class Regrascalculo
        {
            public int Id { get; set; }
            public Regra Regra { get; set; }
            public string Inicio { get; set; }
            public string Fim { get; set; }
        }

        public class Regra
        {
            public int Id { get; set; }
        }

        public class Ambientetrabalhopessoa
        {
            public int Id { get; set; }
            public string Inicio { get; set; }
            public string Fim { get; set; }
            public int TipoAmbienteTrabalho { get; set; }
        }
 }

