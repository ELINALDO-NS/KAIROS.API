using KAIROS.API.Model;
using KAIROS.API.Repositorio.Interface;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Windows.Forms.LinkLabel;

namespace KAIROS.API.Repositorio
{
    public class ExcelRepositorio : IExcelRepositorio
    {

        public ExcelRepositorio()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }
        public async Task<List<Cargo>> ListaCargos(string caminho)
        {
            var cargos = new List<Cargo>();
            var cargosOrdenados = new List<Cargo>();
            await Task.Run(() =>
            {
                var PlanilhaImplantacao = new ExcelPackage(new FileInfo(caminho));
                ExcelWorksheet PlanilhaCargos = PlanilhaImplantacao.Workbook.Worksheets.First(a => a.Name == "CARGOS");
                ExcelWorksheet PlanilhaFuncionario = PlanilhaImplantacao.Workbook.Worksheets.First(a => a.Name == "FUNCIONÁRIOS");


                int Linha = 4;

                while (true)
                {
                    string DescricaoPlCargo = FormataTexto.RemoveAcentos(Convert.ToString(PlanilhaCargos.Cells[Linha, 2].Value));
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
                    string DescricaoPlFuncionario = FormataTexto.RemoveAcentos(Convert.ToString(PlanilhaFuncionario.Cells[Linha, 17].Value));
                    if (!string.IsNullOrEmpty(DescricaoPlFuncionario))
                    {

                        if (!cargos.Any(a => a.Descricao.Replace(" ", "").Equals(DescricaoPlFuncionario.Replace(" ", ""))))
                        {
                            cargos.Add(new Cargo
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
            cargosOrdenados = cargos.OrderBy(c => c.Descricao).ToList();
            cargosOrdenados.ForEach(c => { c.Codigo = codigo; codigo++; });
            return cargosOrdenados;

        }
        public async Task<List<Cargo>> ListaCargosNovo(string caminho)
        {
            var cargos = new List<Cargo>();
            var cargosOrdenados = new List<Cargo>();
            var excel = new Excel(caminho);
            await Task.Run(() =>
            {

                int Linha = 4;
                while (true)
                {
                    string DescricaoPlCargo = excel.LeExcel( "CARGOS", Linha, 2);
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
                    string DescricaoPlCargo = excel.LeExcel("FUNCIONÁRIOS", Linha, 17);
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
        public async Task<List<Estrutura>> ListaEstruturas(string caminho)
        {
            var estrutura = new List<Estrutura>();
            var estruturaOrdenada = new List<Estrutura>();
            await Task.Run(() =>
            {
                var PlanilhaImplantacao = new ExcelPackage(new FileInfo(caminho));
                ExcelWorksheet PlanilhaDepartamentos = PlanilhaImplantacao.Workbook.Worksheets.First(a => a.Name == "DEPARTAMENTOS");
                ExcelWorksheet PlanilhaFuncionario = PlanilhaImplantacao.Workbook.Worksheets.First(a => a.Name == "FUNCIONÁRIOS");

                int Linha = 4;

                while (true)
                {
                    string DescricaoPlDepartamento = FormataTexto.RemoveAcentos(Convert.ToString(PlanilhaDepartamentos.Cells[Linha, 2].Value));
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
                    string DescricaoPlFuncionario = FormataTexto.RemoveAcentos(Convert.ToString(PlanilhaFuncionario.Cells[Linha, 15].Value));

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
        public async Task<List<Estrutura>> ListaEstruturasNovo(string caminho)
        {
            var estrutura = new List<Estrutura>();
            var estruturaOrdenada = new List<Estrutura>();
            var excel = new Excel(caminho);
            await Task.Run(() =>
            {
                int Linha = 4;

                while (true)
                {
                    string DescricaoPlDepartamento = excel.LeExcel( "DEPARTAMENTOS", Linha, 2);
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
                    string DescricaoPlFuncionario = excel.LeExcel("FUNCIONÁRIOS", Linha, 15);

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
        public async Task<List<Horarios>> ListaHorarios(string caminho)
        {
            var horario = new List<Horarios>();
            await Task.Run(() =>
            {
                var PlanilhaImplantacao = new ExcelPackage(new FileInfo(caminho));

                ExcelWorksheet PlanilhaHorario = PlanilhaImplantacao.Workbook.Worksheets.First(a => a.Name == "HORÁRIOS");
                ExcelWorksheet PlanilhaFuncionario = PlanilhaImplantacao.Workbook.Worksheets.First(a => a.Name == "FUNCIONÁRIOS");

                int Linha = 5;
                int Codigo = 1;

                while (true)
                {

                    string DescricaoPHorario = Convert.ToString(PlanilhaHorario.Cells[Linha, 2].Value);
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
                Linha = 4;
                while (true)
                {
                    string DescricaoPFuncionario = Convert.ToString(PlanilhaFuncionario.Cells[Linha, 16].Value);
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
        public async Task<List<Horarios>> ListaHorariosNovo(string caminho)
        {
            var horario = new List<Horarios>();
            var excel = new Excel(caminho);
            await Task.Run(() =>
            {

                int Linha = 5;
                int Codigo = 2;


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
                Linha = 4;
                while (true)
                {

                    string DescricaoPFuncionario = excel.LeExcel( "FUNCIONÁRIOS", Linha, 16);
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
        public async Task<List<Pessoa>> ListaPessoas(string caminho, string CPFResponsavel, List<Cargo> Cargos , List<Estrutura> Estruturas, List<Horarios> Horarois,bool AltPessoa)
        {
            var estruturas = Estruturas;
            var horarios = Horarois;
            var cargos = Cargos;
            var Pessoas = new List<Pessoa>();
            bool divergencia = false;
            var PlanilhaImplantacao = new ExcelPackage(new FileInfo(caminho));
            ExcelWorksheet PlanilhaFuncionario = PlanilhaImplantacao.Workbook.Worksheets.First(a => a.Name == "FUNCIONÁRIOS");
            int Linha = 4;
            await Task.Run(() =>
                  {
                      while (true)
                      {

                          string MAtricula = Convert.ToString(PlanilhaFuncionario.Cells[Linha, 1].Value);
                          if (!string.IsNullOrEmpty(MAtricula))
                          {
                              int Matricula = Convert.ToInt32(Regex.Replace(Convert.ToString(PlanilhaFuncionario.Cells[Linha, 1].Value), @"[^\d]", ""));
                              string Nome = FormataTexto.RemoveAcentos(Convert.ToString(PlanilhaFuncionario.Cells[Linha, 2].Value));
                              string PIS = FormataTexto.SoNumenros(Convert.ToString(PlanilhaFuncionario.Cells[Linha, 3].Value)).PadLeft(11, '0');
                              int FuncionarioSemPIS = 0; // 0 = Tem PIS - 1 = Não tem PIS
                              string Cracha =  Convert.ToString(PlanilhaFuncionario.Cells[Linha, 4].Value);
                              string Nascimento = Convert.ToString(PlanilhaFuncionario.Cells[Linha, 5].Value);
                              string Admissao = Convert.ToString(PlanilhaFuncionario.Cells[Linha, 6].Value);
                              string RG = FormataTexto.SoNumenros(Convert.ToString(PlanilhaFuncionario.Cells[Linha, 7].Value));
                              string CPF = FormataTexto.SoNumenros(Convert.ToString(PlanilhaFuncionario.Cells[Linha, 8].Value)).PadLeft(11, '0');
                              string Telefone = FormataTexto.SoNumenros(Convert.ToString(PlanilhaFuncionario.Cells[Linha, 9].Value));
                              string Celular = FormataTexto.SoNumenros(Convert.ToString(PlanilhaFuncionario.Cells[Linha, 10].Value));
                              string Email = Convert.ToString(PlanilhaFuncionario.Cells[Linha, 11].Value);
                              var TipoDeSalario = new Tiposalario() { Id = 101 }; // Convert.ToString(PlanilhaFuncionario.Cells[Linha, 12].Value);
                              string BaseDeHoras = Convert.ToString(PlanilhaFuncionario.Cells[Linha, 13].Value);
                              string controlaPonto = Convert.ToString(PlanilhaFuncionario.Cells[Linha, 14].Value).ToUpper();
                              var DepartamentoList = new Estrutura();
                              string DepartamentoPessoa = Convert.ToString(PlanilhaFuncionario.Cells[Linha, 15].Value);
                              string HorarioPessoa = Convert.ToString(PlanilhaFuncionario.Cells[Linha, 16].Value);
                              var Horario = new List<Horarios>();
                              var RegraDeCaldulo = new List<Regrascalculo>();
                              string CargoPessoa = FormataTexto.RemoveAcentos(Convert.ToString(PlanilhaFuncionario.Cells[Linha, 17].Value));
                              var Cargo = new Cargo();
                              string EscalaDeFOlga = Convert.ToString(PlanilhaFuncionario.Cells[Linha, 18].Value);
                              var AmbienteDeTrabalho = new List<Ambientetrabalhopessoa>();
                              AmbienteDeTrabalho.Add(new Ambientetrabalhopessoa
                              {
                                  Id = 0,
                                  Inicio = DateTime.Now.ToString(),
                                  Fim = "31/12/9999 23:59:59",
                                  TipoAmbienteTrabalho = 6
                              });

                              string Sexo = Convert.ToString(PlanilhaFuncionario.Cells[Linha, 19].Value).ToUpper();
                              string CNPJ = Convert.ToString(PlanilhaFuncionario.Cells[Linha, 20].Value);
                              var TipoDeFuncionario = new Tipofuncionario() { IdTipoFuncionario = 1 };

                              if (!AltPessoa)
                              {
                                  #region Estrutura
                                  foreach (var e in estruturas)
                                  {

                                      if (FormataTexto.RemoveAcentos(e.Descricao.Replace(" ", "")).Equals(FormataTexto.RemoveAcentos(DepartamentoPessoa).Replace(" ", "")))
                                      {


                                          DepartamentoList.Codigo = 0;
                                          DepartamentoList.Id = e.Id;

                                          break;
                                      }
                                  }
                                  if (DepartamentoList.Id == 0)
                                  {
                                      divergencia = true;
                                      Log.GravaLog($"Estrutura: {DepartamentoPessoa} não encontrada para o funcionario, Matricula: " +
                                      MAtricula.ToString());
                                  }


                                  #endregion
                                  #region Cargo

                                  foreach (var C in cargos)
                                  {

                                      if (FormataTexto.RemoveAcentos(C.Descricao.Replace(" ", "")).Equals(CargoPessoa.Replace(" ", "")))
                                      {

                                          Cargo.Codigo = 0;
                                          Cargo.Id = C.Id;

                                          break;
                                      }


                                  }
                                  if (Cargo.Id == 0)
                                  {
                                      divergencia = true;
                                      Log.GravaLog($"Cargo: {CargoPessoa} não encontrada para o funcionario, Matricula: " + Matricula);
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
                                              Horario = new Horario() { Id = H.Id }
                                          });

                                          break;
                                      }


                                  }
                                  if (Horario.Count <= 0)
                                  {
                                      divergencia = true;
                                      Log.GravaLog($"({HorarioPessoa}) Horario não encontrado para o funcionario, Matricula: " + MAtricula);

                                  }


                                  #endregion
                              }

                              #region Base de Horas
                              if (!string.IsNullOrEmpty(BaseDeHoras))
                              {
                                  BaseDeHoras = Convert.ToString(PlanilhaFuncionario.Cells[Linha, 13].Value);
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
                                  Cracha = FormataTexto.SoNumenros(Convert.ToString(PlanilhaFuncionario.Cells[Linha, 4].Value));
                              }

                              #endregion
                              #region Sexo

                              if (Sexo == "F" || Sexo == "FEMININO" || Sexo == "FEMENINO" || Sexo == "FEMININA")
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
                              if (string.IsNullOrEmpty( Nascimento))
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
                                      Cpf = CPF,
                                      Email = Email,
                                      TelefoneCelular = Celular,
                                      TipoSalario = TipoDeSalario,
                                      BaseHoras = float.Parse(BaseDeHoras),
                                      ControlaPonto = Convert.ToBoolean(controlaPonto),
                                      Estrutura = DepartamentoList,
                                      //HorarioPessoa = HorarioPessoa,
                                      Horarios = Horario.ToArray(),
                                      RegrasCalculo = RegraDeCaldulo.ToArray(),
                                      Cargo = Cargo,
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
            if (divergencia)
            {
                throw new Exception("verifique o arquivo de LOG, existem pessoas com dados inconsistentes !");
            }
            return Pessoas;
        }
        public async Task SalvaHorarios(string caminhoLeitura, string SalvarEm)
        {

            var horarios = await ListaHorariosNovo(caminhoLeitura);
            await Task.Run(() =>
            {

                if (!File.Exists(SalvarEm + "\\HORARIOS.xlsx"))
                {
                    var ExcelHorario = new ExcelPackage(new FileInfo(SalvarEm + "\\HORARIOS.xlsx"));
                    var PlanilhaHoario = ExcelHorario.Workbook.Worksheets.Add("HORARIOS");
                    PlanilhaHoario.Cells["A1:B1"].Style.Font.Bold = true;
                    PlanilhaHoario.Cells[1, 1].Style.Font.Size = 14;
                    PlanilhaHoario.Cells[1, 2].Style.Font.Size = 14;
                    PlanilhaHoario.Cells[1, 1].Value = "CODIGO";
                    PlanilhaHoario.Cells[1, 2].Value = "DESCRICÃO";
                    PlanilhaHoario.Cells["A1:B1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    PlanilhaHoario.Cells["A1:B1"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 165, 80));
                    int linha = 2;
                    foreach (var item in horarios)
                    {
                        PlanilhaHoario.Cells[linha, 1].Value = item.Codigo.ToString();
                        PlanilhaHoario.Cells[linha, 2].Value = item.Descricao;
                        linha++;

                    }
                    PlanilhaHoario.Column(1).AutoFit();
                    PlanilhaHoario.Column(2).AutoFit();
                    ExcelHorario.Save();
                }
                else
                {
                    var ExcelHorario = new ExcelPackage(new FileInfo(SalvarEm + "\\HORARIOS.xlsx"));
                    var PlanilhaHoario = ExcelHorario.Workbook.Worksheets.First(x => x.Name == "HORARIOS");
                    PlanilhaHoario.Cells["A1:B1"].Style.Font.Bold = true;
                    PlanilhaHoario.Cells[1, 1].Style.Font.Size = 14;
                    PlanilhaHoario.Cells[1, 2].Style.Font.Size = 14;
                    PlanilhaHoario.Cells[1, 1].Value = "CODIGO";
                    PlanilhaHoario.Cells[1, 2].Value = "DESCRICÃO";
                    PlanilhaHoario.Cells["A1:B1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    PlanilhaHoario.Cells["A1:B1"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 165, 80));
                    int linha = 2;
                    foreach (var item in horarios)
                    {
                        PlanilhaHoario.Cells[linha, 1].Value = item.Codigo.ToString();
                        PlanilhaHoario.Cells[linha, 2].Value = item.Descricao;
                        linha++;

                    }
                    PlanilhaHoario.Column(1).AutoFit();
                    PlanilhaHoario.Column(2).AutoFit();
                    ExcelHorario.Save();
                }

            });
        }

    }
}


