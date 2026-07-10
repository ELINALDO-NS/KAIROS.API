using API;
using API.Model;
using API.Repositorio;
using API.Repositorio.Interface;
using Microsoft.Win32;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace Kairos_Sync
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<Pessoa> PessoaAPI { get; set; }
        public List<Pessoa> PessoaExcel { get; set; }
        public List<Cargo> CargosAPI { get; set; }
        public List<Estrutura> EstruturasAPI { get; set; }
        public List<Horarios> HorariosAPI { get; set; }
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
            PessoaAPI = new ObservableCollection<Pessoa>();
            PessoaExcel = new();
            CargosAPI = new();
            EstruturasAPI = new();
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

        private string _StatusAltPessoas = string.Empty;
        public string StatusAltPessoas
        {
            get => _StatusAltPessoas;
            set
            {
                _StatusAltPessoas = value; OnPropertyChanged();
            }
        }

        private string _Txb_Alt_Pessoa_CNPJ = string.Empty;
        public string Txb_Alt_Pessoa_CNPJ
        {
            get => _Txb_Alt_Pessoa_CNPJ;
            set
            {
                _Txb_Alt_Pessoa_CNPJ = value; OnPropertyChanged();
            }
        }

        private string _Txb_Alt_Pessoa_Chave = string.Empty;
        public string Txb_Alt_Pessoa_Chave
        {
            get => _Txb_Alt_Pessoa_Chave;
            set
            {
                _Txb_Alt_Pessoa_Chave = value; OnPropertyChanged();
            }
        }
        private string _Txb_Alt_Pessoa_CPFResp = string.Empty;
        public string Txb_Alt_Pessoa_CPFResp
        {
            get => _Txb_Alt_Pessoa_CPFResp;
            set
            {
                _Txb_Alt_Pessoa_CPFResp = value; OnPropertyChanged();
            }
        }

        private bool _Chave_Func_Matricula;
        public bool Chave_Func_Matricula
        {
            get => _Chave_Func_Matricula;
            set
            {
                _Chave_Func_Matricula = value; OnPropertyChanged();
            }
        }
        private bool _Chave_Func_CPF;
        public bool Chave_Func_CPF
        {
            get => _Chave_Func_CPF;
            set
            {
                _Chave_Func_CPF = value; OnPropertyChanged();
            }
        }
        private bool _Chave_Func_PIS;
        public bool Chave_Func_PIS
        {
            get => _Chave_Func_PIS;
            set
            {
                _Chave_Func_PIS = value; OnPropertyChanged();
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

        #region AlteraPessoa

        private bool _ChkMatricula;
        public bool ChkMatricula
        {
            get => _ChkMatricula;
            set { _ChkMatricula = value; OnPropertyChanged(); }
        }

        private bool _ChkNome;
        public bool ChkNome
        {
            get => _ChkNome;
            set { _ChkNome = value; OnPropertyChanged(); }
        }


        private bool _ChkPIS;
        public bool ChkPIS
        {
            get => _ChkPIS;
            set { _ChkPIS = value; OnPropertyChanged(); }
        }

        private bool _ChkCracha;
        public bool ChkCracha
        {
            get => _ChkCracha;
            set { _ChkCracha = value; OnPropertyChanged(); }
        }

        private bool _ChkDataNascimento;
        public bool ChkDataNascimento
        {
            get => _ChkDataNascimento;
            set { _ChkDataNascimento = value; OnPropertyChanged(); }
        }
        private bool _ChkDataAdmissao;
        public bool ChkDataAdmissao
        {
            get => _ChkDataAdmissao;
            set { _ChkDataAdmissao = value; OnPropertyChanged(); }
        }

        private bool _ChkRG;
        public bool ChkRG
        {
            get => _ChkRG;
            set { _ChkRG = value; OnPropertyChanged(); }
        }
        private bool _ChkCPF;
        public bool ChkCPF
        {
            get => _ChkCPF;
            set { _ChkCPF = value; OnPropertyChanged(); }
        }

        private bool _ChkCelular;
        public bool ChkCelular
        {
            get => _ChkCelular;
            set { _ChkCelular = value; OnPropertyChanged(); }
        }

        private bool _ChkEmail;
        public bool ChkEmail
        {
            get => _ChkEmail;
            set { _ChkEmail = value; OnPropertyChanged(); }
        }

        private bool _ChkDepartamento;
        public bool ChkDepartamento
        {
            get => _ChkDepartamento;
            set { _ChkDepartamento = value; OnPropertyChanged(); }
        }

        private bool _ChkHorario;
        public bool ChkHorario
        {
            get => _ChkHorario;
            set { _ChkHorario = value; OnPropertyChanged(); }
        }

        private bool _ChkCargo_AltPess;
        public bool ChkCargo_AltPess
        {
            get => _ChkCargo_AltPess;
            set { _ChkCargo_AltPess = value; OnPropertyChanged(); }
        }

        private bool _ChkSexo;
        public bool ChkSexo
        {
            get => _ChkSexo;
            set { _ChkSexo = value; OnPropertyChanged(); }
        }

        #endregion

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
        public bool PathLeitura(TextBox textBox)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();

                openFileDialog.Filter = "Text files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == true)
                {
                    textBox.Text = openFileDialog.FileName;
                    textBox.Focus();
                    textBox.Select(textBox.Text.Length, 0);

                    return true;
                }
                else
                {

                    return false;

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Path de Leitura", MessageBoxButton.OK, MessageBoxImage.Error);
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
            PathLeitura(TxbCaminhoExcel);
        }
        private async void BtnListaHorarios_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var comunica = Convert.ToBoolean(Rb_Comunica.IsChecked);
                if (string.IsNullOrEmpty(CaminhoExcel))
                {
                    MessageBox.Show("Informe o Local da Planilha de Implantação !", "Listar Horario", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                BtnListaHorarios.IsEnabled = false;
                string LocalGravacao = PathGravacao();
                if (!string.IsNullOrEmpty(LocalGravacao))
                {
                    await _excel.SalvaHorarios(CaminhoExcel, LocalGravacao, comunica);
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
                MessageBox.Show(ex.Message, "Lista Horarios", MessageBoxButton.OK, MessageBoxImage.Error);


            }
        }
        public async Task<bool> ValidaDados(string Caminho)
        {
            CheckValidaDados = "Hidden";
            ErroValidaDados = "Hidden";
            LblValidaDados = "Visivle";
            SpinValidaDados = "Visivle";
            bool comunica = Rb_Comunica.IsChecked ?? false;

            if (!await _validaDados.ValidaColunas(Caminho, comunica))
            {
                SpinValidaDados = "Hidden";
                ErroValidaDados = "Visivle";
                return false;
            }
            var tarefas = new Dictionary<string, Task<bool>>
            {
                ["CPF"] = _validaDados.ValidaCPF(Caminho, comunica),
                ["CPFDuplicado"] = _validaDados.ValidaCPFDuplicado(Caminho, comunica),
                ["PIS"] = _validaDados.ValidaPIS(Caminho, comunica),
                ["PISDuplicado"] = _validaDados.ValidaPISDuplicado(Caminho, comunica),
                ["MatriculaDuplicada"] = _validaDados.ValidaMatriculaDuplicada(Caminho, comunica),
                ["PessoaSemMatricula"] = _validaDados.ValidaPessoaSemMatricula(Caminho, comunica),
                ["DescricaoHorario"] = _validaDados.ValidaDescricaoHorario(Caminho, comunica),
                ["EmailDuplicado"] = _validaDados.ValidaEmailDuplicado(Caminho, comunica),
                ["DataInvalida"] = _validaDados.ValidaDatas(Caminho, comunica),
                ["PessoaSemCPF"] = _validaDados.ValidaPessoaSemCNPJ(Caminho, comunica),
                ["BaseDeHorasInvalida"] = _validaDados.ValidaBaseDeHoras(Caminho, comunica)
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
                if (System.IO.File.Exists(log))
                {
                    System.IO.File.Delete(log);
                }

                if (string.IsNullOrEmpty(CaminhoExcel))
                {
                    if (!PathLeitura(CaminhoExcelAltPessoa))
                    {
                        return;
                    }
                }
                BtnValidaDados.IsEnabled = false;
                if (await ValidaDados(CaminhoExcel) == true)
                {
                    BtnValidaDados.IsEnabled = true;
                    MessageBox.Show("Nâo existem dados invalidos ou duplicados !", "Valida Dados", MessageBoxButton.OK);
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
                MessageBox.Show(ex.Message, "Valida Dados", MessageBoxButton.OK, MessageBoxImage.Error);
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
                if (!PathLeitura(CaminhoExcelAltPessoa))
                {
                    return;
                }
            }
            if (System.IO.File.Exists(log))
            {
                System.IO.File.Delete(log);
            }

            BtnSync.IsEnabled = false;
            List<Cargo> Cargos = new();
            List<Estrutura> Estruturas = new();
            List<Horarios> Horarios = new();
            List<Pessoa> Pessoas = new();
            var tasks1 = new List<Task>();
            var comunica = Convert.ToBoolean(Rb_Comunica.IsChecked);
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
                        var estruturas = await _excel.ListaEstruturas(CaminhoExcel, comunica);
                        await _API.InsereEstruturasAPI(Key: Key.Trim(), CNPJ: CNPJ.Trim(), estruturas);
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
                    //LblValidaDados = "Visible"; 
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
                    if (comunica)
                    {
                        Pessoas = await _excel.ListaPessoasComunica(CaminhoExcel: CaminhoExcel, CPFRESP.Trim(), Cargos, Estruturas, Horarios, comunica);

                    }
                    else
                    {
                        Pessoas = await _excel.ListaPessoas(CaminhoExcel: CaminhoExcel, CPFRESP.Trim(), Cargos, Estruturas, Horarios, comunica);

                    }
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
                MessageBox.Show("Pessoas Inseridas Com Sucesso!", "Sync", MessageBoxButton.OK);

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

        #region ChkChaveFuncionario
        private void RbMatricula_Checked(object sender, RoutedEventArgs e)
        {
            Chave_Func_Matricula = true;
        }
        private void RbMatricula_Unchecked(object sender, RoutedEventArgs e)
        {
            Chave_Func_Matricula = false;
        }

        private void RBCPF_Checked(object sender, RoutedEventArgs e)
        {
            Chave_Func_CPF = true;
        }

        private void RBCPF_Unchecked(object sender, RoutedEventArgs e)
        {
            Chave_Func_CPF = false;
        }

        private void RBPIS_Checked(object sender, RoutedEventArgs e)
        {
            Chave_Func_PIS = true;
        }
        private void RBPIS_Unchecked(object sender, RoutedEventArgs e)
        {
            Chave_Func_PIS = false;
        }
        #endregion

        #region ChkAltPessoa

        private void Chk_Alt_Pess_Matricula_Click(object sender, RoutedEventArgs e)
        {
            if (Chk_Alt_Pess_Matricula.IsChecked == true)
            {
                ChkMatricula = true;
            }
            else
            {
                ChkMatricula = false;
            }

        }
        private void Chk_Alt_Pess_Nome_Click(object sender, RoutedEventArgs e)
        {
            if (Chk_Alt_Pess_Nome.IsChecked == true)
            {
                ChkNome = true;
            }
            else
            {
                ChkNome = false;
            }

        }
        private void Chk_Alt_Pess_PIS_Click(object sender, RoutedEventArgs e)
        {
            if (Chk_Alt_Pess_PIS.IsChecked == true)
            {
                ChkPIS = true;
            }
            else
            {
                ChkPIS = false;
            }

        }
        private void Chk_Alt_Pess_Cracha_Click(object sender, RoutedEventArgs e)
        {
            if (Chk_Alt_Pess_PIS.IsChecked == true)
            {
                ChkCracha = true;
            }
            else
            {
                ChkCracha = false;
            }

        }
        private void Chk_Alt_Pess_DataDeNascimento_Click(object sender, RoutedEventArgs e)
        {
            if (Chk_Alt_Pess_DataDeNascimento.IsChecked == true)
            {
                ChkDataNascimento = true;
            }
            else
            {
                ChkDataNascimento = false;
            }

        }
        private void Chk_Alt_Pess_DataDeAdmissao_Click(object sender, RoutedEventArgs e)
        {
            if (Chk_Alt_Pess_DataDeAdmissao.IsChecked == true)
            {
                ChkDataAdmissao = true;
            }
            else
            {
                ChkDataAdmissao = false;
            }

        }
        private void Chk_Alt_Pess_RG_Click(object sender, RoutedEventArgs e)
        {
            if (Chk_Alt_Pess_RG.IsChecked == true)
            {
                ChkRG = true;
            }
            else
            {
                ChkRG = false;
            }

        }
        private void Chk_Alt_Pess_CPF_Click(object sender, RoutedEventArgs e)
        {
            if (Chk_Alt_Pess_CPF.IsChecked == true)
            {
                ChkCPF = true;
            }
            else
            {
                ChkCPF = false;
            }

        }
        private void Chk_Alt_Pess_TelefoneCelular_Click(object sender, RoutedEventArgs e)
        {
            if (Chk_Alt_Pess_TelefoneCelular.IsChecked == true)
            {
                ChkCelular = true;
            }
            else
            {
                ChkCelular = false;
            }

        }
        private void Chk_Alt_Pess_Email_Click(object sender, RoutedEventArgs e)
        {
            if (Chk_Alt_Pess_Email.IsChecked == true)
            {
                ChkEmail = true;
            }
            else
            {
                ChkEmail = false;
            }

        }
        private void Chk_Alt_Pess_Estrutura_Click(object sender, RoutedEventArgs e)
        {
            if (Chk_Alt_Pess_Estrutura.IsChecked == true)
            {
                ChkDepartamento = true;
                ChkEstrutura = true;
            }
            else
            {
                ChkDepartamento = false;
                ChkEstrutura = false;
            }

        }
        private void Chk_Alt_Pess_Horario_Click(object sender, RoutedEventArgs e)
        {
            if (Chk_Alt_Pess_Horario.IsChecked == true)
            {
                ChkHorario = true;
            }
            else
            {
                ChkHorario = false;
            }

        }
        private void Chk_Alt_Pess_Cargo_Click(object sender, RoutedEventArgs e)
        {
            if (Chk_Alt_Pess_Cargo.IsChecked == true)
            {
                ChkCargo = true;
            }
            else
            {
                ChkCargo = false;
            }

        }
        private void Chk_Alt_Pess_Sexo_Click(object sender, RoutedEventArgs e)
        {
            if (Chk_Alt_Pess_Sexo.IsChecked == true)
            {
                ChkSexo = true;
            }
            else
            {
                ChkSexo = false;
            }

        }

        #endregion

        private async void BtnImportar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Txb_Alt_Pessoa_CNPJ) || string.IsNullOrEmpty(Txb_Alt_Pessoa_Chave))
            {
                MessageBox.Show("Verifique os campos CNPJ e CHAVE", "Importar", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            try
            {
                PessoaAPI.Clear();
                PessoaExcel.Clear();
                GridPessoas.Items.Clear();
                BtnImportar.IsEnabled = false;

                await Task.Run(async () =>
                {
                    PessoaAPI = new ObservableCollection<Pessoa>(await _API.ListaPessoasAPI(Txb_Alt_Pessoa_Chave, Txb_Alt_Pessoa_CNPJ));
                });



                foreach (var item in PessoaAPI.ToList())
                {
                    if (Convert.ToDateTime(item.DataDemissao) != Convert.ToDateTime("01/01/1753 00:00:00"))
                    {
                        PessoaAPI.Remove(item);
                    }
                }

                foreach (var item in PessoaAPI)
                {


                    string? Estrutura = item.Estrutura?.Descricao;
                    string? cargo = item.Cargo?.Descricao;
                    var Horario = item.Horarios[0]?.Horario?.Descricao;
                    string nascimento = "";
                    if (Convert.ToDateTime(item.DataNascimento) != Convert.ToDateTime("01/01/1753 00:00:00"))
                    {
                        nascimento = item.DataNascimento.Replace(" 00:00:00", "");
                    }
                    var estruturaOrg = new Estrutura();
                    estruturaOrg.Descricao = item.Estrutura.Descricao;
                    GridPessoas.Items.Add(new Pessoa()
                    {
                        Id = item.Id,
                        Matricula = item.Matricula,
                        Nome = item.Nome,
                        CodigoPis = item.CodigoPis.ToString(),
                        Cracha = item.Cracha,
                        DataNascimento = nascimento,
                        DataAdmissao = item.DataAdmissao.Replace(" 00:00:00", ""),
                        Rg = item.Rg,
                        Cpf = item.Cpf,
                        TelefoneCelular = item.TelefoneCelular,
                        Email = item.Email,
                        Estrutura = item.Estrutura,
                        Horarios = item.Horarios,
                        Cargo = item.Cargo,
                        Sexo = item.Sexo
                    });
                }
                if (PessoaAPI.Count > 0)
                {

                    MessageBox.Show("Dados Importados com Sucesso !", "Importar dados API", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                else
                {
                    MessageBox.Show("Não foi possivel buscar as pessoas na API \n Verifique o arquivo LOG !", "Importar dados API");
                }

                BtnImportar.IsEnabled = true;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Importar", MessageBoxButton.OK, MessageBoxImage.Error);
                BtnImportar.IsEnabled = true;
            }
        }

        private void BtnCaminhoExcelAltPessoa_Click(object sender, RoutedEventArgs e)
        {
            PathLeitura(CaminhoExcelAltPessoa);
        }

        private async void BtnAltPessoaIniciar_Click(object sender, RoutedEventArgs e)
        {
            if (!PessoaAPI.Any(x => x.Atualiza == true))
            {
                MessageBox.Show("Não existem dados a serem atualizados", "Importar", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;

            }


            await _excel.SalvaBKPExcel(PessoaAPI.ToList(), Txb_Alt_Pessoa_CNPJ);
            var p = JsonConvert.SerializeObject(PessoaAPI);
            var pessoaatualizada = JsonConvert.DeserializeObject<List<AtualizaPessoa>>(p.ToString());
            var ListaDeAlteracoes = pessoaatualizada?.Where(x => x.Atualiza == true).ToList();
            int total = ListaDeAlteracoes.Count;
            int status = 0;
            StatusAltPessoas = $"{status}/{total}";

            _cts = new CancellationTokenSource();
            await Parallel.ForEachAsync(ListaDeAlteracoes, _cts.Token, async (pessoa, token) =>
            {
                token.ThrowIfCancellationRequested();
                await _API.AtualizaPessoasAPI(Txb_Alt_Pessoa_Chave, Txb_Alt_Pessoa_CNPJ, pessoa);
                status++;
                StatusAltPessoas = $"{status}/{total}";

            });

            Lbl_StatusAlteraPessoa.Content = $"{total}/{total}";
            MessageBox.Show($"Pessoas alteradas com sucesso !{Environment.NewLine}Um BackUp dos dados foram salvos na pasta BKP", "Altera Pessoa", MessageBoxButton.OK, MessageBoxImage.Information);


        }

        private async void BtnAtualizaDados_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(CaminhoExcelAltPessoa.Text))
            {
                MessageBox.Show("Informe o caminho da planilha excel", "Atualizar", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (string.IsNullOrEmpty(Txb_Alt_Pessoa_CNPJ.Trim()) || string.IsNullOrEmpty(Txb_Alt_Pessoa_Chave.Trim()))
            {
                MessageBox.Show("Verifique os campos CNPJ e CHAVE", "Atualizar", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            if (PessoaAPI.Count() == 0)
            {
                MessageBox.Show("É necessario impotar os dados da API antes de atualizar", "Atualizar", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            if (string.IsNullOrEmpty(Txb_Alt_Pessoa_CPFResp))
            {
                MessageBox.Show("Informe o CPF do responsavel", "Atualizar", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            var comunica = Convert.ToBoolean(Rb_Comunica.IsChecked);
            if (ChkCargo)
            {
                CargosAPI = await _API.ListaCargosAPI(Txb_Alt_Pessoa_Chave, Txb_Alt_Pessoa_CNPJ);
            }
            if (ChkEstrutura)
            {
                EstruturasAPI = await _API.ListaEstruturasAPI(Txb_Alt_Pessoa_Chave, Txb_Alt_Pessoa_CNPJ);
            }
            if (_ChkHorario)
            {
                HorariosAPI = await _API.ListaHorariosAPI(Txb_Alt_Pessoa_Chave, Txb_Alt_Pessoa_CNPJ);
            }

            BtnAltPessoaIniciar.IsEnabled = false;
            if (comunica)
            {
                PessoaExcel = await _excel.ListaPessoasComunica(CaminhoExcel: CaminhoExcelAltPessoa.Text, CPFRESP.Trim(), CargosAPI, EstruturasAPI, HorariosAPI, comunica);

            }
            else
            {
                PessoaExcel = await _excel.ListaPessoas(CaminhoExcel: CaminhoExcelAltPessoa.Text, CPFRESP.Trim(), CargosAPI, EstruturasAPI, HorariosAPI);

            }
           

            foreach (var item in PessoaExcel)
            {
                int index = 0;
                if (Chave_Func_PIS)
                {
                    index = PessoaAPI.ToList().FindIndex(x => x.CodigoPis.Replace("-", "").Replace(".", "") == item.CodigoPis.Replace("-", "").Replace(".", ""));
                }
                else if (Chave_Func_CPF)
                {
                    index = PessoaAPI.ToList().FindIndex(x => x.Cpf.Replace("-", "").Replace(".", "") == item.Cpf.Replace("-", "").Replace(".", ""));
                }

                else if (Chave_Func_Matricula)
                {

                    index = PessoaAPI.ToList().FindIndex(x => x.Matricula == item.Matricula);

                }
                string CPFResponsavel = Txb_Alt_Pessoa_CPFResp.Trim();

                if (index != -1)
                {
                    if (ChkMatricula)
                    {
                        PessoaAPI[index].Matricula = item.Matricula;
                        PessoaAPI[index].Atualiza = true;
                        PessoaAPI[index].CpfResponsavel = CPFResponsavel;


                    }

                    if (ChkNome)
                    {
                        PessoaAPI[index].Nome = item.Nome;
                        PessoaAPI[index].Atualiza = true;
                        PessoaAPI[index].CpfResponsavel = CPFResponsavel;

                    }

                    if (ChkPIS)
                    {
                        PessoaAPI[index].CodigoPis = item.CodigoPis;
                        PessoaAPI[index].Atualiza = true;
                        PessoaAPI[index].CpfResponsavel = CPFResponsavel;

                    }

                    if (ChkCracha)
                    {
                        PessoaAPI[index].Cracha = item.Cracha;
                        PessoaAPI[index].Atualiza = true;
                        PessoaAPI[index].CpfResponsavel = CPFResponsavel;

                    }

                    if (ChkDataNascimento)
                    {
                        PessoaAPI[index].DataNascimento = item.DataNascimento;
                        PessoaAPI[index].Atualiza = true;
                        PessoaAPI[index].CpfResponsavel = CPFResponsavel;

                    }

                    if (ChkDataAdmissao)
                    {
                        PessoaAPI[index].DataAdmissao = item.DataAdmissao;
                        PessoaAPI[index].Atualiza = true;
                        PessoaAPI[index].CpfResponsavel = CPFResponsavel;

                    }

                    if (ChkRG)
                    {
                        PessoaAPI[index].Rg = item.Rg;
                        PessoaAPI[index].Atualiza = true;
                        PessoaAPI[index].CpfResponsavel = CPFResponsavel;

                    }

                    if (ChkCPF)
                    {
                        PessoaAPI[index].Cpf = item.Cpf;
                        PessoaAPI[index].Atualiza = true;
                        PessoaAPI[index].CpfResponsavel = CPFResponsavel;

                    }

                    if (ChkCelular)
                    {
                        PessoaAPI[index].TelefoneCelular = item.TelefoneCelular;
                        PessoaAPI[index].Atualiza = true;
                        PessoaAPI[index].CpfResponsavel = CPFResponsavel;

                    }

                    if (ChkEmail)
                    {
                        PessoaAPI[index].Email = item.Email;
                        PessoaAPI[index].Atualiza = true;
                        PessoaAPI[index].CpfResponsavel = CPFResponsavel;

                    }

                    if (ChkDepartamento && !string.IsNullOrEmpty(item.Estrutura.Descricao))
                    {
                        PessoaAPI[index].Estrutura = item.Estrutura;
                        PessoaAPI[index].Atualiza = true;
                        PessoaAPI[index].CpfResponsavel = CPFResponsavel;

                    }

                    if (ChkHorario)
                    {

                        PessoaAPI[index].Horarios = item.Horarios;
                        PessoaAPI[index].Atualiza = true;
                        PessoaAPI[index].CpfResponsavel = CPFResponsavel;

                    }

                    if (ChkCargo && !string.IsNullOrEmpty(item.Cargo.Descricao))
                    {
                        PessoaAPI[index].Cargo = item.Cargo;
                        PessoaAPI[index].Atualiza = true;
                        PessoaAPI[index].CpfResponsavel = CPFResponsavel;

                    }
                    if (ChkSexo)
                    {
                        PessoaAPI[index].Sexo = item.Sexo;
                        PessoaAPI[index].Atualiza = true;
                        PessoaAPI[index].CpfResponsavel = CPFResponsavel;

                    }

                }
            }
            GridPessoas.Items.Clear();
            foreach (var item in PessoaAPI.Where(x => x.Atualiza == true).ToList())
            {
                string? Estrutura = item.Estrutura.Descricao;
                string? cargo = item?.Cargo?.Descricao;
                var Horario = item.Horarios[0]?.Horario?.Descricao;
                string nascimento = "";
                if (Convert.ToDateTime(item.DataNascimento) != Convert.ToDateTime("01/01/1753 00:00:00"))
                {
                    nascimento = item.DataNascimento;
                }
                string Sexo = "Masculino";
                if (item.Sexo == 2)
                {
                    Sexo = "Feminino";
                }
                if (item.AmbienteTrabalhoPessoa == null)
                {
                    var AmbienteDeTrabalho = new List<Ambientetrabalhopessoa>();
                    AmbienteDeTrabalho.Add(new Ambientetrabalhopessoa
                    {
                        Id = 0,
                        Inicio = DateTime.Now.ToString(),
                        Fim = "31/12/9999 23:59:59",
                        TipoAmbienteTrabalho = 6
                    });
                    item.AmbienteTrabalhoPessoa = AmbienteDeTrabalho.ToArray();
                }


                GridPessoas.Items.Add(new Pessoa()
                {
                    Id = item.Id,
                    Matricula = item.Matricula,
                    Nome = item.Nome,
                    CodigoPis = item.CodigoPis.ToString(),
                    Cracha = item.Cracha,
                    DataNascimento = nascimento,
                    DataAdmissao = item.DataAdmissao.Replace(" 00:00:00", ""),
                    Rg = item.Rg,
                    Cpf = item.Cpf,
                    TelefoneCelular = item.TelefoneCelular,
                    Email = item.Email,
                    Estrutura = item.Estrutura,
                    Horarios = item.Horarios,
                    Cargo = item.Cargo,
                    Sexo = item.Sexo
                });


                BtnAltPessoaIniciar.IsEnabled = true;
            }
            MessageBox.Show("Lista Atualizada Com Sucesso !", "Atulizar dados", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private async void BtnBKPExcel_Click(object sender, RoutedEventArgs e)
        {
            if (PessoaAPI.Count > 0)
            {
                string LocalGravacao = PathGravacao();
                await _excel.SalvaBKPExcel(PessoaAPI.ToList(), Txb_Alt_Pessoa_CNPJ, LocalGravacao);
                MessageBox.Show("BKP dos dados salvo com sucesso !", "BKP Excel", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            else
            {
                MessageBox.Show("É necessario importar os dados da API antes de fazer o BKP !", "BKP Excel", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

        }
    }
}