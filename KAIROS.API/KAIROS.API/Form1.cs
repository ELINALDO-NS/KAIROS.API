using KAIROS.API.Model;
using KAIROS.API.Repositorio;
using KAIROS.API.Repositorio.Interface;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using OfficeOpenXml.FormulaParsing.Exceptions;
using OpenQA.Selenium.DevTools.V124.Page;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using static System.Windows.Forms.LinkLabel;

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

        public void ResetaStatus()
        {
            Lbl_ValidaDados.Visible = false;
            Lbl_Estruturas.Visible = false;
            Lbl_Cargos.Visible = false;
            Lbl_Horarios.Visible = false;
            Lbl_Pessoas.Visible = false;

            SpinValidaDados.Visible = false;
            SpinEstrutura.Visible = false;
            SpinCargos.Visible = false;
            SpinHorarios.Visible = false;
            SpinPessoa.Visible = false;

            CheckValidaDados.Visible = false;
            CheckEstruturas.Visible = false;
            CheckCargos.Visible = false;
            CheckPessoa.Visible = false;


        }

        private void btn_LocalExcel_Click(object sender, EventArgs e)
        {
            PathLeitura(Txb_Excel);
        }


        private async void btn_Iniciar_Click(object sender, EventArgs e)
        {
            ResetaStatus();

            if (string.IsNullOrEmpty(txb_Key.Text.Trim()) || string.IsNullOrEmpty(Txb_CNPJ.Text.Trim()) || string.IsNullOrEmpty(Txb_CPFResponsavel.Text))
            {
                MessageBox.Show("Verifique os Campos: KEY, CNPJ, e CPFResponsavel", "Iniciar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Check_Cargos.Checked && !Check_Estruturas.Checked && !Check_Pessoas.Checked)
            {
                MessageBox.Show("Selecione os items a serem inseridos!", "Iniciar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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


            #region Labels
            Lbl_ValidaDados.Visible = true;
            //Lbl_Horarios.Visible = true;

            //Lbl_Cargos.Visible = true;
            //Lbl_Pessoas.Visible = true;
            //Lbl_StatusPessoa.Visible = true;
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
                    if (Check_Estruturas.Checked)
                    {
                        Lbl_Estruturas.Invoke(new Action(() => { Lbl_Estruturas.Visible = true; }));
                        AlterarStatus(SpinEstrutura, CheckEstruturas, true);
                        await _API.InsereEstruturasAPI(txb_Key.Text, Txb_CNPJ.Text, Txb_Excel.Text);
                        AlterarStatus(SpinEstrutura, CheckEstruturas, false);
                    }
                }),
                Task.Run(async () =>
                {
                    if (Check_Cargos.Checked)
                    {
                        Lbl_Cargos.Invoke(new Action(() => { Lbl_Cargos.Visible = true; }));
                        AlterarStatus(SpinCargos, CheckCargos, true);
                        await _API.InsereCargosAPI(txb_Key.Text, Txb_CNPJ.Text, Txb_Excel.Text);
                        AlterarStatus(SpinCargos, CheckCargos, false);
                    }

                })
                );
                if (Check_Pessoas.Checked)
                {
                    await Task.Run(async () =>
                     {
                         if (await ValidaDados(Txb_Excel.Text) == false)
                         {
                             AlterarStatus(SpinValidaDados, CheckValidaDados, false);
                             return;
                         }
                         AlterarStatus(SpinValidaDados, CheckValidaDados, false);

                         Lbl_Cargos.Invoke(new Action(() => { Lbl_Cargos.Visible = true; }));
                         AlterarStatus(SpinCargos, CheckCargos, true);
                         Cargos = await _API.ListaCargosAPI(txb_Key.Text, Txb_CNPJ.Text);
                         AlterarStatus(SpinCargos, CheckCargos, false);
                     });
                    await Task.WhenAll(

                    Task.Run(async () =>
                    {
                        Lbl_Horarios.Invoke(new Action(() => { Lbl_Horarios.Visible = true; }));
                        AlterarStatus(SpinHorarios, CheckHorarios, true);
                        Horarios = await _API.ListaHorariosAPI(txb_Key.Text, Txb_CNPJ.Text);
                        AlterarStatus(SpinHorarios, CheckHorarios, false);
                    }),
                    Task.Run(async () =>
                     {
                         Lbl_Estruturas.Invoke(new Action(() => { Lbl_Estruturas.Visible = true; }));
                         AlterarStatus(SpinEstrutura, CheckEstruturas, true);
                         Estruturas = await _API.ListaEstruturasAPI(txb_Key.Text, Txb_CNPJ.Text);
                         AlterarStatus(SpinEstrutura, CheckEstruturas, false);
                     }));

                    Lbl_Pessoas.Invoke(new Action(() => { Lbl_Pessoas.Visible = true; }));
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
                }
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
            Lbl_ValidaDados.Invoke(new Action(() => { Lbl_ValidaDados.Visible = true; }));

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
                ResetaStatus();
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

        private async void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txb_Historico.Text) || string.IsNullOrEmpty(txb_Usuario.Text) || string.IsNullOrEmpty(txb_Senha.Text))
            {
                MessageBox.Show("Preencha os campos: Usuario, Senha e Historico", "Insere Saldo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(txb_InsereSaldo_CaminhoExcel.Text))
            {
                PathLeitura(txb_InsereSaldo_CaminhoExcel);
            }
            try
            {

                bool erro = await _API.InsereSaldo(Kairos.Login(txb_Usuario.Text.Trim(), txb_Senha.Text.Trim()), txb_Historico.Text.Trim(), txb_InsereSaldo_CaminhoExcel.Text);

                if (erro)
                {
                    MessageBox.Show("Ocorreram erros no lançameto do saldo, verifique o arquivo LOG", "Insere Saldo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    MessageBox.Show("Saldo inserido com sucesso !", "Insere Saldo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ocorreram erros \n" + ex.Message, "Insere Saldo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }


        }

        private void Btn_Excel_Desligamento_Click(object sender, EventArgs e)
        {
            PathLeitura(Txb_Caminho_Excel_Desligamento);
        }
        List<Pessoa> PessoaAPI = new List<Pessoa>();
        List<Pessoa> PessoaExcel = new List<Pessoa>();
        List<Cargo> CargosAPI = new List<Cargo>();
        List<Estrutura> EstruturasAPI = new List<Estrutura>();
        bool Atualizadados = false;

        private async void btn_Importar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Txb_Alt_Pessoa_CNPJ.Text.Trim()) || string.IsNullOrEmpty(Txb_Alt_Pessoa_Key.Text.Trim()))
            {
                MessageBox.Show("Verifique os campos CNPJ e CHAVE", "Importar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {

                PessoaAPI.Clear();
                PessoaExcel.Clear();
                Grid_Pessoa.Rows.Clear();
                btn_Importar.Enabled = false;
                
                 await  Task.Run(async () =>
                   {
                       PessoaAPI.AddRange(await _API.ListaPessoasAPI(Txb_Alt_Pessoa_Key.Text, Txb_Alt_Pessoa_CNPJ.Text, 1));
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
                        nascimento = item.DataNascimento;
                    }
                    string Sexo = "Masculino";
                    if (item.Sexo == 2)
                    {
                        Sexo = "Feminino";
                    }


                    Grid_Pessoa.Rows.Add(item.Id,
                    item.Matricula.ToString(), item.Nome.ToString(), item.CodigoPis.ToString(),
                    item.Cracha, nascimento, item.DataAdmissao, item.Rg, item.Cpf,
                    item.TelefoneCelular, item.Email, Estrutura, Horario, cargo, Sexo
                     );
                }
                if (PessoaAPI.Count > 0)
                {

                    MessageBox.Show("Dados Importados com Sucesso !", "Importar dados API", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Não foi possivel buscar as pessoas na API \n Verifique o arquivo LOG !", "Importar dados API");
                }

                btn_Importar.Enabled = true;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Importar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btn_Importar.Enabled = true;
            }

        }

        private void Btn_CaminExcel_Alt_Pessoa_Click(object sender, EventArgs e)
        {
            PathLeitura(Txb_Camin_Excel_Altera_Pessoa);
        }


        private async void Btn_AtualizaDados_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Txb_Camin_Excel_Altera_Pessoa.Text))
            {
                MessageBox.Show("Informe o caminho da planilha excel", "Atualizar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(Txb_Alt_Pessoa_CNPJ.Text.Trim()) || string.IsNullOrEmpty(Txb_Alt_Pessoa_Key.Text.Trim()))
            {
                MessageBox.Show("Verifique os campos CNPJ e CHAVE", "Atualizar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (PessoaAPI.Count() == 0)
            {
                MessageBox.Show("É necessario impotar os dados da API antes de atualizar", "Atualizar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrEmpty(Txb_CPF_Resp_Altera_Pessoa.Text))
            {
                MessageBox.Show("Informe o CPF do responsavel", "Atualizar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (Check_alt_Cargo.Checked)
            {
                CargosAPI = await _API.ListaCargosAPI(Txb_Alt_Pessoa_Key.Text, Txb_Alt_Pessoa_CNPJ.Text);
            }
            if (Check_alt_Departamento.Checked)
            {
                EstruturasAPI = await _API.ListaEstruturasAPI(Txb_Alt_Pessoa_Key.Text, Txb_Alt_Pessoa_CNPJ.Text);
            }

            Btn_AtualizaDados.Enabled = false;
            PessoaExcel = await _excel.ListaPessoas(Txb_Camin_Excel_Altera_Pessoa.Text, "", CargosAPI, EstruturasAPI, new List<Horarios>(), true);


            foreach (var item in PessoaExcel)
            {
                int index = 0;
                if (RB_PIS.Checked)
                {
                    index = PessoaAPI.FindIndex(x => x.CodigoPis.Replace("-", "").Replace(".", "") == item.CodigoPis.Replace("-", "").Replace(".", ""));
                }
                else if (RB_CPF.Checked)
                {
                    index = PessoaAPI.FindIndex(x => x.Cpf.Replace("-", "").Replace(".", "") == item.Cpf.Replace("-", "").Replace(".", ""));
                }

                else if (RB_Matricula.Checked)
                {

                    index = PessoaAPI.FindIndex(x => x.Matricula == item.Matricula);

                }

                if (index != -1)
                {
                    if (Check_alt_Matricula.Checked)
                    {
                        PessoaAPI[index].Matricula = item.Matricula;
                        PessoaAPI[index].Atualiza = true;
                        PessoaAPI[index].CpfResponsavel = Txb_CPF_Resp_Altera_Pessoa.Text.Trim();


                    }

                    if (Check_alt_Nome.Checked)
                    {
                        PessoaAPI[index].Nome = item.Nome;
                        PessoaAPI[index].Atualiza = true;
                        PessoaAPI[index].CpfResponsavel = Txb_CPF_Resp_Altera_Pessoa.Text.Trim();

                    }

                    if (Check_alt_PIS.Checked)
                    {
                        PessoaAPI[index].CodigoPis = item.CodigoPis;
                        PessoaAPI[index].Atualiza = true;
                        PessoaAPI[index].CpfResponsavel = Txb_CPF_Resp_Altera_Pessoa.Text.Trim();

                    }

                    if (Check_alt_Crachar.Checked)
                    {
                        PessoaAPI[index].Cracha = item.Cracha;
                        PessoaAPI[index].Atualiza = true;
                        PessoaAPI[index].CpfResponsavel = Txb_CPF_Resp_Altera_Pessoa.Text.Trim();

                    }

                    if (Check_alt_Nascimento.Checked)
                    {
                        PessoaAPI[index].DataNascimento = item.DataNascimento;
                        PessoaAPI[index].Atualiza = true;
                        PessoaAPI[index].CpfResponsavel = Txb_CPF_Resp_Altera_Pessoa.Text.Trim();

                    }

                    if (Check_alt_Admissao.Checked)
                    {
                        PessoaAPI[index].DataAdmissao = item.DataAdmissao;
                        PessoaAPI[index].Atualiza = true;
                        PessoaAPI[index].CpfResponsavel = Txb_CPF_Resp_Altera_Pessoa.Text.Trim();

                    }

                    if (Check_alt_RG.Checked)
                    {
                        PessoaAPI[index].Rg = item.Rg;
                        PessoaAPI[index].Atualiza = true;
                        PessoaAPI[index].CpfResponsavel = Txb_CPF_Resp_Altera_Pessoa.Text.Trim();

                    }

                    if (Check_alt_CPF.Checked)
                    {
                        PessoaAPI[index].Cpf = item.Cpf;
                        PessoaAPI[index].Atualiza = true;
                        PessoaAPI[index].CpfResponsavel = Txb_CPF_Resp_Altera_Pessoa.Text.Trim();

                    }

                    if (Check_alt_Celular.Checked)
                    {
                        PessoaAPI[index].TelefoneCelular = item.TelefoneCelular;
                        PessoaAPI[index].Atualiza = true;
                        PessoaAPI[index].CpfResponsavel = Txb_CPF_Resp_Altera_Pessoa.Text.Trim();

                    }

                    if (Check_alt_Email.Checked)
                    {
                        PessoaAPI[index].Email = item.Email;
                        PessoaAPI[index].Atualiza = true;
                        PessoaAPI[index].CpfResponsavel = Txb_CPF_Resp_Altera_Pessoa.Text.Trim();

                    }

                    if (Check_alt_Departamento.Checked && !string.IsNullOrEmpty(item.Estrutura.Descricao))
                    {
                        PessoaAPI[index].Estrutura = item.Estrutura;
                        PessoaAPI[index].Atualiza = true;
                        PessoaAPI[index].CpfResponsavel = Txb_CPF_Resp_Altera_Pessoa.Text.Trim();

                    }

                    if (Check_alt_Horario.Checked)
                    {
                        PessoaAPI[index].Horarios = item.Horarios;
                        PessoaAPI[index].Atualiza = true;
                        PessoaAPI[index].CpfResponsavel = Txb_CPF_Resp_Altera_Pessoa.Text.Trim();

                    }

                    if (Check_alt_Cargo.Checked && !string.IsNullOrEmpty(item.Cargo.Descricao))
                    {
                        PessoaAPI[index].Cargo = item.Cargo;
                        PessoaAPI[index].Atualiza = true;
                        PessoaAPI[index].CpfResponsavel = Txb_CPF_Resp_Altera_Pessoa.Text.Trim();

                    }
                    if (Check_alt_Sexo.Checked)
                    {
                        PessoaAPI[index].Sexo = item.Sexo;
                        PessoaAPI[index].Atualiza = true;
                        PessoaAPI[index].CpfResponsavel = Txb_CPF_Resp_Altera_Pessoa.Text.Trim();

                    }

                }
            }
            Grid_Pessoa.Rows.Clear();
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



                Grid_Pessoa.Rows.Add(item.Id,
                item.Matricula.ToString(), item.Nome.ToString(), item.CodigoPis.ToString(),
                item.Cracha, nascimento, item.DataAdmissao, item.Rg, item.Cpf,
                item.TelefoneCelular, item.Email, Estrutura, Horario, cargo, Sexo
                 );
            }
            Atualizadados = true;
            Btn_AtualizaDados.Enabled = true;
            MessageBox.Show("Lista Atualizada Com Sucesso !", "Atulizar dados", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private async void Btn_Iniciar_AlteraPessoa_Click(object sender, EventArgs e)
        {

            if (!PessoaAPI.Any(x => x.Atualiza == true))
            {
                MessageBox.Show("Não existem dados a serem atualizados", "Importar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }


            await _excel.SalvaBKPExcel(PessoaAPI, Txb_Alt_Pessoa_CNPJ.Text);
            var p = JsonConvert.SerializeObject(PessoaAPI);
            var pessoaatualizada = JsonConvert.DeserializeObject<List<AtualizaPessoa>>(p.ToString());
            var ListaDeAlteracoes = pessoaatualizada?.Where(x => x.Atualiza == true).ToList();
            int total = ListaDeAlteracoes.Count();
            int status = 0;
            Lbl_StatusAlteraPessoa.Text = $"{status}/{total}";
            await Task.Run(() =>
            {
                Parallel.ForEach(ListaDeAlteracoes, pessoa =>
                  {

                      _API.AtualizaPessoasAPI(Txb_Alt_Pessoa_Key.Text, Txb_Alt_Pessoa_CNPJ.Text, pessoa);

                      Lbl_StatusAlteraPessoa.Invoke(new MethodInvoker(delegate
                      {
                          Lbl_StatusAlteraPessoa.Text = $"{status}/{total}";
                      }));
                      status++;

                  });
            });

            Lbl_StatusAlteraPessoa.Text = $"{total}/{total}";
            MessageBox.Show($"Pessoas alteradas com sucesso !{Environment.NewLine}Um BackUp dos dados foram salvos na pasta BKP", "Altera Pessoa", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private async void Btn_BKP_Excel_Click(object sender, EventArgs e)
        {
            if (PessoaAPI.Count > 0)
            {
                string LocalGravacao = PathGravacao();
                await _excel.SalvaBKPExcel(PessoaAPI, Txb_Alt_Pessoa_CNPJ.Text, LocalGravacao);
                MessageBox.Show("BKP dos dados salvo com sucesso !", "BKP Excel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


            }
            else
            {
                MessageBox.Show("É necessario importar os dados da API antes de fazer o BKP !", "BKP Excel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            List<Desligamento> deligamento = new();
            deligamento = await _excel.ListaDesligamento(Txb_Caminho_Excel_Desligamento.Text);

            await _API.DesligaPessoa(Txb_Key_Desligamento.Text, Txb_CNPJ_Desligamento.Text, deligamento);
            MessageBox.Show("Desligamentos Concluidos !");
        }

        private async void btn_ValidaSaldo_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txb_InsereSaldo_CaminhoExcel.Text))
                {
                    if (!PathLeitura(txb_InsereSaldo_CaminhoExcel))
                    {
                        return;
                    }

                }
                var valido = await _API.ValidaSaldo(txb_InsereSaldo_CaminhoExcel.Text);
                if (!valido)
                {
                    MessageBox.Show("Existem funcionarios com saldos invalidos, verifique o arquivo LOG!", "Insere Saldo BH", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    MessageBox.Show("Saldo OK !", "Insere Saldo BH", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Btn_IsenreSaldo_Iniciar.Enabled = true;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Insere Saldo BH", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private async void Btn_Gera_txt_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.ShowDialog();
            string gravacao = folderBrowser.SelectedPath;
            var desligamento = await _excel.ListaDesligamento(Txb_Caminho_Excel_Desligamento.Text);
            if (!string.IsNullOrEmpty(gravacao))
            {
               await _API.DesligaPessoaTxt(Txb_Key_Desligamento.Text, Txb_CNPJ_Desligamento.Text, desligamento, gravacao);
            }
           

        }
    }

}
