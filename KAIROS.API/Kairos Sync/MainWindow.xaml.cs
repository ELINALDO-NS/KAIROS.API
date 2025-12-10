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