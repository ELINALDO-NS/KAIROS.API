using KAIROS.API.Model;
using KAIROS.API.Repositorio;
using KAIROS.API.Repositorio.Interface;
using Microsoft.Extensions.DependencyInjection;
using OfficeOpenXml.FormulaParsing.Exceptions;
using System.Runtime.CompilerServices;

namespace KAIROS.API
{
    public partial class Form1 : Form
    {
        private readonly IExcelRepositorio _excel;
        private readonly IAPIRepositorio _API;
        private readonly IValidaDadosRepositorio _validaDados;

        public Form1(ServiceProvider serviceProvider)
        {
            InitializeComponent();
            _excel = serviceProvider.GetRequiredService<IExcelRepositorio>();
            _API = serviceProvider.GetRequiredService<IAPIRepositorio>();
            _validaDados = serviceProvider.GetRequiredService<IValidaDadosRepositorio>();
        }
        static string log = Convert.ToString(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + @"Log\Log.txt");

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }


        private async void btn_Lista_Horarios_Click(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrEmpty(Txb_Excel.Text))
                {
                    MessageBox.Show("Informe o Local da Planilha de Implantação !", "Listar Horario");
                    return;
                }
                string LocalGravacao = PathGravacao();
                if (!string.IsNullOrEmpty(LocalGravacao))
                {
                    await _excel.SalvaHorarios(Txb_Excel.Text, LocalGravacao);
                    MessageBox.Show("Ok");
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
        public bool PathLeitura(TextBox textBox)
        {
            try
            {

                using (OpenFileDialog OpenFileDialog1 = new OpenFileDialog())
                {
                    OpenFileDialog1.Filter = "Text files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        textBox.Text = OpenFileDialog1.FileName;

                        return true;
                    }
                    else
                    {

                        return false;

                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Modelo Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }
        public string PathGravacao()
        {
            try
            {

                using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
                {

                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        return folderBrowserDialog.SelectedPath;
                    }

                }
                return "";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Local de Gravação Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }

        }

        private void btn_LocalExcel_Click(object sender, EventArgs e)
        {
            PathLeitura(Txb_Excel);
        }


        private async void btn_Iniciar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txb_Key.Text.Trim()) || string.IsNullOrEmpty(Txb_CNPJ.Text.Trim()) || string.IsNullOrEmpty(Txb_CPFResponsavel.Text))
            {
                MessageBox.Show("Verifique os Campos: KEY, CNPJ, e CPFResponsavel", "Iniciar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(Txb_Excel.Text))
            {
                if (!PathLeitura(Txb_Excel))
                {
                    return;
                }

            }
            if (File.Exists(log))
            {
                File.Delete(log);
            }
            if (await ValidaDados(Txb_Excel.Text) == false)
            {
                AlterarStatus(SpinValidaDados, CheckValidaDados, false);
                return;
            }
            AlterarStatus(SpinValidaDados, CheckValidaDados, false);

            #region Labels
            Lbl_ValidaDados.Visible = true;
            Lbl_Horarios.Visible = true;
            Lbl_Estruturas.Visible = true;
            Lbl_Cargos.Visible = true;
            Lbl_Pessoas.Visible = true;
            Lbl_StatusPessoa.Visible = true;
            #endregion


            List<Cargo> Cargos = new();
            List<Estrutura> Estruturas = new();
            List<Horarios> Horarios = new();
            List<Pessoa> pessoas = new();
            try
            {
                await Task.WhenAll(
                Task.Run(async () =>
                {
                    AlterarStatus(SpinEstrutura, CheckEstruturas, true);
                    await _API.InsereEstruturasAPI(txb_Key.Text, Txb_CNPJ.Text, Txb_Excel.Text);
                }),
                Task.Run(async () =>
                {
                    AlterarStatus(SpinCargos, CheckCargos, true);
                    await _API.InsereCargosAPI(txb_Key.Text, Txb_CNPJ.Text, Txb_Excel.Text);
                })
                );

                await Task.WhenAll(
                Task.Run(async () =>
                 {
                     Cargos = await _API.ListaCargosAPI(txb_Key.Text, Txb_CNPJ.Text);
                     AlterarStatus(SpinCargos, CheckCargos, false);
                 }),
                Task.Run(async () =>
                {
                    AlterarStatus(SpinHorarios, CheckHorarios, true);
                    Horarios = await _API.ListaHorariosAPI(txb_Key.Text, Txb_CNPJ.Text);
                    AlterarStatus(SpinHorarios, CheckHorarios, false);
                }),
                Task.Run(async () =>
                 {
                     Estruturas = await _API.ListaEstruturasAPI(txb_Key.Text, Txb_CNPJ.Text);
                     AlterarStatus(SpinEstrutura, CheckEstruturas, false);
                 }));

                SpinPessoa.Invoke(new Action(() => { SpinPessoa.Visible = true; }));
                pessoas = await _excel.ListaPessoas(Txb_Excel.Text, Txb_CPFResponsavel.Text, Cargos, Estruturas, Horarios);
                await Task.Run(() =>
                {
                    int Stp = 0;
                    SpinPessoa.Invoke(new Action(() => { SpinPessoa.Visible = false; }));
                    Lbl_StatusPessoa.Invoke(new Action(() => Lbl_StatusPessoa.Text = $"{Stp}/{pessoas.Count}"));
                    Lbl_StatusPessoa.Invoke(new Action(() => Lbl_StatusPessoa.Visible = true));

                    Parallel.ForEach(pessoas, pessoa =>
                    {
                        _API.InserePessoaAPINOVO(txb_Key.Text, Txb_CNPJ.Text, pessoa);
                        Stp++;
                        Lbl_StatusPessoa.Invoke(new Action(() => Lbl_StatusPessoa.Text = $"{Stp}/{pessoas.Count}"));

                    });
                });

                Lbl_StatusPessoa.Visible = false;
                AlterarStatus(SpinPessoa, CheckPessoa, false);

                MessageBox.Show("OK");

            }
            catch (Exception ex)
            {
                DialogResult confirm = MessageBox.Show(ex.Message + Environment.NewLine + " Verifique o arquivo de Logs! \n Deseja Abrir o arquivo de LOG ?", "Iniciar", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                if (confirm.ToString().ToUpper() == "YES")
                {
                    System.Diagnostics.Process.Start("notepad.exe", Convert.ToString(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + @"\Log\Log.txt"));
                }

            }



        }

        private static void AlterarStatus(PictureBox Spin, PictureBox Check, bool Visible)
        {

            //if (Spin.InvokeRequired && Check.InvokeRequired)
            //{
            Spin.Invoke(new Action(() => Spin.Visible = Visible));
            Check.Invoke(new Action(() => Check.Visible = !Visible));
            //}
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
            Lbl_ValidaDados.Visible = true;
            AlterarStatus(SpinValidaDados, CheckValidaDados, true);

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
                AlterarStatus(SpinValidaDados, CheckValidaDados, false);
                DialogResult confirm = MessageBox.Show("Verifique o arquivo de Logs Existem dados invalidos ou duplicados ! \n Deseja Abrir o arquivo de LOG ?", "Operação", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
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

        private async void btn_Valida_Dados_Click(object sender, EventArgs e)
        {

            try
            {
                if (File.Exists(log))
                {
                    File.Delete(log);
                }

                if (string.IsNullOrEmpty(Txb_Excel.Text))
                {
                    if (!PathLeitura(Txb_Excel))
                    {
                        return;
                    }

                }
                if (await ValidaDados(Txb_Excel.Text) == true)
                {
                    AlterarStatus(SpinValidaDados, CheckValidaDados, false);
                    MessageBox.Show("Dados OK, NÃO existem dados invalidos ou duplicados !");
                }
            }
            catch (Exception ex)
            {
                AlterarStatus(SpinValidaDados, CheckValidaDados, false);
                MessageBox.Show(ex.Message, "Valida Dados");
            }





        }

        private void button2_Click(object sender, EventArgs e)
        {
            PathLeitura(txb_InsereSaldo_CaminhoExcel);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty( txb_InsereSaldo_CaminhoExcel.Text))
            {
                PathLeitura(txb_InsereSaldo_CaminhoExcel);
            }
        }
    }

}
