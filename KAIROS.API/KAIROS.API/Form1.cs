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

        public Form1(ServiceProvider serviceProvider)
        {
            InitializeComponent();
            _excel = serviceProvider.GetRequiredService<IExcelRepositorio>();
            _API = serviceProvider.GetRequiredService<IAPIRepositorio>();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public static string StatusPessoas = string.Empty;

        private void btn_Lista_Horarios_Click(object sender, EventArgs e)
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
                    _excel.SalvaHorarios(Txb_Excel.Text, LocalGravacao);
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
        public bool PathLeitura()
        {
            try
            {

                using (OpenFileDialog OpenFileDialog1 = new OpenFileDialog())
                {
                    OpenFileDialog1.Filter = "Text files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        Txb_Excel.Text = OpenFileDialog1.FileName;

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
            PathLeitura();
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
                if (!PathLeitura())
                {
                    return;
                }

            }
            string log = Convert.ToString(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + @"\Log");
            if (File.Exists(log))
            {
                File.Delete(log);
            }
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
             }));
            await Task.WhenAll(
             Task.Run(async () =>
                {
                    Cargos = await _API.ListaCargosAPI(txb_Key.Text, Txb_CNPJ.Text);
                    AlterarStatus(SpinCargos, CheckCargos, false);
                }),
             Task.Run(async () =>
                {
                    Estruturas = await _API.ListaEstruturasAPI(txb_Key.Text, Txb_CNPJ.Text);
                    AlterarStatus(SpinEstrutura, CheckEstruturas, false);
                }),
             Task.Run(async () =>
                {
                    Horarios = await _API.ListaHorariosAPI(txb_Key.Text, Txb_CNPJ.Text);
                    AlterarStatus(SpinHorarios, CheckHorarios, false);
                }));

            var ListaPessoas = await _excel.ListaPessoas(Txb_Excel.Text, Txb_CPFResponsavel.Text, Cargos, Estruturas, Horarios);
            await _API.InserePessoaAPI(txb_Key.Text, Txb_CNPJ.Text, Txb_Excel.Text, Txb_CPFResponsavel.Text, ListaPessoas);
            Lbl_StatusPessoa.Visible = false;
            AlterarStatus(SpinCargos, CheckPessoa, true);

            MessageBox.Show("OK");


        }

        private static void AlterarStatus(PictureBox Spin, PictureBox Check, bool Visible)
        {

            if (Spin.InvokeRequired && Check.InvokeRequired)
            {
                Spin.Invoke(new Action(() => Spin.Visible = Visible));
                Check.Invoke(new Action(() => Check.Visible = !Visible));
            }


        }
    }
}
