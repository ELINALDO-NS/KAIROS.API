using API.Model;
using API.Repositorio;
using API.Repositorio.Interface;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
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
            set{
                _SpinValidaDados = value ; OnPropertyChanged();
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

        private string _StatusPessoas = "Hidden";
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
                string LocalGravacao = PathGravacao();
                if (!string.IsNullOrEmpty(LocalGravacao))
                {
                    await _excel.SalvaHorarios(CaminhoExcel, LocalGravacao);
                    MessageBox.Show("Lista de Horarios Salva Com Sucesso !", "Lista Horarios", MessageBoxButton.OK, MessageBoxImage.Information);
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
            await Task.Delay(1000*5);
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
                ["PessoaSemCPF"] = _validaDados.ValidaPessoaSemCNPJ(Caminho)
            };

            await Task.WhenAll(tarefas.Values);
            bool dadosValidos = tarefas.Values.All(t => t.Result);

            if (!dadosValidos)
            {       
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
                CheckValidaDados = "Hidden";
                ErroValidaDados = "Hidden";
                LblValidaDados = "Visivle";
                SpinValidaDados = "Visivle";
                if (await ValidaDados(CaminhoExcel) == true)
                {                    
                    SpinValidaDados = "Hidden";
                    CheckValidaDados = "Visivle";
                    MessageBox.Show("NÃO existem dados invalidos ou duplicados !");
                }
                else
                {
                    SpinValidaDados = "Hidden";
                    ErroValidaDados = "Visivle";
                    var confirm = MessageBox.Show("Verifique o arquivo de Logs Existem dados invalidos ou duplicados ! \n Deseja Abrir o arquivo de LOG ?", "Operação", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                    if (confirm.ToString().ToUpper() == "YES")
                    {
                        System.Diagnostics.Process.Start("notepad.exe", Convert.ToString(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + @"\Log\Log.txt"));
                    }
                }
            }
            catch (Exception ex)
            {
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

            List<Cargo> Cargos = new();
            List<Estrutura> Estruturas = new();
            List<Horarios> Horarios = new();
            List<Pessoa> Pessoas = new();
            try
            {
                var tasks1 = new List<Task>();
                if (ChkEstrutura)
                {
                    tasks1.Add(_API.InsereEstruturasAPI(Key: Key.Trim(), CNPJ: CNPJ.Trim(), CaminhoExcel: CaminhoExcel.Trim()));
                }
                if (ChkCargo)
                {
                    tasks1.Add(_API.InsereCargosAPI(Key: Key, CNPJ: CNPJ, CaminhoExcel: CaminhoExcel));
                }

                await Task.WhenAll(tasks1);

                if (ChkPessoa)
                {
                    if (await ValidaDados(CaminhoExcel) == false)
                    {
                        return;
                    }

                    var cargosTask = _API.ListaCargosAPI(Key: Key.Trim(), CNPJ: CNPJ.Trim());
                    var horariosTask = _API.ListaHorariosAPI(Key: Key.Trim(), CNPJ: CNPJ.Trim());
                    var estruturasTask = _API.ListaEstruturasAPI(Key: Key.Trim(), CNPJ: CNPJ.Trim());
                    await Task.WhenAll(cargosTask, horariosTask, estruturasTask);

                    Cargos = await cargosTask;
                    Horarios = await horariosTask;
                    Estruturas = await estruturasTask;
                }

                Pessoas = await _excel.ListaPessoas(CaminhoExcel: CaminhoExcel, CPFRESP.Trim(), Cargos, Estruturas, Horarios);

                int Stp = 0;

                using (var semaphore = new SemaphoreSlim(20))
                {
                    var tasks = Pessoas.Select(async pessoa =>
                    {
                        await semaphore.WaitAsync();
                        try
                        {
                            await _API.InserePessoaAPI(Key: Key, CNPJ: CNPJ, Pessoa: pessoa);
                            Interlocked.Increment(ref Stp);
                        }
                        finally { semaphore.Release(); }
                    });
                    await Task.WhenAll(tasks);
                }


                MessageBox.Show("OK");
            }
            catch (Exception ex)
            {
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