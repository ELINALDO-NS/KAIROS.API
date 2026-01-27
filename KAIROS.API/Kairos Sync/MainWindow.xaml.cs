using API;
using API.Model;
using API.Repositorio;
using API.Repositorio.Interface;
using Microsoft.Win32;
using OfficeOpenXml.FormulaParsing.LexicalAnalysis;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

namespace Kairos_Sync
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<Pessoa> ListaDePessoas { get; set; }
        static string log = Convert.ToString(AppDomain.CurrentDomain.BaseDirectory.ToString() + @"Log\Log.txt");
        private readonly IExcelRepositorio _excel;
        private readonly IAPIRepositorio _API;
        private readonly IValidaDadosRepositorio _validaDados;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            _excel = new ExcelRepositorio();
            _API = new APIRepositorio(_excel);
            _validaDados = new ValidaDadosRepositorio();
            ListaDePessoas = new()
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
        private CancellationTokenSource? _cts;
        private string _CaminhoExcel = string.Empty;
        public string CaminhoExcel
        {
            get { return _CaminhoExcel; }
            set { _CaminhoExcel = value; OnPropertyChanged(); }
        }

        private string _Key = string.Empty;
        public string Key
        {
            get { return _Key; }
            set { _Key = value; OnPropertyChanged(); }
        }

        private string _CNPJ = string.Empty;
        public string CNPJ
        {
            get { return _CNPJ; }
            set { _CNPJ = value; OnPropertyChanged(); }
        }

        private string _CPFRESP = string.Empty;
        public string CPFRESP
        {
            get { return _CPFRESP; }
            set { _CPFRESP = value; OnPropertyChanged(); }
        }

        private string _SpinValidaDados = "Hidden";
        public string SpinValidaDados
        {
            get => _SpinValidaDados;
            set
            {
                _SpinValidaDados = value; OnPropertyChanged();
            }
        }

        private string _SpinEstruturas = "Hidden";
        public string SpinEstruturas
        {
            get => _SpinEstruturas;
            set
            {
                _SpinEstruturas = value; OnPropertyChanged();
            }
        }

        private string _SpinHorarios = "Hidden";
        public string SpinHoarios
        {
            get => _SpinHorarios;
            set
            {
                _SpinHorarios = value; OnPropertyChanged();
            }
        }

        private string _SpinCargos = "Hidden";
        public string SpinCargos
        {
            get => _SpinCargos;
            set
            {
                _SpinCargos = value; OnPropertyChanged();
            }
        }

        private string _CheckValidaDados = "Hidden";
        public string CheckValidaDados
        {
            get => _CheckValidaDados;
            set
            {
                _CheckValidaDados = value; OnPropertyChanged();
            }
        }

        private string _ErroValidaDados = "Hidden";
        public string ErroValidaDados
        {
            get => _ErroValidaDados;
            set
            {
                _ErroValidaDados = value; OnPropertyChanged();
            }
        }

        private string _CheckEstruturas = "Hidden";
        public string CheckEstruturas
        {
            get => _CheckEstruturas;
            set
            {
                _CheckEstruturas = value; OnPropertyChanged();
            }
        }

        private string _CheckHorarios = "Hidden";
        public string CheckHorarios
        {
            get => _CheckHorarios;
            set
            {
                _CheckHorarios = value; OnPropertyChanged();
            }
        }

        private string _CheckCargos = "Hidden";
        public string CheckCargos
        {
            get => _CheckCargos;
            set
            {
                _CheckCargos = value; OnPropertyChanged();
            }
        }

        private string _CheckPessoas = "Hidden";
        public string CheckPessoas
        {
            get => _CheckPessoas;
            set
            {
                _CheckPessoas = value; OnPropertyChanged();
            }
        }

        private string _LblValidaDados = "Hidden";
        public string LblValidaDados
        {
            get => _LblValidaDados;
            set
            {
                _LblValidaDados = value; OnPropertyChanged();
            }
        }

        private string _LblEstruturas = "Hidden";
        public string LblEstruturas
        {
            get => _LblEstruturas;
            set
            {
                _LblEstruturas = value; OnPropertyChanged();
            }
        }

        private string _LblHorarios = "Hidden";
        public string LblHorarios
        {
            get => _LblHorarios;
            set
            {
                _LblHorarios = value; OnPropertyChanged();
            }
        }

        private string _LblCargos = "Hidden";
        public string LblCargos
        {
            get => _LblCargos;
            set
            {
                _LblCargos = value; OnPropertyChanged();
            }
        }
        private string _LblPessoas = "Hidden";
        public string LblPessoas
        {
            get => _LblPessoas;
            set
            {
                _LblPessoas = value; OnPropertyChanged();
            }
        }

        private string _LblStatusPessoas = "Hidden";
        public string LblStatusPessoas
        {
            get => _LblStatusPessoas;
            set
            {
                _LblStatusPessoas = value; OnPropertyChanged();
            }
        }
        private string _StatusPessoas = string.Empty;
        public string StatusPessoas
        {
            get => _StatusPessoas;
            set
            {
                _StatusPessoas = value; OnPropertyChanged();
            }
        }

        #endregion

        #region Inserir
        private bool _ChkEstrutura;
        public bool ChkEstrutura
        {
            get { return _ChkEstrutura; }
            set { _ChkEstrutura = value; OnPropertyChanged(); }
        }
        private bool _ChkCargo;
        public bool ChkCargo
        {
            get { return _ChkCargo; }
            set { _ChkCargo = value; OnPropertyChanged(); }
        }
        private bool _ChkPessoa;
        public bool ChkPessoa
        {
            get { return _ChkPessoa; }
            set { _ChkPessoa = value; OnPropertyChanged(); }
        }

        #endregion

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
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
                MessageBox.Show(ex.Message, "Local de Gravação Excel", MessageBoxButton.OK, MessageBoxImage.Error);
                return "";
            }

        }
        private async void BtnCaminhoExcel_Click_1(object sender, RoutedEventArgs e)
        {
            PathLeitura();
        }
        private async void BtnListaHorarios_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(CaminhoExcel))
                {
                    MessageBox.Show("Informe o Local da Planilha de Implantação !", "Listar Horario", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                BtnListaHorarios.IsEnabled = false;
                string LocalGravacao = PathGravacao();
                if (!string.IsNullOrEmpty(LocalGravacao))
                {
                    await _excel.SalvaHorarios(CaminhoExcel, LocalGravacao);
                    BtnListaHorarios.IsEnabled = true;
                    MessageBox.Show("Lista de Horarios Salva Com Sucesso !", "Lista Horarios", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                else
                {
                    BtnListaHorarios.IsEnabled = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                BtnListaHorarios.IsEnabled = true;
                MessageBox.Show(ex.Message);
            }
        }
        public async Task<bool> ValidaDados(string Caminho)
        {
            CheckValidaDados = "Hidden";
            ErroValidaDados = "Hidden";
            LblValidaDados = "Visivle";
            SpinValidaDados = "Visivle";
            var tarefas = new Dictionary<string, Task<bool>>
            {
                ["CPF"] = _validaDados.ValidaCPF(Caminho),
                ["CPFDuplicado"] = _validaDados.ValidaCPFDuplicado(Caminho),
                ["PIS"] = _validaDados.ValidaPIS(Caminho),
                ["PISDuplicado"] = _validaDados.ValidaPISDuplicado(Caminho),
                ["MatriculaDuplicada"] = _validaDados.ValidaMatriculaDuplicada(Caminho),
                ["PessoaSemMatricula"] = _validaDados.ValidaPessoaSemMatricula(Caminho),
                ["DescricaoHorario"] = _validaDados.ValidaDescricaoHorario(Caminho),
                ["EmailDuplicado"] = _validaDados.ValidaEmailDuplicado(Caminho),
                ["DataInvalida"] = _validaDados.ValidaDatas(Caminho),
                ["PessoaSemCPF"] = _validaDados.ValidaPessoaSemCNPJ(Caminho),
                ["BaseDeHorasInvalida"] = _validaDados.ValidaBaseDeHoras(Caminho)
            };

            await Task.WhenAll(tarefas.Values);
            bool dadosValidos = tarefas.Values.All(t => t.Result);

            if (!dadosValidos)
            {
                SpinValidaDados = "Hidden";
                ErroValidaDados = "Visivle";
                return false;

            }
            else
            {
                SpinValidaDados = "Hidden";
                CheckValidaDados = "Visivle";
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
                BtnValidaDados.IsEnabled = false;
                if (await ValidaDados(CaminhoExcel) == true)
                {
                    BtnValidaDados.IsEnabled = true;
                    MessageBox.Show("NÃO existem dados invalidos ou duplicados !");
                }
                else
                {
                    BtnValidaDados.IsEnabled = true;
                    var confirm = MessageBox.Show("Verifique o arquivo de Logs Existem dados invalidos ou duplicados ! \n Deseja Abrir o arquivo de LOG ?", "Operação", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                    if (confirm.ToString().ToUpper() == "YES")
                    {
                        System.Diagnostics.Process.Start("notepad.exe", Convert.ToString(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + @"\Log\Log.txt"));
                    }
                }
            }
            catch (Exception ex)
            {
                BtnValidaDados.IsEnabled = true;
                ErroValidaDados = "Visivle";
                MessageBox.Show(ex.Message, "Valida Dados");
            }

        }

        private async void BtnSync_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Key.Trim()) || string.IsNullOrEmpty(CNPJ.Trim()) || string.IsNullOrEmpty(CPFRESP.Trim()))
            {
                MessageBox.Show("Verifique os Campos: KEY, CNPJ, e CPFResponsavel", "Iniciar", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!ChkCargo && !ChkEstrutura && !ChkPessoa)
            {
                MessageBox.Show("Selecione os items a serem inseridos!", "Iniciar", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrEmpty(CaminhoExcel))
            {
                if (!PathLeitura())
                {
                    return;
                }
            }
            if (File.Exists(log))
            {
                File.Delete(log);
            }
            BtnSync.IsEnabled = false;
            List<Cargo> Cargos = new();
            List<Estrutura> Estruturas = new();
            List<Horarios> Horarios = new();
            List<Pessoa> Pessoas = new();
            var tasks1 = new List<Task>();
            try
            {
                CheckEstruturas = "Hidden";
                LblEstruturas = "Hidden";
                SpinEstruturas = "Hidden";

                LblCargos = "Hidden";
                SpinCargos = "Hidden";
                CheckCargos = "Hidden";

                LblHorarios = "Hidden";
                SpinHoarios = "Hidden";
                CheckHorarios = "Hidden";


                if (ChkEstrutura)
                {
                    tasks1.Add(Task.Run(async () =>
                    {
                        LblEstruturas = "Visible";
                        SpinEstruturas = "Visible";
                        await _API.InsereEstruturasAPI(Key: Key.Trim(), CNPJ: CNPJ.Trim(), CaminhoExcel: CaminhoExcel.Trim());
                        if (!ChkPessoa)
                        {
                            SpinEstruturas = "Hidden";
                            CheckEstruturas = "Visible";
                        }

                    }));
                }

                if (ChkCargo)
                {
                    tasks1.Add(Task.Run(async () =>
                    {
                        LblCargos = "Visible";
                        SpinCargos = "Visible";
                        await _API.InsereCargosAPI(Key: Key.Trim(), CNPJ: CNPJ.Trim(), CaminhoExcel: CaminhoExcel.Trim());
                        if (!ChkPessoa)
                        {
                            SpinCargos = "Hidden";
                            CheckCargos = "Visible";
                        }

                    }));
                }

                await Task.WhenAll(tasks1);

                if (ChkPessoa)
                {
                    if (await ValidaDados(CaminhoExcel) == false)
                    {
                        return;
                    }
                    var tasks2 = new List<Task>();

                    tasks2.Add(Task.Run(async () =>
                    {
                        LblEstruturas = "Visible";
                        SpinEstruturas = "Visible";
                        Estruturas = await _API.ListaEstruturasAPI(Key: Key.Trim(), CNPJ: CNPJ.Trim());
                        SpinEstruturas = "Hidden";
                        CheckEstruturas = "Visible";
                    }));

                    tasks2.Add(Task.Run(async () =>
                    {
                        LblCargos = "Visible";
                        SpinCargos = "Visible";
                        Cargos = await _API.ListaCargosAPI(Key: Key.Trim(), CNPJ: CNPJ.Trim());
                        SpinCargos = "Hidden";
                        CheckCargos = "Visible";
                    }));

                    tasks2.Add(Task.Run(async () =>
                    {
                        LblHorarios = "Visible";
                        Horarios = await _API.ListaHorariosAPI(Key: Key.Trim(), CNPJ: CNPJ.Trim());
                        SpinHoarios = "Hidden";
                        CheckHorarios = "Visible";
                    }));

                    await Task.WhenAll(tasks2);
                    int Stp = 0;
                    LblPessoas = "Visible";
                    LblStatusPessoas = "Visible";
                    Pessoas = await _excel.ListaPessoas(CaminhoExcel: CaminhoExcel, CPFRESP.Trim(), Cargos, Estruturas, Horarios);
                    int TotalPessoa = Pessoas.Count;
                    StatusPessoas = $"{Stp}/{TotalPessoa}";

                    _cts = new CancellationTokenSource();
                    await Parallel.ForEachAsync(Pessoas, _cts.Token, async (pessoa, token) =>
                    {
                        token.ThrowIfCancellationRequested();
                        await _API.InserePessoaAPI(Key: Key, CNPJ: CNPJ, Pessoa: pessoa);
                        Stp++;
                        StatusPessoas = $"{Stp}/{TotalPessoa}";

                    });

                    await Task.Delay(1000 * 2);
                    LblStatusPessoas = "Hidden";
                    CheckPessoas = "Visible";
                }
                BtnSync.IsEnabled = true;
                MessageBox.Show("OK");
            }
            catch (OperationCanceledException)
            {
                Log.GravaLog("Aperação cancelada !");
            }
            catch (Exception ex)
            {
                BtnSync.IsEnabled = true;
                var confirm = MessageBox.Show(ex.Message + Environment.NewLine + " Verifique o arquivo de Logs! \n Deseja Abrir o arquivo de LOG ?", "Iniciar", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                if (confirm.ToString().ToUpper() == "YES")
                {
                    System.Diagnostics.Process.Start("notepad.exe", Convert.ToString(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + @"\Log\Log.txt"));
                }
            }
        }

        #region ChkInserir  

        private void ChkEstruturas_Checked(object sender, RoutedEventArgs e)
        {
            ChkEstrutura = true;
        }
        private void ChkEstruturas_UnChecked(object sender, RoutedEventArgs e)
        {
            ChkEstrutura = false;
        }
        private void ChkCargos_Checked(object sender, RoutedEventArgs e)
        {
            ChkCargo = true;
        }
        private void ChkCargos_Unchecked(object sender, RoutedEventArgs e)
        {
            ChkCargo = false;
        }
        private void ChkPessoas_Checked(object sender, RoutedEventArgs e)
        {
            ChkPessoa = true;
        }
        private void ChkPessoas_Unchecked(object sender, RoutedEventArgs e)
        {
            ChkPessoa = false;
        }
        #endregion
    }
}