using KAIROS.API;
using KAIROS.API.Model;
using KAIROS.API.Repositorio;
using KAIROS.API.Repositorio.Interface;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows;



namespace Kairos_Sync
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<Pessoa> Pessoas { get; set; }
        static string log = Convert.ToString(AppDomain.CurrentDomain.BaseDirectory.ToString() + @"Log\Log.txt");
        private readonly IExcelRepositorio _excel;
        private readonly IAPIRepositorio _API;
        private readonly IValidaDadosRepositorio _validaDados;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            _excel = new ExcelRepositorio();
            _API = new APIRepositorio();
            _validaDados = new ValidaDadosRepositorio();
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

        public bool PathLeitura()
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();

                openFileDialog.Filter = "Text files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == true)
                {
                    CaminhoExcel = openFileDialog.FileName;

                    return true;
                }
                else
                {

                    return false;

                }
               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Modelo Excel", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        public string PathGravacao()
        {
            try
            {

                var dialog = new OpenFolderDialog
                {
                    Title = "Selecione uma pasta"
                };

                if (dialog.ShowDialog() == true)
                {
                    return dialog.FolderName;
                }
                return "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Local de Gravação Excel",MessageBoxButton.OK, MessageBoxImage.Error);
                return "";
            }

        }
        private void BtnCaminhoExcel_Click_1(object sender, RoutedEventArgs e)
        {
            PathLeitura();
        }

        private async void BtnListaHorarios_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(CaminhoExcel))
                {
                    MessageBox.Show("Informe o Local da Planilha de Implantação !", "Listar Horario",MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                string LocalGravacao = PathGravacao();
                if (!string.IsNullOrEmpty(LocalGravacao))
                {
                    await _excel.SalvaHorarios(CaminhoExcel, LocalGravacao);
                    MessageBox.Show("Lista de Horarios Salva Com Sucesso !","Lista Horarios",MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public async Task<bool> ValidaDados(string Caminho)
        {
            bool CPF = true;
            var CPFDuplicado = true;
            var PIS = true;
            var PISDuplicado = true;
            var MatriculaDuplicada = true;
            var PessoaSemMatricula = true;
            var DescricaoHorario = true;
            var EmailDuplicado = true;
            var DataInvalida = true;
            var PessoaSemCPF = true;
           // Lbl_ValidaDados.Invoke(new Action(() => { Lbl_ValidaDados.Visible = true; }));
           //AlterarStatus(SpinValidaDados, CheckValidaDados, true);

            await Task.WhenAll(
               Task.Run(async () => { CPF = await _validaDados.ValidaCPF(Caminho); }),
               Task.Run(async () => { CPFDuplicado = await _validaDados.ValidaCPFDuplicado(Caminho); }),
               Task.Run(async () => { PIS = await _validaDados.ValidaPIS(Caminho); }),
               Task.Run(async () => { PISDuplicado = await _validaDados.ValidaPISDuplicado(Caminho); }),
               Task.Run(async () => { MatriculaDuplicada = await _validaDados.ValidaMatriculaDuplicada(Caminho); }),
               Task.Run(async () => { PessoaSemMatricula = await _validaDados.ValidaPessoaSemMatricula(Caminho); }),
               Task.Run(async () => { DescricaoHorario = await _validaDados.ValidaDescricaoHorario(Caminho); }),
               Task.Run(async () => { EmailDuplicado = await _validaDados.ValidaEmailDuplicado(Caminho); }),
               Task.Run(async () => { DataInvalida = await _validaDados.ValidaDatas(Caminho); }),
               Task.Run(async () => { PessoaSemCPF = await _validaDados.ValidaPessoaSemCNPJ(Caminho); })

               );


            if (!CPF || !CPFDuplicado || !PIS || !PISDuplicado || !MatriculaDuplicada || !PessoaSemMatricula ||
                 !DescricaoHorario || !EmailDuplicado || !DataInvalida || !PessoaSemCPF)
            {
               // AlterarStatus(SpinValidaDados, CheckValidaDados, false);
                var confirm = MessageBox.Show("Verifique o arquivo de Logs Existem dados invalidos ou duplicados ! \n Deseja Abrir o arquivo de LOG ?", "Operação", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                if (confirm.ToString().ToUpper() == "YES")
                {
                    System.Diagnostics.Process.Start("notepad.exe", Convert.ToString(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + @"\Log\Log.txt"));
                }

                return false;
            }
            else
            {
                return true;
            }

        }
        private async void BtnValidaDados_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (File.Exists(log))
                {
                    File.Delete(log);
                }

                if (string.IsNullOrEmpty(CaminhoExcel))
                {
                    if (!PathLeitura())
                    {
                        return;
                    }

                }
                //ResetaStatus();
                if (await ValidaDados(CaminhoExcel) == true)
                {
                    //AlterarStatus(SpinValidaDados, CheckValidaDados, false);
                    MessageBox.Show("NÃO existem dados invalidos ou duplicados !");
                }
            }
            catch (Exception ex)
            {
                //(SpinValidaDados, CheckValidaDados, false);
                MessageBox.Show(ex.Message, "Valida Dados");
            }

        }

        private void BtnSync_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("SYNC");
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