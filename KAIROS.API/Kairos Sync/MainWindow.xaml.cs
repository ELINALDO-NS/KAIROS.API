using KAIROS.API.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kairos_Sync
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<Pessoa> Pessoas { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Pessoas = new()
        {
            new Pessoa { Id = 1, Nome = "João Silva", Cpf = "123.456.789-00", Matricula = 1234567890, Cracha = "A001",Sexo = 0 },
            new Pessoa { Id = 2, Nome = "Maria Oliveira", Cpf = "987.654.321-00", Matricula = 1234567890, Cracha = "A002", Sexo =1},
            new Pessoa { Id = 3, Nome = "Carlos Souza", Cpf = "456.789.123-00", Matricula = 1234567890, Cracha = "A003" },
                        new Pessoa { Id = 1, Nome = "João Silva", Cpf = "123.456.789-00", Matricula = 1234567890, Cracha = "A001" },
            new Pessoa { Id = 2, Nome = "Maria Oliveira", Cpf = "987.654.321-00", Matricula = 1234567890, Cracha = "A002" },
                        new Pessoa { Id = 1, Nome = "João Silva", Cpf = "123.456.789-00", Matricula = 1234567890, Cracha = "A001" },
            new Pessoa { Id = 2, Nome = "Maria Oliveira", Cpf = "987.654.321-00", Matricula = 1234567890, Cracha = "A002" },
                        new Pessoa { Id = 1, Nome = "João Silva", Cpf = "123.456.789-00", Matricula = 1234567890, Cracha = "A001" },
            new Pessoa { Id = 2, Nome = "Maria Oliveira", Cpf = "987.654.321-00", Matricula = 1234567890, Cracha = "A002" },
                        new Pessoa { Id = 1, Nome = "João Silva", Cpf = "123.456.789-00", Matricula = 1234567890, Cracha = "A001" },
            new Pessoa { Id = 2, Nome = "Maria Oliveira", Cpf = "987.654.321-00", Matricula = 1234567890, Cracha = "A002" },
                        new Pessoa { Id = 1, Nome = "João Silva", Cpf = "123.456.789-00", Matricula = 1234567890, Cracha = "A001" },
            new Pessoa { Id = 2, Nome = "Maria Oliveira", Cpf = "987.654.321-00", Matricula = 1234567890, Cracha = "A002" },
                        new Pessoa { Id = 1, Nome = "João Silva", Cpf = "123.456.789-00", Matricula = 1234567890, Cracha = "A001" },
            new Pessoa { Id = 2, Nome = "Maria Oliveira", Cpf = "987.654.321-00", Matricula = 1234567890, Cracha = "A002" },
                        new Pessoa { Id = 1, Nome = "João Silva", Cpf = "123.456.789-00", Matricula = 1234567890, Cracha = "A001" },
            new Pessoa { Id = 2, Nome = "Maria Oliveira", Cpf = "987.654.321-00", Matricula = 1234567890, Cracha = "A002" },
            new Pessoa { Id = 1, Nome = "João Silva", Cpf = "123.456.789-00", Matricula = 1234567890, Cracha = "A001" },
            new Pessoa { Id = 2, Nome = "Maria Oliveira", Cpf = "987.654.321-00", Matricula = 1234567890, Cracha = "A002" },
                        new Pessoa { Id = 1, Nome = "João Silva", Cpf = "123.456.789-00", Matricula = 1234567890, Cracha = "A001" },
            new Pessoa { Id = 2, Nome = "Maria Oliveira", Cpf = "987.654.321-00", Matricula = 1234567890, Cracha = "A002" },
                        new Pessoa { Id = 1, Nome = "João Silva", Cpf = "123.456.789-00", Matricula = 1234567890, Cracha = "A001" },
            new Pessoa { Id = 2, Nome = "Maria Oliveira", Cpf = "987.654.321-00", Matricula = 1234567890, Cracha = "A002" },
        };
        }
        #region Propriedades
        private string _CaminhoExcel = string.Empty;
        public string CaminhoExcel
        {
            get { return _CaminhoExcel; }
            set { _CaminhoExcel = value; OnPropertyChanged(nameof(CaminhoExcel)); }
        }

        private string _Key = string.Empty;

        public string Key
        {
            get { return _Key; }
            set { _Key = value; OnPropertyChanged(nameof(CaminhoExcel)); }
        }

        private string _CPFRESP = string.Empty;

        public string CPFRESP
        {
            get { return _CPFRESP; }
            set { _CPFRESP = value; OnPropertyChanged(nameof(CPFRESP)); }
        }

        private bool _InsereEstrutura;

        public bool InsereEstrutura
        {
            get { return _InsereEstrutura; }
            set { _InsereEstrutura = value; OnPropertyChanged(nameof(InsereEstrutura)); }
        }

        private bool _InsereCargos;

        public bool InsereCargos
        {
            get { return _InsereCargos; }
            set { _InsereCargos = value; OnPropertyChanged(nameof(InsereCargos)); }
        }

        private bool _InserePessos;

        public bool InserePessoas
        {
            get { return _InserePessos; }
            set { _InserePessos = value; OnPropertyChanged(nameof(InserePessoas)); }
        }



        #endregion

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void BtnCaminhoExcel_Click(object sender, RoutedEventArgs e)
        {
            CaminhoExcel = "Caminho do Excel selecionado";
        }

        private void BtnListaorario_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Lista Horarios");
        }

        private void BtnValidaDados_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Valida dados");
        }

        private void BtnSync_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("SYNC");
        }
    }

    public class Pessoa
    {
        public int Id { get; set; }
        public int Matricula { get; set; }
        public string Cracha { get; set; }
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
        public bool Atualiza { get; set; } = false;

        public Regrascalculo[] RegrasCalculo { get; set; }
        public string CodigoPis { get; set; }
        public int FlagGerarNumeroPISAutomatico { get; set; }
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
        public Cargo? Cargo { get; set; }

        public string CNPJ { get; set; }
    }
}