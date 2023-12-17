using KAIROS.API.Model;
using KAIROS.API.Repositorio.Interface;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace KAIROS.API.Repositorio
{
    public class ExcelRepositorio : IExcelRepositorio
    {

        public ExcelRepositorio()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        }

        public async Task<List<Cargo>> LerCargos(string caminho)
        {
            var PlanilhaImplantacao = new ExcelPackage(new FileInfo(caminho));

            ExcelWorksheet PlanilhaCargos = PlanilhaImplantacao.Workbook.Worksheets.First(a => a.Name == "CARGOS");
            ExcelWorksheet PlanilhaFuncionario = PlanilhaImplantacao.Workbook.Worksheets.First(a => a.Name == "FUNCIONÁRIOS");
            var cargos = new List<Cargo>();
            int Linha = 4;
            int Codigo = 1;
            while (true)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(PlanilhaCargos.Cells[Linha, 2].Value)))
                {
                    if (!cargos.Any(a => RemoveAcentos.Remove(a.Descricao.Replace(" ", "")) == RemoveAcentos.Remove(PlanilhaCargos.Cells[Linha, 2].Value.ToString().Replace(" ", ""))))
                    {
                        cargos.Add(new Cargo
                        {
                            Codigo = Codigo,
                            Descricao = RemoveAcentos.Remove(PlanilhaCargos.Cells[Linha, 2].Value.ToString())


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
                if (!string.IsNullOrEmpty(Convert.ToString(PlanilhaFuncionario.Cells[Linha, 2].Value)))
                {
                    
                    if (!cargos.Any(a => RemoveAcentos.Remove(a.Descricao.Replace(" ", "")) == RemoveAcentos.Remove(PlanilhaFuncionario.Cells[Linha, 17].Value.ToString().Replace(" ", ""))))
                    {
                        cargos.Add(new Cargo
                        {
                            Codigo = Codigo,
                            Descricao = RemoveAcentos.Remove(PlanilhaFuncionario.Cells[Linha, 17].Value.ToString())


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

            return cargos;

        }

        public async Task LerEstrutura(string caminho)
        {

            var PlanilhaImplantacao = new ExcelPackage(new FileInfo(caminho));

            ExcelWorksheet PlanilhaDepartamentos = PlanilhaImplantacao.Workbook.Worksheets.First(a => a.Name == "DEPARTAMENTOS");
            ExcelWorksheet PlanilhaFuncionario = PlanilhaImplantacao.Workbook.Worksheets.First(a => a.Name == "FUNCIONÁRIOS");
            var estrutura = new List<Estrutura>();
            int Linha = 4;
            int Codigo = 1;

            while (true)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(PlanilhaDepartamentos.Cells[Linha, 2].Value)))
                {
                    if (!estrutura.Any(a => RemoveAcentos.Remove(a.Descricao.Replace(" ", "")) == RemoveAcentos.Remove(PlanilhaDepartamentos.Cells[Linha, 2].Value.ToString().Replace(" ", ""))))
                    {
                        estrutura.Add(new Estrutura
                        {
                            Codigo = Codigo,
                            Descricao = RemoveAcentos.Remove(PlanilhaDepartamentos.Cells[Linha, 2].Value.ToString())


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
                if (!string.IsNullOrEmpty(Convert.ToString(PlanilhaFuncionario.Cells[Linha, 2].Value)))
                {
                    if (!estrutura.Any(a => RemoveAcentos.Remove(a.Descricao.Replace(" ", "")) == RemoveAcentos.Remove(PlanilhaFuncionario.Cells[Linha, 15].Value.ToString().Replace(" ", ""))))
                    {
                        estrutura.Add(new Estrutura
                        {
                            Codigo = Codigo,
                            Descricao = RemoveAcentos.Remove(PlanilhaFuncionario.Cells[Linha, 15].Value.ToString())


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




        }

        public Task LerHoarios(string Caminho)
        {
            throw new NotImplementedException();
        }

        public Task LerPessoas(string Caminho)
        {
            throw new NotImplementedException();
        }

        public async Task ListaHorarios(string caminho)
        {





        }
    }
}
