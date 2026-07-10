using API;
using API.Model;
using API.Repositorio.Interface;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;

namespace API.Repositorio
{
    public class ExcelRepositorio : IExcelRepositorio
    {
        public int Codigo { get; set; } = 2;
        public ExcelRepositorio()
        {
            ExcelPackage.License.SetNonCommercialPersonal("Jubileu");

        }
        public async Task<List<Cargo>> ListaCargos(string CaminhoExcel, bool comunicacao)
        {
            if (comunicacao)
                return [];

            var cargos = new List<Cargo>();
            var cargosOrdenados = new List<Cargo>();
            var excel = new Excel(CaminhoExcel);
            await Task.Run(() =>
            {

                int Linha = 4;
                while (true)
                {

                    string DescricaoPlCargo = FormataTexto.RemoveAcentos(excel.LeExcel("CARGOS", Linha, 2));
                    if (!string.IsNullOrEmpty(DescricaoPlCargo))
                    {
                        if (!cargos.Any(a => a.Descricao.Replace(" ", "").Equals(DescricaoPlCargo.Replace(" ", ""))))
                        {
                            cargos.Add(new Cargo
                            {
                                Descricao = DescricaoPlCargo
                            });

                        }
                        Linha++;
                    }
                    else
                    {
                        break;
                    }
                }
                Linha = 4;
                while (true)
                {
                    string DescricaoPlCargo = FormataTexto.RemoveAcentos(excel.LeExcel("FUNCIONÁRIOS", Linha, 17));
                    if (!string.IsNullOrEmpty(DescricaoPlCargo))
                    {
                        if (!cargos.Any(a => a.Descricao.Replace(" ", "").Equals(DescricaoPlCargo.Replace(" ", ""))))
                        {
                            cargos.Add(new Cargo
                            {
                                Descricao = DescricaoPlCargo
                            });

                        }
                        Linha++;
                    }
                    else
                    {
                        break;
                    }
                }

            });
            int codigo = 1;
            cargosOrdenados = cargos.OrderBy(c => c.Descricao).ToList();
            cargosOrdenados.ForEach(c => { c.Codigo = codigo; codigo++; });
            return cargosOrdenados;

        }
        public async Task<List<Desligamento>> ListaDesligamento(string CaminhoExcel)
        {
            var desligamento = new List<Desligamento>();
            var excel = new Excel(CaminhoExcel);
            await Task.Run(() =>
            {

                int Linha = 2;
                while (true)
                {

                    string matricula = FormataTexto.RemoveAcentos(excel.LeExcel("Desligamento", Linha, 1));
                    if (!string.IsNullOrEmpty(matricula))
                    {
                        if (!desligamento.Any(a => a.Matricula.Equals(matricula)))
                        {
                            desligamento.Add(new Desligamento
                            {
                                Matricula = Convert.ToInt32(FormataTexto.RemoveAcentos(excel.LeExcel("Desligamento", Linha, 1))),
                                DATA = Convert.ToDateTime(FormataTexto.RemoveAcentos(excel.LeExcel("Desligamento", Linha, 2))),

                            });

                        }
                        Linha++;
                    }
                    else
                    {
                        break;
                    }
                }


            });

            return desligamento;

        }
        public async Task<List<Estrutura>> ListaEstruturas(string CaminhoExcel, bool comunicacao = false)
        {
            var estrutura = new List<Estrutura>();
            var estruturaOrdenada = new List<Estrutura>();
            var excel = new Excel(CaminhoExcel);
            await Task.Run(() =>
            {
                int Linha = 4;
                int coluna = comunicacao ? 9 : 15;

                while (!comunicacao)
                {
                    string DescricaoPlDepartamento = FormataTexto.RemoveAcentos(excel.LeExcel("DEPARTAMENTOS", Linha, 2));
                    if (!string.IsNullOrEmpty(DescricaoPlDepartamento))
                    {
                        if (!estrutura.Any(a => a.Descricao.Replace(" ", "").Equals(DescricaoPlDepartamento.Replace(" ", ""))))
                        {
                            estrutura.Add(new Estrutura
                            {
                                Descricao = DescricaoPlDepartamento
                            });

                        }

                        Linha++;
                    }
                    else
                    {
                        break;
                    }
                }
                Linha = 4;
                while (true)
                {
                    string DescricaoPlFuncionario = FormataTexto.RemoveAcentos(excel.LeExcel("FUNCIONÁRIOS", Linha, coluna));

                    if (!string.IsNullOrEmpty(DescricaoPlFuncionario))
                    {
                        if (!estrutura.Any(a => a.Descricao.Replace(" ", "").Equals(DescricaoPlFuncionario.Replace(" ", ""))))
                        {
                            estrutura.Add(new Estrutura
                            {

                                Descricao = DescricaoPlFuncionario
                            });

                        }

                        Linha++;
                    }
                    else
                    {
                        break;
                    }
                }
            });
            int codigo = 1;
            estruturaOrdenada = estrutura.OrderBy(c => c.Descricao).ToList();
            estruturaOrdenada.ForEach(c => { c.Codigo = codigo; codigo++; });
            return estruturaOrdenada;


        }
        public async Task<List<Horarios>> ListaHorariosAssociados(string CaminhoExcel, bool comunicacao = false)
        {
            if (comunicacao)
                return [];

            var horario = new List<Horarios>();
            var excel = new Excel(CaminhoExcel);
            await Task.Run(() =>
            {
                Codigo = 2;
                int Linha = 4;

                while (true)
                {

                    string DescricaoPFuncionario = excel.LeExcel("FUNCIONÁRIOS", Linha, 16);
                    if (!string.IsNullOrEmpty(DescricaoPFuncionario))
                    {
                        if (!horario.Any(a => FormataTexto.SoLetrasENumeros(a.Descricao).Replace(" ", "").Equals(FormataTexto.SoLetrasENumeros(DescricaoPFuncionario).Replace(" ", ""))))
                        {
                            horario.Add(new Horarios
                            {
                                Codigo = Codigo.ToString(),
                                Descricao = DescricaoPFuncionario
                            });
                            Codigo++;
                        }

                        Linha++;
                    }
                    else
                    {
                        break;
                    }
                }


            });
            return horario;

        }
        public async Task<List<Horarios>> ListaHorariosNaoAssociados(string CaminhoExcel, bool comunicacao = false)
        {
            if (comunicacao)
                return [];

            var horario = new List<Horarios>();
            var excel = new Excel(CaminhoExcel);
            await Task.Run(() =>
            {

                int Linha = 5;

                while (true)
                {

                    string DescricaoPHorario = excel.LeExcel("HORÁRIOS", Linha, 2);
                    if (!string.IsNullOrEmpty(DescricaoPHorario))
                    {
                        if (!horario.Any(a => FormataTexto.SoLetrasENumeros(a.Descricao).Replace(" ", "").Equals(FormataTexto.SoLetrasENumeros(DescricaoPHorario).Replace(" ", ""))))
                        {
                            horario.Add(new Horarios
                            {
                                Codigo = Codigo.ToString(),
                                Descricao = DescricaoPHorario,

                            });
                            Codigo++;
                        }

                        Linha++;
                    }
                    else
                    {
                        break;
                    }
                }



            });
            return horario;

        }
        public async Task<List<Pessoa>> ListaPessoas(string CaminhoExcel, string CPFResponsavel, List<Cargo> Cargos, List<Estrutura> Estruturas, List<Horarios> Horarois, bool AtualizaPessoa)
        {
            var excel = new Excel(CaminhoExcel);
            var estruturas = Estruturas;
            var horarios = Horarois;
            var cargos = Cargos;
            var Pessoas = new List<Pessoa>();
            string Planilha = "FUNCIONÁRIOS";
            bool divergencia = false;
            int Linha = 4;
            await Task.Run(() =>
                  {
                      while (true)
                      {

                          string Mat = excel.LeExcel(Planilha, Linha, 1);

                          if (!string.IsNullOrEmpty(Mat))
                          {

                              int Matricula = Convert.ToInt32(Regex.Replace(excel.LeExcel(Planilha, Linha, 1), @"[^\d]", ""));
                              string Nome = FormataTexto.RemoveAcentos(excel.LeExcel(Planilha, Linha, 2));
                              string PIS = FormataTexto.SoNumenros(excel.LeExcel(Planilha, Linha, 3)).PadLeft(11, '0');
                              int FuncionarioSemPIS = 0; // 0 = Tem PIS - 1 = Não tem PIS
                              string Cracha = excel.LeExcel(Planilha, Linha, 4).Trim();
                              string Nascimento = excel.LeExcel(Planilha, Linha, 5).Trim();
                              string Admissao = excel.LeExcel(Planilha, Linha, 6).Trim();
                              string RG = FormataTexto.SoNumenros(excel.LeExcel(Planilha, Linha, 7));
                              string CPF = FormataTexto.SoNumenros(excel.LeExcel(Planilha, Linha, 8)).PadLeft(11, '0');
                              string Telefone = FormataTexto.SoNumenros(excel.LeExcel(Planilha, Linha, 9));
                              string Celular = FormataTexto.SoNumenros(excel.LeExcel(Planilha, Linha, 10));
                              string Email = excel.LeExcel(Planilha, Linha, 11).Trim();
                              var TipoDeSalario = new Tiposalario() { Id = 101 }; // Convert.ToString(PlanilhaFuncionario.Cells[Linha, 12].Value);
                              string BaseDeHoras = excel.LeExcel(Planilha, Linha, 13);
                              string controlaPonto = excel.LeExcel(Planilha, Linha, 14).ToUpper();
                              var DepartamentoList = new Estrutura();
                              string DepartamentoPessoa = excel.LeExcel(Planilha, Linha, 15);
                              string HorarioPessoa = excel.LeExcel(Planilha, Linha, 16).Trim();
                              var Horario = new List<Horarios>();
                              var RegraDeCaldulo = new List<Regrascalculo>();
                              string CargoPessoa = FormataTexto.RemoveAcentos(excel.LeExcel(Planilha, Linha, 17));
                              Cargo? Cargo = new();
                              string EscalaDeFOlga = excel.LeExcel(Planilha, Linha, 18);
                              var AmbienteDeTrabalho = new List<Ambientetrabalhopessoa>();
                              AmbienteDeTrabalho.Add(new Ambientetrabalhopessoa
                              {
                                  Id = 0,
                                  Inicio = DateTime.Now.ToString(),
                                  Fim = "31/12/9999 23:59:59",
                                  TipoAmbienteTrabalho = 6
                              });
                              if (CPF == "00000000000")
                              {
                                  CPF = null!;
                              }
                              string Sexo = FormataTexto.SoLetrasENumeros(excel.LeExcel(Planilha, Linha, 19).ToUpper());
                              string CNPJ = excel.LeExcel(Planilha, Linha, 20);
                              var TipoDeFuncionario = new Tipofuncionario() { IdTipoFuncionario = 1 };
                              #region Estrutura
                              if (estruturas.Count > 0)
                              {

                                  foreach (var e in estruturas)
                                  {

                                      if (FormataTexto.RemoveAcentos(e.Descricao.Replace(" ", "")).Equals(FormataTexto.RemoveAcentos(DepartamentoPessoa).Replace(" ", "")))
                                      {

                                          DepartamentoList.Id = e.Id;
                                          DepartamentoList.Codigo = 0;
                                          DepartamentoList.Descricao = e.Descricao;


                                          break;
                                      }
                                  }
                                  if (DepartamentoList.Id == 0)
                                  {
                                      divergencia = true;
                                      Log.GravaLog($"Estrutura: {DepartamentoPessoa} não encontrada para o funcionario, Matricula: " +
                                      Matricula.ToString());
                                  }
                              }

                              #endregion

                              #region Cargo
                              if (cargos.Count > 0)
                              {
                                  foreach (var C in cargos)
                                  {

                                      if (FormataTexto.RemoveAcentos(C.Descricao.Replace(" ", "")).Equals(CargoPessoa.Replace(" ", "")))
                                      {
                                          Cargo.Id = C.Id;
                                          Cargo.Codigo = 0;
                                          Cargo.Descricao = C.Descricao;
                                          break;
                                      }


                                  }

                              }


                              #endregion

                              #region Horario

                              foreach (var H in horarios)
                              {
                                  if (FormataTexto.SoLetrasENumeros(H.Descricao.Replace(" ", "")).Equals(FormataTexto.SoLetrasENumeros(HorarioPessoa.Replace(" ", ""))))
                                  {

                                      Horario.Add(new Horarios()
                                      {
                                          //Codigo = H.Codigo,

                                          Inicio = DateTime.Now.ToString(),
                                          Fim = "31/12/9999 23:59:59",
                                          Horario = new Horario() { Id = H.Id, Descricao = H.Descricao },
                                          Descricao = H.Descricao
                                      });

                                      break;
                                  }


                              }
                              if (Horario.Count <= 0)
                              {
                                  divergencia = true;
                                  Log.GravaLog($"({HorarioPessoa}) Horario não encontrado para o funcionario, Matricula: " + Matricula);

                              }


                              #endregion

                              #region Base de Horas
                              if (!string.IsNullOrEmpty(BaseDeHoras))
                              {
                                  BaseDeHoras = excel.LeExcel(Planilha, Linha, 13);
                              }
                              else
                              {
                                  BaseDeHoras = "220";
                              }
                              #endregion

                              #region Cracha

                              if (string.IsNullOrEmpty(Cracha))
                              {
                                  Cracha = Matricula.ToString();
                              }
                              else if (Cracha.ToUpper() == "CPF" && !string.IsNullOrEmpty(CPF))
                              {
                                  Cracha = CPF;
                              }
                              else
                              {
                                  Cracha = FormataTexto.SoNumenros(excel.LeExcel(Planilha, Linha, 4));
                              }

                              #endregion

                              #region Sexo

                              if (Sexo == "F" || Sexo == "FEMININO" || Sexo == "FEMENINO" || Sexo == "FEMININA" || Sexo == "FEM")
                              {
                                  Sexo = "2";
                              }
                              else
                              {
                                  Sexo = "1";
                              }
                              #endregion

                              #region ControlaPonto

                              if (controlaPonto == "NAO" || controlaPonto == "NÃO" || controlaPonto == "Não")
                              {
                                  controlaPonto = "false";
                              }
                              else
                              {
                                  controlaPonto = "true";
                              }
                              #endregion                             

                              #region PIS
                              if (string.IsNullOrEmpty(PIS) || PIS == "00000000000")
                              {
                                  FuncionarioSemPIS = 1;
                              }
                              #endregion

                              #region DataNascimento
                              if (string.IsNullOrEmpty(Nascimento))
                              {
                                  Nascimento = "01/01/1753";
                              }
                              #endregion


                              if (!Pessoas.Any(a => a.Matricula.Equals(Matricula)))
                              {
                                  Pessoas.Add(new Pessoa
                                  {
                                      Matricula = Matricula,
                                      Nome = Nome,
                                      CodigoPis = PIS,
                                      FlagGerarNumeroPISAutomatico = FuncionarioSemPIS,
                                      Cracha = Cracha,
                                      DataNascimento = Nascimento,
                                      DataAdmissao = Admissao,
                                      Rg = RG,
                                      Cpf = (CPF != "00000000000" && CPF != null) ? Convert.ToUInt64(CPF).ToString(@"000\.000\.000\-00") : null!,
                                      Email = Email,
                                      TelefoneCelular = Celular != "" ? Celular : "",
                                      TipoSalario = TipoDeSalario,
                                      BaseHoras = float.Parse(BaseDeHoras),
                                      ControlaPonto = Convert.ToBoolean(controlaPonto),
                                      Estrutura = DepartamentoList,
                                      //HorarioPessoa = HorarioPessoa,
                                      Horarios = Horario.ToArray(),
                                      RegrasCalculo = RegraDeCaldulo.ToArray(),
                                      Cargo = Cargo.Id == 0 ? null : Cargo,
                                      //EscalaFolga = EscalaDeFOlga,
                                      Sexo = Convert.ToInt32(Sexo),
                                      TipoFuncionario = TipoDeFuncionario,
                                      AmbienteTrabalhoPessoa = AmbienteDeTrabalho.ToArray(),
                                      CpfResponsavel = CPFResponsavel,
                                      CNPJ = CNPJ

                                  });

                              }

                              Linha++;
                          }
                          else
                          {
                              break;
                          }
                      }
                  });
            if (divergencia && !AtualizaPessoa)
            {
                throw new Exception("verifique o arquivo de LOG, existem pessoas com dados inconsistentes !");
            }
            return Pessoas;
        }
        public async Task<List<Pessoa>> ListaPessoasComunica(string CaminhoExcel, string CPFResponsavel, List<Cargo> Cargos, List<Estrutura> Estruturas, List<Horarios> Horarois, bool AtualizaPessoa)
        {
            var excel = new Excel(CaminhoExcel);
            var estruturas = Estruturas;
            var horarios = Horarois;
            var cargos = Cargos;
            var Pessoas = new List<Pessoa>();
            string Planilha = "FUNCIONÁRIOS";
            bool divergencia = false;
            int Linha = 4;
            await Task.Run(() =>
            {
                while (true)
                {

                    string Mat = excel.LeExcel(Planilha, Linha, 1);

                    if (!string.IsNullOrEmpty(Mat))
                    {

                        int Matricula = Convert.ToInt32(Regex.Replace(excel.LeExcel(Planilha, Linha, 1), @"[^\d]", ""));
                        string Nome = FormataTexto.RemoveAcentos(excel.LeExcel(Planilha, Linha, 2));
                        string PIS = FormataTexto.SoNumenros(excel.LeExcel(Planilha, Linha, 3)).PadLeft(11, '0');
                        int FuncionarioSemPIS = 0; // 0 = Tem PIS - 1 = Não tem PIS
                        string Cracha = excel.LeExcel(Planilha, Linha, 4).Trim();
                        string Nascimento = excel.LeExcel(Planilha, Linha, 6).Trim();
                        string Admissao = excel.LeExcel(Planilha, Linha, 5).Trim();
                        // string RG = FormataTexto.SoNumenros(excel.LeExcel(Planilha, Linha, 7));
                        string CPF = FormataTexto.SoNumenros(excel.LeExcel(Planilha, Linha, 7)).PadLeft(11, '0');
                        //string Telefone = FormataTexto.SoNumenros(excel.LeExcel(Planilha, Linha, 9));
                        //string Celular = FormataTexto.SoNumenros(excel.LeExcel(Planilha, Linha, 10));
                        string Email = excel.LeExcel(Planilha, Linha, 8).Trim();
                        var TipoDeSalario = new Tiposalario() { Id = 101 }; // Convert.ToString(PlanilhaFuncionario.Cells[Linha, 12].Value);
                        string BaseDeHoras = "220";
                        string controlaPonto = "false";
                        var DepartamentoList = new Estrutura();
                        string DepartamentoPessoa = excel.LeExcel(Planilha, Linha, 9);
                        // string HorarioPessoa = excel.LeExcel(Planilha, Linha, 16).Trim();
                        var Horario = new List<Horarios>();
                        var RegraDeCaldulo = new List<Regrascalculo>();
                        //string CargoPessoa = FormataTexto.RemoveAcentos(excel.LeExcel(Planilha, Linha, 17));
                        //Cargo? Cargo = new();
                        //string EscalaDeFOlga = excel.LeExcel(Planilha, Linha, 18);
                        var AmbienteDeTrabalho = new List<Ambientetrabalhopessoa>();
                        AmbienteDeTrabalho.Add(new Ambientetrabalhopessoa
                        {
                            Id = 0,
                            Inicio = DateTime.Now.ToString(),
                            Fim = "31/12/9999 23:59:59",
                            TipoAmbienteTrabalho = 6
                        });
                        if (CPF == "00000000000")
                        {
                            CPF = null!;
                        }
                        string Sexo = FormataTexto.SoLetrasENumeros(excel.LeExcel(Planilha, Linha, 10).ToUpper());
                        string CNPJ = excel.LeExcel(Planilha, Linha, 11);
                        var TipoDeFuncionario = new Tipofuncionario() { IdTipoFuncionario = 1 };
                        #region Estrutura
                        if (estruturas.Count > 0)
                        {

                            foreach (var e in estruturas)
                            {

                                if (FormataTexto.RemoveAcentos(e.Descricao.Replace(" ", "")).Equals(FormataTexto.RemoveAcentos(DepartamentoPessoa).Replace(" ", "")))
                                {

                                    DepartamentoList.Id = e.Id;
                                    DepartamentoList.Codigo = 0;
                                    DepartamentoList.Descricao = e.Descricao;


                                    break;
                                }
                            }
                            if (DepartamentoList.Id == 0)
                            {
                                divergencia = true;
                                Log.GravaLog($"Estrutura: {DepartamentoPessoa} não encontrada para o funcionario, Matricula: " +
                                Matricula.ToString());
                            }
                        }

                        #endregion

                        #region Horario
                        if (horarios is not null)
                        {
                            foreach (var H in horarios)
                            {
                                if (H.Descricao == "Horário Padrão")
                                {
                                    Horario.Add(new Horarios()
                                    {
                                        //Codigo = H.Codigo,

                                        Inicio = DateTime.Now.ToString(),
                                        Fim = "31/12/9999 23:59:59",
                                        Horario = new Horario() { Id = H.Id, Descricao = H.Descricao },
                                        Descricao = H.Descricao
                                    });

                                    break;
                                }

                            }
                        }

                        #endregion

                        #region Cracha

                        if (string.IsNullOrEmpty(Cracha))
                        {
                            Cracha = Matricula.ToString();
                        }
                        else if (Cracha.ToUpper() == "CPF" && !string.IsNullOrEmpty(CPF))
                        {
                            Cracha = CPF;
                        }
                        else
                        {
                            Cracha = FormataTexto.SoNumenros(excel.LeExcel(Planilha, Linha, 4));
                        }

                        #endregion

                        #region Sexo

                        if (Sexo == "F" || Sexo == "FEMININO" || Sexo == "FEMENINO" || Sexo == "FEMININA" || Sexo == "FEM")
                        {
                            Sexo = "2";
                        }
                        else
                        {
                            Sexo = "1";
                        }
                        #endregion


                        #region PIS
                        if (string.IsNullOrEmpty(PIS) || PIS == "00000000000")
                        {
                            FuncionarioSemPIS = 1;
                        }
                        #endregion

                        #region DataNascimento
                        if (string.IsNullOrEmpty(Nascimento))
                        {
                            Nascimento = "01/01/1753";
                        }
                        #endregion


                        if (!Pessoas.Any(a => a.Matricula.Equals(Matricula)))
                        {
                            Pessoas.Add(new Pessoa
                            {
                                Matricula = Matricula,
                                Nome = Nome,
                                CodigoPis = PIS,
                                FlagGerarNumeroPISAutomatico = FuncionarioSemPIS,
                                Cracha = Cracha,
                                DataNascimento = Nascimento,
                                DataAdmissao = Admissao,
                                Cpf = (CPF != "00000000000" && CPF != null) ? Convert.ToUInt64(CPF).ToString(@"000\.000\.000\-00") : null!,
                                Email = Email,
                                TipoSalario = TipoDeSalario,
                                BaseHoras = float.Parse(BaseDeHoras),
                                ControlaPonto = Convert.ToBoolean(controlaPonto),
                                Estrutura = DepartamentoList,
                                //HorarioPessoa = HorarioPessoa,
                                Horarios = Horario.ToArray(),
                                RegrasCalculo = RegraDeCaldulo.ToArray(),
                                //EscalaFolga = EscalaDeFOlga,
                                Sexo = Convert.ToInt32(Sexo),
                                TipoFuncionario = TipoDeFuncionario,
                                AmbienteTrabalhoPessoa = AmbienteDeTrabalho.ToArray(),
                                CpfResponsavel = CPFResponsavel,
                                CNPJ = CNPJ

                            });

                        }

                        Linha++;
                    }
                    else
                    {
                        break;
                    }
                }
            });
            if (divergencia && !AtualizaPessoa)
            {
                throw new Exception("verifique o arquivo de LOG, existem pessoas com dados inconsistentes !");
            }
            return Pessoas;
        }


        public async Task SalvaBKPExcel(List<Pessoa> pessoas, string CNPJ, string SalvarEm = "")
        {
            Directory.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + @"\BKP");
            string data = DateTime.Now.ToString("dd-MM-yyyy_HH-mm");
            string diretorio = Convert.ToString(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + @"\BKP");
            if (!string.IsNullOrEmpty(SalvarEm))
            {
                diretorio = SalvarEm;
            }

            if (!File.Exists(diretorio + $"\\Pessoas_BKP_{data}.xlsx"))
            {
                var ExcelHorario = new ExcelPackage(new FileInfo($"{diretorio}\\Pessoas_BKP_{data}.xlsx"));
                var PlanilhaHoario = ExcelHorario.Workbook.Worksheets.Add("FUNCIONÁRIOS");

                PlanilhaHoario.Cells["A1:T1"].Style.Font.Bold = true;
                PlanilhaHoario.Cells[$"A1:T1"].Style.Font.Size = 13;
                PlanilhaHoario.Cells[$"A1:T1"].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                PlanilhaHoario.Cells["A2:T2"].Style.Font.Bold = true;
                PlanilhaHoario.Cells[$"A2:T2"].Style.Font.Size = 13;
                PlanilhaHoario.Cells[$"A2:T2"].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                PlanilhaHoario.Cells["A3:T3"].Style.Font.Bold = true;
                PlanilhaHoario.Cells[$"A3:T3"].Style.Font.Size = 13;
                PlanilhaHoario.Cells[$"A3:T3"].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                pessoas.Sort((a, b) => a.Nome.CompareTo(b.Nome));
                for (int i = 2; i < pessoas.Count + 4; i++)
                {
                    PlanilhaHoario.Cells[$"A{i}:T{i}"].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    PlanilhaHoario.Cells[$"A{i}:T{i}"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    PlanilhaHoario.Cells[$"A{i}:T{i}"].Style.Font.Size = 12;

                }



                PlanilhaHoario.Cells[2, 1].Value = "MATRICULA";
                PlanilhaHoario.Cells[2, 2].Value = "NOME";
                PlanilhaHoario.Cells[2, 3].Value = "PIS";
                PlanilhaHoario.Cells[2, 4].Value = "CRACHA";
                PlanilhaHoario.Cells[2, 5].Value = "DATA DE NASCIMENTO";
                PlanilhaHoario.Cells[2, 6].Value = "DATA DE ADMISSÃO";
                PlanilhaHoario.Cells[2, 7].Value = "RG";
                PlanilhaHoario.Cells[2, 8].Value = "CPF";
                PlanilhaHoario.Cells[2, 9].Value = "TELEFONE";
                PlanilhaHoario.Cells[2, 10].Value = "CELULAR";
                PlanilhaHoario.Cells[2, 11].Value = "E-MAIL";
                PlanilhaHoario.Cells[2, 12].Value = "TIPO DE SALARIO";
                PlanilhaHoario.Cells[2, 13].Value = "BASE DE HORAS";
                PlanilhaHoario.Cells[2, 14].Value = "CONTROLA PONTO";
                PlanilhaHoario.Cells[2, 15].Value = "DEPARTAMENTO";
                PlanilhaHoario.Cells[2, 16].Value = "HORARIO";
                PlanilhaHoario.Cells[2, 17].Value = "CARGO";
                PlanilhaHoario.Cells[2, 18].Value = "ESCALADE FOLGA";
                PlanilhaHoario.Cells[2, 19].Value = "SEXO";
                PlanilhaHoario.Cells[2, 20].Value = "CNPJ";

                PlanilhaHoario.Cells["A1:T1"].Merge = true;
                PlanilhaHoario.Cells["A1:T1"].Value = "Planilha Backup";
                PlanilhaHoario.Cells["A1:T1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                PlanilhaHoario.Cells["A2:T2"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                PlanilhaHoario.Cells["A2:T2"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 165, 80));

                PlanilhaHoario.Cells["A3:T3"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                PlanilhaHoario.Cells["A3:T3"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 165, 80));
                int linha = 4;
                foreach (var item in pessoas)
                {
                    PlanilhaHoario.Cells[linha, 1].Value = item.Matricula.ToString();
                    PlanilhaHoario.Cells[linha, 2].Value = item.Nome;
                    PlanilhaHoario.Cells[linha, 3].Value = item.CodigoPis.ToString();
                    PlanilhaHoario.Cells[linha, 4].Value = item.Cracha;
                    PlanilhaHoario.Cells[linha, 5].Value = item.DataNascimento.ToString();
                    PlanilhaHoario.Cells[linha, 6].Value = item.DataAdmissao.ToString();
                    PlanilhaHoario.Cells[linha, 7].Value = item.Rg.ToString();
                    PlanilhaHoario.Cells[linha, 8].Value = item.Cpf.ToString();
                    PlanilhaHoario.Cells[linha, 9].Value = item.Telefone;
                    PlanilhaHoario.Cells[linha, 10].Value = item.TelefoneCelular;
                    PlanilhaHoario.Cells[linha, 11].Value = item.Email;
                    PlanilhaHoario.Cells[linha, 13].Value = item.BaseHoras;
                    PlanilhaHoario.Cells[linha, 15].Value = item.Estrutura.Descricao;
                    PlanilhaHoario.Cells[linha, 17].Value = item?.Cargo?.Descricao;
                    PlanilhaHoario.Cells[linha, 18].Value = "";// item.escaladefolga.ToString();
                    #region Horario
                    foreach (var Hora in item.Horarios)
                    {
                        if (Convert.ToDateTime(Hora.Fim) == Convert.ToDateTime("31/12/9999 23:59:59"))
                        {
                            PlanilhaHoario.Cells[linha, 16].Value = Hora?.Horario?.Descricao?.ToString();

                        }
                    }
                    #endregion
                    #region Controla Ponto
                    if (item.ControlaPonto)
                    {
                        PlanilhaHoario.Cells[linha, 14].Value = "SIM";
                    }
                    else
                    {
                        PlanilhaHoario.Cells[linha, 14].Value = "NÂO";
                    }
                    #endregion
                    #region Sexo
                    if (item.Sexo == 2)
                    {
                        PlanilhaHoario.Cells[linha, 19].Value = "Feminino";
                    }
                    else
                    {
                        PlanilhaHoario.Cells[linha, 19].Value = "Masculino";
                    }
                    #endregion
                    #region Tipo de Salario
                    if (item.TipoSalario.Id == 101)
                    {
                        PlanilhaHoario.Cells[linha, 12].Value = "MENSALISTA";
                    }


                    #endregion


                    PlanilhaHoario.Cells[linha, 20].Value = CNPJ;

                    linha++;
                }

                PlanilhaHoario.Column(1).AutoFit();
                PlanilhaHoario.Column(2).AutoFit();
                PlanilhaHoario.Column(3).AutoFit();
                PlanilhaHoario.Column(4).AutoFit();
                PlanilhaHoario.Column(5).AutoFit();
                PlanilhaHoario.Column(6).AutoFit();
                PlanilhaHoario.Column(7).AutoFit();
                PlanilhaHoario.Column(8).AutoFit();
                PlanilhaHoario.Column(9).AutoFit();
                PlanilhaHoario.Column(10).AutoFit();
                PlanilhaHoario.Column(11).AutoFit();
                PlanilhaHoario.Column(12).AutoFit();
                PlanilhaHoario.Column(13).AutoFit();
                PlanilhaHoario.Column(14).AutoFit();
                PlanilhaHoario.Column(15).AutoFit();
                PlanilhaHoario.Column(16).AutoFit();
                PlanilhaHoario.Column(17).AutoFit();
                PlanilhaHoario.Column(18).AutoFit();
                PlanilhaHoario.Column(19).AutoFit();
                PlanilhaHoario.Column(20).AutoFit();
                ExcelHorario.Save();
            }
        }
        public async Task SalvaHorarios(string CaminhoExcelLeitura, string SalvarEm, bool comunicacao)
        {
            List<Horarios> HorariosAssociados = await ListaHorariosAssociados(CaminhoExcelLeitura, comunicacao);
            List<Horarios> HorariosNaoAssociados = await ListaHorariosNaoAssociados(CaminhoExcelLeitura, comunicacao);
            await Task.Run(() =>
            {
                string caminho = SalvarEm + "\\HORARIOS.xlsx";

                if (File.Exists(caminho))
                {
                    File.Delete(caminho);
                }
                #region Horarios Associados
                var ExcelHorario = new ExcelPackage(new FileInfo(SalvarEm + "\\HORARIOS.xlsx"));
                var PlanilhaHoario = ExcelHorario.Workbook.Worksheets.Add("HORARIOS ASSOCIADOS");
                PlanilhaHoario.Cells["A1:B1"].Style.Font.Bold = true;
                PlanilhaHoario.Cells[1, 1].Style.Font.Size = 14;
                PlanilhaHoario.Cells[1, 2].Style.Font.Size = 14;
                PlanilhaHoario.Cells[1, 1].Value = "CODIGO";
                PlanilhaHoario.Cells[1, 2].Value = "DESCRICÃO";
                PlanilhaHoario.Cells["A1:B1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                PlanilhaHoario.Cells["A1:B1"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 165, 80));
                int linha = 2;
                foreach (var item in HorariosAssociados)
                {
                    PlanilhaHoario.Cells[linha, 1].Value = item.Codigo.ToString();
                    PlanilhaHoario.Cells[linha, 2].Value = item.Descricao;
                    linha++;
                }
                PlanilhaHoario.Column(1).AutoFit();
                PlanilhaHoario.Column(2).AutoFit();
                #endregion

                #region Horarios não associado
                var PlanilhaHoario1 = ExcelHorario.Workbook.Worksheets.Add("HORARIOS NÃO ASSOCIADOS");
                PlanilhaHoario1.Cells["A1:B1"].Style.Font.Bold = true;
                PlanilhaHoario1.Cells[1, 1].Style.Font.Size = 14;
                PlanilhaHoario1.Cells[1, 2].Style.Font.Size = 14;
                PlanilhaHoario1.Cells[1, 1].Value = "CODIGO";
                PlanilhaHoario1.Cells[1, 2].Value = "DESCRICÃO";
                PlanilhaHoario1.Cells["A1:B1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                PlanilhaHoario1.Cells["A1:B1"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 165, 80));
                int linha1 = 2;

                List<Horarios> horarios = new List<Horarios>();
                int codigo = Convert.ToInt32(HorariosAssociados.Max(x => int.Parse(x.Codigo))) + 1;

                foreach (var item in HorariosNaoAssociados)
                {
                    if (!HorariosAssociados.Exists(x => x.Descricao.SoLetrasENumeros() == item.Descricao.SoLetrasENumeros()))
                    {
                        item.Codigo = codigo.ToString();
                        horarios.Add(item);
                        codigo++;
                    }
                }

                foreach (var item in horarios)
                {
                    PlanilhaHoario1.Cells[linha1, 1].Value = item.Codigo.ToString();
                    PlanilhaHoario1.Cells[linha1, 2].Value = item.Descricao.RemoveAcentos();
                    linha1++;
                }

                PlanilhaHoario1.Column(1).AutoFit();
                PlanilhaHoario1.Column(2).AutoFit();
                #endregion
                ExcelHorario.Save();
            });
        }



    }
}


