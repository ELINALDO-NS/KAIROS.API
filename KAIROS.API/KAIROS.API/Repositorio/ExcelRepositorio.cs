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
            await Task.Run(() =>
            {
                var PlanilhaImplantacao = new ExcelPackage(new FileInfo(caminho));
                ExcelWorksheet PlanilhaCargos = PlanilhaImplantacao.Workbook.Worksheets.First(a => a.Name == "CARGOS");
                ExcelWorksheet PlanilhaFuncionario = PlanilhaImplantacao.Workbook.Worksheets.First(a => a.Name == "FUNCIONÁRIOS");

                int Linha = 4;
                int Codigo = 1;

                while (true)
                {
                    string DescricaoPlCargo = FormataTexto.RemoveAcentos(Convert.ToString(PlanilhaCargos.Cells[Linha, 2].Value)).Replace(" ", "");
                    if (!string.IsNullOrEmpty(DescricaoPlCargo))
                    {
                        if (!cargos.Any(a => a.Descricao.Contains(DescricaoPlCargo)))
                        {
                            cargos.Add(new Cargo
                            {
                                Codigo = Codigo,
                                Descricao = DescricaoPlCargo
                            }); ;
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
                    string DescricaoPlFuncionario = FormataTexto.RemoveAcentos(Convert.ToString(PlanilhaFuncionario.Cells[Linha, 17].Value)).Replace(" ", "");
                    if (!string.IsNullOrEmpty(DescricaoPlFuncionario))
                    {

                        if (!cargos.Any(a => a.Descricao.Contains(DescricaoPlFuncionario)))
                        {
                            cargos.Add(new Cargo
                            {
                                Codigo = Codigo,
                                Descricao = DescricaoPlFuncionario
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
            return cargos.OrderBy(x => x.Descricao).ToList(); ;

        }

        public async Task<List<Estrutura>> ListaEstrutura(string caminho)
        {
            var estrutura = new List<Estrutura>();
            await Task.Run(() =>
            {
                var PlanilhaImplantacao = new ExcelPackage(new FileInfo(caminho));
                ExcelWorksheet PlanilhaDepartamentos = PlanilhaImplantacao.Workbook.Worksheets.First(a => a.Name == "DEPARTAMENTOS");
                ExcelWorksheet PlanilhaFuncionario = PlanilhaImplantacao.Workbook.Worksheets.First(a => a.Name == "FUNCIONÁRIOS");

                int Linha = 4;
                int Codigo = 1;

                while (true)
                {
                    string DescricaoPlDepartamento = FormataTexto.RemoveAcentos(Convert.ToString(PlanilhaDepartamentos.Cells[Linha, 2].Value)).Replace(" ", "");
                    if (!string.IsNullOrEmpty(DescricaoPlDepartamento))
                    {
                        if (!estrutura.Any(a => a.Descricao.Contains(DescricaoPlDepartamento)))
                        {
                            estrutura.Add(new Estrutura
                            {
                                Codigo = Codigo,
                                Descricao = DescricaoPlDepartamento
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
                    string DescricaoPlFuncionario = FormataTexto.RemoveAcentos(Convert.ToString(PlanilhaFuncionario.Cells[Linha, 15].Value)).Replace(" ", "");

                    if (!string.IsNullOrEmpty(DescricaoPlFuncionario))
                    {
                        if (!estrutura.Any(a => a.Descricao.Contains(DescricaoPlFuncionario)))
                        {
                            estrutura.Add(new Estrutura
                            {
                                Codigo = Codigo,
                                Descricao = DescricaoPlFuncionario
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
            return estrutura.OrderBy(x => x.Descricao).ToList();


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
                        if (!horario.Any(a => FormataTexto.FormataHorario(a.Descricao).Contains(FormataTexto.FormataHorario(DescricaoPHorario))))
                        {
                            horario.Add(new Horarios
                            {
                                Codigo = Codigo,
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
                    string DescricaoPHorario = Convert.ToString(PlanilhaFuncionario.Cells[Linha, 16].Value);
                    if (!string.IsNullOrEmpty(DescricaoPHorario))
                    {
                        if (!horario.Any(a => FormataTexto.FormataHorario(a.Descricao).Contains(FormataTexto.FormataHorario(DescricaoPHorario))))
                        {
                            horario.Add(new Horarios
                            {
                                Codigo = Codigo,
                                Descricao = DescricaoPHorario
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
            return horario.OrderBy(x => x.Descricao).ToList();

        }

        public async Task<List<Pessoa>> ListaPessoas(string caminho)
        {
            var Pessoas = new List<Pessoa>();
            var PlanilhaImplantacao = new ExcelPackage(new FileInfo(caminho));
            ExcelWorksheet PlanilhaFuncionario = PlanilhaImplantacao.Workbook.Worksheets.First(a => a.Name == "FUNCIONÁRIOS");

            int Linha = 4;

            while (true)
            {

                string MAtricula = Convert.ToString(PlanilhaFuncionario.Cells[Linha, 1].Value);
                if (!string.IsNullOrEmpty(MAtricula))
                {
                    int Matricula = Convert.ToInt32(Regex.Replace(Convert.ToString(PlanilhaFuncionario.Cells[Linha, 1].Value), @"[^\d]", ""));
                    string Nome = FormataTexto.RemoveAcentos(Convert.ToString(PlanilhaFuncionario.Cells[Linha, 2].Value));
                    string PIS = FormataTexto.SoNumenros(Convert.ToString(PlanilhaFuncionario.Cells[Linha, 3].Value));
                    int Cracha = Convert.ToInt32(FormataTexto.SoNumenros(Convert.ToString(PlanilhaFuncionario.Cells[Linha, 4].Value)));
                    string Nascimento = Convert.ToString(PlanilhaFuncionario.Cells[Linha, 5].Value);
                    string Admissao = Convert.ToString(PlanilhaFuncionario.Cells[Linha, 6].Value);
                    string RG = FormataTexto.SoNumenros(Convert.ToString(PlanilhaFuncionario.Cells[Linha, 7].Value));
                    string CPF = FormataTexto.SoNumenros(Convert.ToString(PlanilhaFuncionario.Cells[Linha, 8].Value));
                    string Telefone = FormataTexto.SoNumenros(Convert.ToString(PlanilhaFuncionario.Cells[Linha, 9].Value));
                    string Celular = FormataTexto.SoNumenros(Convert.ToString(PlanilhaFuncionario.Cells[Linha, 10].Value));
                    string Email = Convert.ToString(PlanilhaFuncionario.Cells[Linha, 11].Value);
                    var TipoDeSalario = new Tiposalario() { Id = 101 }; // Convert.ToString(PlanilhaFuncionario.Cells[Linha, 12].Value);
                    float BaseDeHoras = float.Parse(Convert.ToString(PlanilhaFuncionario.Cells[Linha, 13].Value));
                    bool controlaPonto = true; // Convert.ToString(PlanilhaFuncionario.Cells[Linha, 14].Value);
                    var Departamento = new Estrutura(); // Convert.ToString(PlanilhaFuncionario.Cells[Linha, 15].Value);
                    string HorarioPessoa = Convert.ToString(PlanilhaFuncionario.Cells[Linha, 16].Value);
                    var Horario = new List<Horarios>().ToArray();
                    string CargoPessoa = Convert.ToString(PlanilhaFuncionario.Cells[Linha, 17].Value);
                    var Cargo = new Cargo();
                    string EscalaDeFOlga = Convert.ToString(PlanilhaFuncionario.Cells[Linha, 18].Value);
                    int Sexo = 1; // Convert.ToInt32(PlanilhaFuncionario.Cells[Linha, 19].Value);
                    string CNPJ = Convert.ToString(PlanilhaFuncionario.Cells[Linha, 20].Value);

                    if (!Pessoas.Any(a => a.Matricula.Equals(Matricula)))
                    {
                        Pessoas.Add(new Pessoa
                        {
                            Matricula = Matricula,
                            Nome = Nome,
                            CodigoPis = PIS,
                            Cracha = Cracha,
                            DataNascimento = Nascimento,
                            DataAdmissao = Admissao,
                            Rg = RG,
                            Cpf = CPF,
                            TipoSalario = TipoDeSalario,
                            BaseHoras = BaseDeHoras,
                            ControlaPonto = controlaPonto,
                            Estrutura = Departamento,
                            HorarioPessoa = HorarioPessoa,
                            Horarios = Horario,
                            Cargo = Cargo,
                            //EscalaFolga = EscalaDeFOlga,
                            Sexo = Sexo,
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

            return Pessoas;
        }

        public async Task SalvaHorarios(string caminhoLeitura, string SalvarEm)
        {
            var horarios = await ListaHorarios(caminhoLeitura);
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

